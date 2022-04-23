using System.ComponentModel.DataAnnotations;

namespace PptNemocnice.Api.Data;

public class Vybaveni
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public double PriceCzk { get; set; }

    public DateTime BoughtDate { get; set; }

    public DateTime LastRevisionDate { get; set; }
}

