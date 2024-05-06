using Microsoft.EntityFrameworkCore;

namespace yemekAPI.Models
{
    public class YemekAPIContext : DbContext
    {
        public YemekAPIContext(DbContextOptions<YemekAPIContext> options) : base(options)
        {

        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Kullanıcı> Kullanıcıs { get; set; }
        public DbSet<Menüler> Menülers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestMenüsü> RestMenüsüs { get; set; }
        public DbSet<Sepet> Sepets { get; set; }
        public DbSet<SepetUrun> SepetUruns { get; set; }
        public DbSet<Siparisler> Siparislers { get; set; }
        public DbSet<Ürünler> Ürünlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>()
                .HasData(
                    new Adress() { AdresId = 1, EvAdresi = "Batıkent", IsAdresi = "ostim" },
                    new Adress() { AdresId = 2, EvAdresi = "Çankaya", IsAdresi = "yenimahalle" },
                    new Adress() { AdresId = 3, EvAdresi = "Ostim", IsAdresi = "osb" },
                    new Adress() { AdresId = 4, EvAdresi = "turgut Özal Mah", IsAdresi = "ivedik" },
                    new Adress() { AdresId = 5, EvAdresi = "Batımerkez", IsAdresi = "ostim" }
                );

            modelBuilder.Entity<Kategoriler>()
                .HasData(
                    new Kategoriler() { KategoriId = 2, KategoriTuru = "tatlılar" },
                    new Kategoriler() { KategoriId = 3, KategoriTuru = "içecekler" },
                    new Kategoriler() { KategoriId = 4, KategoriTuru = "pizza" },
                    new Kategoriler() { KategoriId = 5, KategoriTuru = "hamburger" },
                    new Kategoriler() { KategoriId = 6, KategoriTuru = "döner" }
                );

            modelBuilder.Entity<Kullanıcı>()
                .HasData(
                    new Kullanıcı() { UserId = 3, Ad = "oyku", Soyad = "yetgin", Email = "oykuyetgin@gmail.com", Tel = "05522166019", AdresId = 1 },
                    new Kullanıcı() { UserId = 4, Ad = "tugba", Soyad = "yetgin", Email = "tugbayetgin@gmail.com", Tel = "0123456789", AdresId = 2 },
                    new Kullanıcı() { UserId = 5, Ad = "ayse", Soyad = "yılmaz", Email = "ayseyilmaz@gmail.com", Tel = "0789456123", AdresId = 3 },
                    new Kullanıcı() { UserId = 6, Ad = "ali", Soyad = "solmaz", Email = "alisolmaz@gmail.com", Tel = "0741852963", AdresId = 4 },
                    new Kullanıcı() { UserId = 7, Ad = "fatma", Soyad = "fahir", Email = "fatmafahir@gmail.com", Tel = "0369258147", AdresId = 5 }
                );

            modelBuilder.Entity<Menüler>()
               .HasData(
                   new Menüler() { MenuId = 4, UrunId = 5 },
                   new Menüler() { MenuId = 5, UrunId = 6 },
                   new Menüler() { MenuId = 6, UrunId = 7 },
                   new Menüler() { MenuId = 7, UrunId = 8 },
                   new Menüler() { MenuId = 8, UrunId = 9 }
               );

            modelBuilder.Entity<Restaurant>()
               .HasData(
                   new Restaurant() { RestaurantId = 6, KategoriId = 2, Ad = "Lavilla", Adres = "Çankaya", Tel = "02564561278" },
                   new Restaurant() { RestaurantId = 7, KategoriId = 3, Ad = "Pastannecim", Adres = "Kızılay", Tel = "0789456123" },
                   new Restaurant() { RestaurantId = 8, KategoriId = 4, Ad = "Domino's Pizza", Adres = "Batıkent", Tel = "0456123789" },
                   new Restaurant() { RestaurantId = 9, KategoriId = 5, Ad = "Cajun Corner", Adres = "Ostim", Tel = "0789456123" },
                   new Restaurant() { RestaurantId = 10, KategoriId = 6, Ad = "Öncü Dürüm", Adres = "Turgut Özal", Tel = "012345678" }
               );

            modelBuilder.Entity<RestMenüsü>()
               .HasData(
                   new RestMenüsü() { RestaurantId = 6, MenuId = 4 },
                   new RestMenüsü() { RestaurantId = 7, MenuId = 5 },
                   new RestMenüsü() { RestaurantId = 8, MenuId = 6 },
                   new RestMenüsü() { RestaurantId = 9, MenuId = 7 },
                   new RestMenüsü() { RestaurantId = 10, MenuId = 8 }

               );

            modelBuilder.Entity<Sepet>()
               .HasData(
                   new Sepet() { SepetId = 7, UserId = 3, UrunAdet = 1, Tutar = 15 },
                   new Sepet() { SepetId = 8, UserId = 4, UrunAdet = 3, Tutar = 250 },
                   new Sepet() { SepetId = 9, UserId = 5, UrunAdet = 4, Tutar = 620 },
                   new Sepet() { SepetId = 10, UserId = 6, UrunAdet = 5, Tutar = 400 },
                   new Sepet() { SepetId = 11, UserId = 7, UrunAdet = 6, Tutar = 120 }
               );

            modelBuilder.Entity<SepetUrun>()
               .HasData(
                   new SepetUrun() { SepetId = 7, UrunId = 5 },
                   new SepetUrun() { SepetId = 8, UrunId = 6 },
                   new SepetUrun() { SepetId = 9, UrunId = 7 },
                   new SepetUrun() { SepetId = 10, UrunId = 8 },
                   new SepetUrun() { SepetId = 11, UrunId = 9 }
               );

            modelBuilder.Entity<Siparisler>()
               .HasData(
                   new Siparisler() { SiparisId = 8, UserId = 3, SiparisTarih = DateTime.Parse("2023-06-19"), SiparisAdet = 1, SiparisTutar = 25, RestaurantId = 6 },
                   new Siparisler() { SiparisId = 9, UserId = 4, SiparisTarih = DateTime.Parse("2023-06-20"), SiparisAdet = 3, SiparisTutar = 280, RestaurantId = 7 },
                   new Siparisler() { SiparisId = 10, UserId = 5, SiparisTarih = DateTime.Parse("2023-06-18"), SiparisAdet = 4, SiparisTutar = 200, RestaurantId = 8 },
                   new Siparisler() { SiparisId = 11, UserId = 6, SiparisTarih = DateTime.Parse("2023-05-16"), SiparisAdet = 2, SiparisTutar = 100, RestaurantId = 9 },
                   new Siparisler() { SiparisId = 12, UserId = 7, SiparisTarih = DateTime.Parse("2023-03-10"), SiparisAdet = 2, SiparisTutar = 189, RestaurantId = 10 }
               );

            modelBuilder.Entity<Ürünler>()
               .HasData(
                   new Ürünler() { UrunId = 5, Ad = "Coca Cola", Fiyat = 32 },
                   new Ürünler() { UrunId = 6, Ad = "Chicken Burger", Fiyat = 152 },
                   new Ürünler() { UrunId = 7, Ad = "Mozaik Kek", Fiyat = 89 },
                   new Ürünler() { UrunId = 8, Ad = "Waffle", Fiyat = 60 },
                   new Ürünler() { UrunId = 9, Ad = "Napolitan Pizza", Fiyat = 100 }
               );
        }
    }
}
