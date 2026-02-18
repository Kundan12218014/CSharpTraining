using System.Globalization;

namespace HospitalManagementSystem03;

public static class Program
{
	public static void Main(string[] args)
	{
		var hospital = new HospitalService();

		var doctors = SeedDoctors();
		var patients = SeedPatients();

		foreach (var d in doctors)
		{
			hospital.AddDoctor(d);
		}

		foreach (var p in patients)
		{
			hospital.AddPatient(p);
		}

		SeedAppointmentsAndRecords(hospital, doctors, patients);

		Console.WriteLine("=== Appointment Report ===");
		hospital.ExportAppointmentReport();
		Console.WriteLine();

		Console.WriteLine("=== LINQ Tasks ===");

		var busyDocs = hospital.GetDoctorsWithMoreThanNAppointments(10);
		Console.WriteLine($"Doctors with > 10 appointments: {string.Join(", ", busyDocs.Select(d => d.DisplayName))}");

		var recentPatients = hospital.GetPatientsTreatedInLastDays(30);
		Console.WriteLine($"Patients treated in last 30 days: {string.Join(", ", recentPatients.Select(p => p.DisplayName))}");

		Console.WriteLine("Appointments grouped by doctor:");
		foreach (var group in hospital.GroupAppointmentsByDoctor())
		{
			Console.WriteLine($"  {group.Doctor.DisplayName}: {group.Appointments.Count} appointment(s)");
		}

		var topEarners = hospital.GetTopHighestEarningDoctors(3);
		Console.WriteLine("Top 3 highest earning doctors:");
		foreach (var item in topEarners)
		{
			Console.WriteLine($"  {item.Doctor.DisplayName} - {item.TotalEarnings.ToString("C", CultureInfo.CurrentCulture)}");
		}

		var disease = "Flu";
		var fluPatients = hospital.GetPatientsByDisease(disease);
		Console.WriteLine($"Patients by disease '{disease}': {string.Join(", ", fluPatients.Select(p => p.DisplayName))}");

		var revenue = hospital.CalculateTotalRevenue();
		Console.WriteLine($"Total revenue generated: {revenue.ToString("C", CultureInfo.CurrentCulture)}");

		Console.WriteLine();
		Console.WriteLine("=== Projections (Select new) ===");
		var projected = hospital.GetAppointmentProjections();
		foreach (var row in projected.Take(8))
		{
			Console.WriteLine($"  #{row.AppointmentId} | {row.When:yyyy-MM-dd HH:mm} | Dr {row.Doctor} | {row.Patient} | {row.Disease} | {row.Bill.ToString("C", CultureInfo.CurrentCulture)}");
		}
	}

	private static List<Doctor> SeedDoctors() =>
	[
		new Doctor(1, "Aarav", "Sharma", 42) { Specialty = "Cardiology", FeePerAppointment = 1000m, CommissionRate = 0.70m },
		new Doctor(2, "Diya", "Patel", 37) { Specialty = "General Medicine", FeePerAppointment = 600m, CommissionRate = 0.65m },
		new Doctor(3, "Ishaan", "Verma", 45) { Specialty = "Orthopedics", FeePerAppointment = 900m, CommissionRate = 0.72m },
		new Doctor(4, "Meera", "Nair", 33) { Specialty = "Pediatrics", FeePerAppointment = 700m, CommissionRate = 0.68m },
		new Doctor(5, "Kabir", "Singh", 50) { Specialty = "Dermatology", FeePerAppointment = 800m, CommissionRate = 0.66m },
	];

	private static List<Patient> SeedPatients() =>
	[
		new Patient(101, "Rohan", "Kumar", 29) { Phone = "999-000-1111" },
		new Patient(102, "Anaya", "Gupta", 24) { Phone = "999-000-2222" },
		new Patient(103, "Vivaan", "Joshi", 36) { Phone = "999-000-3333" },
		new Patient(104, "Sara", "Ali", 31) { Phone = "999-000-4444" },
		new Patient(105, "Arjun", "Das", 41) { Phone = "999-000-5555" },
		new Patient(106, "Neha", "Roy", 27) { Phone = "999-000-6666" },
		new Patient(107, "Aditya", "Malhotra", 34) { Phone = "999-000-7777" },
		new Patient(108, "Pooja", "Iyer", 22) { Phone = "999-000-8888" },
		new Patient(109, "Karan", "Bajaj", 39) { Phone = "999-000-9999" },
		new Patient(110, "Ira", "Kapoor", 28) { Phone = "999-000-0000" },
	];

	private static void SeedAppointmentsAndRecords(HospitalService hospital, List<Doctor> doctors, List<Patient> patients)
	{
		var now = DateTime.Now;
		var apptId = 1;

		for (var i = 0; i < 12; i++)
		{
			hospital.ScheduleAppointment(new Appointment(
				id: apptId++,
				doctorId: doctors[1].Id,
				patientId: patients[i % patients.Count].Id,
				start: now.Date.AddDays(-i).AddHours(10).AddMinutes(i * 30),
				duration: TimeSpan.FromMinutes(30),
				disease: i % 3 == 0 ? "Flu" : (i % 3 == 1 ? "Fever" : "Back Pain")));
		}

		hospital.ScheduleAppointment(new Appointment(apptId++, doctors[0].Id, patients[0].Id, now.AddDays(-5).Date.AddHours(9), TimeSpan.FromMinutes(45), "Hypertension"));
		hospital.ScheduleAppointment(new Appointment(apptId++, doctors[0].Id, patients[1].Id, now.AddDays(-40).Date.AddHours(11), TimeSpan.FromMinutes(45), "Flu"));
		hospital.ScheduleAppointment(new Appointment(apptId++, doctors[2].Id, patients[2].Id, now.AddDays(-2).Date.AddHours(14), TimeSpan.FromMinutes(30), "Fracture"));
		hospital.ScheduleAppointment(new Appointment(apptId++, doctors[3].Id, patients[3].Id, now.AddDays(-15).Date.AddHours(16), TimeSpan.FromMinutes(30), "Flu"));
		hospital.ScheduleAppointment(new Appointment(apptId++, doctors[4].Id, patients[4].Id, now.AddDays(-1).Date.AddHours(12), TimeSpan.FromMinutes(30), "Dermatitis"));

		try
		{
			hospital.ScheduleAppointment(new Appointment(apptId++, doctors[1].Id, patients[5].Id, now.Date.AddDays(-1).AddHours(10).AddMinutes(30), TimeSpan.FromMinutes(30), "Flu"));
		}
		catch (InvalidAppointmentException ex)
		{
			Console.WriteLine($"[Expected] Overlap prevented: {ex.Message}");
			Console.WriteLine();
		}

		hospital.AddMedicalRecord(new MedicalRecord(10001, patients[0].Id, doctors[1].Id, "Flu", "Medication", now.AddDays(-10)));
		hospital.AddMedicalRecord(new MedicalRecord(10002, patients[2].Id, doctors[2].Id, "Fracture", "Cast", now.AddDays(-2)));
		hospital.AddMedicalRecord(new MedicalRecord(10003, patients[3].Id, doctors[3].Id, "Flu", "Rest", now.AddDays(-15)));

		try
		{
			hospital.AddMedicalRecord(new MedicalRecord(10003, patients[4].Id, doctors[4].Id, "Dermatitis", "Ointment", now.AddDays(-1)));
		}
		catch (DuplicateMedicalRecordException ex)
		{
			Console.WriteLine($"[Expected] Duplicate record prevented: {ex.Message}");
			Console.WriteLine();
		}
	}
}

public abstract class Person
{
	protected Person(int id, string firstName, string lastName, int age)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Age = age;
	}

	public int Id { get; }
	public string FirstName { get; }
	public string LastName { get; }
	public int Age { get; }
	public string DisplayName => $"{FirstName} {LastName}";
}

public interface IBillable
{
	decimal CalculateBill(Appointment appointment);
}

public sealed class Doctor : Person, IBillable
{
	public Doctor(int id, string firstName, string lastName, int age) : base(id, firstName, lastName, age)
	{
	}

	public string Specialty { get; set; } = "General";
	public decimal FeePerAppointment { get; set; } = 500m;
	public decimal CommissionRate { get; set; } = 0.70m;

	public decimal CalculateBill(Appointment appointment)
	{
		var multiplier = appointment.Disease switch
		{
			"Fracture" => 1.30m,
			"Hypertension" => 1.20m,
			_ => 1.00m
		};

		return Math.Round(FeePerAppointment * multiplier, 2, MidpointRounding.AwayFromZero);
	}

	public decimal CalculateEarnings(IEnumerable<Appointment> appointments)
		=> Math.Round(appointments.Sum(a => CalculateBill(a)) * CommissionRate, 2, MidpointRounding.AwayFromZero);
}

public sealed class Patient : Person
{
	public Patient(int id, string firstName, string lastName, int age) : base(id, firstName, lastName, age)
	{
	}

	public string Phone { get; set; } = string.Empty;
}

public sealed class Appointment
{
	public Appointment(int id, int doctorId, int patientId, DateTime start, TimeSpan duration, string disease)
	{
		Id = id;
		DoctorId = doctorId;
		PatientId = patientId;
		Start = start;
		Duration = duration;
		Disease = disease;
	}

	public int Id { get; }
	public int DoctorId { get; }
	public int PatientId { get; }
	public DateTime Start { get; }
	public TimeSpan Duration { get; }
	public string Disease { get; }
	public DateTime End => Start + Duration;
}

public sealed class MedicalRecord
{
	public MedicalRecord(int recordId, int patientId, int doctorId, string disease, string treatment, DateTime createdOn)
	{
		RecordId = recordId;
		PatientId = patientId;
		DoctorId = doctorId;
		Disease = disease;
		Treatment = treatment;
		CreatedOn = createdOn;
	}

	public int RecordId { get; }
	public int PatientId { get; }
	public int DoctorId { get; }
	public string Disease { get; private set; }
	public string Treatment { get; private set; }
	public DateTime CreatedOn { get; }

	public void UpdateTreatment(string treatment) => Treatment = treatment;
	public void UpdateDisease(string disease) => Disease = disease;
}

public sealed class DoctorNotAvailableException : Exception
{
	public DoctorNotAvailableException(string message) : base(message) { }
}

public sealed class InvalidAppointmentException : Exception
{
	public InvalidAppointmentException(string message) : base(message) { }
}

public sealed class PatientNotFoundException : Exception
{
	public PatientNotFoundException(string message) : base(message) { }
}

public sealed class DuplicateMedicalRecordException : Exception
{
	public DuplicateMedicalRecordException(string message) : base(message) { }
}

public sealed class HospitalService
{
	private readonly List<Doctor> _doctors = [];
	private readonly List<Patient> _patients = [];
	private readonly List<Appointment> _appointments = [];
	private readonly Dictionary<int, MedicalRecord> _medicalRecords = [];

	public IReadOnlyList<Doctor> Doctors => _doctors;
	public IReadOnlyList<Patient> Patients => _patients;
	public IReadOnlyList<Appointment> Appointments => _appointments;
	public IReadOnlyDictionary<int, MedicalRecord> MedicalRecords => _medicalRecords;

	public void AddDoctor(Doctor doctor) => _doctors.Add(doctor);
	public void AddPatient(Patient patient) => _patients.Add(patient);

	public void AddMedicalRecord(MedicalRecord record)
	{
		if (_medicalRecords.ContainsKey(record.RecordId))
		{
			throw new DuplicateMedicalRecordException($"Medical record with id {record.RecordId} already exists.");
		}

		EnsurePatientExists(record.PatientId);
		EnsureDoctorExists(record.DoctorId);
		_medicalRecords.Add(record.RecordId, record);
	}

	public void ScheduleAppointment(Appointment appointment)
	{
		ValidateAppointment(appointment);
		_appointments.Add(appointment);
	}

	private void ValidateAppointment(Appointment appointment)
	{
		var doctor = _doctors.FirstOrDefault(d => d.Id == appointment.DoctorId)
			?? throw new DoctorNotAvailableException($"Doctor id {appointment.DoctorId} not found.");

		EnsurePatientExists(appointment.PatientId);

		if (appointment.Duration <= TimeSpan.Zero)
		{
			throw new InvalidAppointmentException("Appointment duration must be positive.");
		}

		var overlaps = _appointments.Any(a =>
			a.DoctorId == doctor.Id && appointment.Start < a.End && a.Start < appointment.End);

		if (overlaps)
		{
			throw new InvalidAppointmentException($"Doctor '{doctor.DisplayName}' already has an overlapping appointment.");
		}
	}

	private void EnsurePatientExists(int patientId)
	{
		if (!_patients.Any(p => p.Id == patientId))
		{
			throw new PatientNotFoundException($"Patient id {patientId} not found.");
		}
	}

	private void EnsureDoctorExists(int doctorId)
	{
		if (!_doctors.Any(d => d.Id == doctorId))
		{
			throw new DoctorNotAvailableException($"Doctor id {doctorId} not found.");
		}
	}

	public void ExportAppointmentReport()
	{
		var rows = _appointments
			.OrderBy(a => a.Start)
			.Select(a =>
			{
				var doctor = _doctors.First(d => d.Id == a.DoctorId);
				var patient = _patients.First(p => p.Id == a.PatientId);
				var bill = doctor.CalculateBill(a);
				return new { a.Id, a.Start, a.End, Doctor = doctor.DisplayName, Patient = patient.DisplayName, a.Disease, Bill = bill };
			})
			.ToList();

		Console.WriteLine("Id  | Start              | End                | Doctor               | Patient              | Disease        | Bill");
		Console.WriteLine(new string('-', 110));
		foreach (var r in rows)
		{
			Console.WriteLine($"{r.Id, -3} | {r.Start:yyyy-MM-dd HH:mm} | {r.End:yyyy-MM-dd HH:mm} | {Trunc(r.Doctor, 20), -20} | {Trunc(r.Patient, 20), -20} | {Trunc(r.Disease, 12), -12} | {r.Bill,8:0.00}");
		}
	}

	private static string Trunc(string value, int len)
		=> value.Length <= len ? value : value[..(len - 1)] + "…";

	public List<Doctor> GetDoctorsWithMoreThanNAppointments(int n) =>
		_appointments
			.GroupBy(a => a.DoctorId)
			.Where(g => g.Count() > n)
			.Join(_doctors, g => g.Key, d => d.Id, (g, d) => d)
			.ToList();

	public List<Patient> GetPatientsTreatedInLastDays(int days)
	{
		var cutoff = DateTime.Now.AddDays(-days);
		var ids = _appointments
			.Where(a => a.Start >= cutoff)
			.Select(a => a.PatientId)
			.Distinct();

		return _patients.Where(p => ids.Contains(p.Id)).ToList();
	}

	public List<(Doctor Doctor, List<Appointment> Appointments)> GroupAppointmentsByDoctor() =>
		_appointments
			.GroupBy(a => a.DoctorId)
			.Join(_doctors, g => g.Key, d => d.Id,
				(g, d) => (Doctor: d, Appointments: g.OrderBy(a => a.Start).ToList()))
			.OrderByDescending(x => x.Appointments.Count)
			.ToList();

	public List<(Doctor Doctor, decimal TotalEarnings)> GetTopHighestEarningDoctors(int top)
	{
		var earnings = _doctors
			.Select(d =>
			{
				var appts = _appointments.Where(a => a.DoctorId == d.Id);
				return (Doctor: d, TotalEarnings: d.CalculateEarnings(appts));
			})
			.OrderByDescending(x => x.TotalEarnings)
			.Take(top)
			.ToList();

		return earnings;
	}

	public List<Patient> GetPatientsByDisease(string disease)
	{
		var ids = _medicalRecords
			.Values
			.Where(r => string.Equals(r.Disease, disease, StringComparison.OrdinalIgnoreCase))
			.Select(r => r.PatientId)
			.Distinct();

		return _patients.Where(p => ids.Contains(p.Id)).ToList();
	}

	public decimal CalculateTotalRevenue()
		=> _appointments.Sum(a => _doctors.First(d => d.Id == a.DoctorId).CalculateBill(a));

	public IEnumerable<AppointmentProjection> GetAppointmentProjections() =>
		_appointments
			.OrderByDescending(a => a.Start)
			.Select(a =>
			{
				var d = _doctors.First(x => x.Id == a.DoctorId);
				var p = _patients.First(x => x.Id == a.PatientId);
				return new AppointmentProjection(
					AppointmentId: a.Id,
					When: a.Start,
					Doctor: d.DisplayName,
					Patient: p.DisplayName,
					Disease: a.Disease,
					Bill: d.CalculateBill(a));
			});
}

public sealed record AppointmentProjection(int AppointmentId, DateTime When, string Doctor, string Patient, string Disease, decimal Bill);
