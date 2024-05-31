using AutoMapper;
using InkWell.Application.Dtos.Audit;
using InkWell.Application.Dtos.User;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.ObjectValues;
using Newtonsoft.Json;

namespace InkWell.Application.Mapper;

public class AuditMapper : AutoMapperProfile
{
	public AuditMapper()
	{
		CreateMap<AuditDetailsJsonDto, AuditDetailsJson>().ReverseMap();
		CreateMap<AuditDetailsJsonUpdatedFieldDto, AuditDetailsJsonUpdatedField>().ReverseMap();

		CreateMap<Audit, AuditDto>()
			.ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.EntityId))
			.ForMember(dest => dest.DetailsJson, opt => opt.MapFrom<AuditDetailsJsonResolver>())
			.ForMember(dest => dest.ExecutedBy, opt => opt.MapFrom(src => src.User))
			.ForMember(dest => dest.EntityType, opt => opt.MapFrom(src => Enum.GetName(typeof(eEntityType), src.EntityTypeId)))
			.ForMember(dest => dest.ActionType, opt => opt.MapFrom(src => Enum.GetName(typeof(eActionType), src.ActionTypeId)));
	}
}

public class AuditDetailsJsonResolver : IValueResolver<Audit, AuditDto, AuditDetailsJsonDto>
{
	public AuditDetailsJsonDto? Resolve(
		Audit source,
		AuditDto destination,
		AuditDetailsJsonDto destMember,
		ResolutionContext context)
	{
		if (!string.IsNullOrEmpty(source.DetailsJson))
		{
			return JsonConvert.DeserializeObject<AuditDetailsJsonDto>(source.DetailsJson);
		}
		return null;
	}
}