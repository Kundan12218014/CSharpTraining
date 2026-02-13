using System;
using DatabaseFirstApproach.Models;
using DatabaseFirstApproach.Repositories;

namespace DatabaseFirstApproach
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHospitalRepository repository = new HospitalRepository();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Hospital Management System ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. Cancel Appointment");
                Console.WriteLine("5. Add Prescription");
                Console.WriteLine("6. List Doctors (with Department)");
                Console.WriteLine("7. Patient Appointment History");
                Console.WriteLine("8. [LINQ] Doctors by Department");
                Console.WriteLine("9. [LINQ] Appointments Today");
                Console.WriteLine("10. [LINQ] Patients > 30 Years");
                Console.WriteLine("11. [LINQ] Revenue Per Doctor");
                Console.WriteLine("12. [LINQ] Completed Appointments per Dept");
                Console.WriteLine("13. [Advanced] Doctors Paging");
                Console.WriteLine("14. [Advanced] Update Status (Concurrency Check)");
                Console.WriteLine("15. [Advanced] Patient History (Stored Proc)");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPatient(repository);
                        break;
                    case "2":
                        AddDoctor(repository);
                        break;
                    case "3":
                        BookAppointment(repository);
                        break;
                    case "4":
                        CancelAppointment(repository);
                        break;
                    case "5":
                        AddPrescription(repository);
                        break;
                    case "6":
                        ListDoctors(repository);
                        break;
                    case "7":
                        PatientHistory(repository);
                        break;
                    case "8":
                        DoctorsByDept(repository);
                        break;
                    case "9":
                        AppointmentsToday(repository);
                        break;
                    case "10":
                        PatientsAbove30(repository);
                        break;
                    case "11":
                        RevenuePerDoctor(repository);
                        break;
                    case "12":
                        CompletedAppointmentsPerDept(repository);
                        break;
                    case "13":
                        DoctorsPaged(repository);
                        break;
                    case "14":
                        UpdateStatusConcurrency(repository);
                        break;
                    case "15":
                        PatientHistorySP(repository);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void PatientHistorySP(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Patient ID:");
            int pid = int.Parse(Console.ReadLine()!);
            var history = repo.GetPatientAppointmentHistoryStoredProc(pid);
            foreach(var h in history)
            {
                Console.WriteLine($"[SP] Appt ID: {h.AppointmentId}, Date: {h.AppointmentDate}, Status: {h.Status}");
            }
        }

        static void AddPatient(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Patient Name:");
            string name = Console.ReadLine()!;
            Console.WriteLine("Enter Gender (Male/Female):");
            string gender = Console.ReadLine()!;
            Console.WriteLine("Enter DoB (yyyy-mm-dd):");
            if(DateOnly.TryParse(Console.ReadLine(), out DateOnly dob))
            {
                var p = new Patient { PatientName = name, Gender = gender, DateOfBirth = dob };
                repo.AddPatient(p);
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        static void AddDoctor(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Doctor Name:");
            string name = Console.ReadLine()!;
            Console.WriteLine("Enter Specialization:");
            string spec = Console.ReadLine()!;
            Console.WriteLine("Enter Department ID:");
            int deptId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter Fee:");
            decimal fee = decimal.Parse(Console.ReadLine()!);

            var d = new Doctor { DoctorName = name, Specialization = spec, DepartmentId = deptId, ConsultationFee = fee };
            repo.AddDoctor(d);
        }

        static void BookAppointment(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Doctor ID:");
            int docId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter Patient ID:");
            int patId = int.Parse(Console.ReadLine()!);
            
            var appt = new Appointment 
            { 
                DoctorId = docId, 
                PatientId = patId, 
                AppointmentDate = DateTime.Now, 
                Status = "Scheduled" 
            };
            repo.BookAppointment(appt);
        }

        static void CancelAppointment(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Appointment ID to cancel:");
            int id = int.Parse(Console.ReadLine()!);
            repo.CancelAppointment(id);
        }

        static void AddPrescription(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Appointment ID:");
            int apptId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Diagnosis:");
            string diag = Console.ReadLine()!;
            Console.WriteLine("Medicines:");
            string meds = Console.ReadLine()!;
            Console.WriteLine("Remarks:");
            string rem = Console.ReadLine()!;

            var pre = new Prescription { AppointmentId = apptId, Diagnosis = diag, MedicineDetails = meds, Remarks = rem };
            repo.AddPrescription(pre);
        }

        static void ListDoctors(IHospitalRepository repo)
        {
            var doctors = repo.GetAllDoctorsWithDepartment();
            foreach(var d in doctors)
            {
                Console.WriteLine($"ID: {d.DoctorId}, Name: {d.DoctorName}, Dept: {d.Department.DepartmentName}, Fee: {d.ConsultationFee}");
            }
        }

        static void PatientHistory(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Patient ID:");
            int pid = int.Parse(Console.ReadLine()!);
            var history = repo.GetAppointmentHistory(pid);
            foreach(var h in history)
            {
                Console.WriteLine($"Appt ID: {h.AppointmentId}, Date: {h.AppointmentDate}, Doctor: {h.Doctor.DoctorName}, Status: {h.Status}");
            }
        }

        static void DoctorsByDept(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Department Name:");
            string dept = Console.ReadLine()!;
            var docs = repo.GetDoctorsByDepartment(dept);
            foreach(var d in docs)
                Console.WriteLine($" - {d.DoctorName} ({d.Specialization})");
        }

        static void AppointmentsToday(IHospitalRepository repo)
        {
            var appts = repo.GetAppointmentsForToday();
            Console.WriteLine($"Total Today: {appts.Count}");
            foreach(var a in appts)
                Console.WriteLine($"ID: {a.AppointmentId}, Patient: {a.Patient.PatientName}, Doctor: {a.Doctor.DoctorName}");
        }

        static void PatientsAbove30(IHospitalRepository repo)
        {
            var patients = repo.GetPatientsAbove30();
            foreach(var p in patients)
                Console.WriteLine($"ID: {p.PatientId}, Name: {p.PatientName}, DoB: {p.DateOfBirth}");
        }

        static void RevenuePerDoctor(IHospitalRepository repo)
        {
            var data = repo.GetRevenuePerDoctor();
            foreach(var kvp in data)
                Console.WriteLine($"Doctor: {kvp.Key}, Revenue: {kvp.Value}");
        }

        static void CompletedAppointmentsPerDept(IHospitalRepository repo)
        {
            var data = repo.GetCompletedAppointmentsCountPerDepartment();
            foreach(var kvp in data)
                Console.WriteLine($"Dept: {kvp.Key}, Completed Count: {kvp.Value}");
        }

        static void DoctorsPaged(IHospitalRepository repo)
        {
            Console.WriteLine("Page Number:");
            if(!int.TryParse(Console.ReadLine(), out int page)) page = 1;
            Console.WriteLine("Page Size:");
            if(!int.TryParse(Console.ReadLine(), out int size)) size = 2;

            var docs = repo.GetDoctorsPaged(page, size);
            foreach(var d in docs)
                Console.WriteLine($"[P{page}] {d.DoctorName} - {d.Specialization}");
        }

        static void UpdateStatusConcurrency(IHospitalRepository repo)
        {
            Console.WriteLine("Enter Appointment ID:");
            int id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter New Status:");
            string status = Console.ReadLine()!;
            
            repo.UpdateAppointmentStatusConcurrencyAware(id, status);
        }
    }
}
