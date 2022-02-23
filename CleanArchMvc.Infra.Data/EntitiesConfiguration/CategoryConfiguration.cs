using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
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


            // Recurso da Fluent.API
            // HasData
            // Popula a tabela Categories quando aplicar a migração
            builder.HasData(
                new Category(1,"Material Escolar"),
                new Category(2,"Eletrônicos"),
                new Category(3,"Acessórios")
            );
        }
    }
}