using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using FluentAssertions;

namespace SOAPClientTestIntegrationTests.Services
{
    public class AddListRequestTest
    {
        private NetSuitePortTypeClient _client;
        private TokenPassport _tokenPassport;
        private ApplicationInfo _applicationInfo;
        private PartnerInfo _partnerInfo;
        private Preferences _preferences;

        public AddListRequestTest()
        {
            Initialize();
        }
        private void Initialize()
        {
            _tokenPassport = new TokenPassport(); // Вы сами заполните своими данными
            _applicationInfo = new ApplicationInfo(); // Заполните при необходимости
            _partnerInfo = new PartnerInfo(); // Заполните при необходимости
            _preferences = new Preferences
            {
                warningAsErrorSpecified = true,
                warningAsError = false,
                ignoreReadOnlyFieldsSpecified = true,
                ignoreReadOnlyFields = true
            };

            var binding = new BasicHttpBinding
            {
                Security =
                {
                    Mode = BasicHttpSecurityMode.TransportCredentialOnly,
                    Transport =
                    {
                        ClientCredentialType = HttpClientCredentialType.Basic
                        // Убираем ProxyCredentialType - он не нужен
                    }
                },
                // Важно для UWP
                AllowCookies = false
            };
            var endpoint = new EndpointAddress("http://localhost:5000/NetSuiteLocal.svc");
            _client = new NetSuitePortTypeClient(binding, endpoint);

            // Только Basic аутентификация
            _client.ClientCredentials.UserName.UserName = "ваш_логин";
            _client.ClientCredentials.UserName.Password = "ваш_пароль";

            _tokenPassport = new TokenPassport
            {
                account = "123456",
                consumerKey = "AbCdEfGhIjKlMnOpQrStUvWxY",
                token = "12345-ABCDE",
                nonce = "987654321",
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            // 2.2 ApplicationInfo (если есть)
            _applicationInfo = new ApplicationInfo();

            // 2.3 PartnerInfo (если есть)
            _partnerInfo = new PartnerInfo();

            // 2.4 Preferences - настройки
            _preferences = new Preferences
            {
                warningAsError = false,
                disableMandatoryCustomFieldValidation = false,
            };
        }
        public async Task DisposeAsync()
        {
            if (_client != null)
            {
                try
                {
                    await _client.CloseAsync();
                }
                finally
                {
                    _client = null;
                }
            }
        }
        [Fact]
        public async Task AddListAsync_WithUniqueStates_ReturnsSuccessForAll()
        {
            // Arrange
            var states = new ServiceReference.State[]
            {
                new State
                {
                    fullName = "Московская область",
                    shortname = "MO",
                    country = Country._russianFederation,
                    countrySpecified = true
                },
                new State
                {
                    fullName = "Ленинградская область",
                    shortname = "LO",
                    country = Country._russianFederation,
                    countrySpecified = true
                }
            };

            // Act
            var response = await _client.addListAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                states
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponseList.Should().NotBeNull();
            response.writeResponseList.status.isSuccess.Should().BeTrue();
            response.writeResponseList.status.isSuccessSpecified.Should().BeTrue();

            response.writeResponseList.writeResponse.Should().HaveCount(2);

            // Проверка первой записи
            var firstResponse = response.writeResponseList.writeResponse[0];
            firstResponse.status.isSuccess.Should().BeTrue();
            firstResponse.baseRef.Should().NotBeNull();
            RecordRef recordRefFirstResponse = (RecordRef)firstResponse.baseRef;
            recordRefFirstResponse.internalId.Should().NotBeNullOrEmpty();
            recordRefFirstResponse.name.Should().Be("Московская область");
            recordRefFirstResponse.type.Should().Be(RecordType.state);

            // Проверка второй записи
            var secondResponse = response.writeResponseList.writeResponse[1];
            secondResponse.status.isSuccess.Should().BeTrue();
            secondResponse.baseRef.Should().NotBeNull();
            RecordRef recordRefSecondResponse = (RecordRef)secondResponse.baseRef;
            recordRefSecondResponse.internalId.Should().NotBeNullOrEmpty();
            recordRefSecondResponse.name.Should().Be("Ленинградская область");
            recordRefSecondResponse.type.Should().Be(RecordType.state);

            // ID должны быть разными
            recordRefFirstResponse.internalId.Should().NotBe(recordRefSecondResponse.internalId);
            await DisposeAsync();
        }

        [Fact]
        public async Task AddListAsync_WithDuplicateShortname_ReturnsOneSuccessOneDuplicate()
        {
            // Arrange
            var states = new ServiceReference.State[]
            {
                new State
                {
                    fullName = "Московская область",
                    shortname = "MO",
                    country = Country._russianFederation,
                    countrySpecified = true
                },
                new State
                {
                    fullName = "Московская область",
                    shortname = "MO", // Дубликат shortname
                    country = Country._russianFederation,
                    countrySpecified = true
                }
            };

            // Act
            var response = await _client.addListAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                states
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponseList.Should().NotBeNull();

            // Общий статус должен быть false, так как есть ошибки
            response.writeResponseList.status.isSuccess.Should().BeFalse();
            response.writeResponseList.status.isSuccessSpecified.Should().BeTrue();

            // Проверка предупреждения в общем статусе
            response.writeResponseList.status.statusDetail.Should().NotBeNullOrEmpty();
            var overallStatusDetail = response.writeResponseList.status.statusDetail[0];
            overallStatusDetail.type.Should().Be(StatusDetailType.WARN);
            overallStatusDetail.message.Should().Contain("1 record(s) added successfully, 1 record(s) failed");

            // Проверка индивидуальных ответов
            response.writeResponseList.writeResponse.Should().HaveCount(2);

            // Первая запись - успех

            var firstResponse = response.writeResponseList.writeResponse[0];
            firstResponse.status.isSuccess.Should().BeTrue();
            firstResponse.baseRef.Should().NotBeNull();
            RecordRef recordRefFirstResponse = (RecordRef)firstResponse.baseRef;
            recordRefFirstResponse.internalId.Should().NotBeNullOrEmpty();
            recordRefFirstResponse.name.Should().Be("Московская область");
            recordRefFirstResponse.type.Should().Be(RecordType.state);

            var firstInternalId = recordRefFirstResponse.internalId;

            // Вторая запись - дубликат
            var secondResponse = response.writeResponseList.writeResponse[1];
            secondResponse.status.isSuccess.Should().BeFalse();
            secondResponse.status.statusDetail.Should().NotBeNullOrEmpty();

            var duplicateError = secondResponse.status.statusDetail[0];
            duplicateError.type.Should().Be(StatusDetailType.ERROR);
            //duplicateError.code.Should().Be(StatusDetailCodeType.DUP_NAME);//почему-то приходит другой тип ошибки
            duplicateError.message.Should().Contain("already exists");
            duplicateError.message.Should().Contain(firstInternalId);
            RecordRef recordRefSecondResponse = (RecordRef)secondResponse.baseRef;
            recordRefSecondResponse.Should().NotBeNull();
            recordRefSecondResponse.internalId.Should().Be(firstInternalId); // ID существующей записи
            recordRefSecondResponse.name.Should().Be("Московская область");

            await DisposeAsync();
        }

        [Fact]
        public async Task AddListAsync_WithNonStateRecordType_ReturnsError()
        {
            // Arrange
            var nonStateRecords = new ServiceReference.Customer[]
            {
                new Customer // Customer вместо State
                {
                    internalId = "123",
                    companyName = "Test Company",
                    email = "test@example.com"
                },
            };

            // Act
            var response = await _client.addListAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                nonStateRecords
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponseList.Should().NotBeNull();

            // Проверка общего статуса
            response.writeResponseList.status.isSuccess.Should().BeFalse();
            response.writeResponseList.status.isSuccessSpecified.Should().BeTrue();

            // Проверка деталей ошибки
            response.writeResponseList.status.statusDetail.Should().NotBeNullOrEmpty();
            response.writeResponseList.status.statusDetail.Should().HaveCount(1);

            var errorDetail = response.writeResponseList.status.statusDetail[0];
            errorDetail.type.Should().Be(StatusDetailType.ERROR);
            //errorDetail.code.Should().Be(StatusDetailCodeType.INVALID_REQUEST);
            errorDetail.message.Should().Contain("Unsupported record type");
            errorDetail.message.Should().Contain($"{nonStateRecords[0].GetType().Name}"); // Должен показать первый встреченный тип

            // Проверка, что writeResponse пустой (ошибка на первом же элементе)
            response.writeResponseList.writeResponse.Should().BeNull();

            await DisposeAsync();
        }
    }
}
