namespace BlazorApp1.Models
{
    public class TypeSection
    {
        public string Code { get; set; } = String.Empty;
        public string NameInEnglish { get; set; } = String.Empty;
        public string NameInRussian { get; set; } = String.Empty;

        public List<GeoObjectType> GeoObjectTypes { get; set; } = new List<GeoObjectType>();
    }
}
