using WebAPI_6_01.Domain.Model;

namespace WebAPI_6_01.API.DTO
{
    public static class TypeSectionDtoMapper
    {
        public static TypeSectionDto ToDto(TypeSection typeSection)
        {
            var typeSectionDto = new TypeSectionDto
            {
                Code = typeSection.Code,
                NameInEnglish = typeSection.NameInEnglish,
                NameInRussian = typeSection.NameInRussian
            };

            foreach(var geoObjectType in typeSection.GeoObjectTypes)
            {
                typeSectionDto.GeoObjectTypeDtos.Add(GeoObjectTypeDtoMapper.ToDto(geoObjectType));
            }

            return typeSectionDto;
        }


        public static TypeSection ToEntity(TypeSectionDto typeSectionDto)
        {
            var typeSection = new TypeSection
            {
                Code = typeSectionDto.Code,
                NameInEnglish = typeSectionDto.NameInEnglish,
                NameInRussian = typeSectionDto.NameInRussian
            };

            foreach(var geoObjectTypeDto in typeSectionDto.GeoObjectTypeDtos)
            {
                typeSection.GeoObjectTypes.Add(GeoObjectTypeDtoMapper.ToEntity(geoObjectTypeDto));
            }

            return typeSection;
        }

        public static List<TypeSectionDto> ToDto(List<TypeSection> typeSections)
        {
            var typeSectionDtos = new List<TypeSectionDto>();
            foreach(var typeSection in typeSections)
            {
                typeSectionDtos.Add(ToDto(typeSection));
            }

            return typeSectionDtos;
        }
    }
}
