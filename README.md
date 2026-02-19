# NetSuite Local Mock Server

Мок-сервер для локального тестирования интеграции с NetSuite Web Services, эмулирующий поведение NetSuite API.

## Реализованные методы

### `getAsync`
- Получение SalesOrder по internalId = "12345"
- Возвращает полностью заполненный объект SalesOrder со всеми полями:
  - Основные идентификаторы (internalId, externalId, tranId)
  - Финансовые поля (total, subTotal, taxTotal, discountTotal)
  - Информация о клиенте, адресах, доставке
  - Список товаров, команда продаж, партнеры
  - Кастомные поля
- Для других ID возвращает ошибку "Order not found"
- Для других типов записей возвращает ошибку "Unsupported recordRef type"

### `addListAsync`
- Массовое добавление записей типа State
- Проверка на дубликаты по полю `shortname`:
  - Уникальные shortname → успешное добавление с генерацией случайного internalId
  - Дубликаты shortname → ошибка с указанием ID существующей записи
- Для других типов записей возвращает общую ошибку

### `updateAsync`
- Обновление записей типов: State, SalesOrder, Customer
- Для State:
  - internalId = "1" → успех
  - internalId = "999" → ошибка "Record does not exist"
  - internalId = "666" → ошибка "Insufficient permission"
  - Без internalId → ошибка "internalId is required"
- Для SalesOrder:
  - Валидация отрицательной суммы total
  - Успешное обновление для корректных данных
- Для Customer:
  - externalId = "CONFLICT" → ошибка конфликта версий
  - Успешное обновление для остальных случаев

### `searchAsync`
- Поиск по State (CustomRecordSearchBasic):
  - Фильтрация по internalId, fullName
  - Тестовые данные: 5 записей (Московская, Ленинградская области, California, Texas, Bavaria)
- Поиск по Customer (CustomerSearchBasic):
  - Фильтрация по internalId, externalId, companyName, email, phone, firstName, lastName, isPerson
  - Тестовые данные: 3 записи (ООО Ромашка, ИП Иванов, ООО Технологии)
- Для других типов поиска возвращает ошибку

## Тестовые сценарии

### GetRequestTest
- `GetSalesOrder_WithValidId_ReturnsOrderFromRealServer` - проверка полного заполнения SalesOrder
- `GetSalesOrder_WithExistentId_ReturnsOrderFromRealServer` - ошибка при несуществующем ID
- `GetSalesOrder_WithExistentType_ReturnsOrderFromRealServer` - ошибка при неподдерживаемом типе

### AddListRequestTest
- `AddListAsync_WithUniqueStates_ReturnsSuccessForAll` - успешное добавление уникальных записей
- `AddListAsync_WithDuplicateShortname_ReturnsOneSuccessOneDuplicate` - обработка дубликатов
- `AddListAsync_WithNonStateRecordType_ReturnsError` - ошибка при неверном типе записи

### UpdateAsyncRequestTest
- `UpdateAsync_WithState_ReturnsExpectedResult` - параметризованный тест для State (4 сценария)
- `UpdateAsync_WithSalesOrder_ReturnsExpectedResult` - параметризованный тест для SalesOrder (3 сценария)
- `UpdateAsync_WithCustomer_ReturnsExpectedResult` - параметризованный тест для Customer (3 сценария)
- `UpdateAsync_WithNullRecord_ReturnsError` - ошибка при null записи
- `UpdateAsync_WithUnsupportedRecordType_ReturnsError` - ошибка при неподдерживаемом типе

### SearchAsyncRequestTest
- `SearchAsync_WithCustomerSearch_ReturnsMatchingCustomers` - поиск клиентов по companyName
- `SearchAsync_WithStateSearch_ReturnsMatchingStates` - поиск регионов по fullName
- `SearchAsync_WithUnsupportedSearchType_ReturnsError` - ошибка при неподдерживаемом типе поиска

## Структура ответов

Все методы возвращают стандартные объекты NetSuite:
- `getResponse` с `readResponse` (Status + record)
- `addListResponse` с `writeResponseList` (общий Status + массив WriteResponse)
- `updateResponse` с `writeResponse` (Status + baseRef)
- `searchResponse` с `searchResult` (Status + recordList)

Статусы содержат `isSuccess` и при ошибках - массив `statusDetail` с типом и сообщением.
