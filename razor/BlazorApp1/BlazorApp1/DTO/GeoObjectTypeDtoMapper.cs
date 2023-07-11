using BlazorApp1.Models ;

namespace BlazorApp1.Models
{
    public static class GeoObjectTypeDtoMapper
    {
        public static GeoObjectTypeDto ToDto(GeoObjectType geoObjectType) => new GeoObjectTypeDto
        {
            Code = geoObjectType.Code,
            TypeSectionCode = geoObjectType.TypeSectionCode,
            NameInEnglish = geoObjectType.NameInEnglish,
            NameInRussian = geoObjectType.NameInRussian,
            DescriptionInEnglish = geoObjectType.DescriptionInEnglish,
            DescriptionInRussian = geoObjectType.DescriptionInRussian
        };

        public static GeoObjectType ToEntity(GeoObjectTypeDto geoObjectTypeDto) => new GeoObjectType
        {
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
