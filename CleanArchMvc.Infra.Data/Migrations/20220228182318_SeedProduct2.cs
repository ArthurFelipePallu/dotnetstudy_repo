using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProduct2 : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" 
            + "Values('Caderno espiral','Caderno espiral 100 folhas','7.45','50','caderno1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" 
            + "Values('Estojo escolar','Estojo escolar cinza','12.50','35','estojo1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" 
            + "Values('Lapiziera','Lapizeira 0.6 preta','15.39','120','lapizeira1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" 
            + "Values('Calculadora escolar','Calculadora simples','79.99','10','calculadora1.jpg',1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
