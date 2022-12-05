﻿using AppointmentSchedulerUI.Repositories.Interfaces;
using AppointmentSchedulerUILibrary.AppointmentDTOs;
using AppointmentSchedulerUILibrary.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace AppointmentSchedulerUI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsEmployee(long id)
        {
            return View("DetailsEmployee", _appointmentService.FindById(id));
        }
        public IActionResult DetailsCustomer(long id)
        {
            return View("DetailsCustomer", _appointmentService.FindById(id));
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> SaveAppointment(CreateAppointmentDTO appointment)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterAccount", appointment);
            }
            var result = await _appointmentService.Save(appointment);
            if (result != null && result.IsSuccessStatusCode)
            {
                return View();
            }
            else
            {
/*                ModelState.AddModelError("ConfirmPassword", UIErrorMessages.AccountCreationFailed);
*/                //return View("Dashboard", appointment);
                return View();
            }
        }
    }
}
