using System;
using System.IO;
using System.Text;

namespace StreamRedirection
{
    class Program
    {
        static TextWriter originalOut = Console.Out;
        static TextReader originalIn = Console.In;

        static void Main(string[] args)
        {
            //Init();
            RedirectOutStream();
            Reset();
            RedirectInStream();
            Reset();

        }

        private static void Reset()
        {
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
        }


        private static void RedirectInStream()
        {
            var targetIn = new StreamReader("log.txt");
            Console.SetIn(targetIn);

            var line = Console.ReadLine();

            Console.WriteLine(line);

        }

        private static void RedirectOutStream()
        {
            var builder = new StringBuilder();
            var targetOut = new StreamWriter("log.txt");

            Console.SetOut(targetOut);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            targetOut.Close();

        }
    }
}


