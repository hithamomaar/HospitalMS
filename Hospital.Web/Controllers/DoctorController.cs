using AutoMapper;
using Hospital.Services;
using Hospital.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class DoctorController: Controller
    {
        private readonly DoctorService doctorService;
        private readonly IMapper mapper;

        public DoctorController(DoctorService _doctorService, IMapper _mapper)
        {
            doctorService = _doctorService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index(int specialtyId)
        {
            var doctors = await doctorService.GetDoctorsBySpecialtyAsync(specialtyId);

            var viewModels = mapper.Map<List<DoctorViewModel>>(doctors);

            return View(viewModels);
        }
    }
}
