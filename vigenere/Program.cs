using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "";
            //for (int i = 0; i < args.Length - 1; i++)
            //{
            //    text += args[i] + " ";
            //}
            //string keyString = args[args.Length - 1];
            Console.WriteLine("Input text: ");
            string text = Console.ReadLine();
            Console.WriteLine("Input keyString: ");
            string keyString = Console.ReadLine();
            //verify that input contains only letters
            bool success = Regex.IsMatch(keyString, @"^[a-zA-Z]+$");

            if (success)
            {
                int n = text.Length;
                int[] asciiValueOfText = new int[n];
                char[] arr = new char[n];

                int k = keyString.Length;
                int[] asciiValueOfKeyString = new int[k];
                //Get the index of each letter
                //of keyString in the alphabet index (26 indexes)
                //and then add each of value in an array
                for (int i = 0; i < k; i++)
                {
                    var x = keyString[i];                    
                    if (char.IsUpper(x))
                        asciiValueOfKeyString[i] = x - 65;
                    else
                        asciiValueOfKeyString[i] = x - 97;
                }                
                    for (int i = 0; i < n; i++)
                    {
                        var a = text[i];
                        var b = asciiValueOfKeyString[i%k];
                        if (char.IsLetter(a))
                        {
                            if (char.IsUpper(a))
                            {
                                if (a <= (90 - b))
                                    asciiValueOfText[i] = a + b;
                                else
                                    asciiValueOfText[i] = a + b - 26;
                            }
                            if (char.IsLower(a))
                            {
                                if (a <= (122 - b))
                                    asciiValueOfText[i] = a + b;
                                else
                                    asciiValueOfText[i] = a + b - 26;
                            }
                        }
                        else
                            asciiValueOfText[i] = a;
                    }    

                  
                //Convert form ASCII to char
                for (int i = 0; i < n; i++)
                {
                    arr[i] = (char)asciiValueOfText[i];
                    Console.Write(arr[i]);
                }
                Console.ReadLine();
            }
            else
                Console.WriteLine("Please input a valid key. A key must be a string.");
        }
    }
}
