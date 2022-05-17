namespace PptNemocnice.Shared;

public class UkonModel
{
    public Guid Id { get; set; }

    public string Kod { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime DateTime { get; set; }

    public string PracovnikName { get; set; } = string.Empty;

}

