using WebApplication9.Domain;
using WebApplication9.Web;

public interface IBookingService
{
    IEnumerable<Booking> GetAllBookings(int doctorId, DateTime startDate, int pageSize, int pageNumber);
    bool ConfirmCheckUp(int bookingId);
    Task<IEnumerable<Booking>> GetAllBookingsAsync();
    Task<Booking> GetBookingByIdAsync(int id);
    void AddBooking(Booking booking);
    void UpdateBooking(Booking booking);
    void DeleteBooking(Booking booking);

    // Add the following methods for managing appointments
    bool AddAppointment(Appointment appointment);
    bool UpdateAppointment(int appointmentId, Appointment appointment);
    bool DeleteAppointment(int appointmentId);

}