using FluentAssertions;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace SOAPClientTestIntegrationTests.Services
{
    public class UpdateAsyncRequestTest
    {
        private NetSuitePortTypeClient _client;
        private TokenPassport _tokenPassport;
        private ApplicationInfo _applicationInfo;
        private PartnerInfo _partnerInfo;
        private Preferences _preferences;

        public UpdateAsyncRequestTest()
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

        [Theory]
        [InlineData("121211" , true)]           // Успех
        [InlineData("",  false)]                 // Нет internalId
        [InlineData("999", false)]          // Не существует
        [InlineData("666", false)]                // Нет прав
        public async Task UpdateAsync_WithState_ReturnsExpectedResult(string internalId, bool expectedSuccess)
        {
            // Arrange
            var state = CreateRecordForUpdate<State>() as State;
            state.internalId = internalId;

            // Act
            var response = await _client.updateAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                state
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponse.Should().NotBeNull();
            response.writeResponse.status.isSuccess.Should().Be(expectedSuccess);
            response.writeResponse.status.isSuccessSpecified.Should().BeTrue();
            RecordRef recordRefResponse = (RecordRef)response.writeResponse.baseRef;

            if (expectedSuccess)
            {
                recordRefResponse.Should().NotBeNull();
                recordRefResponse.internalId.Should().Be(internalId);
                recordRefResponse.type.Should().Be(RecordType.state);
                recordRefResponse.name.Should().Be(state.fullName);
            }
            else
            {
                recordRefResponse.Should().BeNull();
                response.writeResponse.status.statusDetail[0].type.Should().Be(StatusDetailType.ERROR);
                response.writeResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            }
        }
        private ServiceReference.Record CreateRecordForUpdate<TRecord>() where TRecord : class
        {
            if (typeof(TRecord) == typeof(State))
            {
                return new State
                {
                    fullName = "Московская область",
                    shortname = "MO",
                    country = Country._russianFederation,
                    countrySpecified = true,
                };
            }
            else if (typeof(TRecord) == typeof(SalesOrder))
            {
                return new SalesOrder
                {
                    internalId = "12345",
                    tranId = "SO-2024-001",
                    memo = "Обновление через API",
                    source = "WebStore",
                    tranDate = DateTime.Now,
                    tranDateSpecified = true,
                    createdDate = DateTime.Now.AddDays(-5),
                    createdDateSpecified = true,
                    shipDate = DateTime.Now.AddDays(3),
                    shipDateSpecified = true,
                    entity = new RecordRef
                    {
                        internalId = "789",
                        name = "ООО Ромашка",
                        type = RecordType.customer
                    },
                    total = 15000.75,
                    totalSpecified = true,
                    subTotal = 12500.00,
                    subTotalSpecified = true,
                    taxTotal = 2500.75,
                    taxTotalSpecified = true,
                    discountTotal = 500.00,
                    discountTotalSpecified = true,
                    balance = 15000.75,
                    balanceSpecified = true,
                    currency = new RecordRef
                    {
                        internalId = "1",
                        name = "RUB"
                    },
                    currencyName = "Российский рубль",
                    exchangeRate = 1.0,
                    exchangeRateSpecified = true,
                    status = "A",
                    orderStatus = SalesOrderOrderStatus._pendingApproval,
                    orderStatusSpecified = true,
                    shipMethod = new RecordRef
                    {
                        internalId = "456",
                        name = "Курьерская доставка"
                    },
                    shippingCost = 500.00,
                    shippingCostSpecified = true,
                    handlingCost = 100.00,
                    handlingCostSpecified = true,
                    fob = "Москва",
                    billingAddress = new Address
                    {
                        addr1 = "ул. Ленина, д. 10",
                        addr2 = "офис 101",
                        city = "Москва",
                        state = "Москва",
                        zip = "123456",
                        country = Country._russianFederation
                    },
                    shippingAddress = new Address
                    {
                        addr1 = "ул. Тверская, д. 5",
                        city = "Москва",
                        zip = "123789",
                        country = Country._russianFederation
                    },
                    paymentMethod = new RecordRef
                    {
                        internalId = "1",
                        name = "Банковская карта"
                    },
                    ccNumber = "411111XXXXXX1111",
                    ccName = "IVANOV IVAN",
                    ccExpireDate = new DateTime(2025, 12, 1),
                    ccExpireDateSpecified = true,
                    taxItem = new RecordRef
                    {
                        internalId = "444",
                        name = "НДС 20%"
                    },
                    taxRate = 20.0,
                    taxRateSpecified = true,
                    createdFrom = new RecordRef
                    {
                        internalId = "987",
                        name = "QUOTE-001"
                    },
                    opportunity = new RecordRef
                    {
                        internalId = "654",
                        name = "OPP-001"
                    },
                    salesTeamList = new SalesOrderSalesTeamList
                    {
                        replaceAll = true,
                        salesTeam = new SalesOrderSalesTeam[]
                        {
                            new SalesOrderSalesTeam
                            {
                                employee = new RecordRef { internalId = "777", name = "Иванов Иван" },
                                salesRole = new RecordRef { internalId = "1", name = "Менеджер" },
                                contribution = 100,
                                contributionSpecified = true,
                                isPrimary = true,
                                isPrimarySpecified = true
                            }
                        }
                    },
                    partnersList = new SalesOrderPartnersList
                    {
                        replaceAll = true,
                        partners = new Partners[]
                        {
                            new Partners
                            {
                                partner = new RecordRef { internalId = "888", name = "Партнер ООО" },
                                partnerRole = new RecordRef { internalId = "2", name = "Посредник" },
                                contribution = 50,
                                contributionSpecified = true
                            }
                        }
                    },
                    itemList = new SalesOrderItemList
                    {
                        replaceAll = true,
                        item = new SalesOrderItem[]
                        {
                            new SalesOrderItem
                            {
                                item = new RecordRef { internalId = "111", name = "Товар 1" },
                                quantity = 2,
                                quantitySpecified = true,
                                amount = 5000.00,
                                amountSpecified = true,
                                description = "Описание товара 1",
                                rate = "2500.00",
                                line = 1,
                                lineSpecified = true
                            },
                            new SalesOrderItem
                            {
                                item = new RecordRef { internalId = "222", name = "Товар 2" },
                                quantity = 1,
                                quantitySpecified = true,
                                amount = 7500.00,
                                amountSpecified = true,
                                description = "Описание товара 2",
                                rate = "7500.00",
                                line = 2,
                                lineSpecified = true
                            }
                        }
                    },
                    customFieldList = new CustomFieldRef[]
                    {
                        new StringCustomFieldRef
                        {
                            scriptId = "custbody_mytext",
                            value = "Тестовое значение"
                        },
                        new DoubleCustomFieldRef
                        {
                            internalId = "123",
                            value = 999.99
                        }
                    }
                };
            }
            else if (typeof(TRecord) == typeof(Customer))
            {
                return new Customer
                {
                    internalId = "12345",
                    companyName = "ООО Ромашка",
                    firstName = "Иван",
                    lastName = "Петров",
                    email = "ivan.petrov@romashka.ru",
                    phone = "+7 (495) 123-45-67",
                    fax = "+7 (495) 123-45-68",
                    altPhone = "+7 (916) 765-43-21",
                    mobilePhone = "+7 (903) 111-22-33",
                    url = "www.romashka.ru",
                    comments = "Клиент обновлен через API",
                    isInactive = false,
                    isInactiveSpecified = true,
                    taxable = true,
                    taxableSpecified = true,
                    creditLimit = 1000000.00,
                    creditLimitSpecified = true,
                    balance = 15000.75,
                    balanceSpecified = true
                };
            }
            else if (typeof(TRecord) == typeof(Deposit))
            {
                return new Deposit
                {
                    internalId = "12345",
                    tranDate = DateTime.Now,
                    tranDateSpecified = true,
                    account = new RecordRef
                    {
                        internalId = "456"
                    },
                    memo = "Обновленный комментарий",
                    total = 60000.00,
                    totalSpecified = true
                };
            }

            return null;
        }

        [Theory]
        [InlineData("12345", 15000.75, true)]      // Успех
        [InlineData("12345", -100.00, false)]      // Отрицательная сумма
        [InlineData("", 15000.75, false)]          // Нет internalId
        public async Task UpdateAsync_WithSalesOrder_ReturnsExpectedResult(string internalId, double total, bool expectedSuccess)
        {
            // Arrange
            var salesOrder = CreateRecordForUpdate<SalesOrder>() as SalesOrder;
            salesOrder.internalId = internalId;
            salesOrder.total = total;

            // Act
            var response = await _client.updateAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                salesOrder
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponse.Should().NotBeNull();
            response.writeResponse.status.isSuccess.Should().Be(expectedSuccess);
            RecordRef recordRefResponse = (RecordRef)response.writeResponse.baseRef;

            if (expectedSuccess)
            {
                response.writeResponse.baseRef.Should().NotBeNull();
                recordRefResponse.internalId.Should().Be(internalId);
                recordRefResponse.type.Should().Be(RecordType.salesOrder);
                recordRefResponse.name.Should().Be("SO-2024-001");
            }
            else
            {
                recordRefResponse.Should().BeNull();
                response.writeResponse.status.statusDetail[0].type.Should().Be(StatusDetailType.ERROR);
                response.writeResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            }
        }

        [Theory]
        [InlineData("12345", "ООО Ромашка", true)]      // Успех
        [InlineData("", "ООО Ромашка", false)]          // Нет internalId
        [InlineData("12345", "CONFLICT", false)]        // Конфликт версий
        public async Task UpdateAsync_WithCustomer_ReturnsExpectedResult(string internalId, string companyName, bool expectedSuccess)
        {
            // Arrange
            var customer = CreateRecordForUpdate<Customer>() as Customer;
            customer.internalId = internalId;

            if (companyName == "CONFLICT")
            {
                customer.externalId = "CONFLICT";
                customer.companyName = "ООО Ромашка";
            }
            else
            {
                customer.companyName = companyName;
            }

            // Act
            var response = await _client.updateAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                customer
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponse.Should().NotBeNull();
            response.writeResponse.status.isSuccess.Should().Be(expectedSuccess);
            RecordRef recordRefResponse = (RecordRef)response.writeResponse.baseRef;

            if (expectedSuccess)
            {
                recordRefResponse.Should().NotBeNull();
                recordRefResponse.internalId.Should().Be(internalId);
                recordRefResponse.type.Should().Be(RecordType.customer);
                recordRefResponse.name.Should().Be(companyName == "CONFLICT" ? "ООО Ромашка" : companyName);
            }
            else
            {
                recordRefResponse.Should().BeNull();
                response.writeResponse.status.statusDetail[0].type.Should().Be(StatusDetailType.ERROR);
                response.writeResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public async Task UpdateAsync_WithNullRecord_ReturnsError()
        {
            // Act
            var response = await _client.updateAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                null
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponse.Should().NotBeNull();
            response.writeResponse.status.isSuccess.Should().BeFalse();
            response.writeResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            response.writeResponse.baseRef.Should().BeNull();
            response.writeResponse.status.statusDetail[0].message.Should().Contain("Record is null or does not exist");
        }

        [Fact]
        public async Task UpdateAsync_WithUnsupportedRecordType_ReturnsError()
        {
            // Arrange
            var deposit = CreateRecordForUpdate<Deposit>() as Deposit; // Deposit - неподдерживаемый тип

            // Act
            var response = await _client.updateAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                deposit
            );

            // Assert
            response.Should().NotBeNull();
            response.writeResponse.Should().NotBeNull();
            response.writeResponse.status.isSuccess.Should().BeFalse();
            response.writeResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            response.writeResponse.baseRef.Should().BeNull();
            response.writeResponse.status.statusDetail[0].message.Should().Contain("Unsupported record type");
            response.writeResponse.status.statusDetail[0].message.Should().Contain("Deposit");
        }

    }
}
