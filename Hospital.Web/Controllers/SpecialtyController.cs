using AutoMapper;
using Hospital.Services;
using Hospital.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class SpecialtyController: Controller
    {
        private readonly SpecialtyService specialtyService;
        private readonly IMapper mapper;
        public SpecialtyController(SpecialtyService _specialtyService, IMapper _mapper)
        {

            specialtyService = _specialtyService;
            mapper = _mapper;
        }
        public async Task<IActionResult> Index()
        {
            var specialties = await specialtyService.GetAllSpecialtiesAsync();

            var viewModels = mapper.Map<List<SpecialtyViewModel>>(specialties);

            return View(viewModels);
        }
    }
}
