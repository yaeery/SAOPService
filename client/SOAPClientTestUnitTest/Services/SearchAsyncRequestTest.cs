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
    public class SearchAsyncRequestTest
    {
        private NetSuitePortTypeClient _client;
        private TokenPassport _tokenPassport;
        private ApplicationInfo _applicationInfo;
        private PartnerInfo _partnerInfo;
        private SearchPreferences _searchPreferences;

        public SearchAsyncRequestTest()
        {
            Initialize();
        }
        private void Initialize()
        {
            _tokenPassport = new TokenPassport(); // Вы сами заполните своими данными
            _applicationInfo = new ApplicationInfo(); // Заполните при необходимости
            _partnerInfo = new PartnerInfo(); // Заполните при необходимости
            _searchPreferences = new SearchPreferences
            {
                bodyFieldsOnly = false,
                returnSearchColumns = true,
                pageSize = 50,
                pageSizeSpecified = true
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
            _searchPreferences = new SearchPreferences
            {
                bodyFieldsOnly = false,
                returnSearchColumns = true,
                pageSize = 50,
                pageSizeSpecified = true
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
        public async Task SearchAsync_WithCustomerSearch_ReturnsMatchingCustomers()
        {
            // Arrange
            var searchRecord = new CustomerSearchBasic
            {
                companyName = new SearchStringField
                {
                    @operator = SearchStringFieldOperator.contains,
                    searchValue = "Ромашка"
                }
            };

            // Act
            var response = await _client.searchAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _searchPreferences,
                searchRecord
            );

            // Assert
            response.Should().NotBeNull();
            response.searchResult.Should().NotBeNull();
            response.searchResult.status.isSuccess.Should().BeTrue();
            response.searchResult.status.isSuccessSpecified.Should().BeTrue();

            response.searchResult.totalRecords.Should().BeGreaterThan(0);
            response.searchResult.totalRecordsSpecified.Should().BeTrue();
            response.searchResult.pageSize.Should().Be(50);
            response.searchResult.pageSizeSpecified.Should().BeTrue();
            response.searchResult.pageIndex.Should().Be(0);
            response.searchResult.pageIndexSpecified.Should().BeTrue();
            response.searchResult.totalPages.Should().BeGreaterThan(0);
            response.searchResult.totalPagesSpecified.Should().BeTrue();

            response.searchResult.recordList.Should().NotBeNullOrEmpty();

            var customers = response.searchResult.recordList.Cast<Customer>().ToList();
            customers.Should().AllSatisfy(c =>
            {
                // Основные поля
                c.internalId.Should().NotBeNullOrEmpty();
                c.entityId.Should().NotBeNullOrEmpty();
                c.companyName.Should().Be("ООО Ромашка");

                // Дополнительные поля
                c.email.Should().NotBeNullOrEmpty();
                c.phone.Should().NotBeNullOrEmpty();

                // Тип клиента
                c.isPersonSpecified.Should().BeTrue();

                    c.internalId.Should().Be("1001");
                    c.entityId.Should().Be("CUST-001");
                    c.email.Should().Be("info@romashka.ru");
                    c.phone.Should().Be("+7 (495) 111-22-33");
            });
        }

        [Fact]
        public async Task SearchAsync_WithStateSearch_ReturnsMatchingStates()
        {
            // Arrange
            var searchRecord = new CustomRecordSearchBasic
            {
                name = new SearchStringField
                {
                    @operator = SearchStringFieldOperator.contains,
                    searchValue = "Московская"
                }
            };

            // Act
            var response = await _client.searchAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _searchPreferences,
                searchRecord
            );

            // Assert
            response.Should().NotBeNull();
            response.searchResult.Should().NotBeNull();
            response.searchResult.status.isSuccess.Should().BeTrue();
            response.searchResult.status.isSuccessSpecified.Should().BeTrue();

            response.searchResult.totalRecords.Should().Be(1);
            response.searchResult.totalRecordsSpecified.Should().BeTrue();
            response.searchResult.pageSize.Should().Be(50);
            response.searchResult.pageSizeSpecified.Should().BeTrue();
            response.searchResult.pageIndex.Should().Be(0);
            response.searchResult.pageIndexSpecified.Should().BeTrue();
            response.searchResult.totalPages.Should().Be(1);
            response.searchResult.totalPagesSpecified.Should().BeTrue();

            response.searchResult.recordList.Should().NotBeNullOrEmpty();
            response.searchResult.recordList.Should().HaveCount(1);

            var states = response.searchResult.recordList.Cast<State>().ToList();
            var state = states.First();

            state.internalId.Should().Be("1");
            state.fullName.Should().Be("Московская область");
            state.shortname.Should().Be("MO");
            state.country.Should().Be(Country._russianFederation);
            state.countrySpecified.Should().BeTrue();
        }

        [Fact]
        public async Task SearchAsync_WithUnsupportedSearchType_ReturnsError()
        {
            // Arrange
            var searchRecord = new TransactionSearchBasic(); // Неподдерживаемый тип

            // Act
            var response = await _client.searchAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _searchPreferences,
                searchRecord
            );

            // Assert
            response.Should().NotBeNull();
            response.searchResult.Should().NotBeNull();
            response.searchResult.status.isSuccess.Should().BeFalse();
            response.searchResult.status.statusDetail.Should().NotBeNullOrEmpty();

            var errorDetail = response.searchResult.status.statusDetail[0];
            errorDetail.type.Should().Be(StatusDetailType.ERROR);
            //errorDetail.code.Should().Be(StatusDetailCodeType.INVALID_SEARCH_TYPE);
            errorDetail.message.Should().Contain("Unsupported search type");
            errorDetail.message.Should().Contain("TransactionSearchBasic");

            response.searchResult.recordList.Should().BeNullOrEmpty();
            response.searchResult.totalRecords.Should().Be(0);
        }

    }
}
