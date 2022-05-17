using System.ComponentModel.DataAnnotations;

namespace PptNemocnice.Api.Data
{
	public class Pracovnik
	{
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string JobTitle { get; set; } = string.Empty;

        public List<Ukon> Ukons { get; set; } = new();
    }
}

