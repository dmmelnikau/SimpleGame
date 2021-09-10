using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Game
{
    class Table
    {

       public static void Gen_Table()
        {
            string[] arg_cmd = Environment.GetCommandLineArgs();
            arg_cmd = arg_cmd.Where((source, index) => index != 0).ToArray();
            int m = arg_cmd.Length;
            string[,] arr = new string[m + 1, m + 1];
            arr[0, 0] = "user/pc";
            for (int i = 1; i < m + 1; i++)
            {
                arr[i, 0] = arg_cmd[i - 1];
            }
            for (int j = 1; j < m + 1; j++)
            {
                arr[0, j] = arg_cmd[j - 1];
            }
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (i == j)
                    {
                        arr[i, j] = "Draw";
                    }
                    if ((i < j) && ((i + arg_cmd.Length / 2.0) < j))
                    {
                        arr[i, j] = "Lose";
                    }
                    if ((i < j) && (i + arg_cmd.Length / 2.0) > j)
                    {

                        arr[i, j] = "Win";
                    }
                    if ((i > j) && ((j + arg_cmd.Length / 2.0) < i))
                    {
                        arr[i, j] = "Win";
                    }
                    if ((i > j) && ((j + arg_cmd.Length / 2.0) > i))
                    {

                        arr[i, j] = "Lose";

                    }

                }
            }

            for (int i = 0; i < m + 1; i++)
            {
              
                Console.Write(new String('-', 16*(m+1)) + "\n");
                for (int j = 0; j < m + 1; j++)
                {
                    
                    Console.Write(arr[i, j]+"\t\t" + "|");
                
                }
            
                Console.WriteLine();
            }

            Console.WriteLine(new String('-', 16 * (m + 1)));

        }

    }
}
