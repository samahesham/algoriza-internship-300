using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication9.Domain;
using WebApplication9.Web;

namespace WebApplication9.Application
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;
        private readonly IDoctorRepository _doctorRepository;  // Add this line

        public PatientController(ILogger<PatientController> logger, IPatientService patientService, IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;  // Add this line

            _patientService = patientService;
            _logger = logger;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        public IActionResult Register([FromBody] RegisterPatientRequest request)
        {
            try
            {
                // Validate the request
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Message = "Invalid registration data"
                    });
                }

                // Register the patient
                var result = _patientService.RegisterPatient(request);

                if (result)
                {
                    return Ok(new ApiResponse<string>
                    {
                        Message = "Patient registration successful"
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Message = "Patient registration failed"
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during patient registration");
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    Message = "Internal server error"
                });
            }
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Patient>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<string>))]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            try
            {
                var patient = _patientService.GetPatientByEmailAndPassword(request.Email, request.Password);

                if (patient != null)
                {
                    return Ok(new ApiResponse<Patient>
                    {
                        Data = patient,
                        Message = "Login successful"
                    });
                }
                else
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Message = "Login failed"
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login");
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<string>
                {
                    Message = "Internal server error"
                });
            }
        }

        [HttpGet("bookings")]
        public IActionResult GetPatientBookings(int patientId)
        {
            var bookings = _patientService.GetPatientBookings(patientId);
            return Ok(bookings);
        }

        [HttpPost("cancel-booking")]
        public IActionResult CancelBooking(int bookingId)
        {
            var result = _patientService.CancelBooking(bookingId);

            if (result)
            {
                return Ok("Booking canceled successfully");
            }
            else
            {
                return BadRequest("Unable to cancel booking");
            }
        }
    }
}