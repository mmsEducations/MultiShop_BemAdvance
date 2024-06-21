using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MultiShop.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories"); // Tablo adını belirtme

            builder.HasKey(c => c.CategoryId); // Primary key olarak CategoryId kullanma

            // Diğer özelliklerin konfigürasyonu
            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Image)
                .HasMaxLength(int.MaxValue); // max nvarchar

            builder.Property(c => c.Order)
                .IsRequired(false);

            builder.Property(c => c.IsActive)
                .IsRequired(false);

            builder.Property(c => c.CrationDate)
                .IsRequired();

            // ParentCategoryId için ilişkiyi yapılandırma
            //builder.HasOne(c => c.ParentCategory)
            //    .WithMany(c => c.ChildCategories) // Bir kategoriye birden fazla alt kategori olabilir
            //    .HasForeignKey(c => c.ParentCategoryId)
            //    .IsRequired(false); // ParentCategoryId null olabilir

            // Ek olarak, varsa ek isteğe bağlı ilişkiler ve özellikler buraya eklenmeli

            // Indeksleme, kısıtlamalar ve diğer veritabanı ayarları burada yapılandırılabilir
            builder.HasIndex(c => c.CategoryName); // Örnek: CategoryName için indeks

            // Ekstra veritabanı ayarları ve optimizasyonlar burada yapılabilir
            //builder.Property(c => c.CategoryId)
            //    .UseIdentityColumn(); // Identity (auto increment) özelliğini kullanarak CategoryId'yi yapılandırma
        }
    }
}
