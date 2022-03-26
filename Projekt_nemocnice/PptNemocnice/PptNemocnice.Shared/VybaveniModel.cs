using System;
using System.ComponentModel.DataAnnotations;
namespace PptNemocnice.Shared
{
	public class VybaveniModel
	{
		public Guid Id { get; set; }

		[Required, MinLength(5, ErrorMessage = "Délka u pole \"{0}\" musí být alespoň {1} znaků")]
		[Display(Name = "Název")]
		public string Name { get; set; } = "";

		public DateTime BoughtDate { get; set; }

		public DateTime LastRevisionDate { get; set; }

		public bool NeedsRevision => DateTime.Now - LastRevisionDate > TimeSpan.FromDays(365 * 2);

		public bool? IsInEditMode { get; set; }

        public double PriceCzk { get; set; }

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

        public static List<VybaveniModel> GetTestList()
        {
            List<VybaveniModel> list = new List<VybaveniModel>();

            Random random = new Random();

            DateTime RandomDateOne()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }

            DateTime RandomDateTwo(DateTime var)
            {
                int range = (DateTime.Today - var).Days;
                return var.AddDays(random.Next(range));
            }

            for (var j = 0; j < 6; j++)
            {
                int length = 16;
                var rString = "";

                for (var i = 0; i < length; i++)
                {
                    rString += ((char)(random.Next(1, 26) + 64)).ToString().ToLower();
                }

                DateTime date1 = RandomDateOne();
                DateTime date2 = RandomDateTwo(date1);

                list.Add(new VybaveniModel
                {
                    Id = Guid.NewGuid(),
                    Name = rString,
                    BoughtDate = date1,
                    LastRevisionDate = date2,
                    IsInEditMode = false,
                    PriceCzk = random.Next(5000, 10_000_000)
                }
            );
            }
            return list;
        }
	}

}

