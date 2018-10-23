using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1127M_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserInput, RGB, Inverse, Mono;
            int Conversion, IConversion;
            float Threshold, Grayscale = 0;
            //Defines all the variables to be used throughout the Main class.

            Console.WriteLine("Enter a hexadecimal colour code:"); //Requests through console the colour to be converted in the correct format.
            UserInput = Console.ReadLine(); //Takes the users input as a string.

            char[] Array = UserInput.ToCharArray(); //Creates an array which holds the string seperated into the base characters.

            RGB = UserInput + " : ("; //Creates the initial part of the result string for the RGB colour output to the user.
            Inverse = "Inverse: " + UserInput + " : " + "("; //Creates the initial result string for the output string of the inverse RGB colour result.

            for (int i = 1; i < 4; i++) //Loops for a count of three.
            {
                Conversion = 16 * Converter(Array[i * 2 - 1]) + Converter(Array[i * 2]); //Converts a pair of hexadecimal values to an integer value. 
                IConversion = 255 - Conversion; //Takes the inverse of the integer value by subtracting it from the RGB upper limit 255.

                if (i == 3) //If this is the last loop do:
                {
                    RGB = RGB + Conversion + ")"; //Adds the last RGB value to the string and ends the format.
                    Inverse = Inverse + IConversion + ")"; //Adds the last inverse value to the string and ends the format.
                }

                else
                {
                    RGB = RGB + Conversion + ", "; //Adds the RGB value to the result string.
                    Inverse = Inverse + IConversion + ", "; //Adds the inverse RGB value to the secondary result string.
                }

                Grayscale = Grayscale + (Conversion / 3); //Calculates the average RGB value to use as the grayscale value.      
            }
 
            Console.WriteLine(RGB); //Outputs the RGB result string to the User.
            Console.WriteLine(Inverse); //Outputs the Inverse result string to the User.

            Console.WriteLine("Enter a threshold (%):"); //Prompts the user to a enter a percentage theshold for the grayscale to mono conversion.
            Threshold = Convert.ToInt32(Console.ReadLine()); //Converts the users input from a string to an integer.
            
            if (Grayscale / 255 >= Threshold / 100) //Checks if the grayscale as a percentage of the RGB scale is higher than the threshold.
                Mono = "White"; //Sets monochrome result to White.
            else
                Mono = "Black"; //Sets monochrome result to Black.

            Console.WriteLine("Result: " + Mono); //Outputs the monochrome result to the user.
            Console.ReadLine(); //Prevents the program from closing immediately.
        }

        static int Converter(char Value)
        {
            int Hexadecimal;
            if (Value == Convert.ToChar("A"))
                Hexadecimal = 10;
            else if (Value == Convert.ToChar("B"))
                Hexadecimal = 11;
            else if (Value == Convert.ToChar("C"))
                Hexadecimal = 12;
            else if (Value == Convert.ToChar("D"))
                Hexadecimal = 13;
            else if (Value == Convert.ToChar("E"))
                Hexadecimal = 14;
            else if (Value == Convert.ToChar("F"))
                Hexadecimal = 15;
            else
                Hexadecimal = (int)Char.GetNumericValue(Value);
            
            //Converts any hexadecimal value to its integer counterpart.

            return Hexadecimal; //Returns the converted value
        }
    }
}
