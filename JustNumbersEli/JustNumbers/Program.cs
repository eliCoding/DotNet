using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Task 1:

Create console project JustNumbers.
In a loop ask user for a positive integer number.
Keep asking until user enters 0 or less.
Save each number in List<>.

After all numbers are saved compute and display:
- the average of all numbers (floating point)
- the maximum of all numbers
- median (you probably need to sort numbers first)
- standard deviation

Save the list of numbers to "output.txt" file, on a single line, semincolon-separated*/
namespace JustNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            List<int> numberList = new List<int>();
            Console.WriteLine("Please Enter a Number(0 to finish):");
            Console.ReadKey();
            
            input = Convert.ToInt32(Console.ReadLine());

            do
            {
                numberList.Add(input);
                input = Convert.ToInt32(Console.ReadLine());


            } while (input > 0 || input != 0);
          
           
           
            float sum = numberList.Sum();
            double avg = numberList.Average();
            double min = numberList.Min();
            double max = numberList.Max();
          
           

            numberList.Sort();
            double median;
            if (numberList.Count % 2 == 1)
            {
                median = numberList[numberList.Count / 2];

            }
            else {
                int right = numberList[numberList.Count / 2];
                int left = numberList[numberList.Count / 2 -1];
                median = ((double)right + left) / 2;
            
            }


            Console.WriteLine("Sum is:" + sum + "Average is: " + avg + "Minimum: " + min + "Maximum: " + max + "Median: " + median);
            Console.ReadKey();

            String data ="";
            foreach (int num in numberList) {
                data = data + num + ";";
            }

            File.WriteAllText("C:\\Users\\ipd\\Documents\\2017_dotnet\\JustNumbers\\List.txt", data);
            
           

           


           

           



        }
}
    }
