using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.Commands.CancelSale
{
    /// <summary>
    /// Result returned after cancelling a sale.
    /// </summary>
    public class CancelSaleResult
    {
        /// <summary>
        /// Gets or sets the ID of the canceled sale.
        /// </summary>
        public Guid SaleId { get; set; }
    }
}
