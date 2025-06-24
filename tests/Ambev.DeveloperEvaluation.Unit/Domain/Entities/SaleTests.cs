using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover cancellation logic, item addition, and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that validation passes when the Sale entity has valid data.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSale_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when required fields are missing.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data")]
    public void Given_InvalidSale_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = new Sale(Guid.Empty, "", Guid.Empty, "");

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that adding a sale item correctly reflects in the Items collection.
    /// </summary>
    [Fact(DisplayName = "Adding item should increase item count and affect total")]
    public void Given_Sale_When_AddItem_Then_ItemShouldBeAdded()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(0);
        var item = SaleTestData.GenerateValidSaleItem();

        // Act
        sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);

        // Assert
        Assert.Single(sale.Items);
        Assert.Equal(item.TotalAmount, sale.TotalAmount);
    }

    /// <summary>
    /// Tests that total with discount includes the correct logic for item quantity.
    /// </summary>
    [Fact(DisplayName = "Total amount with discount should reflect item discounts")]
    public void Given_SaleWithItems_When_CalculatingTotalWithDiscount_Then_ResultShouldBeCorrect()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(1);
        var item = sale.Items.First();

        // Act
        var expected = item.TotalAmountWithDiscount;

        // Assert
        Assert.Equal(expected, sale.TotalAmountWithDiscount);
    }

    /// <summary>
    /// Tests that cancelling a sale marks the sale and all items as canceled.
    /// </summary>
    [Fact(DisplayName = "Cancelling a sale should mark sale and items as canceled")]
    public void Given_SaleWithItems_When_Cancel_Then_AllItemsShouldBeCanceled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(2);

        // Act
        sale.Cancel();

        // Assert
        Assert.True(sale.IsCanceled);
        Assert.All(sale.Items, i => Assert.True(i.IsCanceled));
    }

    /// <summary>
    /// Tests that cancelling an individual item marks only that item as canceled.
    /// </summary>
    [Fact(DisplayName = "Cancelling a single item should mark only that item as canceled")]
    public void Given_SaleWithMultipleItems_When_CancelItem_Then_OnlyThatItemShouldBeCanceled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(2);
        var itemToCancel = sale.Items.First();

        // Act
        sale.CancelItem(itemToCancel.Id);

        // Assert
        Assert.True(itemToCancel.IsCanceled);
        Assert.Contains(itemToCancel, sale.Items);
        Assert.Contains(sale.Items, i => !i.IsCanceled && i.Id != itemToCancel.Id);
    }

    /// <summary>
    /// Tests that adding items to a cancelled sale throws an exception.
    /// </summary>
    [Fact(DisplayName = "Adding item to cancelled sale should throw exception")]
    public void Given_CancelledSale_When_AddItem_Then_ShouldThrowException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(0);
        sale.Cancel();
        var item = SaleTestData.GenerateValidSaleItem();

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() =>
            sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice)
        );

        Assert.Equal("Cannot add item to a cancelled sale", ex.Message);
    }

    /// <summary>
    /// Tests that cancelling a nonexistent item throws an exception.
    /// </summary>
    [Fact(DisplayName = "Cancelling non-existent item should throw exception")]
    public void Given_Sale_When_CancelInvalidItem_Then_ShouldThrowException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() =>
            sale.CancelItem(Guid.NewGuid())
        );

        Assert.Equal("Item not found", ex.Message);
    }
}
