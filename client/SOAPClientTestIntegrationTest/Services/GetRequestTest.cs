using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using FluentAssertions;

namespace SOAPClientTestUnitTest.Services
{
    public class GetRequestTest
    {
        private NetSuitePortTypeClient _client;
        private TokenPassport _tokenPassport;
        private ApplicationInfo _applicationInfo;
        private PartnerInfo _partnerInfo;
        private Preferences _preferences;

        public GetRequestTest()
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
        public async Task GetSalesOrder_WithValidId_ReturnsOrderFromRealServer()
        {
            // Arrange
            string existingOrderId = "12345";
            var recordRef = new RecordRef
            {
                type = RecordType.salesOrder,
                typeSpecified = true,
                internalId = existingOrderId
            };
            // Act
            var response = await _client.getAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                recordRef
            );

            // Assert
            response.Should().NotBeNull();
            response.readResponse.Should().NotBeNull();
            response.readResponse.status.isSuccess.Should().BeTrue();
            response.readResponse.status.isSuccessSpecified.Should().BeTrue();

            var salesOrder = response.readResponse.record as SalesOrder;
            salesOrder.Should().NotBeNull();

            // Основные идентификаторы
            salesOrder.internalId.Should().Be(existingOrderId);
            salesOrder.externalId.Should().Be("EXT-SO-001");
            salesOrder.tranId.Should().Be("SO-12345");

            // Связанные записи
            salesOrder.entity.Should().NotBeNull();
            salesOrder.entity.internalId.Should().Be("5678");
            salesOrder.entity.name.Should().Be("Тестовый клиент");

            // Финансовые поля
            salesOrder.total.Should().Be(1500.75);
            salesOrder.totalSpecified.Should().BeTrue();
            salesOrder.subTotal.Should().Be(1250.00);
            salesOrder.subTotalSpecified.Should().BeTrue();
            salesOrder.taxTotal.Should().Be(250.75);
            salesOrder.taxTotalSpecified.Should().BeTrue();
            salesOrder.discountTotal.Should().Be(100.00);
            salesOrder.discountTotalSpecified.Should().BeTrue();
            salesOrder.shippingCost.Should().Be(300.00);
            salesOrder.shippingCostSpecified.Should().BeTrue();
            salesOrder.handlingCost.Should().Be(50.00);
            salesOrder.handlingCostSpecified.Should().BeTrue();
            salesOrder.balance.Should().Be(1500.75);
            salesOrder.balanceSpecified.Should().BeTrue();

            // Налоги
            salesOrder.taxItem.Should().NotBeNull();
            salesOrder.taxItem.internalId.Should().Be("444");
            salesOrder.taxItem.name.Should().Be("НДС 20%");
            salesOrder.taxRate.Should().Be(20.0);
            salesOrder.taxRateSpecified.Should().BeTrue();
            salesOrder.tax2Total.Should().Be(0);
            salesOrder.tax2TotalSpecified.Should().BeTrue();

            // Валютные поля
            salesOrder.currency.Should().NotBeNull();
            salesOrder.currency.internalId.Should().Be("1");
            salesOrder.currency.name.Should().Be("RUB");
            salesOrder.currencyName.Should().Be("Российский рубль");
            salesOrder.exchangeRate.Should().Be(75.5);
            salesOrder.exchangeRateSpecified.Should().BeTrue();

            // Даты
            salesOrder.tranDateSpecified.Should().BeTrue();
            salesOrder.tranDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(50));
            salesOrder.shipDateSpecified.Should().BeTrue();
            salesOrder.shipDate.Should().BeCloseTo(DateTime.Now.AddDays(2), TimeSpan.FromSeconds(59));
            salesOrder.actualShipDateSpecified.Should().BeTrue();
            salesOrder.actualShipDate.Should().BeCloseTo(DateTime.Now.AddDays(2), TimeSpan.FromSeconds(59));
            salesOrder.createdDateSpecified.Should().BeTrue();
            salesOrder.createdDate.Should().BeCloseTo(DateTime.Now.AddDays(-10), TimeSpan.FromSeconds(59));
            salesOrder.lastModifiedDateSpecified.Should().BeTrue();
            salesOrder.lastModifiedDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(59));
            salesOrder.startDateSpecified.Should().BeTrue();
            salesOrder.startDate.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(59));
            salesOrder.endDateSpecified.Should().BeTrue();
            salesOrder.endDate.Should().BeCloseTo(DateTime.Now.AddDays(30), TimeSpan.FromSeconds(59));

            // Связи с другими объектами
            salesOrder.createdFrom.Should().NotBeNull();
            salesOrder.createdFrom.internalId.Should().Be("987");
            salesOrder.createdFrom.name.Should().Be("QUOTE-001");
            salesOrder.opportunity.Should().NotBeNull();
            salesOrder.opportunity.internalId.Should().Be("456");
            salesOrder.opportunity.name.Should().Be("OPP-001");
            salesOrder.job.Should().NotBeNull();
            salesOrder.job.internalId.Should().Be("789");
            salesOrder.job.name.Should().Be("PROJECT-001");

            // Статус
            salesOrder.status.Should().Be("A");
            salesOrder.orderStatus.Should().Be(SalesOrderOrderStatus._pendingApproval);
            salesOrder.orderStatusSpecified.Should().BeTrue();

            // Контактная информация
            salesOrder.memo.Should().Be("Это тестовый заказ из mock-объекта.");
            salesOrder.email.Should().Be("test@example.com");
            salesOrder.fax.Should().Be("+7 (495) 123-45-67");

            // Адреса
            salesOrder.billingAddress.Should().NotBeNull();
            salesOrder.billingAddress.addr1.Should().Be("ул. Ленина, д. 1");
            salesOrder.billingAddress.addr2.Should().Be("офис 101");
            salesOrder.billingAddress.city.Should().Be("Москва");
            salesOrder.billingAddress.state.Should().Be("Москва");
            salesOrder.billingAddress.zip.Should().Be("123456");
            salesOrder.billingAddress.country.Should().Be(Country._russianFederation);
            salesOrder.billingAddress.countrySpecified.Should().BeTrue();
            salesOrder.billingAddress.attention.Should().Be("Иванов И.И.");

            salesOrder.shippingAddress.Should().NotBeNull();
            salesOrder.shippingAddress.addr1.Should().Be("ул. Тверская, д. 5");
            salesOrder.shippingAddress.city.Should().Be("Москва");
            salesOrder.shippingAddress.zip.Should().Be("123789");
            salesOrder.shippingAddress.country.Should().Be(Country._russianFederation);
            salesOrder.shippingAddress.countrySpecified.Should().BeTrue();

            salesOrder.shipIsResidential.Should().BeFalse();
            salesOrder.shipIsResidentialSpecified.Should().BeTrue();

            // Доставка
            salesOrder.shipMethod.Should().NotBeNull();
            salesOrder.shipMethod.internalId.Should().Be("123");
            salesOrder.shipMethod.name.Should().Be("Курьерская доставка");
            salesOrder.fob.Should().Be("Москва");

            // Платежная информация
            salesOrder.paymentMethod.Should().NotBeNull();
            salesOrder.paymentMethod.internalId.Should().Be("1");
            salesOrder.paymentMethod.name.Should().Be("Банковская карта");
            salesOrder.ccNumber.Should().Be("411111XXXXXX1111");
            salesOrder.ccName.Should().Be("IVANOV IVAN");
            salesOrder.ccExpireDateSpecified.Should().BeTrue();
            salesOrder.ccExpireDate.Should().Be(new DateTime(2025, 12, 1));
            salesOrder.ccApproved.Should().BeTrue();
            salesOrder.ccApprovedSpecified.Should().BeTrue();
            salesOrder.authCode.Should().Be("AUTH123456");

            // Скидки
            salesOrder.discountItem.Should().NotBeNull();
            salesOrder.discountItem.internalId.Should().Be("333");
            salesOrder.discountItem.name.Should().Be("Скидка 10%");
            salesOrder.discountRate.Should().Be("10");

            // Поля для печати и отправки
            salesOrder.toBePrinted.Should().BeTrue();
            salesOrder.toBePrintedSpecified.Should().BeTrue();
            salesOrder.toBeEmailed.Should().BeFalse();
            salesOrder.toBeEmailedSpecified.Should().BeTrue();

            // Дополнительные поля
            salesOrder.otherRefNum.Should().Be("REF-001");
            salesOrder.source.Should().Be("WebStore");

            // Список товаров
            salesOrder.itemList.Should().NotBeNull();
            salesOrder.itemList.replaceAll.Should().BeTrue();
            salesOrder.itemList.item.Should().HaveCount(2);

            // Первый товар
            var firstItem = salesOrder.itemList.item[0];
            firstItem.item.Should().NotBeNull();
            firstItem.item.internalId.Should().Be("111");
            firstItem.item.name.Should().Be("Товар 1");
            firstItem.quantity.Should().Be(2);
            firstItem.quantitySpecified.Should().BeTrue();
            firstItem.amount.Should().Be(500.00);
            firstItem.amountSpecified.Should().BeTrue();
            firstItem.description.Should().Be("Описание товара 1");
            firstItem.rate.Should().Be("250.00");
            firstItem.line.Should().Be(1);
            firstItem.lineSpecified.Should().BeTrue();

            // Второй товар
            var secondItem = salesOrder.itemList.item[1];
            secondItem.item.Should().NotBeNull();
            secondItem.item.internalId.Should().Be("222");
            secondItem.item.name.Should().Be("Товар 2");
            secondItem.quantity.Should().Be(1);
            secondItem.quantitySpecified.Should().BeTrue();
            secondItem.amount.Should().Be(750.00);
            secondItem.amountSpecified.Should().BeTrue();
            secondItem.description.Should().Be("Описание товара 2");
            secondItem.rate.Should().Be("750.00");
            secondItem.line.Should().Be(2);
            secondItem.lineSpecified.Should().BeTrue();

            // Команда продаж
            salesOrder.salesTeamList.Should().NotBeNull();
            salesOrder.salesTeamList.replaceAll.Should().BeTrue();
            salesOrder.salesTeamList.salesTeam.Should().HaveCount(1);

            var salesTeam = salesOrder.salesTeamList.salesTeam[0];
            salesTeam.employee.Should().NotBeNull();
            salesTeam.employee.internalId.Should().Be("777");
            salesTeam.employee.name.Should().Be("Иванов Иван");
            salesTeam.salesRole.Should().NotBeNull();
            salesTeam.salesRole.internalId.Should().Be("1");
            salesTeam.salesRole.name.Should().Be("Менеджер");
            salesTeam.contribution.Should().Be(100);
            salesTeam.contributionSpecified.Should().BeTrue();
            salesTeam.isPrimary.Should().BeTrue();
            salesTeam.isPrimarySpecified.Should().BeTrue();

            // Партнеры
            salesOrder.partnersList.Should().NotBeNull();
            salesOrder.partnersList.replaceAll.Should().BeTrue();
            salesOrder.partnersList.partners.Should().HaveCount(1);

            var partner = salesOrder.partnersList.partners[0];
            partner.partner.Should().NotBeNull();
            partner.partner.internalId.Should().Be("888");
            partner.partner.name.Should().Be("Партнер ООО");
            partner.partnerRole.Should().NotBeNull();
            partner.partnerRole.internalId.Should().Be("2");
            partner.partnerRole.name.Should().Be("Посредник");
            partner.contribution.Should().Be(50);
            partner.contributionSpecified.Should().BeTrue();

            // Кастомные поля
            salesOrder.customFieldList.Should().HaveCount(2);

            // Первое кастомное поле (String)
            var stringField = salesOrder.customFieldList[0] as StringCustomFieldRef;
            stringField.Should().NotBeNull();
            stringField.scriptId.Should().Be("custbody_my_text_field");
            stringField.value.Should().Be("Мое кастомное значение");

            // Второе кастомное поле (Double)
            var doubleField = salesOrder.customFieldList[1] as DoubleCustomFieldRef;
            doubleField.Should().NotBeNull();
            doubleField.internalId.Should().Be("123");
            doubleField.value.Should().Be(999.99);

            await DisposeAsync();
        }

        [Fact]
        public async Task GetSalesOrder_WithExistentId_ReturnsOrderFromRealServer()
        {
            // Arrange
            string existingOrderId = "2222222";
            var recordRef = new RecordRef
            {
                type = RecordType.salesOrder,
                typeSpecified = true,
                internalId = existingOrderId
            };
            // Act
            var response = await _client.getAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                recordRef
            );

            // Assert
            response.Should().NotBeNull();
            response.readResponse.Should().NotBeNull();
            response.readResponse.status.isSuccess.Should().BeFalse();
            response.readResponse.status.isSuccessSpecified.Should().BeTrue();
            response.readResponse.record.Should().BeNull();

            response.readResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            response.readResponse.status.statusDetail.Should().HaveCount(1);

            var errorDetail = response.readResponse.status.statusDetail[0];
            errorDetail.type.Should().Be(StatusDetailType.ERROR);
            errorDetail.message.Should().Be($"Order with id {existingOrderId} not found"); // Или любое другое ожидаемое сообщение

            await DisposeAsync();
        }

        [Fact]
        public async Task GetSalesOrder_WithExistentType_ReturnsOrderFromRealServer()
        {
            // Arrange
            string existingOrderId = "2222222";
            var recordRef = new RecordRef
            {
                type = RecordType.state,
                typeSpecified = true,
                internalId = existingOrderId
            };
            // Act
            var response = await _client.getAsync(
                _tokenPassport,
                _applicationInfo,
                _partnerInfo,
                _preferences,
                recordRef
            );

            // Assert
            response.Should().NotBeNull();
            response.readResponse.Should().NotBeNull();
            response.readResponse.status.isSuccess.Should().BeFalse();
            response.readResponse.status.isSuccessSpecified.Should().BeTrue();
            response.readResponse.record.Should().BeNull();

            response.readResponse.status.statusDetail.Should().NotBeNullOrEmpty();
            response.readResponse.status.statusDetail.Should().HaveCount(1);

            var errorDetail = response.readResponse.status.statusDetail[0];
            errorDetail.type.Should().Be(StatusDetailType.ERROR);
            errorDetail.message.Should().Be($"Unsupported recordRef type: {recordRef.type}");

            await DisposeAsync();
        }
    }
}
