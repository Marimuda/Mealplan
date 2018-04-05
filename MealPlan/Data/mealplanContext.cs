using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MealPlan.Models
{
    public partial class MealplanContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<ActivityLevels> ActivityLevel { get; set; }
        public virtual DbSet<BioData> BioData { get; set; }
        public virtual DbSet<CourseRecipeChoices> CourseRecipeChoices { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Memberships> Memberships { get; set; }
        public virtual DbSet<MenuCourse> MenuCourse { get; set; }
        public virtual DbSet<MenuCourses> MenuCourses { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<RecipeRatning> RecipeRatning { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<RecipeStepsIngredients> RecipeStepsIngredients { get; set; }
        public virtual DbSet<SuggestedMenus> SuggestedMenus { get; set; }

        public MealplanContext(DbContextOptions<MealplanContext> options)
    : base(options)
        {
        }


        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=Admin;password=1234;database=mealplan");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId).HasColumnType("int(10)");

                entity.Property(e => e.DisplayedName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("'Anonymous'");

                entity.Property(e => e.Role).HasColumnType("tinyint(1)");
            });

            modelBuilder.Entity<ActivityLevels>(entity =>
            {
                entity.HasKey(e => e.BioId);

                entity.ToTable("activity_level");

                entity.HasIndex(e => e.BioId)
                    .HasName("FKactivity_l263631");

                entity.Property(e => e.BioId).HasColumnType("int(10)");

                entity.Property(e => e.ActivityDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ActivityLevel)
                    .HasColumnName("ActivityLevel")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.BioData)
                    .WithOne(p => p.ActivityLevel)
                    .HasForeignKey<ActivityLevels>(d => d.BioId)
                    .HasConstraintName("FKactivity_l263631");
            });

            modelBuilder.Entity<BioData>(entity =>
            {
                entity.HasKey(e => e.BioId);

                entity.ToTable("bio_data");

                entity.HasIndex(e => e.PersonId)
                    .HasName("FKBio_data523729");

                entity.Property(e => e.BioId).HasColumnType("int(10)");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Height).HasColumnType("tinyint(3)");

                entity.Property(e => e.PersonId).HasColumnType("int(10)");

                entity.Property(e => e.Weight).HasColumnType("tinyint(3)");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BioData)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FKBio_data523729");
            });

            modelBuilder.Entity<CourseRecipeChoices>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.RecipesId });

                entity.ToTable("course_recipe_choices");

                entity.HasIndex(e => e.RecipesId)
                    .HasName("FKCourse_Rec894165");

                entity.HasIndex(e => new { e.CourseId, e.MenuId })
                    .HasName("FKCourse_Rec371103");

                entity.Property(e => e.CourseId).HasColumnType("smallint(5)");

                entity.Property(e => e.RecipesId).HasColumnType("int(10)");

                entity.Property(e => e.MenuId).HasColumnType("int(10)");

                entity.HasOne(d => d.Recipes)
                    .WithMany(p => p.CourseRecipeChoices)
                    .HasForeignKey(d => d.RecipesId)
                    .HasConstraintName("FKCourse_Rec894165");

                entity.HasOne(d => d.MenuCourse)
                    .WithMany(p => p.CourseRecipeChoices)
                    .HasForeignKey(d => new { d.CourseId, d.MenuId })
                    .HasConstraintName("FKCourse_Rec371103");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.HasKey(e => new { e.CourseIdr, e.MenuId });

                entity.ToTable("course_type");

                entity.HasIndex(e => new { e.CourseIdr, e.MenuId })
                    .HasName("FKCourse_typ472992");

                entity.Property(e => e.CourseIdr).HasColumnType("smallint(5)");

                entity.Property(e => e.MenuId).HasColumnType("int(10)");

                entity.Property(e => e.CourseType1)
                    .IsRequired()
                    .HasColumnName("CourseType")
                    .HasMaxLength(50);

                entity.HasOne(d => d.MenuCourse)
                    .WithOne(p => p.CourseType)
                    .HasForeignKey<CourseType>(d => new { d.CourseIdr, d.MenuId })
                    .HasConstraintName("FKCourse_typ472992");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => e.IngredientId);

                entity.ToTable("ingredients");

                entity.Property(e => e.IngredientId).HasColumnType("smallint(5)");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("logins");

                entity.HasIndex(e => e.PasswordHash)
                    .HasName("PasswordHash")
                    .IsUnique();

                entity.HasIndex(e => e.PersonId)
                    .HasName("FKLogins640643");

                entity.HasIndex(e => e.Username)
                    .HasName("Username")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnType("int(10)");

                entity.Property(e => e.IsActivated).HasColumnType("bit(1)");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("char(64)");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.PersonId).HasColumnType("int(10)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FKLogins640643");
            });

            modelBuilder.Entity<Memberships>(entity =>
            {
                entity.HasKey(e => e.MembershipId);

                entity.ToTable("memberships");

                entity.HasIndex(e => e.AccountId)
                    .HasName("FKMembership716389");

                entity.HasIndex(e => e.LoginId)
                    .HasName("FKMembership459979");

                entity.Property(e => e.MembershipId).HasColumnType("int(10)");

                entity.Property(e => e.AccountId).HasColumnType("int(10)");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.EmailAdress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FailedAttempts)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LoginId).HasColumnType("int(10)");

                entity.Property(e => e.PasswordAnswer).HasMaxLength(255);

                entity.Property(e => e.PasswordQuestion).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FKMembership716389");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Memberships)
                    .HasForeignKey(d => d.LoginId)
                    .HasConstraintName("FKMembership459979");
            });

            modelBuilder.Entity<MenuCourse>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.MenuId });

                entity.ToTable("menu_course");

                entity.HasIndex(e => e.MenuId)
                    .HasName("FKMenu_Cours370256");

                entity.Property(e => e.CourseId).HasColumnType("smallint(5)");

                entity.Property(e => e.MenuId).HasColumnType("int(10)");

                entity.Property(e => e.CimageUrl)
                    .HasColumnName("CImageUrl")
                    .HasMaxLength(255);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuCourse)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMenu_Cours370256");
            });

            modelBuilder.Entity<MenuCourses>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.CourseNumber });

                entity.ToTable("menu_courses");

                entity.HasIndex(e => e.MenuId)
                    .HasName("menu_id")
                    .IsUnique();

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CourseNumber)
                    .HasColumnName("course_number")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasColumnName("course_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("persons");

                entity.Property(e => e.PersonId).HasColumnType("int(10)");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RecipeRatning>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.ToTable("recipe_ratning");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("FKRecipe_Rat281140");

                entity.Property(e => e.RecipeId).HasColumnType("int(10)");

                entity.Property(e => e.RecipeRating).HasColumnType("smallint(5)");

                entity.HasOne(d => d.Recipe)
                    .WithOne(p => p.RecipeRatning)
                    .HasForeignKey<RecipeRatning>(d => d.RecipeId)
                    .HasConstraintName("FKRecipe_Rat281140");
            });

            modelBuilder.Entity<Recipes>(entity =>
            {
                entity.HasKey(e => e.RecipeId);

                entity.ToTable("recipes");

                entity.HasIndex(e => e.AccountId)
                    .HasName("FKRecipes688032");

                entity.Property(e => e.RecipeId).HasColumnType("int(10)");

                entity.Property(e => e.AccountId).HasColumnType("int(10)");

                entity.Property(e => e.ReCreationDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RecipeDescription)
                    .IsRequired()
                    .HasColumnType("blob");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FKRecipes688032");
            });

            modelBuilder.Entity<RecipeStepsIngredients>(entity =>
            {
                entity.HasKey(e => e.StepId);

                entity.ToTable("recipe_steps_ingredients");

                entity.HasIndex(e => e.IngredientId)
                    .HasName("FKRecipe_Ste374390");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("FKRecipe_Ste135474");

                entity.Property(e => e.StepId).HasColumnType("tinyint(2)");

                entity.Property(e => e.Amount).HasColumnType("smallint(5)");

                entity.Property(e => e.IngredientId).HasColumnType("smallint(5)");

                entity.Property(e => e.RecipeId).HasColumnType("int(10)");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeStepsIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRecipe_Ste374390");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeStepsIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FKRecipe_Ste135474");
            });

            modelBuilder.Entity<SuggestedMenus>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("suggested_menus");

                entity.Property(e => e.MenuId).HasColumnType("int(10)");

                entity.Property(e => e.MenuDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
