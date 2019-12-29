using System.Data.Entity;
using Pollen.DataLayer.Entities;

namespace Pollen.DataLayer.EntityFrameworkContext
{
    public class PollenContext : DbContext
    {
        public PollenContext(string name) : base(name /* выше будет передаваться значенине ="Context"*/)
        {
            string str = name;
        }
        
        public DbSet<Form> Forms { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Genus> Genera { get; set; }
        public DbSet<EquatorialGrainShape> EquatorialGrainShapes { get; set; }
        public DbSet<PolarGrainShape> PolarGrainShapes { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<AbnormalImage> AbnormalImages { get; set; }
        public DbSet<EquatorialImage> EquatorialImages { get; set; }
        public DbSet<PolarImage> PolarImages { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                        .HasMany(e => e.Genera)//метод HasMany() устанавливает множественную связь между объектом Family и объектами Genera
                        .WithRequired(e => e.Family)//метод WithRequired() требует обязательной установки свойства Family у класса Genus
                        .HasForeignKey(e => e.ID_Family)//метод HasForeignKey() переопределяет название столбца и внешнего ключа на ID_Family
            //свойство ID_Family имеет тип int и поэтому при генерации таблицы будет действовать правило ON DELETE CASCADE
                        .WillCascadeOnDelete(true);//метод WillCascadeOnDelete(false) включает каскадное удаление

            modelBuilder.Entity<Form>()
                        .HasMany(e => e.Families)
                        .WithRequired(e => e.Form)
                        .HasForeignKey(e => e.ID_Form)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genus>()
                        .HasMany(e => e.PlantTypes)
                        .WithRequired(e => e.Genus)
                        .HasForeignKey(e => e.ID_Genus)
                        .WillCascadeOnDelete(true);

            modelBuilder.Entity<EquatorialGrainShape>()
                        .HasMany(e => e.PlantTypes)
                        .WithMany(e => e.EquatorialGrainShapes)
                        .Map(m => m.ToTable("EquatorialPositions")
                        .MapLeftKey("ID_EquatorialGrainShape")
                        .MapRightKey("ID_PlantType"));

            modelBuilder.Entity<PolarGrainShape>()
                        .HasMany(e => e.PlantTypes)
                        .WithMany(e => e.PolarGrainShapes)
                        .Map(m => m.ToTable("PolarPositions")
                        .MapLeftKey("ID_PolarGrainShape")
                        .MapRightKey("ID_PlantType"));

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.PollenPolarMinSize)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.PollenPolarMaxSize)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.PollenEquatorialMinSize)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.PollenEquatorialMaxSize)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.ExinePolarMinThickness)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.ExinePolarMaxThickness)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.ExineEquatorialMinThickness)
                        .HasPrecision(9, 2);

            //настройка чисел decimal
            modelBuilder.Entity<PlantType>()
                        .Property(e => e.ExineEquatorialMaxThickness)
                        .HasPrecision(9, 2);

         


            modelBuilder.Entity<PlantType>()
                .HasMany(e => e.PolarImages)//метод HasMany() устанавливает множественную связь между объектом PlantType и объектами PolarImages
                .WithRequired(e => e.PlantType)//метод WithRequired() требует обязательной установки свойства PlantType у класса PolarImages
                .HasForeignKey(e => e.ID_PlantType)//метод HasForeignKey() переопределяет название столбца и внешнего ключа на ID_PlantType
                //свойство ID_PlantType имеет тип int и поэтому при генерации таблицы будет действовать правило ON DELETE CASCADE
                .WillCascadeOnDelete(true);//метод WillCascadeOnDelete(false) отключает каскадное удаление

            modelBuilder.Entity<PlantType>()
                .HasMany(e => e.EquatorialImages)
                .WithRequired(e => e.PlantType)
                .HasForeignKey(e => e.ID_PlantType)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PlantType>()
                .HasMany(e => e.AbnormalImages)
                .WithRequired(e => e.PlantType)
                .HasForeignKey(e => e.ID_PlantType)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
