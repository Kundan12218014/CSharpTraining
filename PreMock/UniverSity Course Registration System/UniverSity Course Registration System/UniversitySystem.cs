using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }
        List<Student> ActiveStudents = new List<Student>();

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
            ActiveStudents = new List<Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            // 2. Create Course object
            // 3. Add to AvailableCourses
            foreach(var courses in AvailableCourses.Values)
            {
                if (courses.CourseCode.Equals(code)){
                    throw new ArgumentException("Course Already Exits");
                }
            }
            Course course=new Course(code,name,credits,maxCapacity,prerequisites);

            AvailableCourses.Add(course.CourseCode, course);
            throw new NotImplementedException();
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            // 2. Create Student object
            // 3. Add to Students dictionary
            foreach (Student stud in Students.Values)
            {
                if (stud.StudentId.Equals(id))
                {
                    throw new ArgumentException("Student Already Exits");
                }
            }
            Student student = new Student(id, name, major, maxCredits, completedCourses);
            ActiveStudents.Add(student);
            Students.Add(student.StudentId, student);
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            // 2. Call student.AddCourse(course)
            // 3. Display meaningful messages
            if(Students.ContainsKey(studentId) && AvailableCourses.ContainsKey(courseCode))
            {
                Student student = Students[studentId];
                Course course = AvailableCourses[courseCode];
                if (student.AddCourse(course))
                {
                    Console.WriteLine("Course Registered Successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to Register Course: Check prerequisites, credits, or capacity");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Prerequisites not met");
                return false;
            }
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            if(Students.ContainsKey(studentId))
            {
                Student student = Students[studentId];
                if (student.DropCourse(courseCode))
                {
                    Console.WriteLine("Course Dropped Successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to Drop Course: Course not found in student's schedule");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Student Not Found");
                return false;
            }
        }

        public void DisplayAllCourses()
        {
            // TODO:
            // Display course code, name, credits, enrollment info
            foreach(var course in AvailableCourses.Values)
            {
                Console.WriteLine($"{course.CourseCode} {course.CourseName} {course.Credits} {course.MaxCapacity}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            foreach(var student in Students.Values)
            {
                if(student.StudentId.Equals(studentId))
                {
                    student.DisplaySchedule();
                    return;
                }
            }
            throw new NotImplementedException();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            // Display total students, total courses, average enrollment
                Console.WriteLine($"Total Students: {Students.Count}");
                Console.WriteLine($"Total Courses: {AvailableCourses.Count}");
                int avg = 0;
                foreach(var course in AvailableCourses.Values)
                {
                    avg+=Convert.ToInt32(course.GetEnrollmentInfo());
                }
                Console.WriteLine(avg);

            }
          
        }
    }
}
