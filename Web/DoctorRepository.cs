using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication9.Infrastructure;

namespace WebApplication9.Web
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly YourDbContext _dbContext;
        public IEnumerable<Doctor> SearchDoctors(string searchTerm, int page, int pageSize)
        {

            var query = _dbContext.Doctors.Include(d => d.Appointments).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(d => d.FirstName.Contains(searchTerm) || d.LastName.Contains(searchTerm));
            }

            // Implement pagination if needed
            var paginatedDoctors = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return paginatedDoctors;
        }
        public DoctorRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _dbContext.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _dbContext.Doctors.FindAsync(id);
        }

        public void AddDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _dbContext.Entry(doctor).State = EntityState.Modified;

        }

        public void DeleteDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Remove(doctor);
        }
        public Doctor GetDoctorByEmail(string email)
        {
            return _dbContext.Doctors.FirstOrDefault(d => d.Email == email);
        }
    }
}