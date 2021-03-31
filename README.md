# PotentialDuplicateIndicator

The Problem
-----------
This is a real problem we encountered and dealt with here.  Our advertiser database had duplicate entries with slightly different names for the same advertiser.
One such example is: "1-800-Flowers.com" and "1800Flowers.com"
   
The Challenge
-------------
Write a program in the language of your choice that accepts as input a text file of advertiser names and outputs potential duplicate advertisers.


Algorithm Used : Levenshtein Distance
-------------
The Levenshtein distance is a number that tells how different two strings are.
The higher the distance value, the more different between two strings.
The Levenshtein distance for strings A and B can be calculated by using a matrix (in code that will be 2-dimensional array)
Calculate how many steps needed from string B 1 of the cell letter to become the same position cell letter from string A

source from : https://medium.com/@ethannam/understanding-the-levenshtein-distance-equation-for-beginners-c4285a5604f0

The Goal
-------------
Phase 1: Use C# Console Application 

1. A text file contains duplicate entries with slightly different names for the same advertise
2. User inputs the loacation (path) of the text file contains advertiser names
3. If the path is valid and the file read properly
4. System will read the advertiser name line by line and stores in the adversiter name list
5. while reading the string from text file line by line, compare the similarity between current reading string line with names already in the adversiter name list
6. when the system found out there is similar word already in the adversiter name list, add current word to potential duplicate name list
7. After successfully read all the lines from text file and checked the similarity 
8. System then outputs potential duplicate advertisers names

Final thoughts (Parts need to improve)
-------------
1. The first thought is, the whole string read process and compare process loop is taking much longer time than I expected
      need to come up a better algorithm to read and compare strings in the file
2. Because of the algorithm is new to me, I have to make a Unit Test to actually test the algorithm is correct and also I truly understand the logic behind it
3. Under limit of time, I could not find out a better algorithm to actually compare two strings and decide one of the string is similar to another
4. The validation check process still need to improve, since there is not much time to actually apply more edge test case
5. The system is only running once the file is finished reading and checked all strings for potential duplicate
