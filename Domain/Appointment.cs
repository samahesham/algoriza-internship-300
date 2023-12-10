using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication9.Web;

namespace WebApplication9.Domain
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }

        public decimal Price { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public Doctor Doctor { get; set; }
        public string PatientName { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        // Other properties
    }

}
public class TimeSlot
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public bool IsBooked { get; set; }
    // ... other properties
}