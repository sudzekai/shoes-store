# Магазин обуви

В решении три проекта. **StoreWeb** показывает каталог и заказы, **Presentation** предоставляет HTTP API, **StoreData** содержит DTO, сервисы и модели EF Core. Контроллеры передают работу сервисам, а сервисы обращаются к таблицам через LINQ и `DbSet<T>`.

## База данных

Понадобятся Docker и SDK .NET 10. Команды ниже рассчитаны на PowerShell и выполняются из корня репозитория. Для первого запуска задайте свой локальный пароль в переменной `MSSQL_SA_PASSWORD`.

```powershell
docker run -d --name shoes-store-sql --restart unless-stopped -p 127.0.0.1:1433:1433 -e ACCEPT_EULA=Y -e MSSQL_PID=Express -e MSSQL_SA_PASSWORD -v shoes-store-sql-data:/var/opt/mssql mcr.microsoft.com/mssql/server:2022-latest
```

Когда SQL Server будет готов к подключениям, один раз выполните скрипт для новой базы.

```powershell
docker cp DB/sqlserver.sql shoes-store-sql:/tmp/shoes-store.sql
docker exec shoes-store-sql sh -c 'SQLCMDPASSWORD="$MSSQL_SA_PASSWORD" /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -C -b -f 65001 -i /tmp/shoes-store.sql'
```

[SQL Server: схема и данные](DB/sqlserver.sql) · [CSV и XLS по таблицам](DB/exports) · [ER-диаграмма](DB/erd.png)

## Запуск

```powershell
$storeConnection = "Server=127.0.0.1,1433;Database=ShoesStoreDb;User Id=sa;Password=$env:MSSQL_SA_PASSWORD;Encrypt=True;TrustServerCertificate=True"
$storeJwtKey = [Convert]::ToBase64String([Security.Cryptography.RandomNumberGenerator]::GetBytes(48))
dotnet user-secrets set 'ConnectionStrings:ShoesStore' $storeConnection --project ShoesStoreAPI/StoreWeb
dotnet user-secrets set 'ConnectionStrings:ShoesStore' $storeConnection --project ShoesStoreAPI/Presentation
dotnet user-secrets set 'Jwt:Key' $storeJwtKey --project ShoesStoreAPI/Presentation
dotnet build ShoesStoreAPI/ShoesStoreAPI.slnx
```

Запустите проекты в отдельных окнах терминала.

```powershell
dotnet run --project ShoesStoreAPI/StoreWeb
dotnet run --project ShoesStoreAPI/Presentation
```

- [Сайт](http://127.0.0.1:5080)
- [Список товаров API](http://127.0.0.1:5081/api/products)

Для входа используйте учебные учётные записи из [выгрузки пользователей](DB/exports/users.csv). Клиенты могут создавать и просматривать свои заказы. Менеджеры и администраторы видят все заказы. Итог заказа рассчитывается по текущим ценам товаров со скидкой, поскольку исходная схема не хранит цену на дату заказа.

## API

| Метод и путь | Доступ |
| --- | --- |
| `POST /api/auth/login` | Вход по полям `login` и `password`, ответ содержит `accessToken` |
| `GET /api/products`, `GET /api/products/{article}`, `GET /api/products/options` | Все |
| `POST /api/products`, `PUT /api/products/{article}`, `DELETE /api/products/{article}` | Менеджер и администратор |
| `GET /api/orders?login=...` | Клиент для своего логина. Менеджер и администратор для любого логина или всех заказов |
| `GET /api/orders/statuses`, `PATCH /api/orders/{id}` | Менеджер и администратор. При изменении передаются `statusId` и `deliveryDate` |

В защищённых запросах передавайте заголовок `Authorization: Bearer <accessToken>`.

## Модели EF Core

```powershell
dotnet tool install --global dotnet-ef --version 10.0.15
dotnet ef dbcontext scaffold $storeConnection Microsoft.EntityFrameworkCore.SqlServer --project ShoesStoreAPI/StoreData --context ShoesStoreContext --output-dir Models --context-dir Data --no-onconfiguring --force
```
