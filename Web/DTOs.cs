namespace WebApplication9.Web
{
    public class DoctorDto
    {

        public string Image { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public decimal Price { get; set; }
        public string Gender { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }

    public class AppointmentDto
    {
        public string Day { get; set; }
        public List<TimeDto> Times { get; set; }
    }

    public class TimeDto
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public bool IsBooked { get; set; }

    }
}
