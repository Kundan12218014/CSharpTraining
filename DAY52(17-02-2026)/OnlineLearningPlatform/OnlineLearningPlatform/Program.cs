using OnlineLearningPlatform.Entities;
using OnlineLearningPlatform.Repositories;

namespace OnlineLearningPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Online Learning Platform Simulation\n");

            var courseRepo = new Repository<Course>();
            var studentRepo = new Repository<Student>();
            var instructorRepo = new Repository<Instructor>();
            var enrollmentRepo = new Repository<Enrollment>();
            var assignmentRepo = new Repository<Assignment>();

            SeedData(courseRepo, studentRepo, instructorRepo);

           
            Console.WriteLine("--- Business Rules: Enrollments ---");
            
            EnrollStudent(1, 1, courseRepo, enrollmentRepo);
        
            EnrollStudent(1, 1, courseRepo, enrollmentRepo);
           
            EnrollStudent(2, 2, courseRepo, enrollmentRepo); 
            EnrollStudent(3, 2, courseRepo, enrollmentRepo); 

            Console.WriteLine("\n--- Business Rules: Assignments ---");
        
            var assignment = new Assignment { Id = 1, Title = "Calculus HW 1", CourseId = 1, Deadline = DateTime.Now.AddDays(-1) }; 
            try
            {
                Console.WriteLine($"Submitting {assignment.Title} (Deadline: {assignment.Deadline})...");
                assignment.Submit(DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            var assignment2 = new Assignment { Id = 2, Title = "Physics HW 1", CourseId = 2, Deadline = DateTime.Now.AddDays(1) }; 
            try
            {
                Console.WriteLine($"Submitting {assignment2.Title} (Deadline: {assignment2.Deadline})...");
                assignment2.Submit(DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n--- LINQ Tasks ---");

            var coursesOver50 = courseRepo.GetAll().Where(c => 
                enrollmentRepo.GetAll().Count(e => e.CourseId == c.Id) > 50).ToList();
            Console.WriteLine($"Courses with > 50 students: {coursesOver50.Count}");

           
            var activeStudents = enrollmentRepo.GetAll()
                .GroupBy(e => e.StudentId)
                .Where(g => g.Count() > 3)
                .Select(g => g.Key)
                .ToList();
            Console.WriteLine($"Students in > 3 courses: {activeStudents.Count}");

            var mostPopularCourseId = enrollmentRepo.GetAll()
                .GroupBy(e => e.CourseId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
            
            var mostPopularCourse = courseRepo.GetById(c => c.Id == mostPopularCourseId);
            Console.WriteLine($"Most Popular Course: {(mostPopularCourse != null ? mostPopularCourse.Title : "None")}");

            if (courseRepo.GetAll().Any())
            {
                var avgRating = courseRepo.GetAll().Average(c => c.Rating);
                Console.WriteLine($"Average Course Rating: {avgRating:F2}");
            }

            
            var instructorEnrollments = from i in instructorRepo.GetAll()
                                        join c in courseRepo.GetAll() on i.Id equals c.InstructorId
                                        join e in enrollmentRepo.GetAll() on c.Id equals e.CourseId
                                        group e by i into g
                                        orderby g.Count() descending
                                        select new { Instructor = g.Key, Count = g.Count() };
            
            var topInstructor = instructorEnrollments.FirstOrDefault();
            if (topInstructor != null)
                Console.WriteLine($"Top Instructor by Enrollment: {topInstructor.Instructor.Name} with {topInstructor.Count} enrollment(s)");
            else
                Console.WriteLine("Top Instructor by Enrollment: None");


            Console.WriteLine("\n--- Advanced Features: Sorting (IComparable) ---");
            Console.WriteLine("Sorting courses by Title:");
            var allCourses = courseRepo.GetAll().ToList();
            allCourses.Sort();
            foreach (var c in allCourses)
            {
                Console.WriteLine(c);
            }
        }

        static void SeedData(IRepository<Course> courses, IRepository<Student> students, IRepository<Instructor> instructors)
        {
            instructors.Add(new Instructor { Id = 1, Name = "Dr. Smith" });
            instructors.Add(new Instructor { Id = 2, Name = "Prof. Jones" });

            courses.Add(new Course { Id = 1, Title = "Introduction to CS", Capacity = 30, Rating = 4.5, InstructorId = 1 });
            courses.Add(new Course { Id = 2, Title = "Advanced Algorithms", Capacity = 1, Rating = 4.8, InstructorId = 1 }); 
            courses.Add(new Course { Id = 3, Title = "Data Structures", Capacity = 25, Rating = 4.2, InstructorId = 2 });

            students.Add(new Student { Id = 1, Name = "Alice" });
            students.Add(new Student { Id = 2, Name = "Bob" });
            students.Add(new Student { Id = 3, Name = "Charlie" });
        }

        static void EnrollStudent(int studentId, int courseId, IRepository<Course> courses, IRepository<Enrollment> enrollments)
        {
            var course = courses.GetById(c => c.Id == courseId);
            if (course == null)
            {
                Console.WriteLine($"Error: Course {courseId} not found.");
                return;
            }

            var existingEnrollment = enrollments.GetAll().FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);
            if (existingEnrollment != null)
            {
                Console.WriteLine($"Error: Student {studentId} is already enrolled in Course '{course.Title}'.");
                return;
            }

            var currentEnrollmentCount = enrollments.GetAll().Count(e => e.CourseId == courseId);
            if (currentEnrollmentCount >= course.Capacity)
            {
                Console.WriteLine($"Error: Course '{course.Title}' is at maximum capacity ({course.Capacity}).");
                return;
            }

            enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId, EnrollmentDate = DateTime.Now });
            Console.WriteLine($"Success: Student {studentId} enrolled in '{course.Title}'.");
        }
    }
}
