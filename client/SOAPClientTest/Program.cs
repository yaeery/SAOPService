using System;
using ServiceReference;
using System.Diagnostics;
using System.ServiceModel;
using Task = System.Threading.Tasks.Task;

namespace SOAPClientTest
{
    class Program
    {
        NetSuitePortTypeClient CreateClient()
        {
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
            var client = new NetSuitePortTypeClient(binding, endpoint);

            // Только Basic аутентификация
            client.ClientCredentials.UserName.UserName = "ваш_логин";
            client.ClientCredentials.UserName.Password = "ваш_пароль";

            return client;
        }

        async Task<getResponse> clientGetAsync(NetSuitePortTypeClient client, TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences)
        {
            var recordRef = new RecordRef
            {
                type = RecordType.salesOrder,
                typeSpecified = true,
                internalId = "123456"
            };

            return await client.getAsync(
                tokenPassport,
                applicationInfo,
                partnerInfo,
                preferences,
                recordRef
            );
        }

        async Task<addListResponse> clientAddListAsync(NetSuitePortTypeClient client, TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences)
        {
            var newState = new State
            {
                fullName = "Московская область",

                shortname = "MO",

                country = Country._russianFederation,
                countrySpecified = true,

                // InternalId не задаем - он сгенерируется при добавлении
            };

            var existingState = new State
            {
                fullName = "Московская область",
                shortname = "MO",
                country = Country._russianFederation,
                countrySpecified = true,
            };

            return await client.addListAsync(
                tokenPassport,
                applicationInfo,
                partnerInfo,
                preferences,
                new State[] { newState, existingState } 
            );
        }

        async Task<updateResponse> clientUpdateAsync(NetSuitePortTypeClient client, TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo, Preferences preferences)
        {
            var record = CreateRecordForUpdate<State>();
            return await client.updateAsync(
                tokenPassport,
                applicationInfo,
                partnerInfo,
                preferences,
                record
            );
        }
        async Task<searchResponse> clientSearchAsync(NetSuitePortTypeClient client, TokenPassport tokenPassport, ApplicationInfo applicationInfo, PartnerInfo partnerInfo)
        {
            var searchPreferences = new SearchPreferences
            {
                bodyFieldsOnly = false,
                returnSearchColumns = true,
                pageSize = 50,
                pageSizeSpecified = true
            };
            var searchRecord = new CustomerSearchBasic
            {
                companyName = new SearchStringField
                {
                    @operator = SearchStringFieldOperator.contains,
                    searchValue = "Ромашка"
                }
            };

            return await client.searchAsync(
                tokenPassport,
                applicationInfo,
                partnerInfo,
                searchPreferences,
                searchRecord
            );
        }

        private Record CreateRecordForUpdate<TRecord>()
                where TRecord : class
        {
            if (typeof(TRecord) == typeof(State))
            {
                return new State
                {
                    internalId = "121211",
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
                    // ОБЯЗАТЕЛЬНО: ID существующего заказа
                    internalId = "12345",

                    // 1. ОСНОВНАЯ ИНФОРМАЦИЯ
                    tranId = "SO-2024-001",           // Номер заказа
                    memo = "Обновление через API",     // Комментарий
                    source = "WebStore",               // Источник

                    // 2. ДАТЫ
                    tranDate = DateTime.Now,
                    tranDateSpecified = true,

                    createdDate = DateTime.Now.AddDays(-5),
                    createdDateSpecified = true,

                    shipDate = DateTime.Now.AddDays(3),
                    shipDateSpecified = true,

                    // 3. КЛИЕНТ
                    entity = new RecordRef
                    {
                        internalId = "789",            // ID клиента
                        name = "ООО Ромашка",
                        type = RecordType.customer
                    },

                    // 4. ФИНАНСЫ
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

                    // 5. ВАЛЮТА
                    currency = new RecordRef
                    {
                        internalId = "1",
                        name = "RUB"
                    },
                    currencyName = "Российский рубль",
                    exchangeRate = 1.0,
                    exchangeRateSpecified = true,

                    // 6. СТАТУС
                    status = "A",                       // A - Approved
                    orderStatus = SalesOrderOrderStatus._pendingApproval,
                    orderStatusSpecified = true,

                    // 7. ДОСТАВКА
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

                    // 8. АДРЕСА
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

                    // 9. ПЛАТЕЖИ
                    paymentMethod = new RecordRef
                    {
                        internalId = "1",
                        name = "Банковская карта"
                    },

                    ccNumber = "411111XXXXXX1111",
                    ccName = "IVANOV IVAN",
                    ccExpireDate = new DateTime(2025, 12, 1),
                    ccExpireDateSpecified = true,

                    // 10. НАЛОГИ
                    taxItem = new RecordRef
                    {
                        internalId = "444",
                        name = "НДС 20%"
                    },
                    taxRate = 20.0,
                    taxRateSpecified = true,

                    // 11. СВЯЗИ
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

                    // 12. КОМАНДА ПРОДАЖ
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

                    // 13. ПАРТНЕРЫ
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

                    // 14. ТОВАРЫ
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

                    // 15. КАСТОМНЫЕ ПОЛЯ (если нужны)
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
                    // ОБЯЗАТЕЛЬНО: ID существующего клиента
                    internalId = "12345",

                    // 1. Название компании
                    companyName = "ООО Ромашка",

                    // 2. Имя контактного лица
                    firstName = "Иван",

                    // 3. Фамилия контактного лица
                    lastName = "Петров",

                    // 4. Email
                    email = "ivan.petrov@romashka.ru",

                    // 5. Телефон
                    phone = "+7 (495) 123-45-67",

                    // 6. Факс
                    fax = "+7 (495) 123-45-68",

                    // 7. Альтернативный телефон
                    altPhone = "+7 (916) 765-43-21",

                    // 8. Мобильный телефон
                    mobilePhone = "+7 (903) 111-22-33",

                    // 9. URL сайта
                    url = "www.romashka.ru",

                    // 10. Комментарии
                    comments = "Клиент обновлен через API",

                    // Дополнительно: статус активности
                    isInactive = false,
                    isInactiveSpecified = true,

                    // Дополнительно: налоги
                    taxable = true,
                    taxableSpecified = true,

                    // Дополнительно: кредитный лимит
                    creditLimit = 1000000.00,
                    creditLimitSpecified = true,

                    // Дополнительно: баланс
                    balance = 15000.75,
                    balanceSpecified = true
                };
            }
            else if(typeof(TRecord) == typeof(Deposit))
            {
                return new Deposit
                {
                    internalId = "12345",           // ID существующего депозита

                    // Если нужно обновить дату
                    tranDate = DateTime.Now,
                    tranDateSpecified = true,

                    // Если нужно обновить счет
                    account = new RecordRef
                    {
                        internalId = "456"
                    },

                    // Если нужно обновить мемо
                    memo = "Обновленный комментарий",

                    // Если нужно обновить сумму
                    total = 60000.00,
                    totalSpecified = true
                };
            }
            else
            {
                return null;
            }
        }
        static async Task Main(string[] args)
        {
            var program = new Program();
            var client = program.CreateClient();

            var tokenPassport = new TokenPassport
            {
                account = "123456",
                consumerKey = "AbCdEfGhIjKlMnOpQrStUvWxY",
                token = "12345-ABCDE",
                nonce = "987654321",
                timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            // 2.2 ApplicationInfo (если есть)
            var applicationInfo = new ApplicationInfo();

            // 2.3 PartnerInfo (если есть)
            var partnerInfo = new PartnerInfo();

            // 2.4 Preferences - настройки
            var preferences = new Preferences
            {
                warningAsError = false,
                disableMandatoryCustomFieldValidation = false,
            };

            var getResponse = await program.clientGetAsync(client, tokenPassport, applicationInfo, partnerInfo, preferences);
            var addListResponse = await program.clientAddListAsync(client, tokenPassport, applicationInfo, partnerInfo, preferences);
            var UpdateAsyncResponse = await program.clientUpdateAsync(client, tokenPassport, applicationInfo, partnerInfo, preferences);
            var Response = await program.clientSearchAsync(client, tokenPassport, applicationInfo, partnerInfo);
            int x = 0;
        }
    }
}

