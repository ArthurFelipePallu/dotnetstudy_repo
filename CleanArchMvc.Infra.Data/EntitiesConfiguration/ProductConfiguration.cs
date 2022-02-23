using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Recurso da Fluent.API
            // HasKey
            // Identifica uma propriedade como chave primariana tabela de banco de dados
            builder.HasKey(t=>t.Id);
            // Recurso da Fluent.API
            // Property
            // Identifica uma propriedade da tabelade Banco de Dados e permite alterar seus settings

            // Recurso da Fluent.API
            // HasMaxLength
            // Altera a setting de qtd max de caracteres para um numero específico, min ou max

            // Recurso da Fluent.API
            // IsRequired
            // Implica que o valor da propriedade não pode ser nulo
            builder.Property(p=>p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p=>p.Description).HasMaxLength(200).IsRequired();

            // Recurso da Fluent.API
            // HasPrecision
            // Altera o setting de precisÂo de valores decimais em casas antes e depois da virgula
            builder.Property(p=>p.Price).HasPrecision(10,2);

            // Recurso da Fluent.API
            // HasOne
            // Configura que existe uma referencia que aponta a uma unica instãncia de outro tipo
            // Recurso da Fluent.API
            // WithMany
            // estabelece uma relação de um para muitos

            // Recurso da Fluent.API
            // HasForeignKey
            // Identifica a chave estrangeira para a relação
            builder.HasOne(e=>e.Category).WithMany(e=>e.Products).HasForeignKey(e=>e.CategoryId);
        }
    }
}