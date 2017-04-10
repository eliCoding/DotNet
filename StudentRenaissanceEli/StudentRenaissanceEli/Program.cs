using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*DotNet Fundamentals - Day 2 Tasks

TASK 1

Create project StudentRenaissance

You will perform operations on data in file named "students.txt",
similar to what you did for your homework in Java 2 course.

You should define a class Student with fields:
- string name
- double gpa
Define a constructor for it.
Do NOT define accessor methods.

Use List<Student> to contain data.

Use separate methods for reading data file at startup and writing it back when program is about to exit.

Example session uses the following menu:
1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: 1

Adding a student.
Enter student's name: Jerry Boe
Enter student's GPA: blue
Invalid input
Enter student's GPA: 55
GPA must be between 0 and 4.3 maximum.
Enter student's GPA: 4.1
Student added.

1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: blah
Invalid input
Choice: 1

Adding a student.
Enter student's name: Mimi Mo
Enter student's GPA: 4.3
Student added.

1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: 7
Invalid choice, try again.
Choice: 2

Listing all students
Jerry Boe has GPA 4.1
Mimi Mo has GPA 4.3

1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: 3

Enter first letter of student name (only one letter): abc
Invalid input, try again.
Enter first letter of student name (only one letter): m
Listing students whose names begin with letter m (case insensitive):
Mimi Mo has GPA 4.3

1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: 4

The average GPA of all students is 4.2
If you would like to save it to a file, provide file name (empty to skip): avg.txt
Saved 4.2 to avg.txt

1. Add student and their GPA
2. List all students and their GPAs
3. Find all students whose name begins with a letter
4. Find the average GPA of all students and display it.
0. Exit
Choice: 0

Good bye

Contents of "students.txt" file after the above session will be:
Jerry Boe
4.1
Mimi Mo
4.3

Contents of "avg.txt" file will be:
4.2

NOTES:
* You must handle all IOException, InputMismatchException.
* When operating on numerical types you must use appropriate
numerical type, not string for it
* Show all GPA's with 1 decimal point, so 3.0, not 3

*/
namespace StudentRenaissanceEli
{

    class Student
    {
        public Student(string name, double gpa)
        {
            this.Name = name;
            this.Gpa = gpa;
        }
        public string Name;
        public double Gpa;
    }


    class Program
    {
        static List<Student> studentList = new List<Student>();

            public static void LoadDataFromFile()
       {
           try
           {
               string[] lineArray = System.IO.File.ReadAllLines(@"..\..\students.txt");
               for (int i = 0; i < lineArray.Length; i++)
               {
                   Student s = new Student(lineArray[i], double.Parse(lineArray[i + 1]));
                   studentList.Add(s);
                   ++i;

               }
           }
           catch (IOException ex)
           {
               Console.WriteLine("There is a problem to open the file." + ex);
           }

       }
           
        
       
        static void CreateStudent()
        {
            while (true)
            {
                double gpa = 0.0;
                Console.Write("please add Student name: ");
                string name = Console.ReadLine();
                Console.Write("please add Student GPA: ");              
                try
                {
                    gpa = double.Parse(Console.ReadLine());
                    Student s = new Student(name, gpa);
                    studentList.Add(s);
                    Console.WriteLine("Student added.");
                    break;

                }
                catch (FormatException e)
                {
                    Console.WriteLine("FATAL ERROR: " + e.StackTrace);
                }
                if (gpa <= 0 || gpa > 4.4)
                {
                    Console.WriteLine("gpa has to be between 0 to 4.3 ");
                    continue;
                }
               
            } 
      
        }

        static void ListAllStudents()
        {
            foreach (Student s in studentList) {
                Console.WriteLine("{0} has GPA {1:0.00}", s.Name, s.Gpa);
            
            }
        }

        static void ListStudentsWithNameBeginning()
        {
            Console.Write("Enter a character to find a student(s):");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            foreach (Student s in studentList) {
                if (s.Name[0] == c) {
                    Console.WriteLine("{0} has GPA {1:0.00}", s.Name, s.Gpa);                
                }                          
            }
            Console.ReadKey();
               
        }
        static void FindAndSaveAverageGPA()
        {
            double sum = 0;
            foreach (Student s in studentList)
            {
                sum = s.Gpa;
            }
            double average = sum / studentList.Count;
            Console.WriteLine("Average is " + average);
            Console.Write("Do you want to save in the File?(Y/N)");
            char c = Console.ReadKey().KeyChar;
            if (c == 'Y' || c == 'y')
            {
                Console.WriteLine();
                try
                {
                    //ask uset to write the name og the .txt file
                    Console.WriteLine("Enter file nameto write GPA average to:");
                    String filepath = Console.ReadLine();
                    File.WriteAllText(filepath, average + "");
                    Console.WriteLine("File added.");

                    //write to theb file the average if gpa
                 /*   StreamWriter file = new StreamWriter(@"..\..\averageGpa.txt");

                    file.Write(average);
                    file.Close();
                    Console.ReadKey();*/
                }
                 
                catch (IOException e)
                {
                    Console.WriteLine("FATAL ERROR: " + e.StackTrace);
                }

            }
            else
            {
                Console.WriteLine();
                return;
            }
        }
        static void SaveDataToFile()
        {
            try
            {
                StreamWriter file = new StreamWriter(@"..\..\students.txt");
                for (int i = 0; i < studentList.Count; i++)
                {
                    file.Write(studentList[i].Name + "\r\n");
                    file.Write(studentList[i].Gpa + "\r\n");
                }

                file.Close();
                return;
            }
            catch (IOException e)
            {
                Console.WriteLine("FATAL ERROR: " + e.StackTrace);

            }
        }
                 

        static int GetMenuChoice()
        {
            // show menu and get user's choice, repeat if invalid
            while (true)
            {
                Console.WriteLine("\n===============================");
                Console.WriteLine("Please select following options:\n"
                    + "1. Add student and their GPA\n"
                    + "2. List all students and their GPAs\n"
                    + "3. Find all students whose name begins with a letter\n"
                    + "4. Find the average GPA of all students and display it\n"
                    + "0. Exit");
                Console.WriteLine("===============================");
                Console.Write("Enter your Choice: ");
                string Choice = Console.ReadLine();
                try
                {
                    int num = int.Parse(Choice);
                    return num;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("invalid choice");
                    continue;
                }
            }
                                      
        }


        static void Main(string[] args)
        {

            LoadDataFromFile();
            int choice;                                      
                while ((choice = GetMenuChoice()) != 0)
                {
                    switch (choice)
                    {
                       
                        case 1:
                            CreateStudent();
                            break;
                        case 2:
                            ListAllStudents();
                            break;
                        case 3:
                            ListStudentsWithNameBeginning();
                            break;
                        case 4:
                            FindAndSaveAverageGPA();
                            break;
                        default:
                            Console.WriteLine("Ooops...");
                            break;
                    }
                }
                SaveDataToFile();
                return;



            }

        }
    
}
