using System;

namespace Assignment1_Spring2020_Sri
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //int n = 5;
            //PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            //string s = "09:15:35PM";
            //string t = UsfTime(s);
            //Console.WriteLine(t);

            //int n3 = 110;
            //int k = 11;
            //UsfNumbers(n3, k);

            //string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            //PalindromePairs(words);

            //int n4 = 8;
            //Stones(n4);


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



    }
}
