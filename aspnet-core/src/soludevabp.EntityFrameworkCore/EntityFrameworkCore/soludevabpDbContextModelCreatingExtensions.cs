using Microsoft.EntityFrameworkCore;
using soludevabp.Companies;
using soludevabp.Listings;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace soludevabp.EntityFrameworkCore
{
    public static class soludevabpDbContextModelCreatingExtensions
    {
        public static void Configuresoludevabp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(soludevabpConsts.DbTablePrefix + "YourEntities", soludevabpConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            builder.Entity<Company>(b =>
            {
                b.ToTable("Companies");
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });


            builder.Entity<Listing>(b =>
            {
                b.ToTable("Listings");

                b.ConfigureByConvention();

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(ListingConsts.MaxNameLength);

                b.HasOne<Company>().WithMany().HasForeignKey(x => x.CompanyId).IsRequired();

                b.HasIndex(x => x.Name);
            });
        }
    }
}