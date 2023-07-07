using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_6_01.Domain.Model
{
    public class TypeSection
    {
        public string Code { get; set; } = String.Empty;
        public string NameInEnglish { get; set; } = String.Empty;
        public string NameInRussian { get; set; } = String.Empty;

        public List<GeoObjectType> GeoObjectTypes { get; set; } = new List<GeoObjectType>();
    }
}
