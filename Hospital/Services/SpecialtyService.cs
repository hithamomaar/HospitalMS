using Hospital.Configurations;
using Hospital.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services
{
    public class SpecialtyService
    {
        private readonly HospitalContext context;
        public SpecialtyService(HospitalContext _context)
        {
            context = _context;
        }
        public async Task<List<Specialty>> GetAllSpecialtiesAsync()
        {
            return await context.Specialties
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
