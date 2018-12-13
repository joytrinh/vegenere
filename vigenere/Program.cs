using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vigenere
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            for (int i = 0; i < args.Length - 1; i++)
            {
                text += args[i] + " ";
            }
            string keyString = args[args.Length - 1];
            int key;

            //Check key
            bool success = int.TryParse(keyString, out key);
            if (success)
            {
                int n = text.Length;
                int[] newText = new int[n];
                char[] arr = new char[n];

                //Convert from text to ASCII value:
                for (int i = 0; i < n; i++)
                {
                    var a = text[i];
                    if (char.IsLetter(a))
                    {
                        var b = (int)a;
                        if (char.IsUpper(a))
                        {
                            if (b <= (90 - key))
                                newText[i] = b + key;
                            else
                                newText[i] = b + key - 26;
                        }
                        if (char.IsLower(a))
                        {
                            if (b <= (122 - key))
                                newText[i] = b + key;
                            else
                                newText[i] = b + key - 26;
                        }
                    }
                    else
                        newText[i] = (int)a;
                }
                //Convert form ASCII to char
                for (int i = 0; i < n; i++)
                {
                    arr[i] = (char)newText[i];
                    Console.Write(arr[i]);
                }
                Console.ReadLine();
            }
            else
                Console.WriteLine("Please input a valid key. A key must be a number.");
        }
    }
}
