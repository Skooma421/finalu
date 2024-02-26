using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalu
{
    internal class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }
        //konstruqtori
        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }
        //metodi studentebis detaluri informaciistvis
        public void DisplayStudents()
        {
            Console.WriteLine($"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}");
        }
    }
    //aq vmartavt yvelafers
    public class StudentManager
    {
        private List<Student> students = new List<Student>();//studentebis listi
        //studentis damatebis metodi
        public void AddStudent(string name, int rollNumber, char grade)
        {
            Student newStudent = new Student(name, rollNumber, grade);//vqmnit axal obieqts
            students.Add(newStudent);//vamatebt
        }
        //metodi rom vnaxot yvela studenti
        public void viewAllStud()
        {
            foreach (Student student in students)//forichit vaitereitebt da vichert yvela students
            {
                student.DisplayStudents();
            }
        }
        //siis nomrit dziebus metodi
        public void SearchRoll(int rollNumber)
        {
            bool found = false;//indikatori iqneba tu ara napovni studenti
            foreach (Student student in students)
            {
                if (student.RollNumber == rollNumber)//vamowmebt tu emtxveva ertmanets
                {
                    student.DisplayStudents();
                    found = true;//indikatori rom studenti iqna napovni
                    break;//gamovdivart loopidan imitoro studenti vipovet
                }
            }
            if (!found)//tu ar iqna studenti napovni
            {
                Console.WriteLine("student not found.");
            }
        }
        //qulis ganaxlebis metodi
        public void UpdateGrade(int rollNumber, char newGrade)
        {
            foreach(var student in students)
            {
                if (student.RollNumber == rollNumber)//vamowmebt damtxvevadobas
                {
                    student.Grade = newGrade;//vanaxlebt studentis qulas
                    Console.WriteLine("Student grade updated.");
                    return;//gamovdivart roca qula ganaxldeba
                }
            }
            Console.WriteLine("Student not found");//tu studenti ar iqna napovni
        }
    }
}
