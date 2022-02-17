using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Test
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid Parameters")]
        public void CreateProduct_WithValidParameters_ResultOjectValidState()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,99,"Product Image");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidId_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1,"Product Name","Product Description",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid Id, Id cannot be negative");
        }
        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_DomainExceptionNameTooShort()
        {
            Action action = () => new Product(1,"Pr","Product Description",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product name, name is null,empty or too short");
        }
        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyName_DomainExceptionNameEmpty()
        {
            Action action = () => new Product(1,"","Product Description",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product name, name is null,empty or too short");
        }
        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullName_DomainExceptionNameNull()
        {
            Action action = () => new Product(1,null,"Product Description",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product name, name is null,empty or too short");
        }
        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_DomainExceptionDescriptionTooShort()
        {
            Action action = () => new Product(1,"Product Name","Prod",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product description, description is null, empty or too short");
        }
        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainExceptionDescriptionEmpty()
        {
            Action action = () => new Product(1,"Product Name","",9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product description, description is null, empty or too short");
        }
        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_DomainExceptionDescriptionNull()
        {
            Action action = () => new Product(1,"Product Name",null,9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product description, description is null, empty or too short");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1,"Product Name","Product Description",-9.99m,99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product price, product price can't be negative");
        }
        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidStock_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,-99,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product stock, product stock can't be negative");
        }
        [Fact(DisplayName = "Create Product With Too Long Img Name")]
        public void CreateProduct_WithImageNameTooLong_DomainExceptionImgNameTooLong()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,99,"Product Image naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaammmmmmmmmmeeeeeeeeeeeeeeeeee iiiiiiiiiiisssssssssssssssss ttooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo lloooooooooooooooooooooooooooooooooooonggggg");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid image name, too long , maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Null Img Name")]
        public void CreateProduct_WithNullImageName_DomainExceptionNullImgName()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,99,null);
            action.Should()
                        .NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStock_DomainExceptionNegativeStock(int value)
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,value,"Product Image");
            action.Should()
                        .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                        .WithMessage("Invalid product stock, product stock can't be negative");
        }
    }
}