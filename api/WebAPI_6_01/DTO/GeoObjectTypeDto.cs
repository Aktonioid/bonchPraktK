﻿namespace WebAPI_6_01.API.DTO
{
    public class GeoObjectTypeDto
    {
        public string Id {get;set;} = String.Empty;
        public string Code { get; set; } = String.Empty;
        public string TypeSectionCode { get; set; } = String.Empty;
        public string NameInEnglish { get; set; } = String.Empty;
        public string NameInRussian { get; set; } = String.Empty;
        public string DescriptionInEnglish { get; set; } = String.Empty;
        public string DescriptionInRussian { get; set; } = String.Empty;
    }
}
