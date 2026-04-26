using Hospital.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentService appointmentService;
        public AppointmentController(AppointmentService _appointmentService)
        {
            appointmentService = _appointmentService;
        }
    }
}
