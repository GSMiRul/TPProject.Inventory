using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities;
public class Invoice : AuditIdentityEntity
{
    public string InvoiceNumber { get; set; }
    public Supplier SupplierOrder { get; set; } = new Supplier();
    public List<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public decimal GrandTotal { get; set; }
}
