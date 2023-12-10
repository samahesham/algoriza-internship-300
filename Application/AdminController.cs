using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication9.Application
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // Sample data (you might replace this with a database)
        private static List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { Id = 1, Image = "image_url", FullName = "Dr. John Doe", Email = "john.doe@example.com", Phone = "123456789", Specialize = "Cardiologist", Gender = "Male", DateOfBirth = new DateTime(1980, 1, 1) },
            // Add more sample data as needed
        };

        [HttpGet("doctors")]
        public ActionResult<IEnumerable<Doctor>> GetAllDoctors(int page = 1, int pageSize = 10, string search = "")
        {
            // Implement logic to get doctors based on page, pageSize, and search
            var filteredDoctors = doctors
                .Where(d => d.FullName.Contains(search, StringComparison.OrdinalIgnoreCase))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(filteredDoctors);
        }

        [HttpGet("doctors/{id}")]
        public ActionResult<DoctorDetails> GetDoctorById(int id)
        {
            // Implement logic to get a doctor by id
            var doctor = doctors.Find(d => d.Id == id);

            if (doctor == null)
                return NotFound();

            var doctorDetails = new DoctorDetails
            {
                Image = doctor.Image,
                FullName = doctor.FullName,
                Email = doctor.Email,
                Phone = doctor.Phone,
                Specialize = doctor.Specialize,
                Gender = doctor.Gender,
                DateOfBirth = doctor.DateOfBirth,
                // Add more details as needed
            };

            return Ok(doctorDetails);
        }

        [HttpPost("doctors")]
        public ActionResult<bool> AddDoctor(Doctor doctor)
        {
            // Implement logic to add a new doctor
            // You might want to validate the input and generate a response accordingly

            // Generate a new unique ID for the doctor
            var newDoctorId = doctors.Max(d => d.Id) + 1;
            doctor.Id = newDoctorId;

            // For simplicity, let's just add the doctor to the list
            doctors.Add(doctor);

            return Ok(true);
        }

        [HttpPut("doctors/{id}")]
        public ActionResult<bool> EditDoctor(int id, Doctor doctor)
        {
            // Implement logic to edit an existing doctor
            // You might want to validate the input and generate a response accordingly

            var existingDoctor = doctors.Find(d => d.Id == id);

            if (existingDoctor == null)
                return NotFound();

            // For simplicity, let's just update the doctor's information
            existingDoctor.Image = doctor.Image;
            existingDoctor.FullName = doctor.FullName;
            existingDoctor.Email = doctor.Email;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.Specialize = doctor.Specialize;
            existingDoctor.Gender = doctor.Gender;
            existingDoctor.DateOfBirth = doctor.DateOfBirth;

            return Ok(true);
        }

        [HttpDelete("doctors/{id}")]
        public ActionResult<bool> DeleteDoctor(int id)
        {
            // Implement logic to delete a doctor
            // You might want to validate whether the doctor has any associated requests

            var doctorToDelete = doctors.Find(d => d.Id == id);

            if (doctorToDelete == null)
                return NotFound();

            // For simplicity, let's just remove the doctor from the list
            doctors.Remove(doctorToDelete);

            return Ok(true);
        }

        // Define other endpoints for patients, settings, etc.

        // Define classes for models
        public class Doctor
        {
            public int Id { get; set; }
            public string Image { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Specialize { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class DoctorDetails
        {
            public string Image { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Specialize { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            // Add more details as needed
        }
    }
}