using Domain.Common;
using Domain.Enums;
using System;

namespace Domain.Entities;
public class InvoiceDetail : AuditIdentityEntity
{
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = new Invoice();
    public Guid BrandId { get; set; }
    public Brand BrandProduct { get; set; } = new Brand();
    public Guid ProductId { get; set; }
    public Product ProductInfo { get; set; } = new Product();
    public string? SerialNumber { get; set; }
    public decimal? Cost { get; set; }
    public ProductState State { get; set; } = ProductState.Unavailable;
}
