using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Test;

[TestClass]
public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create Category With Valid State")]
    public void CreateCategory_WithValidParameters()
    {
        Action action = () => new Category(1,"Category Name");
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
       
    }
   
   [Fact(DisplayName = "Create Category With Invalid Id")]
   public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
   {
        Action action = () => new Category(-1,"Category Name");
        action.Should()
                    .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id Value");
   }

   [Fact(DisplayName = "Create Category With Short Name")]
   public void CreateCategory_ShortNameValue_DomainExceptionShortName()
   {
        Action action = () => new Category(1,"Ca");
        action.Should()
                    .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name, too short , minimum 3 characters");
   }
   [Fact(DisplayName = "Create Category With Missing Name")]
   public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
   {
        Action action = () => new Category(1,"");
        action.Should()
                    .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid name.Name is required");
   }
   [Fact(DisplayName = "Create Category With Name Null")]
   public void CreateCategory_WithNullNameValue_DomainExceptionNullName()
   {
        Action action = () => new Category(1,null);
        action.Should()
                    .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
   }
}