using System.Collections.Generic;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Repositories
{
    public interface IHospitalRepository
    {
        // Part 2 - CRUD
        void AddPatient(Patient patient);
        void AddDoctor(Doctor doctor);
        void BookAppointment(Appointment appointment);
        void CancelAppointment(int appointmentId);
        void AddPrescription(Prescription prescription);
        List<Doctor> GetAllDoctorsWithDepartment();
        List<Appointment> GetAppointmentHistory(int patientId); // Also for Part 4 SP? Keep separate or overload?

        // Part 3 - LINQ
        List<Doctor> GetDoctorsByDepartment(string departmentName);
        List<Appointment> GetAppointmentsForToday();
        List<Patient> GetPatientsAbove30();
        Dictionary<string, decimal> GetRevenuePerDoctor();
        Dictionary<string, int> GetCompletedAppointmentsCountPerDepartment();

        // Part 4 - Advanced
        List<Doctor> GetDoctorsPaged(int pageNumber, int pageSize);
        List<Appointment> GetPatientAppointmentHistoryStoredProc(int patientId);
        void UpdateAppointmentStatusConcurrencyAware(int appointmentId, string newStatus);
    }
}
