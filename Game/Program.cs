using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
         
        
            var set = new HashSet<string>();
            foreach (var n in args)
                if (!set.Add(n))
                {
                    Console.WriteLine("Enter an odd non-repeating number of parameters >= 3 (one, two, three, four, five)");
                    return;
                }
            
            if ((args.Length % 2.0 != 0) && (args.Length >= 3) )
            {
                Rules.PlayGame();
             
            }
            else
            {
                Console.WriteLine("Enter an odd non-repeating number of parameters >= 3 (one, two, three, four, five)");
            }

       
           

        }
    }
  
}

