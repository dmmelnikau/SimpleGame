using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
  
    class Rules
    {
        public static string Message { get; set; }
        public static void PlayGame()
        {
            string[] arg_cmd = Environment.GetCommandLineArgs();
            arg_cmd = arg_cmd.Where((source, index) => index != 0).ToArray();
           
            
            bool isValid = false;
            do
            {
                var generator = new Random();
                var randomChoice = generator.Next(1, arg_cmd.Length);
                Message = "Computer move:" + arg_cmd[randomChoice - 1];
                string hmac_hex_key = HMACkey.HmacSha256(Key.Gen(), Rules.Message);
                Console.WriteLine("HMAC:" + hmac_hex_key);
                Console.WriteLine("Avaliable moves:");
                for (int i = 0; i < arg_cmd.Length; i++)
                {
                    Console.WriteLine("{0}-{1}", i + 1, arg_cmd[i]);
                }
                Console.Write($"{arg_cmd.Length + 1}-help\r\n0-exit\r\nEnter your move:");
                try
                {
                    int selection = Convert.ToInt32(Console.ReadLine());
                    if (selection == 0) return;
                    else if ((selection <= arg_cmd.Length) && selection > 0)
                    {
                        Console.WriteLine("Your move:{0}", arg_cmd[selection - 1]);
                       
                    
                      Console.WriteLine("Computer move:{0}", arg_cmd[randomChoice - 1]);
                      //  Console.WriteLine(Message);
                        if (selection == randomChoice) Console.WriteLine("Draw");
                        if ((selection < randomChoice) && ((selection + arg_cmd.Length / 2.0) < randomChoice))
                        {
                            Console.WriteLine("You lose");
                        }
                        if ((selection < randomChoice) && (selection + arg_cmd.Length / 2.0) > randomChoice)
                        {
                            Console.WriteLine("You Win");

                        }
                        if ((selection > randomChoice) && ((randomChoice + arg_cmd.Length / 2.0) < selection))
                        {
                            Console.WriteLine("You Win");
                        }
                        if ((selection > randomChoice) && ((randomChoice + arg_cmd.Length / 2.0) > selection))
                        {

                            Console.WriteLine("You lose");

                        }
                       

                        Console.WriteLine("HMAC key:{0}", Key.Gen());

                    }
                    else if (selection == arg_cmd.Length + 1)
                    {
                        Table.Gen_Table();
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Enter the number [0..{0}]", arg_cmd.Length + 1);
                }
            } while (isValid == false);
        }
    }
}
