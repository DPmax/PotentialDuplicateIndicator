using System;
using System.Collections.Generic;
using System.IO;

namespace PotentialDuplicateIndicator
{
    static class Program
    {
        // set a similarity limit for this process
        // the greater value it is, the similar check is more stricted
        private static double similarityLimit = 0.95;
        static void Main(string[] args)
        {
            // text file location
            //C:\Users\chilc\Desktop\advertisers.txt

            #region Initials
            string fileLocation;
            string stringLine;
            List<string> advertiserNameList = new List<string>();
            List<string> potentialDuplicateNameList = new List<string>();
            bool isPathValid = false;
            #endregion

            #region Process
            Console.WriteLine("Welcome to Potential Duplicate Indicator !!\n");
            Console.WriteLine("\nPlease input file location: ");
            fileLocation = Console.ReadLine();

            // ask user input file path
            // more valid check will be implement
            if (fileLocation?.Length == 0)
            {
                Console.WriteLine("Please input a valid path !");
            }
            else
            {
                isPathValid = true;
            }
            // Use While to loop again if user wants to check other file (not implemented)
            // Therefore, this loop once process once
            while (isPathValid)
            {
                try
                {
                    StreamReader file =   new StreamReader(fileLocation);
                    // read advertiser name line by line
                    while ((stringLine = file.ReadLine()) != null)
                    {
                        // check similarity starts with second name read from text file
                        // starts with second line string
                        // check if the current string name is similar with name already in the name list
                        if (advertiserNameList.Count > 0)
                        {
                            foreach(string name in advertiserNameList)
                            {
                                // if compared two string has equal or greater than similarity limit
                                // in this case the limit is set as 95% (0.95d)
                                // then add to potential duplicate name list
                                if (CompareSimilarity(stringLine,name) >= similarityLimit)
                                {
                                    potentialDuplicateNameList.Add("target: " + stringLine + "  similar with source: " + name);
                                }
                            }
                        }
                        advertiserNameList.Add(stringLine);
                    }
                    file.Close();
                }
                catch (IOException)
                {
                    Console.WriteLine("The file invalid to read !");
                }
                // if found similar string name in the advertiser name text file
                // output potential duplicate name list
                if (potentialDuplicateNameList.Count > 0)
                {
                    potentialDuplicateNameList.Sort();
                    foreach (string name in potentialDuplicateNameList)
                    {
                        Console.WriteLine(name);
                    }
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                isPathValid = false;
            }
            #endregion

        }

        #region Method
        public static int CalculateDistance(string source, string target)
        {
            // Method from https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
            // Using Levenshtein algorithm to calculate similarity of two strings

            // Step 1
            //  If target word length is zero or source word length is zero
            //  then number of steps required to transform will be equals to
            //  source word length and target word length respectively
            //  For example, to transform ‘hello’ to ”, required steps will be 5
            //  (equals to the length of source word) or
            //  to transform ” to ‘hello’ required steps will also be 5 (equals to the length of target word)

            // In Unit test case
            // The inline data already contains the sample string

            int SourceStringCount = source.Length;
            int TargetStringCount = target.Length;
            // 2 dimensional array like matrix
            int[,] distance = new int[SourceStringCount + 1, TargetStringCount + 1];

            // Step 2
            //  If both target word and source word length is greater then zero
            //  In this theory test skip empty string check

            //  Computed distance on each step will be stored in a m x n matrix
            //  In this test that will be int [m,n] distance
            //  where m = source word length +1 and n = target word length +1
            //  Fill matrix first row and first column with consecutive integers starting
            //  from zero at top left corner to bottom left corner of matrix at the end.

            for (int i = 0; i <= SourceStringCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= TargetStringCount; distance[0, j] = j++) ;

            for (int i = 1; i <= SourceStringCount; i++)
            {
                for (int j = 1; j <= TargetStringCount; j++)
                {
                    // Step 3
                    //  For each remaining cell at i x j
                    //  we have to calculate cost that will be 0
                    //  if char at i – 1 in source string is equal to char at j – 1 in target string
                    //  else it will be 1

                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    //  Calculate each cell except from row 1 and column 1 distance
                    //  and store the distanct value in the cell for later return distanct
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[SourceStringCount, TargetStringCount];
        }

        public static double CompareSimilarity (string source, string target)
        {
            // if current name and target item in the name list are same string then return 100% similarity
            if (source == target) return 1.0;

            // else calculate distance (difference) between two string
            int distance = CalculateDistance(source, target);
            // and return similarity percentage
            return (1.0 - ((double)distance / (double)Math.Max(source.Length, target.Length)));
        }
        #endregion
    }
}
