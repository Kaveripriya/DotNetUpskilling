using System;
using System.Collections.Generic;
using Npgsql;

public class StudentRepository
{
    private string connectionstring = "Host=localhost;Username=postgres;Password=Sreealee@2609;Database=StudentDemo";

    public void AddStudent(Student student)
    {
        using(var conn = new NpgsqlConnection(connectionstring))
        {
            conn.Open();
            using(var cmd=new NpgsqlCommand("Insert into Students(Name,Age,Grade) values (@Name,@Age,@Grade)",conn))
            {
                cmd.Parameters.AddWithValue("Name",student.Name);
                cmd.Parameters.AddWithValue("Age", student.Age);
                cmd.Parameters.AddWithValue("Grade", student.Grade);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public List<Student> GetAllStudents() { 
        List<Student> students = new List<Student>();
        using (var conn = new NpgsqlConnection(connectionstring))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("select * from students", conn))
            using(var reader=cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2),
                        Grade = reader.GetString(3)
                    });
                }
            }
        }
        return students;

    }

    //Implement update and delete
}


class Program
{
    static void Main(string[] args)
    {
        StudentRepository repository = new StudentRepository();

        //Add a new student
        Student newStudent = new Student { Name = "Sneha", Age = 20, Grade = "A" };
        repository.AddStudent(newStudent);
        Console.WriteLine("New Student Added");
        Student newStudent1 = new Student { Name = "Krunal", Age = 20, Grade = "A" };
        repository.AddStudent(newStudent1);
        Console.WriteLine("New Student Added");

        // List all students
        List<Student> allStudents = repository.GetAllStudents();
        Console.WriteLine("All students:");
        foreach (var student in allStudents)
        {
            Console.WriteLine($"Id:{student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
        Console.ReadLine();
    }
}