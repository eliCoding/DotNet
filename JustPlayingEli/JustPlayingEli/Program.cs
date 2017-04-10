using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustPlayingEli
{
    class Program
    {
        static void incTwo(int original,int alpha, out int beta)
        {
            alpha = original + 1;
            beta = original + 1;
            Console.WriteLine(" #2: Original {0}, Alpha {1} ,Beta {2}",original, alpha, beta);

        }
        static void Main(string[] args)
        {
            int ooo = 7, aaa = 3, bbb = 11;
            Console.WriteLine(" #1: Original {0}, Alpha {1} ,Beta {2}", ooo, aaa, bbb);
            incTwo(ooo, aaa, out bbb);
            Console.WriteLine(" #3: Original {0}, Alpha {1} ,Beta {2}", ooo, aaa, bbb);
            Console.ReadKey();
        }
        
    }
}
