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
   
   [Fact(DisplayName = " Create Category Invalid Id")]
   public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
   {
        Action action = () => new Category(-1,"Category Name");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value");
   }

}