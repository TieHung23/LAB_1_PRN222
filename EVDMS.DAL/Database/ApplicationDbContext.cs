using EVDMS.Core.CommonEntities;
using EVDMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVDMS.DAL.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var property in modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }
        // Cấu hình mối quan hệ: Một Role có nhiều Account
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Accounts)
            .WithOne(a => a.Role)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Ngăn không cho xóa Role nếu vẫn còn Account

        // Cấu hình mối quan hệ: Một Dealer có nhiều Account
        modelBuilder.Entity<Dealer>()
            .HasMany(d => d.Accounts)
            .WithOne(a => a.Dealer)
            .HasForeignKey(a => a.DealerId)
            .OnDelete(DeleteBehavior.SetNull); // Nếu xóa Dealer, set DealerId của Account thành null

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Account)
            .WithMany()
            .HasForeignKey(o => o.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Inventory)
            .WithMany()
            .HasForeignKey(o => o.InventoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Promotion)
            .WithMany()
            .HasForeignKey(o => o.PromotionId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Data
        SeedRoles(modelBuilder);
        SeedInitialAccounts(modelBuilder);
        SeedExtendedEntities(modelBuilder);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<TestDrive> TestDrives { get; set; }
    public DbSet<VehicleConfig> VehicleConfigs { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }

    // Copilot: Generate seed method for Role entity with CreatedAt/UpdatedAt fields
    private void SeedRoles(ModelBuilder modelBuilder)
    {
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var seedDateTicks = seedDate.Ticks;
        var systemUserId = Guid.Empty;

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = new Guid("11111111-1111-1111-1111-111111111111"), Name = "Dealer Staff", Description = "Staff member of a dealership.", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId },
            new Role { Id = new Guid("22222222-2222-2222-2222-222222222222"), Name = "Dealer Manager", Description = "Manager of a dealership.", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId },
            new Role { Id = new Guid("33333333-3333-3333-3333-333333333333"), Name = "EVM Staff", Description = "Electric Vehicle Manufacturer staff.", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId },
            new Role { Id = new Guid("44444444-4444-4444-4444-444444444444"), Name = "Admin", Description = "System Administrator.", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId }
        );
    }

    private void SeedInitialAccounts(ModelBuilder modelBuilder)
    {
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var seedDateTicks = seedDate.Ticks;
        var systemUserId = Guid.Empty;

        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = NewGuid(100, 1),
                UserName = "admin",
                HashedPassword = "admin_hash",
                FullName = "System Admin",
                IsActive = true,
                IsDeleted = false,
                DealerId = null,
                RoleId = new Guid("44444444-4444-4444-4444-444444444444"),
                CreatedAt = seedDate,
                CreatedAtTick = seedDateTicks,
                CreatedById = systemUserId,
                UpdatedAt = seedDate,
                UpdatedAtTick = seedDateTicks,
                UpdatedById = systemUserId
            },
            new Account { Id = NewGuid(100, 2), UserName = "evmstaff", HashedPassword = "evm_hash", FullName = "EVM Staff Member", IsActive = true, IsDeleted = false, DealerId = null, RoleId = new Guid("33333333-3333-3333-3333-333333333333"), CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId }
        );
    }

    private void SeedExtendedEntities(ModelBuilder modelBuilder)
    {
        var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var seedDateTicks = seedDate.Ticks;
        var systemUserId = Guid.Empty;

        // Role IDs
        var dealerStaffRoleId = new Guid("11111111-1111-1111-1111-111111111111");
        var dealerManagerRoleId = new Guid("22222222-2222-2222-2222-222222222222");

        // Seed Dealers (5)
        var dealers = new List<Dealer>();
        for (int i = 1; i <= 5; i++)
        {
            dealers.Add(new Dealer { Id = NewGuid(1, i), Code = $"DLR00{i}", Name = $"Auto-{i}", Address = $"{i} Street", PhoneNumber = $"12345678{i}", Email = $"dealer{i}@email.com", Region = "North", IsActive = true, IsDeleted = false, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId });
        }
        modelBuilder.Entity<Dealer>().HasData(dealers);
        var defaultHashedPassword = "$2a$11$rDTmn7YPiwBqtZssLgFtquuGBlLPLTFKa2YzLrr9j7.rsMCdSulW.";
        // Seed Dealer Accounts (10)
        var dealerAccounts = new List<Account>();
        for (int i = 0; i < 5; i++)
        {
            var dealerId = dealers[i].Id;
            // Manager Account
            dealerAccounts.Add(new Account { Id = NewGuid(2, i * 2 + 1), UserName = $"manager{i + 1}", HashedPassword = defaultHashedPassword, FullName = $"Manager {i + 1}", IsActive = true, IsDeleted = false, DealerId = dealerId, RoleId = dealerManagerRoleId, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId });
            // Staff Account
            dealerAccounts.Add(new Account { Id = NewGuid(2, i * 2 + 2), UserName = $"staff{i + 1}", HashedPassword = defaultHashedPassword, FullName = $"Staff {i + 1}", IsActive = true, IsDeleted = false, DealerId = dealerId, RoleId = dealerStaffRoleId, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId });
        }
        modelBuilder.Entity<Account>().HasData(dealerAccounts);

        // Seed Customers (5)
        var customers = new List<Customer>();
        for (int i = 1; i <= 5; i++)
        {
            customers.Add(new Customer { Id = NewGuid(3, i), FullName = $"Customer {i}", PhoneNumber = $"98765432{i}", Email = $"customer{i}@email.com", Address = $"{i} Main St", IdCardNumber = $"12345678901{i}", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId });
        }
        modelBuilder.Entity<Customer>().HasData(customers);

        // Seed VehicleConfigs (5)
        var vehicleConfigs = new List<VehicleConfig>();
        var vehicleModels = new List<VehicleModel>();
        var inventories = new List<Inventory>();

        // --- Giữ lại 5 xe Tesla gốc cho 5 đại lý đầu tiên ---
        for (int i = 1; i <= 5; i++)
        {
            var config = new VehicleConfig { Id = NewGuid(4, i), VersionName = "Standard", Color = "White", InteriorType = "Cloth", BasePrice = 35000 + (i * 1000), WarrantyPeriod = 36, IsDeleted = false, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId };
            vehicleConfigs.Add(config);

            var model = new VehicleModel { Id = NewGuid(5, i), ModelName = $"Model {i}", Brand = "Tesla", VehicleType = "Sedan", Description = "Description", ReleaseYear = 2022, IsActive = true, IsDeleted = false, VehicleConfigId = config.Id, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, ImgUrl = "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png" };
            vehicleModels.Add(model);

            inventories.Add(new Inventory { Id = NewGuid(6, i), VehicleModelId = model.Id, DealerId = dealers[i - 1].Id, IsSale = true, Description = "New arrival", CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = systemUserId });
        }

        // --- Dữ liệu xe mới ---
        var newBrands = new List<string> { "VinFast", "BMW", "Hyundai" };
        var modelNames = new Dictionary<string, List<string>>
{
    { "VinFast", new List<string> { "VF 8", "VF 9", "VF e34", "VF 5", "VF 6", "VF 7" } },
    { "BMW", new List<string> { "iX", "i4", "i7", "iX3", "iX1" } },
    { "Hyundai", new List<string> { "Ioniq 5", "Ioniq 6", "Kona Electric" } }
};
        var vehicleTypes = new List<string> { "SUV", "Sedan", "Hatchback", "Crossover" };
        var colors = new List<string> { "Black", "Red", "Blue", "Silver", "Gray" };
        var interiors = new List<string> { "Leather", "Premium Fabric", "Suede" };
        var imgUrls = new Dictionary<string, string>
{
    {"VF 8", "https://shop.vinfastauto.com/on/demandware.static/-/Sites-app_vinfast_vn-Library/default/dw159f3640/images/v8/img-exterior.png"},
    {"VF 9", "https://shop.vinfastauto.com/on/demandware.static/-/Sites-app_vinfast_vn-Library/default/dw053c0704/images/v9/img-exterior-v2.png"},
    {"iX", "https://www.bmw.vn/content/dam/bmw/common/all-models/i-series/ix/2021/navigation/bmw-i-series-ix-modelfinder.png"},
    {"Ioniq 5", "https://media.hatvan.com/uploads/2021/05/hyundai-ioniq-5-ev-2022-1620958197.png"}
};


        int modelCounter = 6;
        int inventoryCounter = 6;

        // Lặp qua từng mẫu xe mới
        foreach (var brand in newBrands)
        {
            foreach (var modelName in modelNames[brand])
            {
                // --- TẠO XE VÀ CẤU HÌNH (Không dùng Random) ---
                var newConfig = new VehicleConfig
                {
                    Id = NewGuid(4, modelCounter),
                    VersionName = "Plus",
                    Color = colors[modelCounter % colors.Count], // Dùng toán tử chia lấy dư để lặp lại màu
                    InteriorType = interiors[modelCounter % interiors.Count], // Dùng toán tử chia lấy dư để lặp lại nội thất
                    BasePrice = 40000 + (modelCounter % 20) * 1000, // Giá thay đổi nhưng có thể dự đoán
                    WarrantyPeriod = 48,
                    CreatedAt = seedDate,
                    CreatedAtTick = seedDateTicks,
                    CreatedById = systemUserId,
                    UpdatedAt = seedDate,
                    UpdatedAtTick = seedDateTicks,
                    UpdatedById = systemUserId
                };
                vehicleConfigs.Add(newConfig);

                var newModel = new VehicleModel
                {
                    Id = NewGuid(5, modelCounter),
                    ModelName = modelName,
                    Brand = brand,
                    VehicleType = vehicleTypes[modelCounter % vehicleTypes.Count],
                    Description = $"A new electric car from {brand}",
                    ReleaseYear = 2023,
                    IsActive = true,
                    VehicleConfigId = newConfig.Id,
                    CreatedAt = seedDate,
                    CreatedAtTick = seedDateTicks,
                    CreatedById = systemUserId,
                    ImgUrl = imgUrls.ContainsKey(modelName) ? imgUrls[modelName] : "https://via.placeholder.com/600x400.png?text=No+Image"
                };
                vehicleModels.Add(newModel);

                // --- THÊM XE VÀO KHO CỦA TẤT CẢ ĐẠI LÝ ---
                foreach (var dealer in dealers)
                {
                    inventories.Add(new Inventory
                    {
                        Id = NewGuid(6, inventoryCounter),
                        VehicleModelId = newModel.Id,
                        DealerId = dealer.Id,
                        IsSale = true,
                        Description = "Available for test drive",
                        CreatedAt = seedDate,
                        CreatedAtTick = seedDateTicks,
                        CreatedById = systemUserId,
                        UpdatedAt = seedDate,
                        UpdatedAtTick = seedDateTicks,
                        UpdatedById = systemUserId
                    });
                    inventoryCounter++;
                }

                modelCounter++;
            }
        }

        modelBuilder.Entity<VehicleConfig>().HasData(vehicleConfigs);
        modelBuilder.Entity<VehicleModel>().HasData(vehicleModels);
        modelBuilder.Entity<Inventory>().HasData(inventories);

        // Seed Promotions (5)
        var promotions = new List<Promotion>();
        for (int i = 1; i <= 5; i++)
        {
            promotions.Add(new Promotion { Id = NewGuid(7, i), Name = $"Sale {i}", Code = $"SALE{i}", PercentDiscount = i * 2, IsActive = true, IsDeleted = false, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = systemUserId });
        }
        modelBuilder.Entity<Promotion>().HasData(promotions);

        // Seed Orders (5)
        var orders = new List<Order>();
        for (int i = 1; i <= 5; i++)
        {
            orders.Add(new Order { Id = NewGuid(8, i), CustomerId = customers[i - 1].Id, AccountId = dealerAccounts[(i - 1) * 2].Id, InventoryId = inventories[i - 1].Id, PromotionId = promotions[i - 1].Id, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = dealerAccounts[(i - 1) * 2].Id });
        }
        modelBuilder.Entity<Order>().HasData(orders);

        // Seed Payments (5)
        var payments = new List<Payment>();
        for (int i = 1; i <= 5; i++)
        {
            var order = orders[i - 1];
            var config = vehicleConfigs[i - 1];
            var promo = promotions[i - 1];
            var basePrice = config.BasePrice;
            var discount = basePrice * promo.PercentDiscount / 100;
            payments.Add(new Payment { Id = NewGuid(9, i), OrderId = order.Id, BasePrice = basePrice, DiscountPrice = discount, FinalPrice = basePrice - discount, Payed = 1000, PaymentMethod = "Card", StartDate = seedDate, EndDate = seedDate.AddDays(30), IsSuccess = false, CreatedAt = seedDate, CreatedAtTick = seedDateTicks, CreatedById = order.CreatedById, UpdatedAt = seedDate, UpdatedAtTick = seedDateTicks, UpdatedById = order.CreatedById });
        }
        modelBuilder.Entity<Payment>().HasData(payments);

        // Seed TestDrives (5)
        var testDrives = new List<TestDrive>();
        for (int i = 1; i <= 5; i++)
        {
            testDrives.Add(new TestDrive { Id = NewGuid(10, i), VehicleModelId = vehicleModels[i - 1].Id, CustomerId = customers[i - 1].Id, ScheduledDateTime = seedDate.AddDays(i), IsSuccess = false, IsActive = true, IsDeleted = false });
        }
        modelBuilder.Entity<TestDrive>().HasData(testDrives);
    }

    private Guid NewGuid(int entityType, int id)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(entityType).CopyTo(bytes, 0);
        BitConverter.GetBytes(id).CopyTo(bytes, 4);
        return new Guid(bytes);
    }
}


