using System;
using System.ComponentModel.DataAnnotations;
namespace PptNemocnice.Shared
{
    public class VybaveniSRevizemiModel
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }

        public Guid VybaveniId { get; set; }

    }



}
