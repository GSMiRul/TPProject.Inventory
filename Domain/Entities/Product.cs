using Domain.Common;
using System;

namespace Domain.Entities;
public class Product : BaseEntity
{
    public string? ProductName { get; set; }

    public Guid? CategoryId { get; set; }
    public Category ProductCategory { get; set; } = new Category();
    public string? Description { get; set; }

}
