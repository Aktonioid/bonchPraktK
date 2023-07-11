using WebAPI_6_01.Domain.Model;

namespace WebAPI_6_01.API.DTO
{
    public static class GeoObjectTypeDtoMapper
    {
        public static GeoObjectTypeDto ToDto(GeoObjectType geoObjectType) => new GeoObjectTypeDto
        {
            Id = geoObjectType.Id,
            Code = geoObjectType.Code,
            TypeSectionCode = geoObjectType.TypeSectionCode,
            NameInEnglish = geoObjectType.NameInEnglish,
            NameInRussian = geoObjectType.NameInRussian,
            DescriptionInEnglish = geoObjectType.DescriptionInEnglish,
            DescriptionInRussian = geoObjectType.DescriptionInRussian
        };

        public static GeoObjectType ToEntity(GeoObjectTypeDto geoObjectTypeDto) => new GeoObjectType
        {
            Id = geoObjectTypeDto.Id,
            Code = geoObjectTypeDto.Code,
            TypeSectionCode = geoObjectTypeDto.TypeSectionCode,
            NameInEnglish = geoObjectTypeDto.NameInEnglish,
            NameInRussian = geoObjectTypeDto.NameInRussian,
            DescriptionInEnglish = geoObjectTypeDto.DescriptionInEnglish,
            DescriptionInRussian = geoObjectTypeDto.DescriptionInRussian
        };

        public static List<GeoObjectTypeDto> ToDto(List<GeoObjectType> geoObjectTypes)
        {
            var geoObjectTypeDtos = new List<GeoObjectTypeDto>();
            foreach (GeoObjectType geoObjectType in geoObjectTypes)
            {
                geoObjectTypeDtos.Add(ToDto(geoObjectType));
            }
            return geoObjectTypeDtos;
        }

        public static List<GeoObjectType> ToEntity(List<GeoObjectTypeDto> geoObjectTypeDtos)
        {
            var entityTypes = new List<GeoObjectType>();
            foreach(var geoObjectTypeDto in geoObjectTypeDtos)
            {
                entityTypes.Add(ToEntity(geoObjectTypeDto));
            }
            return entityTypes;
        }
    }
}
