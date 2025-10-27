using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhoneApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Old Phone App!\n");

            RunExample("33#", "E");                     // Expected: "E"
            RunExample("227*#", "B");                   // Expected: "B"
            RunExample("4433555 555666#", "HELLO");     // Expected: "HELLO"
            RunExample("8 88777444666*664#", "TEST?");  // Expected: "TURING"

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void RunExample(string input, string expected)
        {
            var result = OldPhonePad.Decode(input);
            Console.WriteLine("Input: \"{0}\" => Output: \"{1}\"", input, result);
        }
    }
}