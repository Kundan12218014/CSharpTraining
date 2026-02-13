using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstApproach.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly HospitalDbContext _context;

        public HospitalRepository()
        {
            _context = new HospitalDbContext();
        }

        // --- Part 2: CRUD ---

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            Console.WriteLine("Patient added successfully.");
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            Console.WriteLine("Doctor added successfully.");
        }

        public void BookAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            Console.WriteLine("Appointment booked successfully.");
        }

        public void CancelAppointment(int appointmentId)
        {
            var appt = _context.Appointments.Find(appointmentId);
            if (appt != null)
            {
                appt.Status = "Cancelled";
                _context.SaveChanges();
                Console.WriteLine("Appointment cancelled.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        public void AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            Console.WriteLine("Prescription added.");
        }

        public List<Doctor> GetAllDoctorsWithDepartment()
        {
            return _context.Doctors.Include(d => d.Department).ToList();
        }

        public List<Appointment> GetAppointmentHistory(int patientId)
        {
            return _context.Appointments
                           .Where(a => a.PatientId == patientId)
                           .Include(a => a.Doctor)
                           .ToList();
        }

        // --- Part 3: LINQ Queries ---

        public List<Doctor> GetDoctorsByDepartment(string departmentName)
        {
            return _context.Doctors
                           .Where(d => d.Department.DepartmentName == departmentName)
                           .Include(d => d.Department)
                           .ToList();
        }

        public List<Appointment> GetAppointmentsForToday()
        {
            var today = DateTime.Today;
            return _context.Appointments
                           .Where(a => a.AppointmentDate.Date == today)
                           .Include(a => a.Doctor)
                           .Include(a => a.Patient)
                           .ToList();
        }

        public List<Patient> GetPatientsAbove30()
        {
            // Assuming DateOnly? DateOfBirth
            var thirtyYearsAgo = DateOnly.FromDateTime(DateTime.Today.AddYears(-30));
            return _context.Patients
                           .Where(p => p.DateOfBirth.HasValue && p.DateOfBirth.Value <= thirtyYearsAgo)
                           .ToList();
        }

        public Dictionary<string, decimal> GetRevenuePerDoctor()
        {
            // Assuming revenue = ConsultationFee for Completed appointments
            return _context.Appointments
                           .Where(a => a.Status == "Completed")
                           .GroupBy(a => a.Doctor.DoctorName)
                           .Select(g => new 
                           { 
                               DoctorName = g.Key, 
                               Revenue = g.Sum(x => x.Doctor.ConsultationFee) 
                           })
                           .ToDictionary(k => k.DoctorName, v => v.Revenue);
        }

        public Dictionary<string, int> GetCompletedAppointmentsCountPerDepartment()
        {
            return _context.Appointments
                           .Where(a => a.Status == "Completed")
                           .GroupBy(a => a.Doctor.Department.DepartmentName)
                           .Select(g => new
                           {
                               DepartmentName = g.Key,
                               Count = g.Count()
                           })
                           .ToDictionary(k => k.DepartmentName, v => v.Count);
        }

        // --- Part 4: Advanced ---

        public List<Doctor> GetDoctorsPaged(int pageNumber, int pageSize)
        {
            return _context.Doctors
                           .OrderBy(d => d.DoctorId)
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .Include(d => d.Department)
                           .ToList();
        }

        public List<Appointment> GetPatientAppointmentHistoryStoredProc(int patientId)
        {
            // Assuming a stored procedure named GetPatientHistory exists
            // Since User hasn't provided the SP definition, this is illustrative.
            // If SP is not created, this will fail at runtime.
            // I'll wrap it in a try-catch for demo purposes or explain.
            try
            {
                return _context.Appointments
                               .FromSqlRaw("EXEC GetPatientHistory {0}", patientId)
                               .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SP: {ex.Message}");
                // Fallback to LINQ if SP fails
                return GetAppointmentHistory(patientId);
            }
        }

        public void UpdateAppointmentStatusConcurrencyAware(int appointmentId, string newStatus)
        {
            try
            {
                var appt = _context.Appointments.Find(appointmentId);
                if (appt == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }

                // Simulate concurrency conflict by modifying the entity externally if needed,
                // but here we just update.
                appt.Status = newStatus;
                
                // Concurrency token on Status property (configured in DbContext) ensures
                // if Status changed in DB since retrieval, SaveChanges throws.
                _context.SaveChanges(); 
                Console.WriteLine("Status updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Concurrency conflict detected! Another user modified the data.");
                // Handle conflict: reload entity
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Appointment)
                    {
                        var databaseValues = entry.GetDatabaseValues();
                        var clientValues = entry.CurrentValues;
                        
                        Console.WriteLine("Database value: " + databaseValues["Status"]);
                        Console.WriteLine("Client value: " + clientValues["Status"]);
                        
                        // Decide which value to keep or merge. Here we simply inform user.
                    }
                }
            }
        }
    }
}
