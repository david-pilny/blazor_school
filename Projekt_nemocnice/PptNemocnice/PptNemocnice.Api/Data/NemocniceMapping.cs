using AutoMapper;
using PptNemocnice.Shared;

namespace PptNemocnice.Api.Data
{
	public class NemocniceMapping:Profile
	{
		public NemocniceMapping()
        {
			CreateMap<Vybaveni, VybaveniModel>().ReverseMap();

			CreateMap<Revize, RevizeModel>().ReverseMap();

			CreateMap<Revize, VybaveniSRevizemiModel>().ReverseMap();

			CreateMap<Ukon, UkonModel>().ReverseMap();
		}
	}
}