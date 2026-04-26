using Hospital.Configurations;
using Hospital.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services
{
    public class DoctorService
    {
        private readonly HospitalContext context;

        public DoctorService(HospitalContext _context)
        {
            context = _context;
        }
        public async Task<List<Doctor>> GetDoctorsBySpecialtyAsync(int specialtyId)
        {
            return await context.Doctors
                .AsNoTracking() 
                .Where(d => d.SpecialtyId == specialtyId)
                .ToListAsync();
        }
    }
}
