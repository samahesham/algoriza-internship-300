namespace WebApplication9.Web
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);
        Doctor GetDoctorByEmail(string email);
        // Other methods
    }

    public interface IBookingService
    {
        IEnumerable<Booking> GetAllBookings(int doctorId, DateTime startDate, int pageSize, int pageNumber);
        bool ConfirmCheckUp(int bookingId);
        void DeleteBooking(Booking booking);

        // Other methods
    }
}
