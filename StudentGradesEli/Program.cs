using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
/*TASK 2
======
Create console project StudentsGrades.
In the main directory of your project create file "grades.txt" with content similar to:

Jerry:A-,B+,C,F
Tom:B-
Maria:B+,A+,D+
Eva:A-,B-,B+

Read the file and for every student display their name and their GPA on a separate line.

To convert letter grade to a number grade use a static method with the following signature:
static double letterToNumberGrade(string strGrade) {}
Convert according to http://www.rapidtables.com/calc/grade/gpa-to-letter-grade-calculator.htm

Example output:

Mimi has GPA 3.7
Melinda has GPA 4.1
Larry has GPA 2.9
*/
namespace StudentGrades
{
   
    class Program
    {
        static List<int> numberList = new List<int>();
        // TODO: for teacher only: show how to do it with two arrays
        static double letterToNumberGrade(string strGrade) {

            double result = 0.0;
            switch (strGrade)
            {
                case "A":                
                    result = (4.0);
                    break;                  
                case "A-":                 
                    result = (3.67);
                    break;                           
                case "B+":                 
                    result = (3.33);
                    break;                   
                case "B":                 
                    result = (3.00);
                    break;                 
                case "B-":                
                    result = (2.67);
                    break;                                	
                case "C+":               
                    result = (2.33);
                    break;                   
                case "C":                 
                    result = (2.00);
                    break;                  
                case "C-":                
                    result = (1.67);
                    break;
                case "D+":               
                    result = (1.33);
                    break;                  
                case "D":                
                    result = (1.00);
                    break;                  
                case "D-":                 
                    result = (0.67);
                    break;                  
                case "F":
                   result = (0);
                   break;
                default :
                   throw new ArgumentOutOfRangeException("");
 
            }
            return result;
           
        }

        static void Main(string[] args)
        {
            string[] lineArray = System.IO.File.ReadAllLines(@"..\..\grades.txt");

            foreach (string line in lineArray)
            {
                String[] s1 = line.Split(':');
                String name = s1[0];
                String[] gradeList = s1[1].Split(',');
                double sum = 0;
                foreach (string strGrade in gradeList)
                {
                    try
                    {
                        sum += letterToNumberGrade(strGrade);
                    }
                    catch (ArgumentOutOfRangeException a)
                    {
                        Console.WriteLine("Invalid GPA");

                    }
                }
                double GPA = sum / gradeList.Length;
                Console.WriteLine("{0} has GPA {1:0.00}", name, GPA);
                

            }
            Console.ReadKey();
        }
    }
}
