using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;


/// <summary>
/// Contains unit tests for the SaleValidator class.
/// Tests cover all field rules including required fields.
/// </summary>
public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    [Fact(DisplayName = "Valid sale should pass all validation rules")]
    public void Given_ValidSale_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty customer name should fail validation")]
    public void Given_EmptyCustomerName_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserName);
    }

    [Fact(DisplayName = "Empty branch name should fail validation")]
    public void Given_EmptyBranchName_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BranchName);
    }

    [Fact(DisplayName = "Empty UserId should fail validation")]
    public void Given_EmptyUserId_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.UserId);
    }

    [Fact(DisplayName = "Empty BranchId should fail validation")]
    public void Given_EmptyBranchId_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();
        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.BranchId);
    }

    [Fact(DisplayName = "Future sale date should fail validation")]
    public void Given_FutureSaleDate_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateInvalidSale();

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.SaleDate);
    }

    [Fact(DisplayName = "Empty items should fail validation")]
    public void Given_SaleWithNoItems_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            sale.AddItem(Guid.NewGuid(), "Produto", 0, 10));
    }
}