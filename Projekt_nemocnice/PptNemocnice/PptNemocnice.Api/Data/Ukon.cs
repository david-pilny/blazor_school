using System.ComponentModel.DataAnnotations;

namespace PptNemocnice.Api.Data;

public class Ukon
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public Guid VybaveniId { get; set; }

    public Vybaveni Vybaveni { get; set; } = null!;

}


