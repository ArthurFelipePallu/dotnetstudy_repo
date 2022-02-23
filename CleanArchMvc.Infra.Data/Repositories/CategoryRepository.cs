using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext=context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext .Add(category); // adciona ao banco de dados
            await _categoryContext.SaveChangesAsync(); // salva o banco de dados com a devida alteração
            return category;// retorna a categoria
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category); // remove do banco de dados
            await _categoryContext.SaveChangesAsync(); // salva o banco de dados com a devida alteração
            return category;// retorna a categoria
        }

        public async Task<Category> UpdateAsync(Category category)
        {
             _categoryContext.Update(category); // Atualiza a categoria com novos dados
            await _categoryContext.SaveChangesAsync(); // salva o banco de dados com a devida alteração
            return category;  // retorna a categoria
        }
    }
}