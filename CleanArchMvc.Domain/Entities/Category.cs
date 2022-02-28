using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get;private set; }
        public ICollection<Product> Products {get;set;}


        public Category(string name){
            ValidateDomain(name);
        }
        public Category(int id,string name){
            DomainExceptionValidation.When(id<0,"Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name) {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),"Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length<3,"Invalid name, too short , minimum 3 characters");
            DomainExceptionValidation.When(name.Length>50,"Invalid name, too long , maximum 50 characters");
            Name = name;

        }

    }
}