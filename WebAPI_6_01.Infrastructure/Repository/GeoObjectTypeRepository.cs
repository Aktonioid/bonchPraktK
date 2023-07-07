using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_6_01.Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI_6_01.Domain.Model;

namespace WebAPI_6_01.Infrastructure
{
    public class GeoObjectTypeRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public GeoObjectTypeRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<GeoObjectType>> GetAllAsync()
        {
            return await _context.GeoObjectTypes.OrderBy(e => e.TypeSectionCode).ThenBy(e => e.Code).ToListAsync();
        }
        public async Task<List<GeoObjectType>> GetByTypeSectionCodeAsync(string tyeSectionCode)
        {
            return await _context.GeoObjectTypes.Where(e => e.TypeSectionCode == tyeSectionCode).OrderBy(e => e.Code).ToListAsync();
        }
        public async Task<GeoObjectType> GetByCodeAsync(string code)
        {
            return await _context.GeoObjectTypes.FindAsync(code);
        }
        public async Task AddAsync(GeoObjectType geoObjectType)
        {
            _context.GeoObjectTypes.Add(geoObjectType);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(GeoObjectType geoObjectType)
        {
            var existGeoObjectType = await _context.GeoObjectTypes.FindAsync(geoObjectType.Code);
            _context.Entry(existGeoObjectType).CurrentValues.SetValues(geoObjectType);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string code)
        {
            GeoObjectType geoObjectType = await _context.GeoObjectTypes.FindAsync(code);
            _context.Remove(geoObjectType);
            await _context.SaveChangesAsync();
        }

        public async Task AddTypeSectionAsync(TypeSection typeSection)
        {
            _context.TypeSections.Add(typeSection);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TypeSection>> GetAllTypeSectionsAsync()
        {
            return await _context.TypeSections.OrderBy(ts => ts.Code).ToListAsync();
        }

        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
