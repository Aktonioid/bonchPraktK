using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_6_01.Domain;
using WebAPI_6_01.Domain.Model;
using WebAPI_6_01.API.DTO;
using Xunit;
using WebAPI_6_01.Infrastructure;

namespace TestProject1
{
    public class TestDtoMapper
    {
        [Fact]
        public void TestGeoObjectTypeToDto()
        {
            var entity = GetTypeSection();

            var dto = TypeSectionDtoMapper.ToDto(entity);

            Assert.True(IsTypeSectionDtoEqual(GetTypeSectionDto(), dto));
        }

        [Fact]
        public void TestGeoObjecTypeToEntity()
        {
            var dto = GetTypeSectionDto();

            var entity = TypeSectionDtoMapper.ToEntity(dto);

            Assert.True(IsTypeSectionEqual(GetTypeSection(), entity));
        }

        private TypeSection GetTypeSection()
        {
            var typeSection = new TypeSection
            {
                Code = "A",
                NameInEnglish = "Country, state, region,...",
                NameInRussian = "Страны, регионы, территории"
            };

            GeoObjectType geoObjectType1 = new GeoObjectType
            {
                Code = "ADM1",
                TypeSectionCode = "A",
                NameInEnglish = "first-order administrative division",
                NameInRussian = "первичная административная единица страны, такая как штат в США",
                DescriptionInEnglish = "a primary administrative division of a country, such as a state in the United States",
                TypeSection = typeSection
            };
            
            GeoObjectType geoObjectType2 = new GeoObjectType
            {
                Code = "ADM1H",
                TypeSectionCode = "A",
                NameInEnglish = "historical first-order administrative division",
                NameInRussian = "бывшая административная единица первого порядка",
                DescriptionInEnglish = "a former first-order administrative division",
                TypeSection = typeSection
            };

            GeoObjectType geoObjectType3 = new GeoObjectType
            {
                Code = "ADM2",
                TypeSectionCode = "A",
                NameInEnglish = "second-order administrative division",
                NameInRussian = "подразделение административной единицы первого порядка",
                DescriptionInEnglish = "a subdivision of a first-order administrative division",
                TypeSection = typeSection
            };

            typeSection.GeoObjectTypes.Add(geoObjectType1);
            typeSection.GeoObjectTypes.Add(geoObjectType2);
            typeSection.GeoObjectTypes.Add(geoObjectType3);

            return typeSection;
        }

        private TypeSectionDto GetTypeSectionDto()
        {
            var typeSectionDto = new TypeSectionDto
            {
                Code = "A",
                NameInEnglish = "Country, state, region,...",
                NameInRussian = "Страны, регионы, территории"
            };

            var geoObjectTypeDto1 = new GeoObjectTypeDto
            {
                Code = "ADM1",
                TypeSectionCode = "A",
                NameInEnglish = "first-order administrative division",
                NameInRussian = "первичная административная единица страны, такая как штат в США",
                DescriptionInEnglish = "a primary administrative division of a country, such as a state in the United States"
            };

            var geoObjectTypeDto2 = new GeoObjectTypeDto
            {
                Code = "ADM1H",
                TypeSectionCode = "A",
                NameInEnglish = "historical first-order administrative division",
                NameInRussian = "бывшая административная единица первого порядка",
                DescriptionInEnglish = "a former first-order administrative division"
            };

            var geoObjectTypeDto3 = new GeoObjectTypeDto
            {
                Code = "ADM2",
                TypeSectionCode = "A",
                NameInEnglish = "second-order administrative division",
                NameInRussian = "подразделение административной единицы первого порядка",
                DescriptionInEnglish = "a subdivision of a first-order administrative division"
            };

            typeSectionDto.GeoObjectTypeDtos.Add(geoObjectTypeDto1);
            typeSectionDto.GeoObjectTypeDtos.Add(geoObjectTypeDto2);
            typeSectionDto.GeoObjectTypeDtos.Add(geoObjectTypeDto3);

            return typeSectionDto;
        }

        public bool IsGeoObjectTypeEqual(GeoObjectType obj1, GeoObjectType obj2)
        {
            var result = ((obj1.Code == obj2.Code) 
                && (obj1.TypeSectionCode == obj2.TypeSectionCode)
                && (obj1.NameInEnglish == obj2.NameInEnglish)
                && (obj1.NameInRussian == obj2.NameInRussian)
                && (obj1.DescriptionInEnglish == obj2.DescriptionInEnglish)) ? true : false;

           return result;
        }

        public bool IsGeoObjectTypeDtoEqual(GeoObjectTypeDto obj1, GeoObjectTypeDto obj2)
        {
            var result = ((obj1.Code == obj2.Code)
                && (obj1.TypeSectionCode == obj2.TypeSectionCode)
                && (obj1.NameInEnglish == obj2.NameInEnglish)
                && (obj1.NameInRussian == obj2.NameInRussian)
                && (obj1.DescriptionInEnglish == obj2.DescriptionInEnglish)) ? true : false;

            return result;
        }

        public bool IsTypeSectionEqual(TypeSection obj1, TypeSection obj2)
        {
            var result = ((obj1.Code == obj2.Code)
                && (obj1.NameInEnglish == obj2.NameInEnglish)
                && (obj1.NameInRussian == obj2.NameInRussian)) ? true : false;
            if (!result)
                return false;

            if (!(obj1.GeoObjectTypes.Count == obj2.GeoObjectTypes.Count))
                return false;

            for(int i = 0; i < obj1.GeoObjectTypes.Count; i++)
            {
               if(!IsGeoObjectTypeEqual(obj1.GeoObjectTypes[i], obj2.GeoObjectTypes[i]))
                    return false;
            }

            return true;
        }

        public bool IsTypeSectionDtoEqual(TypeSectionDto obj1, TypeSectionDto obj2)
        {
            var result = ((obj1.Code == obj2.Code)
                && (obj1.NameInEnglish == obj2.NameInEnglish)
                && (obj1.NameInRussian == obj2.NameInRussian)) ? true : false;
            if (!result)
                return false;

            if (!(obj1.GeoObjectTypeDtos.Count == obj2.GeoObjectTypeDtos.Count))
                return false;

            for (int i = 0; i < obj1.GeoObjectTypeDtos.Count; i++)
            {
                if (!IsGeoObjectTypeDtoEqual(obj1.GeoObjectTypeDtos[i], obj2.GeoObjectTypeDtos[i]))
                    return false;
            }

            return true;
        }
    }
}
