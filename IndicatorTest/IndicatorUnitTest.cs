using System;
using Xunit;

namespace IndicatorTest
{
    public class IndicatorUnitTest
    {
        [Theory]
        [InlineData ("1-800-Flowers.com", "1800Flowers.com", 2)]
        [InlineData ("Penske", "Penske System, Inc.", 13)]
        public void CompareTwoStringAndCalculateDistance(string a, string b, int expected)
        {
            //Arrange

            // Method from https://social.technet.microsoft.com/wiki/contents/articles/26805.c-calculating-percentage-similarity-of-2-strings.aspx
            // Using Levenshtein algorithm to calculate similarity of two strings

            //Actual

            // Step 1
            //  If target word length is zero or source word length is zero
            //  then number of steps required to transform will be equals to
            //  source word length and target word length respectively
            //  For example, to transform ‘hello’ to ”, required steps will be 5
            //  (equals to the length of source word) or
            //  to transform ” to ‘hello’ required steps will also be 5 (equals to the length of target word)

            // In Unit test case
            // The inline data already contains the sample string

            int firstStringCount = a.Length;
            int secondStringCount = b.Length;
            int actual;
            // 2 dimensional array like matrix
            int[,] distance = new int[firstStringCount + 1, secondStringCount + 1];

            // Step 2
            //  If both target word and source word length is greater then zero
            //  In this theory test skip empty string check

            //  Computed distance on each step will be stored in a m x n matrix
            //  In this test that will be int [m,n] distance
            //  where m = source word length +1 and n = target word length +1
            //  Fill matrix first row and first column with consecutive integers starting
            //  from zero at top left corner to bottom left corner of matrix at the end.

            for (int i = 0; i <= firstStringCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= secondStringCount; distance[0, j] = j++) ;

            for (int i = 1; i <= firstStringCount; i++)
            {
                for (int j = 1; j <= secondStringCount; j++)
                {
                    // Step 3
                    //  For each remaining cell at i x j
                    //  we have to calculate cost that will be 0
                    //  if char at i – 1 in source string is equal to char at j – 1 in target string
                    //  else it will be 1

                    int cost = (b[j - 1] == a[i - 1]) ? 0 : 1;

                    // Step 4
                    //  Calculate each cell except from row 1 and column 1 distance
                    //  and store the distanct value in the cell for later return distanct
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            actual =  distance[firstStringCount, secondStringCount];

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
