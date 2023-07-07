using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_6_01.Domain;
using WebAPI_6_01.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestGeoObjectTypeDb")
                .Options;

            _context = new Context(contextOptions);


            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public GeoObjectTypeRepository GeoObjectTypeRepository
        {
            get
            {
                return new GeoObjectTypeRepository(_context);
            }
        }
    }
}
