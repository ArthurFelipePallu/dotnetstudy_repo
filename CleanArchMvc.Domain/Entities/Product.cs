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

        public Product(string name,string desc,decimal preco,int stock,string img){
            ValidateDomain(name,desc,preco,stock,img);
        }
       public Product(int id,string name,string desc,decimal preco,int stock,string img){
           DomainExceptionValidation.When(id<0,"Invalid Id, Id cannot be negative");
           Id=id;
            ValidateDomain(name,desc,preco,stock,img);
        }
        public void Update(string name,string desc,decimal preco,int stock,string img,int categoryid) {
            ValidateDomain(name,desc,preco,stock,img);
            CategoryId=categoryid;
        }

        private void ValidateDomain(string name,string desc,decimal preco,int stock,string img){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name) && name.Length<3,"Invalid product name, name is null or too short");
            Name=name;
            DomainExceptionValidation.When(string.IsNullOrEmpty(desc) && desc.Length<5,"Invalid product description, description is null or too short");
            Description=desc;
            DomainExceptionValidation.When(preco<0,"Invalid product price, product price can't be negative");
            Price=preco;
            DomainExceptionValidation.When(stock<0,"Invalid product stock, product stock can't be negative");
            Name=name;
            DomainExceptionValidation.When( img.Length>250,"Invalid image name, too long , maximum 250 characters");
            Image=img;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}