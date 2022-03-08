using System;
namespace PptNemocnice
{
	public class VybaveniModel
	{
		public string? Name { get; set; }

		public DateTime BoughtDate { get; set; }

		public DateTime LastRevisionDate { get; set; }

		public bool NeedsRevision;
	}
}

