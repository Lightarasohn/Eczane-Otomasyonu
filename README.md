
# Eczane Fullstack Uygulama Kurulum ve Çalıştırma Rehberi

## 1) Veri Tabanı Kurulumu

- **Eczane** adında bir veritabanı oluşturun.
- API içindeki modellerde belirtilen tüm tablolar ve ara tabloları veritabanına tanımlayın.
- `appsettings.json` dosyasına aşağıdaki bağlantı dizesini ekleyin:

```json
{
  "ConnectionStrings": {
    "EczaneConnection": "Server=<SERVER>;Database=Eczane;User Id=<KULLANICI>;Password=<PAROLA>;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

## 2) .NET Restore ve API Ayarları

- Aşağıdaki SDK ve Runtime sürümlerini indirip kurun:

  - [.NET 9.0.203 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-9.0.203-windows-x64-installer)
  - [.NET Runtime 9.0.4](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-9.0.4-windows-x64-installer)

- Terminal veya komut satırını açıp aşağıdaki komutları sırasıyla çalıştırın:

```bash
dotnet tool install --global dotnet-ef
# Bu komuttan sonra VSCode'u yeniden başlatın
cd EczaneAPI
dotnet restore
dotnet dbcontext scaffold "name=EczaneConnection" -t SATIS -t SATIS_ILAC -t ILAC -t RAPOR -t RAPOR_SATIS Microsoft.EntityFrameworkCore.SqlServer -f --no-pluralize
```

- `EczaneAPI/Models/EczaneContext.cs` dosyasındaki `DbSet` tanımlamalarını aşağıdaki şekilde değiştirin:

```csharp
public virtual DbSet<Ilac> Ilaclar { get; set; }
public virtual DbSet<Rapor> Raporlar { get; set; }
public virtual DbSet<RaporSatis> RaporSatislar { get; set; }
public virtual DbSet<Satis> Satislar { get; set; }
public virtual DbSet<SatisIlac> SatisIlacs { get; set; }
```

- `EczaneAPI` dizininde `Properties` adında bir klasör oluşturun. Ardından `EczaneAPI/Properties/launchsettings.json` dosyasını oluşturup aşağıdaki içeriği ekleyin:

```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5169",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7289;http://localhost:5169",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

- Artık API servisi çalıştırılmaya hazırdır. Terminalde `dotnet watch run` komutunu kullanarak API'yi başlatabilirsiniz.

## 3) Frontend Kurulumu ve Çalıştırma

- [Node.js](https://nodejs.org/tr/download) önceden yükleyin.
- Komut istemcisinde aşağıdaki komutlarla kurulumun başarılı olduğunu doğrulayın:

```bash
node -v
npm -v
```

- Terminalde aşağıdaki adımları uygulayın:

```bash
cd EczaneUI
npm install
npm install antd
npm run dev
```

- Bu aşamadan sonra uygulamanın tamamı sisteminizde çalışır ve geliştirilebilir durumdadır.
