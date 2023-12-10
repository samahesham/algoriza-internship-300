namespace WebApplication9.Web
{
    public interface IPatientService
    {
        bool RegisterPatient(RegisterPatientRequest request);
        Patient GetPatientByEmailAndPassword(string email, string password);
        IEnumerable<PatientBooking> GetPatientBookings(int patientId);
        bool CancelBooking(int bookingId);
        bool IsEmailAlreadyRegistered(string email);

    }
}