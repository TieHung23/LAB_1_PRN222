using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVDMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PercentDiscount = table.Column<int>(type: "int", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WarrantyPeriod = table.Column<int>(type: "int", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    VehicleConfigId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleConfigs_VehicleConfigId",
                        column: x => x.VehicleConfigId,
                        principalTable: "VehicleConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripsion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DealerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestDrives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestDrives_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestDrives_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Payed = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAtTick = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedAtTick", "CreatedById", "Email", "FullName", "IdCardNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("00000003-0001-0000-0000-000000000000"), "1 Main St", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "customer1@email.com", "Customer 1", "123456789011", "987654321" },
                    { new Guid("00000003-0002-0000-0000-000000000000"), "2 Main St", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "customer2@email.com", "Customer 2", "123456789012", "987654322" },
                    { new Guid("00000003-0003-0000-0000-000000000000"), "3 Main St", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "customer3@email.com", "Customer 3", "123456789013", "987654323" },
                    { new Guid("00000003-0004-0000-0000-000000000000"), "4 Main St", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "customer4@email.com", "Customer 4", "123456789014", "987654324" },
                    { new Guid("00000003-0005-0000-0000-000000000000"), "5 Main St", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "customer5@email.com", "Customer 5", "123456789015", "987654325" }
                });

            migrationBuilder.InsertData(
                table: "Dealers",
                columns: new[] { "Id", "Address", "Code", "CreatedAt", "CreatedAtTick", "CreatedById", "Email", "IsActive", "IsDeleted", "Name", "PhoneNumber", "Region", "UpdatedAt", "UpdatedAtTick", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0000-0000-000000000000"), "1 Street", "DLR001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "dealer1@email.com", true, false, "Auto-1", "123456781", "North", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00000001-0002-0000-0000-000000000000"), "2 Street", "DLR002", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "dealer2@email.com", true, false, "Auto-2", "123456782", "North", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00000001-0003-0000-0000-000000000000"), "3 Street", "DLR003", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "dealer3@email.com", true, false, "Auto-3", "123456783", "North", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00000001-0004-0000-0000-000000000000"), "4 Street", "DLR004", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "dealer4@email.com", true, false, "Auto-4", "123456784", "North", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00000001-0005-0000-0000-000000000000"), "5 Street", "DLR005", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "dealer5@email.com", true, false, "Auto-5", "123456785", "North", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedAtTick", "CreatedById", "IsActive", "IsDeleted", "Name", "PercentDiscount" },
                values: new object[,]
                {
                    { new Guid("00000007-0001-0000-0000-000000000000"), "SALE1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Sale 1", 2 },
                    { new Guid("00000007-0002-0000-0000-000000000000"), "SALE2", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Sale 2", 4 },
                    { new Guid("00000007-0003-0000-0000-000000000000"), "SALE3", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Sale 3", 6 },
                    { new Guid("00000007-0004-0000-0000-000000000000"), "SALE4", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Sale 4", 8 },
                    { new Guid("00000007-0005-0000-0000-000000000000"), "SALE5", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), true, false, "Sale 5", 10 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedAtTick", "CreatedById", "Description", "Name", "UpdatedAt", "UpdatedAtTick", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Staff member of a dealership.", "Dealer Staff", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Manager of a dealership.", "Dealer Manager", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Electric Vehicle Manufacturer staff.", "EVM Staff", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "System Administrator.", "Admin", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "VehicleConfigs",
                columns: new[] { "Id", "BasePrice", "Color", "CreatedAt", "CreatedAtTick", "CreatedById", "InteriorType", "IsDeleted", "UpdatedAt", "UpdatedAtTick", "UpdatedById", "VersionName", "WarrantyPeriod" },
                values: new object[,]
                {
                    { new Guid("00000004-0001-0000-0000-000000000000"), 35000m, "White", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Cloth", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Standard", 36 },
                    { new Guid("00000004-0002-0000-0000-000000000000"), 35000m, "White", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Cloth", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Standard", 36 },
                    { new Guid("00000004-0003-0000-0000-000000000000"), 35000m, "White", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Cloth", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Standard", 36 },
                    { new Guid("00000004-0004-0000-0000-000000000000"), 35000m, "White", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Cloth", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Standard", 36 },
                    { new Guid("00000004-0005-0000-0000-000000000000"), 35000m, "White", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Cloth", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Standard", 36 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "CreatedAtTick", "CreatedById", "DealerId", "FullName", "HashedPassword", "IsActive", "IsDeleted", "RoleId", "UpdatedAt", "UpdatedAtTick", "UpdatedById", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000002-0001-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Manager 1", "hash", true, false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "manager1" },
                    { new Guid("00000002-0002-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Staff 1", "hash", true, false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "staff1" },
                    { new Guid("00000002-0003-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Manager 2", "hash", true, false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "manager2" },
                    { new Guid("00000002-0004-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Staff 2", "hash", true, false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "staff2" },
                    { new Guid("00000002-0005-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Manager 3", "hash", true, false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "manager3" },
                    { new Guid("00000002-0006-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Staff 3", "hash", true, false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "staff3" },
                    { new Guid("00000002-0007-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Manager 4", "hash", true, false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "manager4" },
                    { new Guid("00000002-0008-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Staff 4", "hash", true, false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "staff4" },
                    { new Guid("00000002-0009-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Manager 5", "hash", true, false, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "manager5" },
                    { new Guid("00000002-000a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Staff 5", "hash", true, false, new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "staff5" },
                    { new Guid("00000064-0001-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), null, "System Admin", "admin_hash", true, false, new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "admin" },
                    { new Guid("00000064-0002-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), null, "EVM Staff Member", "evm_hash", true, false, new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "evmstaff" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Brand", "CreatedAt", "CreatedAtTick", "CreatedById", "Description", "FeatureIds", "IsActive", "IsDeleted", "ModelName", "ReleaseYear", "VehicleConfigId", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("00000005-0001-0000-0000-000000000000"), "Tesla", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Description", null, true, false, "Model 1", 2022, new Guid("00000004-0001-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-0002-0000-0000-000000000000"), "Tesla", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Description", null, true, false, "Model 2", 2022, new Guid("00000004-0002-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-0003-0000-0000-000000000000"), "Tesla", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Description", null, true, false, "Model 3", 2022, new Guid("00000004-0003-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-0004-0000-0000-000000000000"), "Tesla", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Description", null, true, false, "Model 4", 2022, new Guid("00000004-0004-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-0005-0000-0000-000000000000"), "Tesla", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Description", null, true, false, "Model 5", 2022, new Guid("00000004-0005-0000-0000-000000000000"), "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedAtTick", "CreatedById", "DealerId", "Description", "IsSale", "UpdatedAt", "UpdatedAtTick", "UpdatedById", "VehicleModelId" },
                values: new object[,]
                {
                    { new Guid("00000006-0001-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "New arrival", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0001-0000-0000-000000000000") },
                    { new Guid("00000006-0002-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "New arrival", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0002-0000-0000-000000000000") },
                    { new Guid("00000006-0003-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "New arrival", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0003-0000-0000-000000000000") },
                    { new Guid("00000006-0004-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "New arrival", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0004-0000-0000-000000000000") },
                    { new Guid("00000006-0005-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "New arrival", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0005-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "TestDrives",
                columns: new[] { "Id", "CustomerId", "IsActive", "IsDeleted", "IsSuccess", "ScheduledDateTime", "VehicleModelId" },
                values: new object[,]
                {
                    { new Guid("0000000a-0001-0000-0000-000000000000"), new Guid("00000003-0001-0000-0000-000000000000"), true, false, false, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000005-0001-0000-0000-000000000000") },
                    { new Guid("0000000a-0002-0000-0000-000000000000"), new Guid("00000003-0002-0000-0000-000000000000"), true, false, false, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000005-0002-0000-0000-000000000000") },
                    { new Guid("0000000a-0003-0000-0000-000000000000"), new Guid("00000003-0003-0000-0000-000000000000"), true, false, false, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000005-0003-0000-0000-000000000000") },
                    { new Guid("0000000a-0004-0000-0000-000000000000"), new Guid("00000003-0004-0000-0000-000000000000"), true, false, false, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000005-0004-0000-0000-000000000000") },
                    { new Guid("0000000a-0005-0000-0000-000000000000"), new Guid("00000003-0005-0000-0000-000000000000"), true, false, false, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000005-0005-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AccountId", "CreatedAt", "CreatedAtTick", "CreatedById", "CustomerId", "InventoryId", "PromotionId" },
                values: new object[,]
                {
                    { new Guid("00000008-0001-0000-0000-000000000000"), new Guid("00000002-0001-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0001-0000-0000-000000000000"), new Guid("00000003-0001-0000-0000-000000000000"), new Guid("00000006-0001-0000-0000-000000000000"), new Guid("00000007-0001-0000-0000-000000000000") },
                    { new Guid("00000008-0002-0000-0000-000000000000"), new Guid("00000002-0003-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0003-0000-0000-000000000000"), new Guid("00000003-0002-0000-0000-000000000000"), new Guid("00000006-0002-0000-0000-000000000000"), new Guid("00000007-0002-0000-0000-000000000000") },
                    { new Guid("00000008-0003-0000-0000-000000000000"), new Guid("00000002-0005-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0005-0000-0000-000000000000"), new Guid("00000003-0003-0000-0000-000000000000"), new Guid("00000006-0003-0000-0000-000000000000"), new Guid("00000007-0003-0000-0000-000000000000") },
                    { new Guid("00000008-0004-0000-0000-000000000000"), new Guid("00000002-0007-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0007-0000-0000-000000000000"), new Guid("00000003-0004-0000-0000-000000000000"), new Guid("00000006-0004-0000-0000-000000000000"), new Guid("00000007-0004-0000-0000-000000000000") },
                    { new Guid("00000008-0005-0000-0000-000000000000"), new Guid("00000002-0009-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0009-0000-0000-000000000000"), new Guid("00000003-0005-0000-0000-000000000000"), new Guid("00000006-0005-0000-0000-000000000000"), new Guid("00000007-0005-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "BasePrice", "CreatedAt", "CreatedAtTick", "CreatedById", "DiscountPrice", "EndDate", "FinalPrice", "IsSuccess", "OrderId", "Payed", "PaymentMethod", "StartDate", "UpdatedAt", "UpdatedAtTick", "UpdatedById" },
                values: new object[,]
                {
                    { new Guid("00000009-0001-0000-0000-000000000000"), 35000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0001-0000-0000-000000000000"), 700m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 34300m, false, new Guid("00000008-0001-0000-0000-000000000000"), 1000m, "Card", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0001-0000-0000-000000000000") },
                    { new Guid("00000009-0002-0000-0000-000000000000"), 35000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0003-0000-0000-000000000000"), 1400m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 33600m, false, new Guid("00000008-0002-0000-0000-000000000000"), 1000m, "Card", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0003-0000-0000-000000000000") },
                    { new Guid("00000009-0003-0000-0000-000000000000"), 35000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0005-0000-0000-000000000000"), 2100m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 32900m, false, new Guid("00000008-0003-0000-0000-000000000000"), 1000m, "Card", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0005-0000-0000-000000000000") },
                    { new Guid("00000009-0004-0000-0000-000000000000"), 35000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0007-0000-0000-000000000000"), 2800m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 32200m, false, new Guid("00000008-0004-0000-0000-000000000000"), 1000m, "Card", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0007-0000-0000-000000000000") },
                    { new Guid("00000009-0005-0000-0000-000000000000"), 35000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0009-0000-0000-000000000000"), 3500m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc), 31500m, false, new Guid("00000008-0005-0000-0000-000000000000"), 1000m, "Card", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000002-0009-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_DealerId",
                table: "Accounts",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_VehicleModelId",
                table: "Features",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_DealerId",
                table: "Inventories",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_VehicleModelId",
                table: "Inventories",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InventoryId",
                table: "Orders",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromotionId",
                table: "Orders",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrives_CustomerId",
                table: "TestDrives",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TestDrives_VehicleModelId",
                table: "TestDrives",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleConfigId",
                table: "VehicleModels",
                column: "VehicleConfigId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "TestDrives");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleConfigs");
        }
    }
}
