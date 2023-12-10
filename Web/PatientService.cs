using WebApplication9.Infrastructure;

namespace WebApplication9.Web
{
    public class PatientService : IPatientService
    {
        private readonly YourDbContext _dbContext;
        private readonly IBookingService _bookingService;

        public PatientService(YourDbContext dbContext, IBookingService bookingService)
        {
            _dbContext = dbContext;
            _bookingService = bookingService;
        }

        public bool CancelBooking(int bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                // Cancel the booking logic
                _bookingService.DeleteBooking(booking);
                return true;
            }
            return false;
        }

        public IEnumerable<PatientBooking> GetPatientBookings(int patientId)
        {
            var bookings = _dbContext.Bookings
                .Where(b => b.PatientId == patientId)
                .Select(b => new PatientBooking { Id = b.Id })
                .ToList();
            return bookings;
        }

        public Patient GetPatientByEmailAndPassword(string email, string password)
        {
            var patient = _dbContext.Patients.FirstOrDefault(p => p.Email == email && p.Password == password);
            return patient;
        }

        public bool IsEmailAlreadyRegistered(string email)
        {
            return _dbContext.Patients.Any(p => p.Email == email);
        }

        public bool RegisterPatient(RegisterPatientRequest request)
        {
            // Check if email is already registered
            if (IsEmailAlreadyRegistered(request.Email))
            {
                return false;
            }

            // Create and save the patient entity
            var patient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                // Set other properties as needed
            };
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();

            return true;
        }
    }
}