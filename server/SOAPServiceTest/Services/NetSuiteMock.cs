using CoreWCF.IdentityModel.Protocols.WSTrust;
using Microsoft.AspNetCore.Identity.Data;
using MockSoapService;
using System.Reflection;
using System.ServiceModel; // namespace Reference.cs
using Task = System.Threading.Tasks.Task;
using ServiceReference;
using Status = ServiceReference.Status;

namespace MockSoapService.Services
{
    public class NetSuiteMock : NetSuitePortType
    {
        public async Task<getResponse> getAsync(getRequest request)
        {
        string _orderId = "12345";
        RecordRef recordRef = (RecordRef)request.@baseRef;
        BaseRef requestedRecord = request.@baseRef;
            if (requestedRecord is RecordRef recordRefProm)
            {
                if (recordRef.type == RecordType.salesOrder)
                {
                    var id = recordRef.internalId;

                    if (id == _orderId)
                    {
                        return await Task.FromResult(CreateSuccessResponseGet(id));
                    }
                    else
                    {
                        return await Task.FromResult(CreateErrorResponseGet($"Order with id {id} not found"));
                    }
                }
                else
                {
                    return await Task.FromResult(CreateErrorResponseGet($"Unsupported recordRef type: {recordRef.type}"));
                }
            }
            else
            {
               return await Task.FromResult(CreateErrorResponseGet($"Unsupported baseRef type: {requestedRecord?.GetType()}"));
            }
        }
        private getResponse CreateSuccessResponseGet(string id)
        {
            var salesOrder = new SalesOrder
            {
                // Основные идентификаторы  
                internalId = id,
                externalId = "EXT-SO-001",
                tranId = "SO-12345",

                // Связанные записи
                entity = new RecordRef
                {
                    internalId = "5678",
                    name = "Тестовый клиент"
                },

                // Финансовые поля
                total = 1500.75,
                totalSpecified = true,

                subTotal = 1250.00,
                subTotalSpecified = true,

                taxTotal = 250.75,
                taxTotalSpecified = true,

                discountTotal = 100.00,
                discountTotalSpecified = true,

                shippingCost = 300.00,
                shippingCostSpecified = true,

                handlingCost = 50.00,
                handlingCostSpecified = true,

                balance = 1500.75,
                balanceSpecified = true,

                // Налоги
                taxItem = new RecordRef { internalId = "444", name = "НДС 20%" },
                taxRate = 20.0,
                taxRateSpecified = true,
                tax2Total = 0,
                tax2TotalSpecified = true,

                // Валютные поля
                currency = new RecordRef { internalId = "1", name = "RUB" },
                currencyName = "Российский рубль",
                exchangeRate = 75.5,
                exchangeRateSpecified = true,

                // Даты
                tranDate = System.DateTime.Now,
                tranDateSpecified = true,

                shipDate = System.DateTime.Now.AddDays(2),
                shipDateSpecified = true,

                actualShipDate = System.DateTime.Now.AddDays(2),
                actualShipDateSpecified = true,

                createdDate = System.DateTime.Now.AddDays(-10),
                createdDateSpecified = true,

                lastModifiedDate = System.DateTime.Now,
                lastModifiedDateSpecified = true,

                startDate = System.DateTime.Now,
                startDateSpecified = true,

                endDate = System.DateTime.Now.AddDays(30),
                endDateSpecified = true,

                // Связи с другими объектами
                createdFrom = new RecordRef { internalId = "987", name = "QUOTE-001" },
                opportunity = new RecordRef { internalId = "456", name = "OPP-001" },
                job = new RecordRef { internalId = "789", name = "PROJECT-001" },

                // Статус
                status = "A", // A - Approved, B - Pending, и т.д.
                orderStatus = SalesOrderOrderStatus._pendingApproval,
                orderStatusSpecified = true,

                // Контактная информация
                memo = "Это тестовый заказ из mock-объекта.",
                email = "test@example.com",
                fax = "+7 (495) 123-45-67",

                // Адреса
                billingAddress = new Address
                {
                    addr1 = "ул. Ленина, д. 1",
                    addr2 = "офис 101",
                    city = "Москва",
                    state = "Москва",
                    zip = "123456",
                    country = Country._russianFederation,
                    countrySpecified = true,
                    attention = "Иванов И.И."
                },

                shippingAddress = new Address
                {
                    addr1 = "ул. Тверская, д. 5",
                    city = "Москва",
                    zip = "123789",
                    country = Country._russianFederation,
                    countrySpecified = true
                },

                shipIsResidential = false,
                shipIsResidentialSpecified = true,

                // Доставка
                shipMethod = new RecordRef { internalId = "123", name = "Курьерская доставка" },
                fob = "Москва",

                // Платежная информация
                paymentMethod = new RecordRef { internalId = "1", name = "Банковская карта" },
                ccNumber = "411111XXXXXX1111",
                ccName = "IVANOV IVAN",
                ccExpireDate = new System.DateTime(2025, 12, 1),
                ccExpireDateSpecified = true,
                ccApproved = true,
                ccApprovedSpecified = true,
                authCode = "AUTH123456",

                // Скидки
                discountItem = new RecordRef { internalId = "333", name = "Скидка 10%" },
                discountRate = "10",

                // Поля для печати и отправки
                toBePrinted = true,
                toBePrintedSpecified = true,
                toBeEmailed = false,
                toBeEmailedSpecified = true,

                // Дополнительные поля
                otherRefNum = "REF-001",
                source = "WebStore",

                // Список товаров
                itemList = new SalesOrderItemList
                {
                    item = new SalesOrderItem[]
                    {
                        new SalesOrderItem
                        {
                            item = new RecordRef { internalId = "111", name = "Товар 1" },
                            quantity = 2,
                            quantitySpecified = true,
                            amount = 500.00,
                            amountSpecified = true,
                            description = "Описание товара 1",
                            rate = "250.00",
                            line = 1,
                            lineSpecified = true
                        },
                        new SalesOrderItem
                        {
                            item = new RecordRef { internalId = "222", name = "Товар 2" },
                            quantity = 1,
                            quantitySpecified = true,
                            amount = 750.00,
                            amountSpecified = true,
                            description = "Описание товара 2",
                            rate = "750.00",
                            line = 2,
                            lineSpecified = true
                        }
                    },
                    replaceAll = true
                },

                // Команда продаж
                salesTeamList = new SalesOrderSalesTeamList
                {
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
                    },
                    replaceAll = true
                },

                // Партнеры
                partnersList = new SalesOrderPartnersList
                {
                    partners = new Partners[]
                    {
                        new Partners
                        {
                            partner = new RecordRef { internalId = "888", name = "Партнер ООО" },
                            partnerRole = new RecordRef { internalId = "2", name = "Посредник" },
                            contribution = 50,
                            contributionSpecified = true
                        }
                    },
                    replaceAll = true
                },

                // Кастомные поля
                customFieldList = new CustomFieldRef[]
                {
                    new StringCustomFieldRef
                    {
                        scriptId = "custbody_my_text_field",
                        value = "Мое кастомное значение"
                    },
                    new DoubleCustomFieldRef
                    {
                        internalId = "123",
                        value = 999.99
                    }
                }
            };

            // 3. Создаем ReadResponse с положительным статусом.
            var successStatus = new Status
            {
                isSuccess = true,
                isSuccessSpecified = true
                // statusDetail не заполняем, т.к. isSuccess = true
            };

            var readResponse = new ReadResponse
            {
                status = successStatus,
                record = salesOrder // Вкладываем наш созданный SalesOrder
            };

            // 4. Формируем и возвращаем финальный ответ getResponse.
            return new getResponse
            {
                readResponse = readResponse
            };
        }
        private getResponse CreateErrorResponseGet(string message)
        {
            return new getResponse
            {
                readResponse = new ReadResponse
                {
                    status = new Status
                    {
                        isSuccess = false,
                        isSuccessSpecified = true,
                        statusDetail = new StatusDetail[]
                        {
                        new StatusDetail
                        {
                            type = StatusDetailType.ERROR,
                            message = message
                        }
                        }
                    },
                    record = null
                }
            };
        }


        public async Task<addListResponse> addListAsync(addListRequest request)
        {
            string _shortname = "";
            string _internalId = "";
            var _writeResponses = new List<WriteResponse>();
            if (!(request.record[0] is State stateList))
            {
                return await Task.FromResult(CreateErrorResponseAddList($"Unsupported record type: {request.record[0].GetType().Name}"));
            }
            else
            {
                for (int i = 0; i < request.record.Count(); i++)
                {
                    if (_shortname != ((State)request.record[i]).shortname)
                    {
                        _shortname = ((State)request.record[i]).shortname;
                        _internalId = new Random().Next(10000, 99999).ToString();
                        _writeResponses.Add(CreateSuccessResponseAddList(((State)request.record[i]), _internalId));
                    }
                    else
                    {
                        _writeResponses.Add(CreateDuplicateResponseAddList(((State)request.record[i]), _internalId));
                    }
                }
            }
            return await Task.FromResult(CreateSuccessResponseAddList(_writeResponses));

        }
        private addListResponse CreateSuccessResponseAddList(List<WriteResponse> writeResponses)
        {
            var successCount = writeResponses.Count(r => r.status.isSuccess);
            var failCount = writeResponses.Count - successCount;

            Status overallStatus;

            if (failCount == 0)
            {
                overallStatus = new Status
                {
                    isSuccess = true,
                    isSuccessSpecified = true
                };
            }
            else if (successCount > 0)
            {
                overallStatus = new Status
                {
                    isSuccess = false,
                    isSuccessSpecified = true,
                    statusDetail = new StatusDetail[]
                    {
                        new StatusDetail
                        {
                            type = StatusDetailType.WARN,
                            code = StatusDetailCodeType.WARNING,
                            message = $"{successCount} record(s) added successfully, {failCount} record(s) failed"
                        }
                    }
                };
            }
            else
            {
                overallStatus = new Status
                {
                    isSuccess = false,
                    isSuccessSpecified = true,
                    statusDetail = new StatusDetail[]
                    {
                        new StatusDetail
                        {
                            type = StatusDetailType.ERROR,
                            code = StatusDetailCodeType.UNEXPECTED_ERROR,
                            message = "All records failed to add"
                        }
                    }
                };
            }

            return new addListResponse
            {
                writeResponseList = new WriteResponseList
                {
                    status = overallStatus,
                    writeResponse = writeResponses.ToArray()
                }
            };
        }
        private WriteResponse CreateDuplicateResponseAddList(State state, string internalId)
        {
            return new WriteResponse
            {
                status = new Status
                {
                    isSuccess = false,
                    isSuccessSpecified = true,
                    statusDetail = new StatusDetail[]
                    {
                        new StatusDetail
                        {
                            type = StatusDetailType.ERROR,
                            code = StatusDetailCodeType.DUP_NAME,
                            message = $"State with name '{state.fullName}' already exists. Existing internalId: {internalId}"
                        }
                    }
                },
                baseRef = new RecordRef
                {
                    internalId = internalId, // ID существующей записи
                    type = RecordType.state,
                    typeSpecified = true,
                    name = state.fullName
                }
            };
        }
        private WriteResponse CreateSuccessResponseAddList(State state, string internalId)
        {
            // Генерируем новый internalId
            state.internalId = internalId;

            return new WriteResponse
            {
                status = new Status
                {
                    isSuccess = true,
                    isSuccessSpecified = true
                },
                baseRef = new RecordRef
                {
                    internalId = state.internalId,
                    type = RecordType.state,
                    typeSpecified = true,
                    name = state.fullName
                }
            };
        }
        private addListResponse CreateErrorResponseAddList(string errorMessage)
        {
            return new addListResponse
            {
                writeResponseList = new WriteResponseList
                {
                    status = new Status
                    {
                        isSuccess = false,
                        isSuccessSpecified = true,
                        statusDetail = new StatusDetail[]
                        {
                    new StatusDetail
                    {
                        type = StatusDetailType.ERROR,
                        code = StatusDetailCodeType.INVALID_REQUEST,
                        message = errorMessage
                    }
                        }
                    },
                    writeResponse = Array.Empty<WriteResponse>()
                }
            };
        }


        public async Task<updateResponse> updateAsync(updateRequest request)
        {
            if(request?.record == null)
            {
                return await Task.FromResult(CreateErrorNullResponseUpdate());
            }
            else
            {
                if (request.record is State state)
                {
                    return await Task.FromResult(CreateResponseUpdateState(state));
                }
                else if (request.record is SalesOrder salesOrder)
                {
                    return await Task.FromResult(CreateResponseUpdateSalesOrder(salesOrder));
                }
                else if (request.record is Customer customer)
                {
                    return await Task.FromResult(CreateResponseUpdateCustomer(customer));
                }
                else
                {
                    return await Task.FromResult(CreateErrorunsupportedResponseUpdate(request.record));
                }
            }
        }
        private updateResponse CreateResponseUpdateState(State state)
        {
            // Проверяем наличие internalId (обязательно для обновления)
            if (string.IsNullOrEmpty(state.internalId))
            {
                return new updateResponse
                {
                    writeResponse = new WriteResponse
                    {
                        status = new Status
                        {
                            isSuccess = false,
                            isSuccessSpecified = true,
                            statusDetail = new StatusDetail[]
                            {
                                new StatusDetail
                                {
                                    type = StatusDetailType.ERROR,
                                    code = StatusDetailCodeType.INVALID_KEY_OR_REF,
                                    message = "internalId is required for update"
                                }
                            }
                        }
                    }
                };
            }

            // Симулируем разные сценарии в зависимости от internalId
            switch (state.internalId)
            {
                case "1": // Успешное обновление
                    return new updateResponse
                    {
                        writeResponse = new WriteResponse
                        {
                            status = new Status
                            {
                                isSuccess = true,
                                isSuccessSpecified = true
                            },
                            baseRef = new RecordRef
                            {
                                internalId = state.internalId,
                                type = RecordType.state,
                                typeSpecified = true,
                                name = state.fullName ?? "Updated State"
                            }
                        }
                    };

                case "999": // Запись не найдена
                    return new updateResponse
                    {
                        writeResponse = new WriteResponse
                        {
                            status = new Status
                            {
                                isSuccess = false,
                                isSuccessSpecified = true,
                                statusDetail = new StatusDetail[]
                                {
                                    new StatusDetail
                                    {
                                        type = StatusDetailType.ERROR,
                                        code = StatusDetailCodeType.RCRD_DSNT_EXIST,
                                        message = $"State with internalId {state.internalId} does not exist"
                                    }
                                }
                            }
                        }
                    };

                case "666": // Ошибка прав доступа
                    return new updateResponse
                    {
                        writeResponse = new WriteResponse
                        {
                            status = new Status
                            {
                                isSuccess = false,
                                isSuccessSpecified = true,
                                statusDetail = new StatusDetail[]
                                {
                                    new StatusDetail
                                    {
                                        type = StatusDetailType.ERROR,
                                        code = StatusDetailCodeType.INSUFFICIENT_PERMISSION,
                                        message = "You do not have permission to update this record"
                                    }
                                }
                            }
                        }
                    };

                default: // Обычное успешное обновление для всех остальных ID
                    return new updateResponse
                    {
                        writeResponse = new WriteResponse
                        {
                            status = new Status
                            {
                                isSuccess = true,
                                isSuccessSpecified = true
                            },
                            baseRef = new RecordRef
                            {
                                internalId = state.internalId,
                                type = RecordType.state,
                                typeSpecified = true,
                                name = state.fullName ?? "Updated State"
                            }
                        }
                    };
            }
        }
        private updateResponse CreateResponseUpdateSalesOrder(SalesOrder salesOrder)
        {
            if (string.IsNullOrEmpty(salesOrder.internalId))
            {
                return new updateResponse
                {
                    writeResponse = new WriteResponse
                    {
                        status = new Status
                        {
                            isSuccess = false,
                            isSuccessSpecified = true,
                            statusDetail = new StatusDetail[]
                            {
                                new StatusDetail
                                {
                                    type = StatusDetailType.ERROR,
                                    code = StatusDetailCodeType.INVALID_KEY_OR_REF,
                                    message = "internalId is required for update"
                                }
                            }
                        }
                    }
                };
            }

            // Дополнительная валидация для SalesOrder
            if (salesOrder.total < 0)
            {
                return new updateResponse
                {
                    writeResponse = new WriteResponse
                    {
                        status = new Status
                        {
                            isSuccess = false,
                            isSuccessSpecified = true,
                            statusDetail = new StatusDetail[]
                            {
                                new StatusDetail
                                {
                                    type = StatusDetailType.ERROR,
                                    code = StatusDetailCodeType.INVALID_AMT,
                                    message = "Total amount cannot be negative"
                                }
                            }
                        }
                    }
                };
            }

            // Успешное обновление SalesOrder
            return new updateResponse
            {
                writeResponse = new WriteResponse
                {
                    status = new Status
                    {
                        isSuccess = true,
                        isSuccessSpecified = true
                    },
                    baseRef = new RecordRef
                    {
                        internalId = salesOrder.internalId,
                        type = RecordType.salesOrder,
                        typeSpecified = true,
                        name = salesOrder.tranId ?? "SO-" + salesOrder.internalId
                    }
                }
            };
        }
        private updateResponse CreateResponseUpdateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.internalId))
            {
                return new updateResponse
                {
                    writeResponse = new WriteResponse
                    {
                        status = new Status
                        {
                            isSuccess = false,
                            isSuccessSpecified = true,
                            statusDetail = new StatusDetail[]
                            {
                                new StatusDetail
                                {
                                    type = StatusDetailType.ERROR,
                                    code = StatusDetailCodeType.INVALID_KEY_OR_REF,
                                    message = "internalId is required for update"
                                }
                            }
                        }
                    }
                };
            }

            // Проверка на конфликт версий (если передан externalId, который не совпадает)
            if (customer.externalId == "CONFLICT")
            {
                return new updateResponse
                {
                    writeResponse = new WriteResponse
                    {
                        status = new Status
                        {
                            isSuccess = false,
                            isSuccessSpecified = true,
                            statusDetail = new StatusDetail[]
                            {
                                new StatusDetail
                                {
                                    type = StatusDetailType.ERROR,
                                    code = StatusDetailCodeType.RCRD_EDITED_SINCE_RETRIEVED,
                                    message = "Record has been changed since retrieved"
                                }
                            }
                        }
                    }
                };
            }

            // Успешное обновление Customer
            return new updateResponse
            {
                writeResponse = new WriteResponse
                {
                    status = new Status
                    {
                        isSuccess = true,
                        isSuccessSpecified = true
                    },
                    baseRef = new RecordRef
                    {
                        internalId = customer.internalId,
                        type = RecordType.customer,
                        typeSpecified = true,
                        name = customer.companyName ?? customer.entityId ?? "Updated Customer"
                    }
                }
            };
        }
        private updateResponse CreateErrorNullResponseUpdate()
        {
            return new updateResponse
            {
                writeResponse = new WriteResponse
                {
                    status = new Status
                    {
                        isSuccess = false,
                        isSuccessSpecified = true,
                        statusDetail = new StatusDetail[]
                        {
                            new StatusDetail
                            {
                                type = StatusDetailType.ERROR,
                                code = StatusDetailCodeType.RCRD_DSNT_EXIST,
                                message = "Record is null or does not exist"
                            }
                        }
                    }
                }
            };
        }
        private updateResponse CreateErrorunsupportedResponseUpdate(Record record)
        {
            return new updateResponse
            {
                writeResponse = new WriteResponse
                {
                    status = new Status
                    {
                        isSuccess = false,
                        isSuccessSpecified = true,
                        statusDetail = new StatusDetail[]
                        {
                            new StatusDetail
                            {
                                type = StatusDetailType.ERROR,
                                code = StatusDetailCodeType.INVALID_RCRD_TYPE,
                                message = $"Unsupported record type: {record.GetType().Name}"
                            }
                        }
                    }
                }
            };
        }


        public async Task<searchResponse> searchAsync(searchRequest request)
        {
            if (request.searchRecord is CustomRecordSearchBasic stateSearch)
            {
                // Поиск по State
                var states = CreateTestStates();
                return await Task.FromResult(SearchStates(stateSearch, states));
            }
            else if (request.searchRecord is CustomerSearchBasic customerSearch)
            {
                // Поиск по Customer
                var customers = CreateTestCustomers();
                return await Task.FromResult(SearchCustomers(customerSearch, customers));
            }
            else
            {
                // Неподдерживаемый тип поиска
                return await Task.FromResult(CreateErrorResponseSearch(request.searchRecord?.GetType().Name));
            }
        }
        private List<State> CreateTestStates()
        {
            return new List<State>
            {
                new State
                {
                    internalId = "1",
                    fullName = "Московская область",
                    shortname = "MO",
                    country = Country._russianFederation,
                    countrySpecified = true
                },
                new State
                {
                    internalId = "2",
                    fullName = "Ленинградская область",
                    shortname = "LEN",
                    country = Country._russianFederation,
                    countrySpecified = true
                },
                new State
                {
                    internalId = "3",
                    fullName = "California",
                    shortname = "CA",
                    country = Country._unitedStates,
                    countrySpecified = true
                },
                new State
                {
                    internalId = "4",
                    fullName = "Texas",
                    shortname = "TX",
                    country = Country._unitedStates,
                    countrySpecified = true
                },
                new State
                {
                    internalId = "5",
                    fullName = "Bavaria",
                    shortname = "BY",
                    country = Country._germany,
                    countrySpecified = true
                }
            };
        }
        private List<Customer> CreateTestCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    internalId = "1001",
                    entityId = "CUST-001",
                    companyName = "ООО Ромашка",
                    email = "info@romashka.ru",
                    phone = "+7 (495) 111-22-33",
                    isPerson = false,
                    isPersonSpecified = true
                },
                new Customer
                {
                    internalId = "1002",
                    entityId = "CUST-002",
                    companyName = "ИП Иванов",
                    email = "ivanov@mail.ru",
                    phone = "+7 (916) 555-66-77",
                    isPerson = true,
                    isPersonSpecified = true,
                    firstName = "Иван",
                    lastName = "Иванов"
                },
                new Customer
                {
                    internalId = "1003",
                    entityId = "CUST-003",
                    companyName = "ООО Технологии",
                    email = "sales@tech.ru",
                    phone = "+7 (495) 777-88-99",
                    isPerson = false,
                    isPersonSpecified = true
                }
            };
        }
        private List<SalesOrder> CreateTestSalesOrders()
        {
            return new List<SalesOrder>
            {
                new SalesOrder
                {
                    internalId = "2001",
                    tranId = "SO-2024-001",
                    entity = new RecordRef { internalId = "1001", name = "ООО Ромашка" },
                    total = 15000.50,
                    totalSpecified = true,
                    status = "A",
                    createdDate = new DateTime(2024, 1, 15),
                    createdDateSpecified = true
                },
                new SalesOrder
                {
                    internalId = "2002",
                    tranId = "SO-2024-002",
                    entity = new RecordRef { internalId = "1002", name = "ИП Иванов" },
                    total = 7500.00,
                    totalSpecified = true,
                    status = "B",
                    createdDate = new DateTime(2024, 2, 20),
                    createdDateSpecified = true
                },
                new SalesOrder
                {
                    internalId = "2003",
                    tranId = "SO-2024-003",
                    entity = new RecordRef { internalId = "1001", name = "ООО Ромашка" },
                    total = 25000.00,
                    totalSpecified = true,
                    status = "A",
                    createdDate = new DateTime(2024, 3, 10),
                    createdDateSpecified = true
                },
                new SalesOrder
                {
                    internalId = "2004",
                    tranId = "SO-2024-004",
                    entity = new RecordRef { internalId = "1003", name = "ООО Технологии" },
                    total = 500000.00,
                    totalSpecified = true,
                    status = "A",
                    createdDate = new DateTime(2024, 3, 15),
                    createdDateSpecified = true
                }
            };
        }
        private searchResponse SearchStates(CustomRecordSearchBasic search, List<State> states)
        {
            var filteredStates = states.AsEnumerable();

            // Поиск по internalId
            if (search.internalId?.searchValue?.Any() == true)
            {
                var ids = search.internalId.searchValue.Select(x => x.internalId).ToList();
                filteredStates = filteredStates.Where(s => ids.Contains(s.internalId));
            }

            // Поиск по имени (fullName)
            if (search.name?.searchValue != null)
            {
                filteredStates = filteredStates.Where(s =>
                    s.fullName.Contains(search.name.searchValue, StringComparison.OrdinalIgnoreCase));
            }

            // Поиск по кастомным полям (здесь будет country)
            if (search.customFieldList != null)
            {
                foreach (var field in search.customFieldList)
                {
                    if (field is SearchMultiSelectCustomField multiField &&
                        multiField.scriptId == "custrecord_country" &&
                        multiField.searchValue?.Any() == true)
                    {
                        var countryIds = multiField.searchValue.Select(x => x.internalId).ToList();
                        // Здесь нужна логика соответствия между countryIds и Country enum
                        // Для простоты пока пропускаем
                    }
                }
            }

            var results = filteredStates.ToList();

            return new searchResponse
            {
                searchResult = new SearchResult
                {
                    status = new Status { isSuccess = true, isSuccessSpecified = true },
                    totalRecords = results.Count,
                    totalRecordsSpecified = true,
                    pageSize = 50,
                    pageSizeSpecified = true,
                    totalPages = 1,
                    totalPagesSpecified = true,
                    pageIndex = 0,
                    pageIndexSpecified = true,
                    recordList = results.Cast<Record>().ToArray()
                }
            };
        }
        private searchResponse SearchCustomers(CustomerSearchBasic search, List<Customer> customers)
        {
            var filteredCustomers = customers.AsEnumerable();

            // Поиск по internalId
            if (search.internalId?.searchValue?.Any() == true)
            {
                var ids = search.internalId.searchValue.Select(x => x.internalId).ToList();
                filteredCustomers = filteredCustomers.Where(c => ids.Contains(c.internalId));
            }

            // Поиск по externalId
            if (search.externalId?.searchValue?.Any() == true)
            {
                var ids = search.externalId.searchValue.Select(x => x.internalId).ToList();
                filteredCustomers = filteredCustomers.Where(c => ids.Contains(c.externalId));
            }

            // Поиск по названию компании
            if (search.companyName?.searchValue != null)
            {
                filteredCustomers = filteredCustomers.Where(c =>
                    c.companyName != null &&
                    c.companyName.Contains(search.companyName.searchValue, StringComparison.OrdinalIgnoreCase));
            }

            // Поиск по email
            if (search.email?.searchValue != null)
            {
                filteredCustomers = filteredCustomers.Where(c =>
                    c.email != null &&
                    c.email.Contains(search.email.searchValue, StringComparison.OrdinalIgnoreCase));
            }

            // Поиск по телефону
            if (search.phone?.searchValue != null)
            {
                filteredCustomers = filteredCustomers.Where(c =>
                    c.phone != null &&
                    c.phone.Contains(search.phone.searchValue));
            }

            // Поиск по имени (для физлиц)
            if (search.firstName?.searchValue != null)
            {
                filteredCustomers = filteredCustomers.Where(c =>
                    c.firstName != null &&
                    c.firstName.Contains(search.firstName.searchValue, StringComparison.OrdinalIgnoreCase));
            }

            if (search.lastName?.searchValue != null)
            {
                filteredCustomers = filteredCustomers.Where(c =>
                    c.lastName != null &&
                    c.lastName.Contains(search.lastName.searchValue, StringComparison.OrdinalIgnoreCase));
            }

            // Поиск по типу (физлицо/юрлицо)
            if (search.isPerson?.searchValue != null)
            {
                bool isPersonValue = search.isPerson.searchValue; // Это уже bool!
                filteredCustomers = filteredCustomers.Where(c =>
                    c.isPerson == isPersonValue);
            }

            // Поиск по статусу
            if (search.entityStatus?.searchValue?.Any() == true)
            {
                var statusIds = search.entityStatus.searchValue.Select(x => x.internalId).ToList();
                filteredCustomers = filteredCustomers.Where(c =>
                    c.entityStatus != null && statusIds.Contains(c.entityStatus.internalId));
            }

            // Поиск по категории
            if (search.category?.searchValue?.Any() == true)
            {
                var categoryIds = search.category.searchValue.Select(x => x.internalId).ToList();
                filteredCustomers = filteredCustomers.Where(c =>
                    c.category != null && categoryIds.Contains(c.category.internalId));
            }

            // Поиск по территории
            if (search.territory?.searchValue?.Any() == true)
            {
                var territoryIds = search.territory.searchValue.Select(x => x.internalId).ToList();
                filteredCustomers = filteredCustomers.Where(c =>
                    c.territory != null && territoryIds.Contains(c.territory.internalId));
            }

            // Поиск по активности
            if (search.isInactive?.searchValue != null)
            {
                var isInactive = search.isInactive.searchValue;
                filteredCustomers = filteredCustomers.Where(c =>
                    c.isInactive == isInactive);
            }

            // Поиск по языку
            if (search.language?.searchValue?.Any() == true)
            {
                var languages = search.language.searchValue.ToList();
                filteredCustomers = filteredCustomers.Where(c =>
                    languages.Contains(c.language.ToString()));
            }

            var results = filteredCustomers.ToList();

            return new searchResponse
            {
                searchResult = new SearchResult
                {
                    status = new Status { isSuccess = true, isSuccessSpecified = true },
                    totalRecords = results.Count,
                    totalRecordsSpecified = true,
                    pageSize = 50,
                    pageSizeSpecified = true,
                    totalPages = (int)Math.Ceiling((double)results.Count / 50),
                    totalPagesSpecified = true,
                    pageIndex = 0,
                    pageIndexSpecified = true,
                    recordList = results.Cast<Record>().ToArray()
                }
            };
        }
        private searchResponse CreateErrorResponseSearch(string errorMessage)
        {
            return new searchResponse
            {
                searchResult = new SearchResult
                {
                    status = new Status
                    {
                        isSuccess = false,
                        isSuccessSpecified = true,
                        statusDetail = new StatusDetail[]
                        {
                            new StatusDetail
                            {
                                type = StatusDetailType.ERROR,
                                code = StatusDetailCodeType.INVALID_SEARCH_TYPE,
                                message = $"Unsupported search type: {errorMessage}"
                            }
                        }
                    }
                }
            };
        }
    }
}

      
    //    // ==================== ПОИСК ПО SALES ORDER ====================

    //    private searchResponse SearchSalesOrders(TransactionSearchBasic search, List<SalesOrder> orders)
    //    {
    //        var filteredOrders = orders.AsEnumerable();

    //        // Фильтр по номеру транзакции
    //        if (search.tranId?.searchValue != null)
    //        {
    //            filteredOrders = filteredOrders.Where(o =>
    //                o.tranId.Contains(search.tranId.searchValue, StringComparison.OrdinalIgnoreCase));
    //        }

    //        // Фильтр по статусу
    //        if (search.status?.searchValue != null && search.status.searchValue.Length > 0)
    //        {
    //            filteredOrders = filteredOrders.Where(o =>
    //                o.status == search.status.searchValue[0]);
    //        }

    //        // Фильтр по клиенту
    //        if (search.entity?.searchValue != null)
    //        {
    //            filteredOrders = filteredOrders.Where(o =>
    //                o.entity.internalId == search.entity.searchValue);
    //        }

    //        // Фильтр по минимальной сумме
    //        if (search.total?.searchValue != null)
    //        {
    //            filteredOrders = filteredOrders.Where(o =>
    //                o.total >= search.total.searchValue);
    //        }

    //        // Фильтр по дате создания
    //        if (search.createdDate?.searchValue != null)
    //        {
    //            filteredOrders = filteredOrders.Where(o =>
    //                o.createdDate >= search.createdDate.searchValue);
    //        }

    //        return CreateSearchResult(filteredOrders.Cast<Record>().ToList());
    //    }
    //}
//}

//        private List<InventoryItem> _inventoryItems = new List<InventoryItem>
//{
//    new InventoryItem
//    {
//        internalId = "1001",
//        externalId = "EXT-001",
//        itemId = "NOTEBOOK-DELL-001",
//        displayName = "Ноутбук Dell XPS 15",
//        upcCode = "123456789012",
//        vendorName = "Dell Inc.",
//        salesDescription = "Мощный ноутбук для работы и игр",
//        purchaseDescription = "Закупка ноутбуков Dell XPS 15",

//        rate = 1500.00,
//        rateSpecified = true,
//        cost = 1200.00,
//        costSpecified = true,

//        quantityOnHand = 50,
//        quantityOnHandSpecified = true,
//        quantityAvailable = 45,
//        quantityAvailableSpecified = true,
//        quantityOnOrder = 10,
//        quantityOnOrderSpecified = true,
//        quantityBackOrdered = 0,
//        quantityBackOrderedSpecified = true,

//        weight = 2.5,
//        weightSpecified = true,

//        isInactive = false,
//        isInactiveSpecified = true,

//        createdDate = DateTime.Now.AddMonths(-6),
//        createdDateSpecified = true,
//        lastModifiedDate = DateTime.Now,
//        lastModifiedDateSpecified = true,

//        vendor = new RecordRef { internalId = "5001", name = "Dell Official" },
//        department = new RecordRef { internalId = "2001", name = "Электроника" },
//        @class = new RecordRef { internalId = "3001", name = "Компьютеры" },
//        location = new RecordRef { internalId = "4001", name = "Склад №1" }
//    },
//    new InventoryItem
//    {
//        internalId = "1002",
//        externalId = "EXT-002",
//        itemId = "NOTEBOOK-MAC-001",
//        displayName = "MacBook Pro 16",
//        upcCode = "098765432109",
//        vendorName = "Apple Inc.",
//        salesDescription = "Профессиональный ноутбук от Apple",
//        purchaseDescription = "Закупка MacBook Pro 16",

//        rate = 2500.00,
//        rateSpecified = true,
//        cost = 2100.00,
//        costSpecified = true,

//        quantityOnHand = 30,
//        quantityOnHandSpecified = true,
//        quantityAvailable = 28,
//        quantityAvailableSpecified = true,
//        quantityOnOrder = 5,
//        quantityOnOrderSpecified = true,
//        quantityBackOrdered = 2,
//        quantityBackOrderedSpecified = true,

//        weight = 2.2,
//        weightSpecified = true,

//        isInactive = false,
//        isInactiveSpecified = true,

//        createdDate = DateTime.Now.AddMonths(-3),
//        createdDateSpecified = true,
//        lastModifiedDate = DateTime.Now.AddDays(-1),
//        lastModifiedDateSpecified = true,

//        vendor = new RecordRef { internalId = "5002", name = "Apple Direct" },
//        department = new RecordRef { internalId = "2001", name = "Электроника" },
//        @class = new RecordRef { internalId = "3002", name = "Ноутбуки" },
//        location = new RecordRef { internalId = "4002", name = "Склад №2" }
//    },
//    new InventoryItem
//    {
//        internalId = "1003",
//        externalId = "EXT-003",
//        itemId = "MOUSE-LOGITECH-001",
//        displayName = "Logitech MX Master 3",
//        upcCode = "567890123456",
//        vendorName = "Logitech",
//        salesDescription = "Профессиональная беспроводная мышь",
//        purchaseDescription = "Закупка мышей Logitech",

//        rate = 100.00,
//        rateSpecified = true,
//        cost = 70.00,
//        costSpecified = true,

//        quantityOnHand = 200,
//        quantityOnHandSpecified = true,
//        quantityAvailable = 195,
//        quantityAvailableSpecified = true,
//        quantityOnOrder = 50,
//        quantityOnOrderSpecified = true,
//        quantityBackOrdered = 0,
//        quantityBackOrderedSpecified = true,

//        weight = 0.15,
//        weightSpecified = true,

//        isInactive = false,
//        isInactiveSpecified = true,

//        createdDate = DateTime.Now.AddMonths(-2),
//        createdDateSpecified = true,
//        lastModifiedDate = DateTime.Now.AddDays(-5),
//        lastModifiedDateSpecified = true,

//        vendor = new RecordRef { internalId = "5003", name = "Logitech Rus" },
//        department = new RecordRef { internalId = "2002", name = "Аксессуары" },
//        @class = new RecordRef { internalId = "3003", name = "Мыши" },
//        location = new RecordRef { internalId = "4001", name = "Склад №1" }
//    },
//    new InventoryItem
//    {
//        internalId = "1004",
//        externalId = "EXT-004",
//        itemId = "KEYBOARD-001",
//        displayName = "Механическая клавиатура",
//        upcCode = "345678901234",
//        vendorName = "Keychron",
//        salesDescription = "Механическая клавиатура с переключателями",
//        purchaseDescription = "Закупка клавиатур",

//        rate = 200.00,
//        rateSpecified = true,
//        cost = 130.00,
//        costSpecified = true,

//        quantityOnHand = 75,
//        quantityOnHandSpecified = true,
//        quantityAvailable = 70,
//        quantityAvailableSpecified = true,
//        quantityOnOrder = 25,
//        quantityOnOrderSpecified = true,
//        quantityBackOrdered = 5,
//        quantityBackOrderedSpecified = true,

//        weight = 1.2,
//        weightSpecified = true,

//        isInactive = false,
//        isInactiveSpecified = true,

//        createdDate = DateTime.Now.AddMonths(-4),
//        createdDateSpecified = true,
//        lastModifiedDate = DateTime.Now.AddDays(-2),
//        lastModifiedDateSpecified = true,

//        vendor = new RecordRef { internalId = "5004", name = "Keychron EU" },
//        department = new RecordRef { internalId = "2002", name = "Аксессуары" },
//        @class = new RecordRef { internalId = "3004", name = "Клавиатуры" },
//        location = new RecordRef { internalId = "4002", name = "Склад №2" }
//    },
//    new InventoryItem
//    {
//        internalId = "1005",
//        externalId = "EXT-005",
//        itemId = "MONITOR-4K-001",
//        displayName = "Монитор 4K 27 дюймов",
//        upcCode = "789012345678",
//        vendorName = "LG",
//        salesDescription = "4K монитор для дизайнеров",
//        purchaseDescription = "Закупка мониторов",

//        rate = 500.00,
//        rateSpecified = true,
//        cost = 380.00,
//        costSpecified = true,

//        quantityOnHand = 20,
//        quantityOnHandSpecified = true,
//        quantityAvailable = 18,
//        quantityAvailableSpecified = true,
//        quantityOnOrder = 10,
//        quantityOnOrderSpecified = true,
//        quantityBackOrdered = 2,
//        quantityBackOrderedSpecified = true,

//        weight = 4.5,
//        weightSpecified = true,

//        isInactive = false,
//        isInactiveSpecified = true,

//        createdDate = DateTime.Now.AddMonths(-1),
//        createdDateSpecified = true,
//        lastModifiedDate = DateTime.Now.AddDays(-3),
//        lastModifiedDateSpecified = true,

//        vendor = new RecordRef { internalId = "5005", name = "LG Electronics" },
//        department = new RecordRef { internalId = "2003", name = "Мониторы" },
//        @class = new RecordRef { internalId = "3005", name = "4K дисплеи" },
//        location = new RecordRef { internalId = "4003", name = "Склад №3" }
//    }
//};

//public searchResponse search(searchRequest request)
//{
//    //if (request?.searchRecord != null && request.searchRecord is ItemSearchBasic itemSearch)
//    //{
//    //    if (itemSearch.itemId != null)
//    //    {
//    //        var itemIdType = itemSearch.itemId.GetType();

//    //        Console.WriteLine("=== ПОЛНЫЙ ДАМП ОБЪЕКТА itemId ===");

//    //        // 1. Смотрим все поля (fields)
//    //        var fields = itemIdType.GetFields(System.Reflection.BindingFlags.Public |
//    //                                          System.Reflection.BindingFlags.NonPublic |
//    //                                          System.Reflection.BindingFlags.Instance);

//    //        Console.WriteLine("--- FIELDS ---");
//    //        foreach (var field in fields)
//    //        {
//    //            var value = field.GetValue(itemSearch.itemId);
//    //            Console.WriteLine($"Field: {field.Name} = '{value}' (type: {value?.GetType()?.Name ?? "null"})");
//    //        }

//    //        // 2. Смотрим все свойства (properties)
//    //        var properties = itemIdType.GetProperties(System.Reflection.BindingFlags.Public |
//    //                                                  System.Reflection.BindingFlags.NonPublic |
//    //                                                  System.Reflection.BindingFlags.Instance);

//    //        Console.WriteLine("--- PROPERTIES ---");
//    //        foreach (var prop in properties)
//    //        {
//    //            try
//    //            {
//    //                var value = prop.GetValue(itemSearch.itemId);
//    //                Console.WriteLine($"Property: {prop.Name} = '{value}' (type: {value?.GetType()?.Name ?? "null"})");
//    //            }
//    //            catch (Exception ex)
//    //            {
//    //                Console.WriteLine($"Property: {prop.Name} - ERROR: {ex.Message}");
//    //            }
//    //        }

//    //        // 3. Проверяем специальные поля (для XML сериализации)
//    //        var searchValueField = itemIdType.GetField("searchValueField",
//    //            System.Reflection.BindingFlags.NonPublic |
//    //            System.Reflection.BindingFlags.Instance);

//    //        if (searchValueField != null)
//    //        {
//    //            var searchValueFieldValue = searchValueField.GetValue(itemSearch.itemId);
//    //            Console.WriteLine($"PRIVATE FIELD 'searchValueField' = '{searchValueFieldValue}'");

//    //            // Если нашли значение, используем его
//    //            if (searchValueFieldValue is string strValue && !string.IsNullOrEmpty(strValue))
//    //            {
//    //                var searchValue = strValue.ToLower();
//    //                results = results.Where(item =>
//    //                    item.displayName?.ToLower().Contains(searchValue) == true ||
//    //                    item.itemId?.ToLower().Contains(searchValue) == true
//    //                );
//    //            }
//    //        }

//    //        // 4. Пробуем найти любое поле с нашим значением
//    //        foreach (var field in fields)
//    //        {
//    //            var val = field.GetValue(itemSearch.itemId);
//    //            if (val is string str && str == "ноутбук")
//    //            {
//    //                Console.WriteLine($"!!! НАШЛИ ЗНАЧЕНИЕ В ПОЛЕ: {field.Name}");
//    //                var searchValue = str.ToLower();
//    //               var  results = results.Where(item =>
//    //                    item.displayName?.ToLower().Contains(searchValue) == true ||
//    //                    item.itemId?.ToLower().Contains(searchValue) == true
//    //                );
//    //                break;
//    //            }
//    //        }

//    //        Console.WriteLine("=== КОНЕЦ ДАМПА ===");
//    //    }
//    //}


//    if (request.searchRecord is ItemSearchBasic itemSearch1)
//    {
//        // Временная диагностика
//        var results = _inventoryItems.AsEnumerable();
//        var itemSearch = request.searchRecord as ItemSearchBasic;

//        var searchValue = itemSearch?.itemId?.searchValue;

//        if (!string.IsNullOrEmpty(searchValue))
//        {
//            var value = searchValue.ToLower();

//            results = results.Where(item =>
//                item.displayName?.ToLower().Contains(value) == true ||
//                item.itemId?.ToLower().Contains(value) == true
//            );
//        }
//        Console.WriteLine(request == null);                 // ?
//        Console.WriteLine(request?.searchRecord == null);  // ?
//        Console.WriteLine(request?.searchRecord?.GetType().FullName);
//        return HandleItemSearch(itemSearch1);
//    }
//    else
//    {
//        return CreateSearchErrorResponse($"Unsupported search type: {request.searchRecord.GetType()}");
//    }
//}
//private searchResponse CreateSearchErrorResponse(string message)
//{
//    return new searchResponse
//    {
//        searchResult = new SearchResult
//        {
//            status = new Status
//            {
//                isSuccess = false,
//                isSuccessSpecified = true,
//                statusDetail = new StatusDetail[]
//                {
//                    new StatusDetail
//                    {
//                        type = StatusDetailType.ERROR,
//                        message = message
//                    }
//                }
//            }
//        }
//    };
//}

//private searchResponse HandleItemSearch(ItemSearchBasic search)
//{









//    var results = _inventoryItems.AsEnumerable();

//    //var itemSearch = search.searchRecord as ItemSearchBasic;

//    //var searchValue = itemSearch?.itemId?.searchValue;

//    //if (!string.IsNullOrEmpty(searchValue))
//    //{
//    //    var value = searchValue.ToLower();

//    //    results = results.Where(item =>
//    //        item.displayName?.ToLower().Contains(value) == true ||
//    //        item.itemId?.ToLower().Contains(value) == true
//    //    );
//    //}

//    var resultArray = results.ToArray();

//    var searchResult = new SearchResult();
//    searchResult.status = new Status
//    {
//        isSuccess = true,
//        isSuccessSpecified = true
//    };
//    searchResult.totalRecords = resultArray.Length;
//    searchResult.totalRecordsSpecified = true;
//    searchResult.pageSize = 50;
//    searchResult.pageSizeSpecified = true;
//    searchResult.totalPages = resultArray.Length > 0 ? 1 : 0;
//    searchResult.totalPagesSpecified = true;
//    searchResult.pageIndex = 1;
//    searchResult.pageIndexSpecified = true;

//    // 👇 ВОТ ЭТО ОТСУТСТВУЕТ
//    searchResult.recordList = resultArray;

//    return new searchResponse
//    {
//        searchResult = searchResult
//    };
//    //IEnumerable<InventoryItem> results = _inventoryItems;

//    //// Поиск по itemId (частичное совпадение)
//    //if (search?.itemId != null && !string.IsNullOrEmpty(search.itemId.searchValue))
//    //{
//    //    var searchValue = search.itemId.searchValue.ToLower();
//    //    results = results.Where(item =>
//    //        item.itemId.ToLower().Contains(searchValue) ||
//    //        item.displayName.ToLower().Contains(searchValue));
//    //}

//    //// Поиск по точному upcCode
//    //if (search?.upcCode != null && !string.IsNullOrEmpty(search.upcCode.searchValue))
//    //{
//    //    results = results.Where(item =>
//    //        item.upcCode == search.upcCode.searchValue);
//    //}

//    //// Поиск по цене (больше чем)
//    //if (search?.basePrice != null && search.basePrice.searchValue > 0)
//    //{
//    //    if (search.basePrice.@operator == SearchDoubleFieldOperator.greaterThan)
//    //    {
//    //        results = results.Where(item =>
//    //            item.basePrice > search.basePrice.searchValue);
//    //    }
//    //    else if (search.basePrice.@operator == SearchDoubleFieldOperator.lessThan)
//    //    {
//    //        results = results.Where(item =>
//    //            item.basePrice < search.basePrice.searchValue);
//    //    }
//    //}

//    //// Поиск по активности
//    //if (search?.isInactive != null)
//    //{
//    //    results = results.Where(item =>
//    //        item.isInactive == search.isInactive.searchValue);
//    //}

//    //var resultArray = results.ToArray();

//    //return new searchResponse
//    //{
//    //    searchResult = new SearchResult
//    //    {
//    //        status = new Status
//    //        {
//    //            isSuccess = true,
//    //            isSuccessSpecified = true
//    //        },
//    //        totalRecords = resultArray.Length,
//    //        totalRecordsSpecified = true,
//    //        pageSize = 50,
//    //        pageSizeSpecified = true,
//    //        totalPages = (int)Math.Ceiling(resultArray.Length / 50.0),
//    //        totalPagesSpecified = true,
//    //        pageIndex = 1,
//    //        pageIndexSpecified = true,
//    //        recordList = new RecordList
//    //        {
//    //            record = resultArray
//    //        }
//    //    }
//    //};
//}