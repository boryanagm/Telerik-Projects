using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Deliverit.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 55, nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    StreetName = table.Column<string>(maxLength: 100, nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRoles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<Guid>(nullable: false),
                    WarehouseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipments_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    ShipmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcels_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcels_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcels_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parcels_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("1db0c76c-ab76-4105-be89-3af983f6f137"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(6711), null, false, null, "Electronics" },
                    { new Guid("df79ccb6-1f56-41da-9f8f-df2f92a468bb"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(7302), null, false, null, "Clothing" },
                    { new Guid("7aeb290e-3592-4128-a77a-1a6db6fd81f5"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(7313), null, false, null, "Medical" },
                    { new Guid("72280df2-7d81-4ec6-936a-51e19aabf7ff"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(7317), null, false, null, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("2a84fe90-6605-4052-8a49-e7251af05754"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(4859), null, false, null, "Spain" },
                    { new Guid("afbcad66-1a0a-49f2-9e9c-2c61ded8ae08"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(5482), null, false, null, "Germany" },
                    { new Guid("72ec653b-aeb1-42fc-bcd1-153f005b1cd4"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(5493), null, false, null, "France" },
                    { new Guid("c4b3bb07-585f-412b-9f5f-f423928015d4"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(5497), null, false, null, "Lithuania" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02424b1b-8544-427e-b7bc-e868c8196f40"), "Admin" },
                    { new Guid("275a10a1-e965-460e-a965-e1fe2453e916"), "Employee" },
                    { new Guid("2d598edd-793a-4324-ac29-c505a5c790a5"), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("917f8117-d392-4f64-81fb-48415f80f77e"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(8393), null, false, null, "preparing" },
                    { new Guid("858ac364-d94f-414c-bbea-a0f5b8679b3d"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(9191), null, false, null, "on the way" },
                    { new Guid("84568d3c-04df-47c3-9ad8-216b1d664166"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(9205), null, false, null, "completed" },
                    { new Guid("b31754e2-82fc-4862-ad20-9331a87537eb"), new DateTime(2021, 4, 21, 23, 38, 28, 99, DateTimeKind.Utc).AddTicks(9205), null, false, null, "canceled" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("e99abf10-63e9-4212-9053-87cb1d80763e"), new Guid("2a84fe90-6605-4052-8a49-e7251af05754"), new DateTime(2021, 4, 21, 23, 38, 28, 97, DateTimeKind.Utc).AddTicks(2748), null, false, null, "Barcelona" },
                    { new Guid("e422b2de-f54d-4a4e-9259-0f3f4033f93d"), new Guid("afbcad66-1a0a-49f2-9e9c-2c61ded8ae08"), new DateTime(2021, 4, 21, 23, 38, 28, 97, DateTimeKind.Utc).AddTicks(4568), null, false, null, "Berlin" },
                    { new Guid("7fdbb1a0-9f76-4b63-aab4-901c61591336"), new Guid("72ec653b-aeb1-42fc-bcd1-153f005b1cd4"), new DateTime(2021, 4, 21, 23, 38, 28, 97, DateTimeKind.Utc).AddTicks(4597), null, false, null, "Paris" },
                    { new Guid("8bf95d78-e5ac-495d-ab67-14b60f644b70"), new Guid("c4b3bb07-585f-412b-9f5f-f423928015d4"), new DateTime(2021, 4, 21, 23, 38, 28, 97, DateTimeKind.Utc).AddTicks(4601), null, false, null, "Vilnius" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "StreetName" },
                values: new object[,]
                {
                    { new Guid("36049406-10ba-499d-916b-063422046239"), new Guid("e99abf10-63e9-4212-9053-87cb1d80763e"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(445), null, false, null, "Ramon Berenguer El Vell 1" },
                    { new Guid("5fd8c18f-6885-488e-af8c-ff06901a7d37"), new Guid("e99abf10-63e9-4212-9053-87cb1d80763e"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(1638), null, false, null, "Gran Via De Les Corts Catalanes 105" },
                    { new Guid("da703902-00bc-47da-b950-4fa730494d4e"), new Guid("e99abf10-63e9-4212-9053-87cb1d80763e"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(1645), null, false, null, "Passatge De Bocabella 11" },
                    { new Guid("ac2fee3a-f76e-4d94-aa42-d85b4bb45299"), new Guid("e422b2de-f54d-4a4e-9259-0f3f4033f93d"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(1612), null, false, null, "Zeughofstraße 20" },
                    { new Guid("b1347388-583d-4324-870a-e487e61ef483"), new Guid("7fdbb1a0-9f76-4b63-aab4-901c61591336"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(1630), null, false, null, "Rue La Boetie 7" },
                    { new Guid("97fa423a-a144-4d67-97f5-4211c2758dc5"), new Guid("8bf95d78-e5ac-495d-ab67-14b60f644b70"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(1634), null, false, null, "Liepkalnio 117" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "CreatedOn", "DeletedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"), new Guid("b1347388-583d-4324-870a-e487e61ef483"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(4303), null, "isabelle.huppert@gmail.com", "Isabelle", false, "Huppert", null },
                    { new Guid("5adb06fe-fca4-4347-b1ea-118c55e17331"), new Guid("97fa423a-a144-4d67-97f5-4211c2758dc5"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(6499), null, "lukas.petr@gmail.com", "Lukas", false, "Petrauskas", null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "CreatedOn", "DeletedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("d2c26c93-d589-4b05-850b-fbf21c59c84d"), new Guid("5fd8c18f-6885-488e-af8c-ff06901a7d37"), new DateTime(2021, 4, 21, 23, 38, 28, 101, DateTimeKind.Utc).AddTicks(674), null, "fer.trujillo@deliverit.com", "Fermin", false, "Trujillo", null },
                    { new Guid("e9a6b4e2-073b-4ebc-a248-a8d71d426174"), new Guid("da703902-00bc-47da-b950-4fa730494d4e"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(7538), null, "admin@deliverit.com", "Antonio", false, "Recio", null },
                    { new Guid("facdefb9-19df-42b3-9d3d-6524076e152f"), new Guid("da703902-00bc-47da-b950-4fa730494d4e"), new DateTime(2021, 4, 21, 23, 38, 28, 101, DateTimeKind.Utc).AddTicks(707), null, "a.rivas@deliverit.com", "Amador", false, "Rivas", null }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "AddressId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn" },
                values: new object[,]
                {
                    { new Guid("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba"), new Guid("36049406-10ba-499d-916b-063422046239"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(2662), null, false, null },
                    { new Guid("988a4201-8c55-42fc-b2a6-e08d1abe6693"), new Guid("ac2fee3a-f76e-4d94-aa42-d85b4bb45299"), new DateTime(2021, 4, 21, 23, 38, 28, 100, DateTimeKind.Utc).AddTicks(3286), null, false, null }
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                columns: new[] { "Id", "CustomerId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("e90608c8-9382-401c-ac2a-51b2c2c4528a"), new Guid("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"), new Guid("2d598edd-793a-4324-ac29-c505a5c790a5") },
                    { new Guid("8a631bc5-1bed-4555-8359-fc9815a84bc8"), new Guid("5adb06fe-fca4-4347-b1ea-118c55e17331"), new Guid("2d598edd-793a-4324-ac29-c505a5c790a5") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "EmployeeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("48bdf2fc-0090-489e-a7bb-027e37ad204e"), new Guid("d2c26c93-d589-4b05-850b-fbf21c59c84d"), new Guid("275a10a1-e965-460e-a965-e1fe2453e916") },
                    { new Guid("4abd3404-5295-4b7c-be0f-e6cd01ea4ba8"), new Guid("e9a6b4e2-073b-4ebc-a248-a8d71d426174"), new Guid("02424b1b-8544-427e-b7bc-e868c8196f40") },
                    { new Guid("dbce65ef-242f-44a7-982d-fd144014cd4d"), new Guid("facdefb9-19df-42b3-9d3d-6524076e152f"), new Guid("275a10a1-e965-460e-a965-e1fe2453e916") }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "ArrivalDate", "CreatedOn", "DeletedOn", "DepartureDate", "IsDeleted", "ModifiedOn", "StatusId", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("ce465c59-4866-4905-bdbd-943a26f59fdd"), new DateTime(2021, 4, 28, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(4371), new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(3824), null, new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(3824), false, null, new Guid("917f8117-d392-4f64-81fb-48415f80f77e"), new Guid("f15b5cf4-6eb6-4e5a-b84f-297e16c206ba") },
                    { new Guid("e2a2c29b-b7f4-458a-9cde-4a70717607c8"), new DateTime(2021, 4, 26, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(6122), new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(6114), null, new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(6114), false, null, new Guid("84568d3c-04df-47c3-9ad8-216b1d664166"), new Guid("988a4201-8c55-42fc-b2a6-e08d1abe6693") }
                });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CustomerId", "DeletedOn", "EmployeeId", "IsDeleted", "ModifiedOn", "ShipmentId", "Weight" },
                values: new object[] { new Guid("198457ae-236c-4592-90af-3ca2302a8737"), new Guid("1db0c76c-ab76-4105-be89-3af983f6f137"), new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(137), new Guid("c803ff6d-efb9-401a-81d8-7e9df0fcd4c1"), null, new Guid("d2c26c93-d589-4b05-850b-fbf21c59c84d"), false, null, new Guid("ce465c59-4866-4905-bdbd-943a26f59fdd"), 10 });

            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "CustomerId", "DeletedOn", "EmployeeId", "IsDeleted", "ModifiedOn", "ShipmentId", "Weight" },
                values: new object[] { new Guid("28ae32a1-10a4-4aef-b262-3baaa1102753"), new Guid("72280df2-7d81-4ec6-936a-51e19aabf7ff"), new DateTime(2021, 4, 21, 23, 38, 28, 102, DateTimeKind.Utc).AddTicks(2777), new Guid("5adb06fe-fca4-4347-b1ea-118c55e17331"), null, new Guid("facdefb9-19df-42b3-9d3d-6524076e152f"), false, null, new Guid("e2a2c29b-b7f4-458a-9cde-4a70717607c8"), 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoles_CustomerId",
                table: "CustomerRoles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRoles_RoleId",
                table: "CustomerRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_EmployeeId",
                table: "EmployeeRoles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRoles_RoleId",
                table: "EmployeeRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_CategoryId",
                table: "Parcels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_CustomerId",
                table: "Parcels",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_EmployeeId",
                table: "Parcels",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ShipmentId",
                table: "Parcels",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_StatusId",
                table: "Shipments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_WarehouseId",
                table: "Shipments",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AddressId",
                table: "Warehouses",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRoles");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
