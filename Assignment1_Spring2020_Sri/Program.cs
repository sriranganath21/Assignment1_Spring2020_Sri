using System;
using System.Globalization;

namespace Assignment1_Spring2020_Sri
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            UsfTime(s);


            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 23;
            Stones(n4);


        }

        /*n – number of lines for the pattern, integer (int)
         * summary   : This method prints number pattern of integers using recursion
         * For example n = 5 will display the output as: 
         * 54321
         * 4321
         * 321
         * 21
         * 1
         * returns      : N/A
         * return type  : void
         */

        private static void PrintPattern(int n)
        {
            int i, j;
            
            try
            {
                for (i = n; i >= 1; i--)
                {
                    for (j = i; j >= 1; j--) // loop to print the numbers in the decreasing order.
                    {
                        Console.Write(" " + j);
                    }
                    Console.WriteLine(); //traverse after printing the line, to the next.
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }

        }

        /*n2 – number of terms of the series, integer (int)
         * This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
         * For example, if n2 = 6, output will be
         * 1,3,6,10,15,21
         * Returns : N/A
         * Return type: void
         * Hint: Series is 1,1+2=3,1+2+3=6,1+2+3+4=10,1+2+3+4+5=15, 1+2+3+4+5+6=21……
         */

        private static void PrintSeries(int n2)
        {
            int b, sum = 0;
            try
            {
                if(n2!=0)
                {
                    for (b = 1; b <= n2; b++)
                    {
                        //sum gets overwritten in each iteration with its previous value and is added to the incrementing value of b
                        sum = sum + b;
                        Console.Write(sum + " ");
                    }
                }
                else
                {
                    Console.WriteLine("zero cannot be the length of the series. Invalid input !!");
                }

               
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        /* On planet “USF” which is similar to that of Earth follows different clock
         * where instead of hours they have U , instead of minutes they have S , instead
         * of seconds they have F. Similar to earth where each day has 24 hours, each hour
         * has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
         * U has 60 S and each S has 45 F. 
         * Your task is to write a method usfTime which takes 12HR  format and return string 
         * representing input time in USF time format.
         * Input format: A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or            * hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
         * Output format: a string with converted time in USF clock format (i.e. UU:SS:FF ) 
         * where 01<= UU<=36, 00<=SS<=59,00<=FF<=45*/

        public static void UsfTime(string s)
        {
            DateTime dateTime;  //I'm parsing the string as Datetime with a custom format "hh:mm:sstt", If TryParseExact fails, the date format entered by the user is wrong and a message will be displayed.
            if (DateTime.TryParseExact(s, "hh:mm:sstt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                TimeSpan span = dateTime.TimeOfDay;     //converting the 12 hour Earth time format to Time elapsed in a Day for total second calculation.
                string timeDuration = Convert.ToString(span);   //converting it back to string to split it into hrs, mins, secs
                int strhrs = Convert.ToInt32(timeDuration.Substring(0, 2));     //Substring to extract that particular part of the string
                int strmins = Convert.ToInt32(timeDuration.Substring(3, 2));
                int strsecs = Convert.ToInt32(timeDuration.Substring(6, 2));

                double noOfSecs;

                noOfSecs = (strhrs * 60 * 60) + (strmins * 60) + strsecs; //calculating secs of Earth time

                double usfhours = noOfSecs / (60 * 45);  // to calculate the USF hours we divide the total secs by 1 U ie (60*45)F.
                double hours_whole = Math.Truncate(usfhours); //To separate the whole number and the decimal part
                double hours_dec = usfhours - Math.Truncate(usfhours);


                double usfmins = hours_dec * 60; //The decimal part is then multiplied with 60 to get the "S" value in USF timing
                double mins_whole = Math.Truncate(usfmins);//To separate the whole number and the decimal part
                double mins_dec = usfmins - Math.Truncate(usfmins); 

                double usfsecs = mins_dec * 45; //The decimal part is then multiplied with 60 to get the "F" value in USF timing
                double secs_whole = Math.Truncate(usfsecs);

                Console.WriteLine("The time equivalent on the planet USF is " + hours_whole + "U :" + mins_whole + "S :" + secs_whole + "F");

            }
            else
            {
                Console.WriteLine("Invalid date format");
            }
        }

        /*n- total number of integers( 110 )
        * k-number of numbers per line ( 11)
        * USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
        * The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
        * multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
        * of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on. 
        * The output shall look like 
        * 1 2 U 4 S U F 8 U S 11 
        * U 13 F US 16 17 U 19 S UF 22
        * 23 U S 26 U F 29 US 31 32 U....
        * 
        * returns      : N/A
        * return type  : void
        */

        public static void UsfNumbers(int n3, int k)
        {
            int i;
            try
            {   
                if(n3!=0 && k!=0)
                {
                    for (i = 1; i <= n3; i++)
                    {
                        if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0) //divisible by 3,5,7
                        {
                            Console.Write("USF" + " ");
                        }
                        else if (i % 3 == 0 && i % 5 == 0) //divisible by 3 and 5
                        {
                            Console.Write("US" + " ");
                        }
                        else if (i % 5 == 0 && i % 7 == 0) //divisible by 5 and 7
                        {
                            Console.Write("SF" + " ");
                        }
                        else if (i % 3 == 0 && i % 7 == 0) //divisible by 3 and 7
                        {
                            Console.Write("UF" + " ");
                        }
                        else if (i % 3 == 0) //only divisible by 3
                        {
                            Console.Write("U" + " ");
                        }
                        else if (i % 5 == 0) //only divisible by 5
                        {
                            Console.Write("S" + " ");
                        }
                        else if (i % 7 == 0) //only divisible by 7
                        {
                            Console.Write("F" + " ");
                        }
                        else
                        {
                            Console.Write(i + " ");
                        }

                        if (i % k == 0)
                        {
                            Console.WriteLine(); // to go to a new line, we see if i is divisble by k
                        }
                    }

                }
                else
                {
                    Console.WriteLine("the length_of_series and the No_of_digits_per_line cannot be 0");
                }
                

            }
            catch (Exception)
            {
                Console.WriteLine("Exception occured while computing UsfNumbers");
            }
        }

        /*You are given a list of unique words, the task is to find all the pairs of 
         * distinct indices (i,j) in the given list such that, the concatenation of two
         * words i.e. words[i]+words[j] is a palindrome.
         * Example:
         * Input: ["abcd","dcba","lls","s","sssll"]
         * Output: [[0,1],[1,0],[3,2],[2,4]] 
         * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
         * Example:
         * Input: ["bat","tab","cat"]
         * Output: [[0,1],[1,0]] 
         * Explanation: The palindromes are ["battab","tabbat"]
         * 
         * returns      : N/A
         * return type  : void
         */

        public static void PalindromePairs(String[] words)
        {
            try
            {
                if(words.Length>1)
                {
                    string indices = "";

                    for (int i = 0; i < words.Length; i++)
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (i != j)
                            {

                                String concatStr = words[i] + words[j]; //concatination each word with every other word in the list
                                int left = 0;
                                int right = concatStr.Length - 1;
                                string rev = "";
                                while (right >= left)
                                {
                                    rev = rev + concatStr[right]; //reversing each word, and concatenating it to the original word
                                    right--;
                                }
                                if (concatStr == rev) //comparing the straight concatenated word with the reversed and concatenated word, to see if its palindrome
                                {
                                    indices = indices + "[" + i + "," + j + "]"; //cording the index positions

                                }

                            }

                        }
                    }
                    Console.WriteLine("[" + indices + "]");
                }
                else
                {
                    Console.WriteLine("The must be atleast more than one word in the list");
                }
                 
        }
        catch
        {

            Console.WriteLine("Exception occured while computing PalindromePairs()");
        }


        }

        /*You are playing a stone game with one of your friends. There are N number of 
         * stones in a bag, each time one of you take turns to take out 1 to 3 stones. 
         * The player who takes out the last stone will be the winner. In this case you
         * will be the first player to remove the stone(s)(Player 1).
         * 
         * Write a method to determine whether you can win the game given the number of 
         * stones in the bag. Print false if you cannot win the game, otherwise print any
         * one set of moves where you are winning the game. Array should contain moves by
         * both the players.
         * Input: 4
         * Output: false
         * Explanation: As there are 4 stones in the bag, you will never win the game. 
         * No matter 1,2 or 3 stones you take out, the last stone will always be removed by   * your friend.
         * Input: 5
          * Output: [1,1,3]   or [1,2,2] or [1,3,1]
          * Player 1 picks up 1 stone then player 2 picks up 1 or 2 or 3 stones and the  
          * remaining stones are picked up by player 1.
          * Explanation: As there are 5 stones in the bag, you take out one stone.
          * As there are 4 stones in the bag and it’s your friend’s turn. He will never win 
          * the game because no matter 1,2 or 3 stones he takes out, you will the one to take 
          * out the last stone.
          * 
          * returns      : N/A
          * return type  : void
          */
        public static void Stones(int n4)
        {
            try
            {
                if (n4 % 4 == 0) //if the total number of stone is in the multiples of 4, I will always loose
                {
                    Console.WriteLine("False");
                }
                else
                {
                    int a = n4 / 4; 
                    int b = a * 4;
                    int num = (b / 2) + 1; // //calculating the total number of turns to be played. My turn will always be an odd number

                    int FstTrn = n4 % 4; // first turn will always be the remainder value from dividing the number of stones by 4
                    Console.WriteLine(FstTrn);

                    for (int i = 1; i <= num / 2; i++)
                    {
                        Console.WriteLine("2"); //Hard coding to the 2 iterate for the rest of turns and the last stone will be picked by me.
                        Console.WriteLine("2");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing moves in Stones() ");
            }
        }
    }
}
