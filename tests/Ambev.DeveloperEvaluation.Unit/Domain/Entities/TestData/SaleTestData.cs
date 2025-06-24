using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

// <summary>
/// Provides methods for generating test data for the Sale entity using the Bogus library.
/// Includes valid and invalid scenarios for comprehensive unit testing.
/// </summary>
public static class SaleTestData
{
    private static readonly Faker _faker = new();

    /// <summary>
    /// Generates a valid Sale with randomized data and items.
    /// </summary>
    /// <param name="itemsCount">The number of SaleItems to include in the sale.</param>
    /// <returns>A valid Sale entity populated with valid data.</returns>
    public static Sale GenerateValidSale(int itemsCount = 3)
    {
        var userId = Guid.NewGuid();
        var userName = _faker.Name.FullName();
        var branchId = Guid.NewGuid();
        var branchName = _faker.Company.CompanyName();
        var saleNumber = _faker.Random.Long(100000, 999999);

        var sale = new Sale(userId, userName, branchId, branchName);
       
        typeof(Sale)
            .GetProperty("SaleDate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            ?.SetValue(sale, DateTime.UtcNow.AddDays(-1));

        for (int i = 0; i < itemsCount; i++)
        {
            var item = GenerateValidSaleItem();
            sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
        }

        return sale;
    }

    /// <summary>
    /// Generates a Sale object with invalid data that violates SaleValidator rules:
    /// - Empty UserId
    /// - Empty Customer Name
    /// - SaleDate in the future
    /// - Empty BranchId
    /// - Empty BranchName
    /// - No items
    /// </summary>
    public static Sale GenerateInvalidSale()
    {
        var sale = new Sale(
            userId: Guid.Empty,         
            customerName: "",           
            branchId: Guid.Empty,       
            branchName: ""              
        );

        typeof(Sale)
            .GetProperty("SaleDate", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public)
            ?.SetValue(sale, DateTime.UtcNow.AddDays(1));

        return sale;
    }

    /// <summary>
    /// Generates a valid SaleItem with randomized product data.
    /// </summary>
    /// <returns>A valid SaleItem instance.</returns>
    public static SaleItem GenerateValidSaleItem()
    {
        return new SaleItem(
            productId: Guid.NewGuid(),
            productName: _faker.Commerce.ProductName(),
            quantity: _faker.Random.Int(1, 20),
            unitPrice: _faker.Random.Decimal(5m, 500m)
        );
    }

    /// <summary>
    /// Generates an invalid SaleItem with invalid quantity (e.g., 0 or > 20).
    /// </summary>
    /// <returns>A SaleItem with invalid data for negative testing.</returns>
    public static SaleItem GenerateInvalidSaleItem()
    {
        return new SaleItem(
            productId: Guid.NewGuid(),
            productName: "",
            quantity: _faker.Random.Bool() ? 0 : 25, 
            unitPrice: -1m 
        );
    }
}
