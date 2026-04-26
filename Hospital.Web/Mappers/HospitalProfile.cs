using AutoMapper;
using Hospital.models;
using Hospital.Web.ViewModels;

namespace Hospital.Web.Mappers
{
    public class HospitalProfile: Profile
    {
        public HospitalProfile()
        {
            CreateMap<Specialty, SpecialtyViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();  
        }
    }
}
