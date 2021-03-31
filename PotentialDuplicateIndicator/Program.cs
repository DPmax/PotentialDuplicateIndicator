using System;
using System.IO;

namespace PotentialDuplicateIndicator
{
    public class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\chilc\Desktop\advertisers.txt

            #region Initials
            string fileLocation = "";
            bool isPathValid = false;
            bool isFileValid = false;
            #endregion

            #region Process
            Console.WriteLine("Welcome to Potential Duplicate Indicator !!\n");
            Console.WriteLine("\nPlease input file location: ");
            fileLocation = Console.ReadLine();


            if (fileLocation == "")
            {
                Console.WriteLine("Cannot find the file, please try again !");
            }
            else
            {
                isPathValid = true;
            }

            while (isPathValid)
            {
                try
                {
                    string[] name_array = File.ReadAllLines(fileLocation);
                }
                catch (IOException)
                {
                    Console.WriteLine("The input file location is invalid !");
                }

                Console.WriteLine("Welcome to Potential Duplicate Indicator !!\n");
                Console.WriteLine("\nPlease input file location: ");
                fileLocation = Console.ReadLine();
            }
            #endregion

        }

        #region Method
        public void ReadFile()
        {

        }

        public void Compare()
        {

        }
        #endregion
    }
}
