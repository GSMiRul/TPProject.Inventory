using Domain.Common;

namespace Domain.Entities;
public class Brand : BaseEntity
{
    public string? BarandName { get; set; }
    public string? ShortName { get; set; }
    public string? Summary { get; set; }
}
