using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAservices.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class S5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Differences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Differences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionsDifferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifferencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsDifferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "serviceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifferenceDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifferencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifferenceDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifferenceDatas_Differences_DifferencesId",
                        column: x => x.DifferencesId,
                        principalTable: "Differences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DifferenceDatas_serviceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "serviceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_serviceRequests_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "serviceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionsDifferenceDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifferenceDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionsDifferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionsDifferenceDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionsDifferenceDatas_DifferenceDatas_DifferenceDataId",
                        column: x => x.DifferenceDataId,
                        principalTable: "DifferenceDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionsDifferenceDatas_OptionsDifferences_OptionsDifferenceId",
                        column: x => x.OptionsDifferenceId,
                        principalTable: "OptionsDifferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DifferenceDatas_DifferencesId",
                table: "DifferenceDatas",
                column: "DifferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_DifferenceDatas_ServiceRequestId",
                table: "DifferenceDatas",
                column: "ServiceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsDifferenceDatas_DifferenceDataId",
                table: "OptionsDifferenceDatas",
                column: "DifferenceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionsDifferenceDatas_OptionsDifferenceId",
                table: "OptionsDifferenceDatas",
                column: "OptionsDifferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ServiceId",
                table: "OrderDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ServiceRequestId",
                table: "orders",
                column: "ServiceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionsDifferenceDatas");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "DifferenceDatas");

            migrationBuilder.DropTable(
                name: "OptionsDifferences");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Differences");

            migrationBuilder.DropTable(
                name: "serviceRequests");
        }
    }
}
