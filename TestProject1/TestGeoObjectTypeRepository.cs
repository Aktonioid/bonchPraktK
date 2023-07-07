using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebAPI_6_01.Domain;
using WebAPI_6_01.Domain.Model;

namespace TestProject1
{
    public class TestGeoObjectTypeRepository
    {
        [Fact]
        public void VoidTest()
        {
            var testHelper = new TestHelper();
            var geoObjectTypeRepository = testHelper.GeoObjectTypeRepository;
        }

        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            var geoObjectTypeRepository = testHelper.GeoObjectTypeRepository;

            var typeSection = new TypeSection
            {
                Code = "A",
                NameInEnglish = "Country, state, region,...",
                NameInRussian = "Страны, регионы, территории"
            };
            geoObjectTypeRepository.AddTypeSectionAsync(typeSection).Wait();
            geoObjectTypeRepository.ChangeTrackerClear();

            GeoObjectType geoObjectType1 = new GeoObjectType 
            { 
                Code = "ADM1", 
                TypeSectionCode = "A", 
                NameInEnglish = "first-order administrative division",
                NameInRussian = "первичная административная единица страны, такая как штат в США",
                DescriptionInEnglish = "a primary administrative division of a country, such as a state in the United States",
                DescriptionInRussian = "Главная административная единица: страна, штат в США"
            };
            geoObjectTypeRepository.AddAsync(geoObjectType1).Wait();

            GeoObjectType geoObjectType2 = new GeoObjectType
            {
                Code = "ADM1H",
                TypeSectionCode = "A",
                NameInEnglish = "historical first-order administrative division",
                NameInRussian = "бывшая административная единица первого порядка",
                DescriptionInEnglish = "a former first-order administrative division"
            };
            geoObjectTypeRepository.AddAsync(geoObjectType2).Wait();

            GeoObjectType geoObjectType3 = new GeoObjectType
            {
                Code = "ADM2",
                TypeSectionCode = "A",
                NameInEnglish = "second-order administrative division",
                NameInRussian = "подразделение административной единицы первого порядка",
                DescriptionInEnglish = "a subdivision of a first-order administrative division"
            };
            geoObjectTypeRepository.AddAsync(geoObjectType3).Wait();

            Assert.Equal("ADM1", geoObjectTypeRepository.GetByCodeAsync("ADM1").Result.Code);
            Assert.True(geoObjectTypeRepository.GetAllAsync().Result.Count == 3);
            Assert.Equal("historical first-order administrative division", geoObjectTypeRepository.GetByCodeAsync("ADM1H").Result.NameInEnglish);
        }
    }
}
