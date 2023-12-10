using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication9.Infrastructure;

namespace WebApplication9.Web
{
    public class BookingService : IBookingService
    {
        private readonly YourDbContext _dbContext;

        public BookingService(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _dbContext.Bookings.FindAsync(id);
        }

        public void AddBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            _dbContext.Entry(booking).State = EntityState.Modified;
        }

        public void DeleteBooking(Booking booking)
        {
            _dbContext.Bookings.Remove(booking);
        }


        public IEnumerable<Booking> GetAllBookings(int doctorId, DateTime startDate, int pageSize, int pageNumber)
        {
            return _dbContext.Bookings
                .Where(b => b.DoctorId == doctorId && b.Appointment >= startDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public bool ConfirmCheckUp(int bookingId)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == bookingId);
            if (booking != null)
            {
                // Update the booking status or perform any necessary actions
                return true;
            }
            return false;
        }

    }
}