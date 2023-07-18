using BlazorApp1.Models;

namespace BlazorApp1.DTO
{
    public class TSDtoMapper
    {
        public static TSDto ToDto(TypeSection ts) 
        {

            string geoObjNames = "";
            foreach (var item in ts.GeoObjectTypes) 
            {
                geoObjNames += item.Code + " ";
            }

            geoObjNames.Trim();
            return new TSDto()
            {
                Code = ts.Code,
                geoObjectNames = geoObjNames,
                NameInEnglish = ts.NameInEnglish,
                NameInRussian = ts.NameInRussian
            };
        }
    }
}
