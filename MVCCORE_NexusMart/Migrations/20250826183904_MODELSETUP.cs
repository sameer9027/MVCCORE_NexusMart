using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCORE_NexusMart.Migrations
{
    /// <inheritdoc />
    public partial class MODELSETUP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Admin",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Admin", x => x.Admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cart",
                columns: table => new
                {
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Prod_ID = table.Column<int>(type: "int", nullable: false),
                    Cart_Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cart", x => x.Cart_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Customer", x => x.Customer_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FAQs",
                columns: table => new
                {
                    FAQ_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FAQs", x => x.FAQ_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Feedback",
                columns: table => new
                {
                    Feedback_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback_Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Feed_msg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Feedback", x => x.Feedback_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<int>(type: "int", nullable: false),
                    Product_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Product", x => x.Product_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Admin");

            migrationBuilder.DropTable(
                name: "Tbl_Cart");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_Customer");

            migrationBuilder.DropTable(
                name: "Tbl_FAQs");

            migrationBuilder.DropTable(
                name: "Tbl_Feedback");

            migrationBuilder.DropTable(
                name: "Tbl_Product");
        }
    }
}
