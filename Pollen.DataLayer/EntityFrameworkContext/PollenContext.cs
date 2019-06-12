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
                        .HasMany(e => e.Families)//метод HasMany() устанавливает множественную связь между объектом Form и объектами Families
                        .WithRequired(e => e.Form)//метод WithRequired() требует обязательной установки свойства Form у класса Family
                        .HasForeignKey(e => e.ID_Form)//метод HasForeignKey() переопределяет название столбца и внешнего ключа на ID_Form
            //свойство ID_Form имеет тип int и поэтому при генерации таблицы будет действовать правило ON DELETE CASCADE
                        .WillCascadeOnDelete(false);//метод WillCascadeOnDelete(false) отключает каскадное удаление

            modelBuilder.Entity<Genus>()
                        .HasMany(e => e.PlantTypes)//метод HasMany() устанавливает множественную связь между объектом Genus и объектами PlantTypes
                        .WithRequired(e => e.Genus)//метод WithRequired() требует обязательной установки свойства Genus у класса PlantType
                        .HasForeignKey(e => e.ID_Genus)//метод HasForeignKey() переопределяет название столбца и внешнего ключа на ID_Genus
            //свойство ID_Genus имеет тип int и поэтому при генерации таблицы будет действовать правило ON DELETE CASCADE
                        .WillCascadeOnDelete(true);//метод WillCascadeOnDelete(false) отключает каскадное удаление

            modelBuilder.Entity<EquatorialGrainShape>()
                        .HasMany(e => e.PlantTypes)//метод HasMany устанавливает множественную связь между объектом EquatorialGrainShape и  объектами PlantTypes
                        .WithMany(e => e.EquatorialGrainShapes)//метод WithMany устанавливает обратную множественную связь между объектом PlantType и объектами EquatorialGrainShapes
            //нас не устраивает автоматически генерируемое название промежуточной таблицы и её столбцов в БД, и мы их переопределяем методом Map
                        .Map(m => m.ToTable("EquatorialPositions")
                        .MapLeftKey("ID_EquatorialGrainShape")
                        .MapRightKey("ID_PlantType"));

            modelBuilder.Entity<PolarGrainShape>()
                        .HasMany(e => e.PlantTypes)//метод HasMany устанавливает множественную связь между объектом PolarGrainShape и  объектами PlantTypes
                        .WithMany(e => e.PolarGrainShapes)//метод WithMany устанавливает обратную множественную связь между объектом PlantType и объектами PolarGrainShapes
            //нас не устраивает автоматически генерируемое название промежуточной таблицы и её столбцов в БД, и мы их переопределяем методом Map
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
                .HasMany(e => e.PolarImages) //метод HasMany устанавливает множественную связь между объектом PlantType и объектами PolarImages
                .WithMany(e => e.PlantTypes) //метод WithMany устанавливает обратную множественную связь между объектом PolarImage и объектами PlantTypes
            //нас не устраивает автоматически генерируемое название промежуточной таблицы и её столбцов в БД, и мы их переопределяем методом Map
                .Map(m => m.ToTable("PolarImages_PlantTypes")
                .MapLeftKey("ID_PlantType")
                .MapRightKey("ID_PolarImage"));

            modelBuilder.Entity<EquatorialImage>()
                .HasMany(e => e.PlantTypes) //метод HasMany устанавливает множественную связь между объектом PlantType и объектами EquatorialImages
                .WithMany(e => e.EquatorialImages) // метод WithMany устанавливает обратную множественную связь между объектом VEquatorialImage и объектами PlantTypes
            //нас не устраивает автоматически генерируемое название промежуточной таблицы и её столбцов в БД, и мы их переопределяем методом Map
                .Map(m => m.ToTable("EquatorialImages_PlantTypes")
                .MapLeftKey("ID_PlantType")
                .MapRightKey("ID_EquatorialImage"));

            modelBuilder.Entity<AbnormalImage>()
                .HasMany(e => e.PlantTypes) //метод HasMany устанавливает множественную связь между объектом PlantType и объектами AbnormalImages
                .WithMany(e => e.AbnormalImages) //метод WithMany устанавливает обратную множественную связь между объектом AbnormalImage и объектами PlantTypes
            //нас не устраивает автоматически генерируемое название промежуточной таблицы и её столбцов в БД, и мы их переопределяем методом Map
                .Map(m => m.ToTable("AbnormalImages_PlantTypes")
                .MapLeftKey("ID_PlantType")
                .MapRightKey("ID_AbnormalImage"));


            base.OnModelCreating(modelBuilder);
        }
    }
}
