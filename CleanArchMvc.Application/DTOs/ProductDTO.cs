using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id{get;set;}


        [Required(ErrorMessage ="The Name Is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get;  set; }

        [Required(ErrorMessage ="The Description Is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get;  set; }

        [Required(ErrorMessage ="The Price Is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DisplayName("Price")]
        public decimal Price { get;  set; }


        [Required(ErrorMessage ="The Stock Is Required")]
        [Range(1,999)]
        [DisplayName("Stock")]
        public int Stock { get;  set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get;  set; }

        [DisplayName("Categories")]
         public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}