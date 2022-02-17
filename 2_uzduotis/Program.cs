using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2_uzduotis
{
    /* 15-2 Longest palindrome subsequence
A palindrome is a nonempty string over some alphabet that reads the same forward and backward.Examples of palindromes
are all strings of length 1, civic, racecar, and aibohphobia(fear of palindromes).Give an efficient algorithm to find
the longest palindrome that is a subsequence of a given input string. For example, given the input character, your algorithm
should return carac.What is the running time of your algorithm?
*/
    class Program
    {
        static int countR = 0;
        static int countD = 0;

        static void Main(string[] args)
        {

            //kayak, madam,civic,mom
            char[] data1 = "kayakmadammmmmmhhhhh".ToCharArray(); //n=20
            char[] data2 = "kayakmadamcivicoooooyyyyy".ToCharArray();//n=25
            char[] data3 = "kayakmadamcivichhuuuuuttttthhh".ToCharArray();//n=30
            char[] data4 = "kayakmadamcivichhhhhdddrrrrrlsiyvbkayakkaaayakkayyakkayyyakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayakkayak".ToCharArray();//n=35

            Console.WriteLine("======================================");
            Console.WriteLine("Algoritmo realizacija rekursiniu būdu");
            var watch = Stopwatch.StartNew();
            int ans = F1(data1, 0, 19);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 20 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch = Stopwatch.StartNew();
            ans = F1(data2, 0, 24);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 25 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch = Stopwatch.StartNew();
            ans = F1(data3, 0, 29);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 30 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            Console.WriteLine("====================================");
            Console.WriteLine("Algoritmo realizacija dinaminiu būdu");
            watch = Stopwatch.StartNew();
            ans = F2(data1);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 20 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch = Stopwatch.StartNew();
            ans = F2(data2);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 25 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch = Stopwatch.StartNew();
            ans = F2(data3);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 30 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch = Stopwatch.StartNew();
            ans = F2(data4);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = " + data4.Count() + " : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            Console.ReadKey();
        }



        static int F1(char[] seq, int i, int j)
        {
            // jei yra tik 1 simbolis 
            if (i == j)
            {
                countR++;
                return 1;
            }

            // Jei yra 2 simboliai ir abu vienodi
            if (seq[i] == seq[j] && i + 1 == j)
            {
                countR++;
                return 2;
            }

            // Jei pirmas ir paskutinis simboliai vienodi  
            if (seq[i] == seq[j])
            {
                countR++;
                return F1(seq, i + 1, j - 1) + 2;
            }

            // Jei pirmas ir paskutinis simboliai nesutampa 
            countR++;
            return Math.Max(F1(seq, i, j - 1), F1(seq, i + 1, j));
        }

        static int F2(char[] seq)
        {
            int n = seq.Length;
            countD++;
            int i, j, cl;
            countD++;

            int[,] L = new int[n, n];
            countD++;

            for (i = 0; i < n; i++)
            {
                countD++;
                L[i, i] = 1;
            }
               
            for (cl = 2; cl <= n; cl++)
            {
                countD++;
                for (i = 0; i < n - cl + 1; i++)
                {
                    countD++;
                    j = i + cl - 1;

                    if (seq[i] == seq[j] && cl == 2)
                    {
                        countD++;
                        L[i, j] = 2;
                    }                 
                    else if (seq[i] == seq[j])
                    {
                        L[i, j] = L[i + 1, j - 1] + 2;
                        countD++;
                    }                    
                    else
                    {
                        L[i, j] = Math.Max(L[i, j - 1], L[i + 1, j]);
                        countD++;
                    }                    
                }
            }
            return L[0, n - 1];
        }

    }
}
    

