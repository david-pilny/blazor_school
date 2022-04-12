using System;
using System.ComponentModel.DataAnnotations;
namespace PptNemocnice.Shared
{
    public class RevizeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";
    }

}
