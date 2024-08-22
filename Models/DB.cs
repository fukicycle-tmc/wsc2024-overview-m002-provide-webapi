using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace provide_webapi.Models;

public partial class DB : DbContext
{
    public DB()
    {
    }

    public DB(DbContextOptions<DB> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartProduct> CartProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CookingPlan> CookingPlans { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngredientDeliveryTracking> IngredientDeliveryTrackings { get; set; }

    public virtual DbSet<IngredientOrder> IngredientOrders { get; set; }

    public virtual DbSet<IngredientOrderDelivery> IngredientOrderDeliveries { get; set; }

    public virtual DbSet<IngredientOrderDetail> IngredientOrderDetails { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<OneTimePassword> OneTimePasswords { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeKeyPoint> RecipeKeyPoints { get; set; }

    public virtual DbSet<RecipeType> RecipeTypes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewDetail> ReviewDetails { get; set; }

    public virtual DbSet<ReviewItem> ReviewItems { get; set; }

    public virtual DbSet<ReviewItemType> ReviewItemTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shifting> Shiftings { get; set; }

    public virtual DbSet<ShiftingType> ShiftingTypes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Stofe> Stoves { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreEmployee> StoreEmployees { get; set; }

    public virtual DbSet<StoveAllocation> StoveAllocations { get; set; }

    public virtual DbSet<StoveProduct> StoveProducts { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierIngredientPrice> SupplierIngredientPrices { get; set; }

    public virtual DbSet<UnitType> UnitTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDeliveryPlan> UserDeliveryPlans { get; set; }

    public virtual DbSet<UserDeliveryTracking> UserDeliveryTrackings { get; set; }

    public virtual DbSet<UserLock> UserLocks { get; set; }

    public virtual DbSet<UserLoginAttempt> UserLoginAttempts { get; set; }

    public virtual DbSet<UserOrder> UserOrders { get; set; }

    public virtual DbSet<UserOrderDetail> UserOrderDetails { get; set; }

    public virtual DbSet<UserPointHistory> UserPointHistories { get; set; }

    public virtual DbSet<UserToken> UserTokens { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseStock> WarehouseStocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC071169F519");

            entity.HasIndex(e => e.PaymentId, "UQ_Carts_PaymentId").IsUnique();

            entity.HasOne(d => d.Payment).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.PaymentId)
                .HasConstraintName("FK_Carts_Payment");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_User");
        });

        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartProd__3214EC075D441510");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartProducts_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartProducts_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0702E29700");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CookingPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CookingP__3214EC07537B953A");

            entity.HasOne(d => d.Baker).WithMany(p => p.CookingPlans)
                .HasForeignKey(d => d.BakerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CookingPlans_Employee");

            entity.HasOne(d => d.Product).WithMany(p => p.CookingPlans)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CookingPlans_Product");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Coupons__3214EC0775FA2D17");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DeliveryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07F8C35B93");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC0778D1977F");

            entity.HasIndex(e => e.Username, "UQ__Employee__536C85E45D714E70").IsUnique();

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Role");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favorite__3214EC07B53C9AAF");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Users");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC078350D002");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.UnitType).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.UnitTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingredients_UnitType");
        });

        modelBuilder.Entity<IngredientDeliveryTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC072A407A0A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.DeliveryType).WithMany(p => p.IngredientDeliveryTrackings)
                .HasForeignKey(d => d.DeliveryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientDeliveryTrackings_DeliveryType");

            entity.HasOne(d => d.IngredientDeliveryPlan).WithMany(p => p.IngredientDeliveryTrackings)
                .HasForeignKey(d => d.IngredientDeliveryPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientDeliveryTrackings_IngredientDeliveryPlan");
        });

        modelBuilder.Entity<IngredientOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC07E9E4BCB6");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Store).WithMany(p => p.IngredientOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientOrders_Store");
        });

        modelBuilder.Entity<IngredientOrderDelivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC071C14A4CF");

            entity.Property(e => e.DeliveryDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.IngredientOrder).WithMany(p => p.IngredientOrderDeliveries)
                .HasForeignKey(d => d.IngredientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientOrderDeliveries_IngredientOrder");
        });

        modelBuilder.Entity<IngredientOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ingredie__3214EC07ACD16F2F");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngredientOrderDetails)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientOrderDetails_Ingredient");

            entity.HasOne(d => d.IngredientOrder).WithMany(p => p.IngredientOrderDetails)
                .HasForeignKey(d => d.IngredientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngredientOrderDetails_IngredientOrder");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC0787EE879D");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Stove).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.StoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Maintenances_Stove");
        });

        modelBuilder.Entity<OneTimePassword>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OneTimeP__3214EC07EC1FC5A2");

            entity.HasIndex(e => e.UserId, "Index_UserId").IsUnique();

            entity.Property(e => e.Code)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ExpiredDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithOne(p => p.OneTimePassword)
                .HasForeignKey<OneTimePassword>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OneTimePasswords_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC0733CDE4A7");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Coupon).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CouponId)
                .HasConstraintName("FK_Payments_Coupons");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Users");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentD__3214EC07765A704E");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetails_Payment");

            entity.HasOne(d => d.Product).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentDetails_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0731D1550F");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Catego__3F466844");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recipes__3214EC0736845B1C");

            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.Product).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipes_Product");

            entity.HasOne(d => d.RecipeType).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.RecipeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipes_RecipeTypes");
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RecipeIn__3214EC07D4C6D6F4");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Ingredients).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_Ingredient");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_Recipe");
        });

        modelBuilder.Entity<RecipeKeyPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RecipeKe__3214EC07FF8FC16B");

            entity.Property(e => e.Comment).HasColumnType("text");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeKeyPoints)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeKeyPoints_Recipe");
        });

        modelBuilder.Entity<RecipeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RecipeTy__3214EC07ACF630DF");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC072EA7F503");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_User");
        });

        modelBuilder.Entity<ReviewDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReviewDe__3214EC07AB4BC73C");

            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewDetails)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewDetails_Review");

            entity.HasOne(d => d.ReviewItem).WithMany(p => p.ReviewDetails)
                .HasForeignKey(d => d.ReviewItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewDetails_ReviewItem");
        });

        modelBuilder.Entity<ReviewItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReviewIt__3214EC07BDF87871");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ReviewItemType).WithMany(p => p.ReviewItems)
                .HasForeignKey(d => d.ReviewItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewItems_ReviewItemType");
        });

        modelBuilder.Entity<ReviewItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReviewIt__3214EC07DA84C872");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC070FF16F27");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Shifting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shifting__3214EC07633B21E8");

            entity.HasOne(d => d.Employee).WithMany(p => p.Shiftings)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shiftings_Employee");

            entity.HasOne(d => d.ShiftingType).WithMany(p => p.Shiftings)
                .HasForeignKey(d => d.ShiftingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shiftings_ShiftingType");
        });

        modelBuilder.Entity<ShiftingType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shifting__3214EC0787B43CD7");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stocks__3214EC07715FA336");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stocks_Ingredient");
        });

        modelBuilder.Entity<Stofe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stoves__3214EC072AC282CB");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stores__3214EC0789E40C7B");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StoreEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StoreEmp__3214EC07D96E34E6");

            entity.HasOne(d => d.Employee).WithMany(p => p.StoreEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreEmployees_Employee");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreEmployees)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreEmployees_Store");
        });

        modelBuilder.Entity<StoveAllocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StoveAll__3214EC0787A687E8");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CookingPlan).WithMany(p => p.StoveAllocations)
                .HasForeignKey(d => d.CookingPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoveAllocations_CookingPlan");

            entity.HasOne(d => d.Stove).WithMany(p => p.StoveAllocations)
                .HasForeignKey(d => d.StoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoveAllocations_Stove");
        });

        modelBuilder.Entity<StoveProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StovePro__3214EC079F1ADA21");

            entity.HasOne(d => d.Product).WithMany(p => p.StoveProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoveProducts_Product");

            entity.HasOne(d => d.Stove).WithMany(p => p.StoveProducts)
                .HasForeignKey(d => d.StoveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoveProducts_Stove");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07B9C5E377");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SupplierIngredientPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07AB280B08");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.SupplierIngredientPrices)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierIngredientPrices_Ingredient");

            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierIngredientPrices)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierIngredientPrices_Supplier");
        });

        modelBuilder.Entity<UnitType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnitType__3214EC07393A2C0C");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07543AB847");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4D94765AC").IsUnique();

            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDeliveryPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeli__3214EC07FBC5EE04");

            entity.Property(e => e.DeliveryDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Driver).WithMany(p => p.UserDeliveryPlans)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDeliveryPlans_Employee");

            entity.HasOne(d => d.UserOrder).WithMany(p => p.UserDeliveryPlans)
                .HasForeignKey(d => d.UserOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDeliveryPlans_UserOrder");
        });

        modelBuilder.Entity<UserDeliveryTracking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeli__3214EC07F1EAEE1E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.DeliveryType).WithMany(p => p.UserDeliveryTrackings)
                .HasForeignKey(d => d.DeliveryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDeliveryTrackings_DeliveryType");

            entity.HasOne(d => d.UserDeliveryPlan).WithMany(p => p.UserDeliveryTrackings)
                .HasForeignKey(d => d.UserDeliveryPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDeliveryTrackings_UserDeliveryPlan");
        });

        modelBuilder.Entity<UserLock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLock__3214EC079FCA42A0");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserLocks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLocks_User");
        });

        modelBuilder.Entity<UserLoginAttempt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3214EC0796768D51");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserLoginAttempts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLoginAttempts_User");
        });

        modelBuilder.Entity<UserOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07F62CCAEA");

            entity.HasIndex(e => e.PaymentId, "Index_PaymentId").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.EstimateDeliveryDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.Payment).WithOne(p => p.UserOrder)
                .HasForeignKey<UserOrder>(d => d.PaymentId)
                .HasConstraintName("FK_UserOrders_Payments");

            entity.HasOne(d => d.User).WithMany(p => p.UserOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<UserOrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC0747DFE725");

            entity.HasOne(d => d.Product).WithMany(p => p.UserOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Product");

            entity.HasOne(d => d.UserOrder).WithMany(p => p.UserOrderDetails)
                .HasForeignKey(d => d.UserOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Order");
        });

        modelBuilder.Entity<UserPointHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserPoin__3214EC07D15FE7C5");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserPointHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPointHistories_User");
        });

        modelBuilder.Entity<UserToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserToke__3214EC07FA378631");

            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserToken__UserI__3A81B327");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC075D662DFA");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Warehouses_Supplier");
        });

        modelBuilder.Entity<WarehouseStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Warehous__3214EC07827F0E5A");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStocks_Ingredient");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.WarehouseStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WarehouseStocks_Warehouse");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
