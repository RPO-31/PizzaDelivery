# PizzaDelivery

PizzaDelivery - небольшое ASP.NET Core Razor Pages приложение для создания заказа на доставку пиццы. Решение разделено на три проекта: веб-приложение, доменную модель и слой доступа к данным.

## Структура проекта

```text
PizzaDelivery/
├── PizzaDelivery.slnx
├── PizzaDelivery/
│   ├── Pages/
│   │   ├── Index.cshtml
│   │   ├── Index.cshtml.cs
│   │   ├── NewOrder.cshtml
│   │   ├── NewOrder.cshtml.cs
│   │   ├── Privacy.cshtml
│   │   ├── Error.cshtml
│   │   └── Shared/
│   ├── Program.cs
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── wwwroot/
│   ├── appsettings.json
│   └── PizzaDelivery.csproj
├── PizzaDelivery.Domain/
│   ├── Models/
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   └── Pizza.cs
│   ├── Enums/
│   │   ├── EIngridient.cs
│   │   └── EOrderStatus.cs
│   └── PizzaDelivery.Domain.csproj
└── PizzaDelivery.DataAccess/
    ├── Interfaces/
    │   ├── ICustomerRepository.cs
    │   └── IPizzaRepository.cs
    ├── Repositorys/
    │   ├── CustomerRepository.cs
    │   └── PizzaRepository.cs
    └── PizzaDelivery.DataAccess.csproj
```

## Проекты

### PizzaDelivery

Веб-приложение на Razor Pages. Здесь лежат страницы, статические файлы, настройки и точка входа приложения.

- `Program.cs` настраивает Razor Pages и регистрирует репозитории в DI-контейнере.
- `Pages/Index.cshtml` содержит форму создания заказа.
- `Pages/Index.cshtml.cs` загружает клиентов и пиццы, принимает отправленную форму, собирает объект `Order`, кладет его в `TempData` и делает редирект на страницу нового заказа.
- `Pages/NewOrder.cshtml` выводит данные сформированного заказа.
- `Pages/NewOrder.cshtml.cs` читает сериализованный заказ из `TempData`.
- `wwwroot/` содержит статические файлы: CSS, JavaScript, Bootstrap, jQuery и библиотеки валидации.

### PizzaDelivery.Domain

Доменный проект с моделями и перечислениями приложения.

- `Customer` описывает клиента: `Id`, `Name`, `Address`.
- `Pizza` описывает пиццу: `Id`, `Name`, `Description`, `Ingridients`, `Price`.
- `Order` описывает заказ: `Id`, `Customer`, `OrderStatus`, выбранные `Pizzas`.
- `EOrderStatus` содержит статусы заказа: `Created`, `Cooking`, `Complete`.
- `EIngridient` содержит доступные ингредиенты для пицц.

### PizzaDelivery.DataAccess

Проект доступа к данным. Сейчас данные хранятся в памяти и возвращаются из простых репозиториев, база данных не используется.

- `ICustomerRepository` описывает контракт для получения клиентов.
- `IPizzaRepository` описывает контракт для получения пицц.
- `CustomerRepository` возвращает текущий список клиентов.
- `PizzaRepository` возвращает текущий список пицц.

## Текущий функционал

На данный момент приложение поддерживает простой сценарий создания заказа:

1. Главная страница загружает список клиентов и список пицц из репозиториев.
2. Пользователь выбирает одного клиента из выпадающего списка.
3. Пользователь выбирает одну или несколько пицц через чекбоксы.
4. Пользователь нажимает кнопку `Сформировать заказ`.
5. Метод `IndexModel.OnPost` собирает объект `Order` с выбранным клиентом, выбранными пиццами и статусом `Created`.
6. Заказ сериализуется и сохраняется в `TempData`.
7. Приложение перенаправляет пользователя на `/new-order`.
8. Страница `/new-order` выводит поля заказа, данные клиента и данные выбранных пицц.

В форме создания заказа есть базовая валидация:

- должен быть выбран клиент;
- должна быть выбрана хотя бы одна пицца.

## Запуск проекта

Собрать решение:

```bash
dotnet build PizzaDelivery.slnx
```

Запустить веб-приложение:

```bash
dotnet run --project PizzaDelivery/PizzaDelivery.csproj
```

По текущему development-профилю приложение запускается на:

```text
http://localhost:5055
```

## Примечания

- Проект использует `.NET 8`.
- Данные сейчас заданы прямо в in-memory репозиториях.
- Базы данных и постоянного хранения заказов пока нет.
- Заказ передается между страницами через `TempData`, поэтому страницу `/new-order` нужно открывать сразу после отправки формы.
