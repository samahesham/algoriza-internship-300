using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using WebApplication9.Domain;
using WebApplication9.Web;
namespace WebApplication9.Application
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IBookingService _bookingService;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(ILogger<DoctorController> logger, IDoctorRepository doctorRepository, IBookingService bookingService)
        {
            _doctorRepository = doctorRepository;
            _bookingService = bookingService;
            _logger = logger;

        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                var doctor = _doctorRepository.GetDoctorByEmail(request.Email);

                if (doctor != null)
                {
                    return Ok(new ApiResponse<Doctor>
                    {
                        Data = doctor,
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
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(500, new ApiResponse<string>
                {
                    Message = "Internal Server Error"
                });
            }
        }

        [HttpGet("bookings")]
        public IActionResult GetBookings(int doctorId, DateTime startDate, int pageSize, int pageNumber)
        {
            var bookings = _bookingService.GetAllBookings(doctorId, startDate, pageSize, pageNumber);
            return Ok(bookings);
        }

        [HttpPost("confirm-checkup")]
        public IActionResult ConfirmCheckUp(int bookingId)
        {
            var result = _bookingService.ConfirmCheckUp(bookingId);
            if (result)
            {
                return Ok("Checkup confirmed successfully");
            }
            else
            {
                return BadRequest("Unable to confirm checkup");
            }
        }

    }
}
