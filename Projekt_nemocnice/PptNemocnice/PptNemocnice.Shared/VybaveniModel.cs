using System;
namespace PptNemocnice
{
	public class VybaveniModel
	{
		public string? Name { get; set; }

		public DateTime BoughtDate { get; set; }

		private DateTime _LastRevisionDate;

		public DateTime LastRevisionDate
		{
			get
			{
				return _LastRevisionDate;
			}

			set
			{
				_LastRevisionDate = value;
				if (_LastRevisionDate.AddYears(2) <= DateTime.Today)
				{
					NeedsRevision = true;
				}

			}
		}

		public bool? NeedsRevision;

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

