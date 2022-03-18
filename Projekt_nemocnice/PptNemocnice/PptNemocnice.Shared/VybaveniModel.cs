using System;
namespace PptNemocnice
{
	public class VybaveniModel
	{
		public string? Name { get; set; }

		public DateTime BoughtDate { get; set; }

		public DateTime LastRevisionDate { get; set; }

		public bool NeedsRevision => DateTime.Now - LastRevisionDate > TimeSpan.FromDays(365 * 2);

		public bool? IsInEditMode { get; set; }

		public VybaveniModel Copy()
		{
			VybaveniModel to = new();
			to.BoughtDate = BoughtDate;
			to.LastRevisionDate = LastRevisionDate;
			to.IsInEditMode = IsInEditMode;
			to.Name = Name;
			return to;
		}

		public void MapTo(VybaveniModel? to)
		{
			if (to == null) return;
			to.BoughtDate = BoughtDate;
			to.LastRevisionDate = LastRevisionDate;
			to.Name = Name;
		}
	}

}

