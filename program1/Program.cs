using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignmnet1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is "+ rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }

        /* 
        <summary>
        You are given a string s of even length. Split this string into two halves of equal lengths, and let a be the first half and b be the second half.
        Two strings are alike if they have the same number of vowels ('a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and lowercase letters.
        Return true if a and b are alike. Otherwise, return false

        Example 1:
        Input: s = "book"
        Output: true
        Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.
        </summary>
        */
        private static bool HalvesAreAlike(string s)
        {
            try
            {
                int l = s.Length, first = 0, second = 0;
                string vowel = "AEIOUaeiou";
                
                //Taking 2 loops , one that starts from beginning of string and the other one from end of string
                //We increase the counters first and second accordingly
                for (int i = 0, j = l / 2; i < l / 2 && j < l; i++, j++)
                {
                    if (vowel.IndexOf(s[i]) >= 0)
                    {
                        first++;
                    }
                    if (vowel.IndexOf(s[j]) >= 0)
                    {
                        second++;
                    }
                }
                //If the no of of vowels in first and second is equal, then both string are alike, and return true else return false
                if (first == second) return true;

                return false;

            }
            catch (Exception)
            {
                throw;
            }

        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
*/
        private static bool CheckIfPangram(string s)
        {
            try
            {
                //intializing an array of size 26, used to check ifx English letter exists in the string or not
                int[] result = new int[26];
                foreach (var i in s)
                {
                    // getting the ascii value of each letter in the string  
                    int index = (int)i - 97;
                    result[index]++;
                }

                // Now we have an array which contains the counters of each letter, so iterate and check if at any array element count is zero 
                
                bool val = true;
                for (int i = 0; i < 26; i++)
                {
                    if (result[i] == 0)
                    {
                        val = false;
                        break;
                    }
                }
                return val;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        <summary> 
        You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the ith customer has in the jth bank. Return the wealth that the richest customer has.
       A customer's wealth is the amount of money they have in all their bank accounts. The richest customer is the customer that has the maximum wealth.

       Example 1:
       Input: accounts = [[1,2,3],[3,2,1]]
       Output: 6
       Explanation:
       1st customer has wealth = 1 + 2 + 3 = 6
       2nd customer has wealth = 3 + 2 + 1 = 6
       Both customers are considered the richest with a wealth of 6 each, so return 6.
       </summary>
        */
        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                int i, j;
                int max = 0, sum = 0;
                ///Using for loop to iterate through first dimension i.e. persons in the 2D array
                for (i = 0; i < accounts.GetLength(0); i++)
                {
                    sum = 0;
                    //Using another for loop to iterate through second dimension i.e. bank accounts in the 2D array
                    for (j = 0; j < accounts.GetLength(1); j++)
                    {
                        sum = sum + accounts[i,j];

                    }
                    //Finding the maximum sum and placing that value in max variable
                    if (sum > max) max = sum;
                }
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
 <summary>
You're given strings jewels representing the types of stones that are jewels, and stones representing the stones you have.
Each character in stones is a type of stone you have. You want to know how many of the stones you have are also jewels.
Letters are case sensitive, so "a" is considered a different type of stone from "A".
 
Example 1:
Input: jewels = "aA", stones = "aAAbbbb"
Output: 3
Example 2:
Input: jewels = "z", stones = "ZZ"
Output: 0
 
Constraints:
•	1 <= jewels.length, stones.length <= 50
•	jewels and stones consist of only English letters.
•	All the characters of jewels are unique.
</summary>
 */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                int i, j, l = 0;
                //Using a for loop to iterate through the jewels string
                for (i = 0; i < jewels.Length; i++)
                {
                    //Using another for loop to iterate through the stones string
                    for (j = 0; j < stones.Length; j++)
                    {
                        //check if the letter from jewels matches with stones. If yes, increase the counter
                        if (jewels[i] == stones[j])
                        {
                            l++;

                        }
                    }
                }
                return l;// returning the counter
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }



        /*

        <summary>
        Given a string s and an integer array indices of the same length.
        The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: s = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"
        */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                var l = s.Length;
                int i;
                char[] result = new char[l];//Creating a char array of the length of string s

                //Using a for loop to iterate over the array and based on the indices value, we will insert the characters from string s to result array
                for (i = 0; i < l; i++)
                {
                    result[indices[i]] = s[i];
                }
                return new String(result);// returning result array after converting it to string
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
Given two arrays of integers nums and index. Your task is to create target array under the following rules:
•	Initially target array is empty.
•	From left to right read nums[i] and index[i], insert at index index[i] the value nums[i] in target array.
•	Repeat the previous step until there are no elements to read in nums and index.
Return the target array.
It is guaranteed that the insertion operations will be valid.
 
Example 1:
Input: nums = [0,1,2,3,4], index = [0,1,2,2,1]
Output: [0,4,1,3,2]


Explanation:
nums       index     target
0            0        [0]
1            1        [0,1]
2            2        [0,1,2]
3            2        [0,1,3,2]
4            1        [0,4,1,3,2]
*/
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {

                // creating target array
                int[] target = new int[nums.Length];
                // Using for loop to iterate through element in nums array
                for (int i = 0; i < nums.Length; i++)
                {
                    //Inserting the numbers in target array based on index
                    if (index[i] == i)
                    {
                        target[i] = nums[i];
                    }
                    else
                    {

                        for (int j = i; j > index[i]; j--)
                        {
                            target[j] = target[j - 1];
                        }
                        target[index[i]] = nums[i];
                    }
                }
                return target;
            }

            catch (Exception)
            {

                throw;
            }

        }
    }
}

/*I learned from this assignment how to use for loop, lists, strings, array and various library funtions
like Length,GetLength, ToArray, IndexOf.
Recommendation- It would be great if we receive more hands on experience regarding C# code and also
if the subject is made more flexible to use other languages as well.
*/
