using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EVDMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleToAllDealers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0001-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 36000m, 720m, 35280m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0002-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 37000m, 1480m, 35520m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0003-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 38000m, 2280m, 35720m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0004-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 39000m, 3120m, 35880m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0005-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 40000m, 4000m, 36000m });

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0001-0000-0000-000000000000"),
                column: "BasePrice",
                value: 36000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0002-0000-0000-000000000000"),
                column: "BasePrice",
                value: 37000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0003-0000-0000-000000000000"),
                column: "BasePrice",
                value: 38000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0004-0000-0000-000000000000"),
                column: "BasePrice",
                value: 39000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0005-0000-0000-000000000000"),
                column: "BasePrice",
                value: 40000m);

            migrationBuilder.InsertData(
                table: "VehicleConfigs",
                columns: new[] { "Id", "BasePrice", "Color", "CreatedAt", "CreatedAtTick", "CreatedById", "InteriorType", "IsDeleted", "UpdatedAt", "UpdatedAtTick", "UpdatedById", "VersionName", "WarrantyPeriod" },
                values: new object[,]
                {
                    { new Guid("00000004-0006-0000-0000-000000000000"), 46000m, "Red", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Leather", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0007-0000-0000-000000000000"), 47000m, "Blue", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Premium Fabric", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0008-0000-0000-000000000000"), 48000m, "Silver", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Suede", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0009-0000-0000-000000000000"), 49000m, "Gray", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Leather", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000a-0000-0000-000000000000"), 50000m, "Black", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Premium Fabric", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000b-0000-0000-000000000000"), 51000m, "Red", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Suede", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000c-0000-0000-000000000000"), 52000m, "Blue", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Leather", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000d-0000-0000-000000000000"), 53000m, "Silver", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Premium Fabric", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000e-0000-0000-000000000000"), 54000m, "Gray", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Suede", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-000f-0000-0000-000000000000"), 55000m, "Black", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Leather", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0010-0000-0000-000000000000"), 56000m, "Red", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Premium Fabric", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0011-0000-0000-000000000000"), 57000m, "Blue", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Suede", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0012-0000-0000-000000000000"), 58000m, "Silver", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Leather", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 },
                    { new Guid("00000004-0013-0000-0000-000000000000"), 59000m, "Gray", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Premium Fabric", false, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "Plus", 48 }
                });

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0001-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0002-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0003-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0004-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0005-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "https://digitalassets.tesla.com/tesla-contents/image/upload/h_1800,w_2880,q_auto:best,f_auto,dpr_2.0/v1/content/dam/tesla/CAR_ASSETS/MODEL_S/U004_Paint_S_desktop.png");

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Brand", "CreatedAt", "CreatedAtTick", "CreatedById", "Description", "FeatureIds", "ImgUrl", "IsActive", "IsDeleted", "ModelName", "ReleaseYear", "VehicleConfigId", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("00000005-0006-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://shop.vinfastauto.com/on/demandware.static/-/Sites-app_vinfast_vn-Library/default/dw159f3640/images/v8/img-exterior.png", true, false, "VF 8", 2023, new Guid("00000004-0006-0000-0000-000000000000"), "Hatchback" },
                    { new Guid("00000005-0007-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://shop.vinfastauto.com/on/demandware.static/-/Sites-app_vinfast_vn-Library/default/dw053c0704/images/v9/img-exterior-v2.png", true, false, "VF 9", 2023, new Guid("00000004-0007-0000-0000-000000000000"), "Crossover" },
                    { new Guid("00000005-0008-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "VF e34", 2023, new Guid("00000004-0008-0000-0000-000000000000"), "SUV" },
                    { new Guid("00000005-0009-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "VF 5", 2023, new Guid("00000004-0009-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-000a-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "VF 6", 2023, new Guid("00000004-000a-0000-0000-000000000000"), "Hatchback" },
                    { new Guid("00000005-000b-0000-0000-000000000000"), "VinFast", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from VinFast", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "VF 7", 2023, new Guid("00000004-000b-0000-0000-000000000000"), "Crossover" },
                    { new Guid("00000005-000c-0000-0000-000000000000"), "BMW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from BMW", null, "https://www.bmw.vn/content/dam/bmw/common/all-models/i-series/ix/2021/navigation/bmw-i-series-ix-modelfinder.png", true, false, "iX", 2023, new Guid("00000004-000c-0000-0000-000000000000"), "SUV" },
                    { new Guid("00000005-000d-0000-0000-000000000000"), "BMW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from BMW", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "i4", 2023, new Guid("00000004-000d-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-000e-0000-0000-000000000000"), "BMW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from BMW", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "i7", 2023, new Guid("00000004-000e-0000-0000-000000000000"), "Hatchback" },
                    { new Guid("00000005-000f-0000-0000-000000000000"), "BMW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from BMW", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "iX3", 2023, new Guid("00000004-000f-0000-0000-000000000000"), "Crossover" },
                    { new Guid("00000005-0010-0000-0000-000000000000"), "BMW", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from BMW", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "iX1", 2023, new Guid("00000004-0010-0000-0000-000000000000"), "SUV" },
                    { new Guid("00000005-0011-0000-0000-000000000000"), "Hyundai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from Hyundai", null, "https://media.hatvan.com/uploads/2021/05/hyundai-ioniq-5-ev-2022-1620958197.png", true, false, "Ioniq 5", 2023, new Guid("00000004-0011-0000-0000-000000000000"), "Sedan" },
                    { new Guid("00000005-0012-0000-0000-000000000000"), "Hyundai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from Hyundai", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "Ioniq 6", 2023, new Guid("00000004-0012-0000-0000-000000000000"), "Hatchback" },
                    { new Guid("00000005-0013-0000-0000-000000000000"), "Hyundai", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), "A new electric car from Hyundai", null, "https://via.placeholder.com/600x400.png?text=No+Image", true, false, "Kona Electric", 2023, new Guid("00000004-0013-0000-0000-000000000000"), "Crossover" }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedAt", "CreatedAtTick", "CreatedById", "DealerId", "Description", "IsSale", "UpdatedAt", "UpdatedAtTick", "UpdatedById", "VehicleModelId" },
                values: new object[,]
                {
                    { new Guid("00000006-0006-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0006-0000-0000-000000000000") },
                    { new Guid("00000006-0007-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0006-0000-0000-000000000000") },
                    { new Guid("00000006-0008-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0006-0000-0000-000000000000") },
                    { new Guid("00000006-0009-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0006-0000-0000-000000000000") },
                    { new Guid("00000006-000a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0006-0000-0000-000000000000") },
                    { new Guid("00000006-000b-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0007-0000-0000-000000000000") },
                    { new Guid("00000006-000c-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0007-0000-0000-000000000000") },
                    { new Guid("00000006-000d-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0007-0000-0000-000000000000") },
                    { new Guid("00000006-000e-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0007-0000-0000-000000000000") },
                    { new Guid("00000006-000f-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0007-0000-0000-000000000000") },
                    { new Guid("00000006-0010-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0008-0000-0000-000000000000") },
                    { new Guid("00000006-0011-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0008-0000-0000-000000000000") },
                    { new Guid("00000006-0012-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0008-0000-0000-000000000000") },
                    { new Guid("00000006-0013-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0008-0000-0000-000000000000") },
                    { new Guid("00000006-0014-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0008-0000-0000-000000000000") },
                    { new Guid("00000006-0015-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0009-0000-0000-000000000000") },
                    { new Guid("00000006-0016-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0009-0000-0000-000000000000") },
                    { new Guid("00000006-0017-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0009-0000-0000-000000000000") },
                    { new Guid("00000006-0018-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0009-0000-0000-000000000000") },
                    { new Guid("00000006-0019-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0009-0000-0000-000000000000") },
                    { new Guid("00000006-001a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000a-0000-0000-000000000000") },
                    { new Guid("00000006-001b-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000a-0000-0000-000000000000") },
                    { new Guid("00000006-001c-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000a-0000-0000-000000000000") },
                    { new Guid("00000006-001d-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000a-0000-0000-000000000000") },
                    { new Guid("00000006-001e-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000a-0000-0000-000000000000") },
                    { new Guid("00000006-001f-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000b-0000-0000-000000000000") },
                    { new Guid("00000006-0020-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000b-0000-0000-000000000000") },
                    { new Guid("00000006-0021-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000b-0000-0000-000000000000") },
                    { new Guid("00000006-0022-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000b-0000-0000-000000000000") },
                    { new Guid("00000006-0023-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000b-0000-0000-000000000000") },
                    { new Guid("00000006-0024-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000c-0000-0000-000000000000") },
                    { new Guid("00000006-0025-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000c-0000-0000-000000000000") },
                    { new Guid("00000006-0026-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000c-0000-0000-000000000000") },
                    { new Guid("00000006-0027-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000c-0000-0000-000000000000") },
                    { new Guid("00000006-0028-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000c-0000-0000-000000000000") },
                    { new Guid("00000006-0029-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000d-0000-0000-000000000000") },
                    { new Guid("00000006-002a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000d-0000-0000-000000000000") },
                    { new Guid("00000006-002b-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000d-0000-0000-000000000000") },
                    { new Guid("00000006-002c-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000d-0000-0000-000000000000") },
                    { new Guid("00000006-002d-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000d-0000-0000-000000000000") },
                    { new Guid("00000006-002e-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000e-0000-0000-000000000000") },
                    { new Guid("00000006-002f-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000e-0000-0000-000000000000") },
                    { new Guid("00000006-0030-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000e-0000-0000-000000000000") },
                    { new Guid("00000006-0031-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000e-0000-0000-000000000000") },
                    { new Guid("00000006-0032-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000e-0000-0000-000000000000") },
                    { new Guid("00000006-0033-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000f-0000-0000-000000000000") },
                    { new Guid("00000006-0034-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000f-0000-0000-000000000000") },
                    { new Guid("00000006-0035-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000f-0000-0000-000000000000") },
                    { new Guid("00000006-0036-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000f-0000-0000-000000000000") },
                    { new Guid("00000006-0037-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-000f-0000-0000-000000000000") },
                    { new Guid("00000006-0038-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0010-0000-0000-000000000000") },
                    { new Guid("00000006-0039-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0010-0000-0000-000000000000") },
                    { new Guid("00000006-003a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0010-0000-0000-000000000000") },
                    { new Guid("00000006-003b-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0010-0000-0000-000000000000") },
                    { new Guid("00000006-003c-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0010-0000-0000-000000000000") },
                    { new Guid("00000006-003d-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0011-0000-0000-000000000000") },
                    { new Guid("00000006-003e-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0011-0000-0000-000000000000") },
                    { new Guid("00000006-003f-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0011-0000-0000-000000000000") },
                    { new Guid("00000006-0040-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0011-0000-0000-000000000000") },
                    { new Guid("00000006-0041-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0011-0000-0000-000000000000") },
                    { new Guid("00000006-0042-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0012-0000-0000-000000000000") },
                    { new Guid("00000006-0043-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0012-0000-0000-000000000000") },
                    { new Guid("00000006-0044-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0012-0000-0000-000000000000") },
                    { new Guid("00000006-0045-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0012-0000-0000-000000000000") },
                    { new Guid("00000006-0046-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0012-0000-0000-000000000000") },
                    { new Guid("00000006-0047-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0001-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0013-0000-0000-000000000000") },
                    { new Guid("00000006-0048-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0002-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0013-0000-0000-000000000000") },
                    { new Guid("00000006-0049-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0003-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0013-0000-0000-000000000000") },
                    { new Guid("00000006-004a-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0004-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0013-0000-0000-000000000000") },
                    { new Guid("00000006-004b-0000-0000-000000000000"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000001-0005-0000-0000-000000000000"), "Available for test drive", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 638396640000000000L, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000005-0013-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0006-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0007-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0008-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0009-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-000f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0010-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0011-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0012-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0013-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0014-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0015-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0016-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0017-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0018-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0019-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-001f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0020-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0021-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0022-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0023-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0024-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0025-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0026-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0027-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0028-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0029-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-002f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0030-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0031-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0032-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0033-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0034-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0035-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0036-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0037-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0038-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0039-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-003f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0040-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0041-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0042-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0043-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0044-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0045-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0046-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0047-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0048-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0049-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-004a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-004b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0006-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0007-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0008-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0009-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-000f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0010-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0011-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0012-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0013-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0006-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0007-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0008-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0009-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000a-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000b-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000c-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000d-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000e-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-000f-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0010-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0011-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0012-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0013-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0001-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 35000m, 700m, 34300m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0002-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 35000m, 1400m, 33600m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0003-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 35000m, 2100m, 32900m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0004-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 35000m, 2800m, 32200m });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0005-0000-0000-000000000000"),
                columns: new[] { "BasePrice", "DiscountPrice", "FinalPrice" },
                values: new object[] { 35000m, 3500m, 31500m });

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0001-0000-0000-000000000000"),
                column: "BasePrice",
                value: 35000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0002-0000-0000-000000000000"),
                column: "BasePrice",
                value: 35000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0003-0000-0000-000000000000"),
                column: "BasePrice",
                value: 35000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0004-0000-0000-000000000000"),
                column: "BasePrice",
                value: 35000m);

            migrationBuilder.UpdateData(
                table: "VehicleConfigs",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0005-0000-0000-000000000000"),
                column: "BasePrice",
                value: 35000m);

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0001-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0002-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0003-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0004-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");

            migrationBuilder.UpdateData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0005-0000-0000-000000000000"),
                column: "ImgUrl",
                value: "Hahahaha");
        }
    }
}
