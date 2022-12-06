using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCatalogAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoProdutos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    GrupoProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CatalogoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produtos_GrupoProdutos_GrupoProdutoId",
                        column: x => x.GrupoProdutoId,
                        principalTable: "GrupoProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CatalogoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoProdutos", x => new { x.CatalogoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_CatalogoProdutos_Catalogos_CatalogoId",
                        column: x => x.CatalogoId,
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogoProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "Id", "Nome", "Status" },
                values: new object[] { 1, "Sanduiches Tradicionais", true });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "Id", "Nome", "Status" },
                values: new object[] { 2, "Bebidas", true });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "Id", "Nome", "Status" },
                values: new object[] { 3, "Sobremesas", true });

            migrationBuilder.InsertData(
                table: "Catalogos",
                columns: new[] { "Id", "Nome", "Status" },
                values: new object[] { 4, "Promocional", false });

            migrationBuilder.InsertData(
                table: "GrupoProdutos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Sanduiche" });

            migrationBuilder.InsertData(
                table: "GrupoProdutos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Bebida" });

            migrationBuilder.InsertData(
                table: "GrupoProdutos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Sobremesa" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 1, null, "Hambuger, pão com gergelim, carne, presunto, muçarela, bacon, ovo, salsicha, alface, tomate, milho e Catupiry.", 1, "X-Tudo", true, 19.9m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 2, null, "Hambuger, pão com gergelim, carne, presunto, muçarela, bacon, ovo, alface, tomate, milho e Catupiry.", 1, "X-Especial", true, 17.9m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 3, null, "Hambuger, pão com gergelim, carne, presunto, muçarela, ovo, alface, tomate, milho e Catupiry.", 1, "X-Simples", true, 15.9m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 4, null, "Pão Francês, presunto, muçarela e ovo.", 1, "Misto Quente", true, 11.9m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 5, null, "Creme com leite condensado", 3, "Creme", true, 9.9m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CatalogoId", "Descricao", "GrupoProdutoId", "Nome", "Status", "Valor" },
                values: new object[] { 6, null, "Refrigerante Lara 350ml", 1, "Refrigerante Lata", true, 4.5m });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "CatalogoProdutos",
                columns: new[] { "CatalogoId", "ProdutoId" },
                values: new object[] { 3, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoProdutos_ProdutoId",
                table: "CatalogoProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CatalogoId",
                table: "Produtos",
                column: "CatalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_GrupoProdutoId",
                table: "Produtos",
                column: "GrupoProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoProdutos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Catalogos");

            migrationBuilder.DropTable(
                name: "GrupoProdutos");
        }
    }
}
