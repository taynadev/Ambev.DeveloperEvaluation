namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CreateSaleFromCart
{
    /// <summary>
    /// Represents the response after successfully creating a sale from a cart.
    /// </summary>
    public class CreateSaleFromCartResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Gets or sets the sale number.
        /// </summary>
        public long SaleNumber { get; set; }
    }
}
