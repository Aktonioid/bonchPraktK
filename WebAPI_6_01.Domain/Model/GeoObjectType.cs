using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_6_01.Domain.Model
{
    public class GeoObjectType
    {
        public string Code { get; set; } = String.Empty;
        public string NameInEnglish { get; set; } = String.Empty;
        public string NameInRussian { get; set; } = String.Empty;
        public string DescriptionInEnglish { get; set; } = String.Empty;
        public string DescriptionInRussian { get; set; } = String.Empty;

        public string TypeSectionCode { get; set; } = String.Empty;
        public TypeSection TypeSection { get; set; } = null!;
    }
}
