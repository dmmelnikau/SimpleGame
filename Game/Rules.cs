using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Moves_in_game(arg_cmd);
        }
        public static void ConditionsOfGame(string[] arg_cmd, int randomChoice)
        {
            try{
                int selection = Convert.ToInt32(Console.ReadLine());
                if (selection == 0) Process.GetCurrentProcess().Kill();
                else if ((selection <= arg_cmd.Length) && selection > 0){Main_Rules(arg_cmd, selection, randomChoice);}
                else if (selection == arg_cmd.Length + 1){Table.Gen_Table();}
                else{throw new Exception();}
            }
            catch (Exception){Console.WriteLine("Enter the number [0..{0}]", arg_cmd.Length + 1);}
        }
        public static void Main_Rules( string[] arg_cmd, int selection, int randomChoice)
        {
            Console.WriteLine("Your move:{0}\nComputer move:{1}", arg_cmd[selection - 1], arg_cmd[randomChoice - 1]);
            if (selection == randomChoice) Console.WriteLine("Draw");
            if ((selection < randomChoice) && ((selection + arg_cmd.Length / 2.0) < randomChoice)) { Console.WriteLine("You lose"); }
            if ((selection < randomChoice) && (selection + arg_cmd.Length / 2.0) > randomChoice) { Console.WriteLine("You Win"); }
            if ((selection > randomChoice) && ((randomChoice + arg_cmd.Length / 2.0) < selection)) { Console.WriteLine("You Win"); }
            if ((selection > randomChoice) && ((randomChoice + arg_cmd.Length / 2.0) > selection)) { Console.WriteLine("You lose"); }
            Console.WriteLine("HMAC key:{0}", Key.Gen());
        }
        public static void Moves_in_game(string[] arg_cmd)
        {
            bool isValid = false;
            do
            {
                New_Game(arg_cmd); 
            } while (isValid == false);
        }
        public static void New_Game(string[] arg_cmd)
        {
            Console.WriteLine("New Game");
            var generator = new Random();
            var randomChoice = generator.Next(1, arg_cmd.Length);
            Message = "Computer move:" + arg_cmd[randomChoice - 1];
            string hmac_hex_key = HMACkey.HmacSha256(Key.Gen(), Rules.Message);
            Console.WriteLine("HMAC:" + hmac_hex_key + "\n" + "Avaliable moves:");
            for (int i = 0; i < arg_cmd.Length; i++) { Console.WriteLine("{0}-{1}", i + 1, arg_cmd[i]); }
            Console.Write($"{arg_cmd.Length + 1}-help\r\n0-exit\r\nEnter your move:");
            ConditionsOfGame(arg_cmd, randomChoice);
        }
    }
}
