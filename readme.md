## .net API Example App 




#### Gereklilikler
    (DB Arayüz Yönetimi için) SQL Server Management 

#### Proje Notları
    1) API 'ı çalıştırmak için /api dizininde 

```
dotnet watch
```

    2) Entity Framework'ün yeni projeye dahil edilmesi için gerekli paketlerin yüklenmesi:
        - Microsoft.EntityFrameworkCore 8.0.8
        - Microsoft.EntityFrameworkCore.Design 8.0.8
        - Microsoft.EntityFrameworkCore.Sqlite.Core 8.0.8
        - Microsoft.EntityFrameworkCore.SqlServer 8.0.8
        - Microsoft.EntityFrameworkCore.Tools 8.0.8
        - Microsoft.AspNetCore.Mvc.NewtonsoftJson 8.0.8
        - Newtonsoft.Json 13.0.3
        - Microsoft.AspNetCore.Identity.EntityFrameworkCore 8.0.8
        - Microsoft.Extensions.Identity.Core 8.0.8
        - Microsoft.AspNetCore.Authentication.JwtBearer 8.0.8

    2.1) api/appsettings.json "DefaultConnection" değeri veri kaynağınız ile güncellenmeli 

    2.2) Modellerin intialize işlemi/migration attach
    
```
dotnet ef migrations add InitialMigration
```
    2.3) Modellerin güncellenmesi
```
dotnet ef database update
```
Identity migrationunu eklenmesi
```
dotnet ef migrations add Identity
dotnet ef database update


```

SeedRole migrationunu eklenmesi
```
dotnet ef migrations add SeedRole
dotnet ef database update
```