# sporSalonu
Basit bir C# spor salonu otomasyonu.

## Özellikler
- Üye Ekle/Güncelle/Sil  
- Üye Listesi & İsimle Ara  
- Telefon, yaş ve ödeme validasyonları  
- Standart/Premium üye tipi desteği  

## Teknolojiler
- C# (.NET Framework) & Windows Forms  
- SQL Server LocalDB (System.Data.SqlClient)  
- OOP: Encapsulation, Inheritance, Abstraction  

<h3>📸 Login Ekranı</h3>

<p align="center">
  <img src="https://github.com/zerazra7/sporSalonu/blob/main/Resources/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-05-18%20150928.png?raw=true" alt="Ana Sayfa" width="600"/>
</p>
<h3>📸 Ana Sayfa Ekranı</h3>

<p align="center">
  <img src="https://github.com/zerazra7/sporSalonu/blob/main/Resources/Ekran%20görüntüsü%202025-05-18%20150942.png?raw=true" alt="Ana Sayfa" width="600"/>
</p>
## 🔧 Veritabanı Kurulumu

Projede kullanılan veritabanı dosyası (`sporDB.mdf`) SQL Server ile birlikte kullanılmaktadır. Aşağıdaki adımları takip ederek `.mdf` dosyasını SQL Server'a bağlayabilir (attach edebilir) ve projeyi sorunsuz çalıştırabilirsiniz.

### 📦 1. SQL Server Management Studio (SSMS) ile `sporDB.mdf` dosyasını attach et

1. SQL Server Management Studio (SSMS)’yi açın
2. Sol menüde `Databases` üzerine sağ tıklayın → **Attach…** seçeneğini tıklayın
3. Açılan pencerede `Add...` butonuna tıklayın
4. Proje klasöründe bulunan `sporDB.mdf` dosyasını seçin  
   (Örnek yol: `C:\Users\kullanici_adiniz\source\repos\proje_adi\sporDB.mdf`)
5. **Database Name** kısmına `sporDB` yazın (önemli!)
6. OK diyerek veritabanını bağlayın

