using WebAPI_6_01.Domain.Model;

namespace WebAPI_6_01.API.DTO
{
    public class TypeSectionDto
    {
        
        public string Code { get; set; } = String.Empty;
        public string NameInEnglish { get; set; } = String.Empty;
        public string NameInRussian { get; set; } = String.Empty;

        public List<GeoObjectTypeDto> GeoObjectTypes { get; set; } = new List<GeoObjectTypeDto>();
    }
}
