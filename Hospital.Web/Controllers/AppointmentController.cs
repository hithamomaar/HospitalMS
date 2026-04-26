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
        [HttpGet]
        public IActionResult GetAvailableSchedules(int doctorId)
        {
            // بننادي على اللوجيك اللي في بروجكت الـ EF
            var schedules = appointmentService.GetDoctorAvailableSchedules(doctorId);

            // بنرجع الداتا كـ JSON عشان نختبر إن الربط شغال صح
            return Json(schedules);
            //return View();
        }
    }
}
