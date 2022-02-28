using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;


namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name,string description,decimal price,int stock,string image){
            ValidateDomain(name,description,price,stock,image);
        }
       public Product(int id,string name,string description,decimal price,int stock,string image){
           DomainExceptionValidation.When(id<0,"Invalid Id, Id cannot be negative");
           Id=id;
            ValidateDomain(name,description,price,stock,image);
            
        }
        public Product()
        {}
        public void Update(string name,string desc,decimal preco,int stock,string img,int categoryid) {
            ValidateDomain(name,desc,preco,stock,img);

            CategoryId=categoryid;
        }

        private void ValidateDomain(string name,string desc,decimal preco,int stock,string img){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name) || name.Length<3,"Invalid product name, name is null,empty or too short");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(desc) || desc.Length<5,"Invalid product description, description is null, empty or too short");
            
            DomainExceptionValidation.When(preco<0,"Invalid product price, product price can't be negative");
            
            DomainExceptionValidation.When(stock<0,"Invalid product stock, product stock can't be negative");
            
            DomainExceptionValidation.When(img?.Length>250,"Invalid image name, too long , maximum 250 characters");
            Name=name;
            Description=desc;
            Price=preco;
            Name=name;
            Image=img;

        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}