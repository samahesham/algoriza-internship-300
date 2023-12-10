using WebApplication9.Domain;

namespace WebApplication9.Web
{
    public class Doctor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime Appointment { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public int Price { get; set; }
        public List<Appointment> Appointments { get; set; }

        public string Password { get; set; }
        // Other properties
    }

    public class Booking
    {
        public int Id { get; set; }
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
        public DateTime Appointment { get; set; }
        // Other properties
    }

}
