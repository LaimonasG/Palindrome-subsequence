using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorai2
{
    //1 užduoties 5 variantas
    class Program
    {
        static void Main(string[] args)
        {                      
            int[] w1 = { 7, 10, 2 };// n = 3
            int[] w2 = { 7, 10, 2, 7, 10, 2 };// n = 6
            int[] w3 = { 7, 10, 2, 7, 10, 2, 7, 10, 2 };// n = 9
            int[] w4 = { 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2 };// n = 12
            int[] w5 = { 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2 };// n = 15
            int[] w6 = { 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2, 7, 10, 2 };// n = 18

            int[] v1 = { 6, 1, 9 };// n = 3
            int[] v2 = { 6, 1, 9, 6, 1, 9 };// n = 6
            int[] v3 = { 6, 1, 9, 6, 1, 9, 6, 1, 9 };// n = 9
            int[] v4 = { 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9 };// n = 12
            int[] v5 = { 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9 };// n = 15
            int[] v6 = { 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9, 6, 1, 9 };// n = 18

            int[] save1 = { -1, -1, -1 };
            int[] save2 = { -1, -1, -1, -1, -1, -1 };
            int[] save3 = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] save4 = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] save5 = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            int[] save6 = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };

            Console.WriteLine("======================");
            Console.WriteLine("Rekursinis būdas");

            int W = 20;
            Console.WriteLine("W = " + W);

            var watch = Stopwatch.StartNew();
            int ans = F1(W, w1, v1);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 3 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F1(W, w2, v2);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 6 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");          

            watch.Reset();
            watch.Start();
            ans = F1(W, w3, v3);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 9 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");
      
            watch.Reset();
            watch.Start();
            ans = F1(W, w4, v4);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 12 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F1(W, w5, v5);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 15 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F1(W, w6, v6);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 18 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            
            Console.WriteLine("======================");
            Console.WriteLine("Dinaminis būdas");

            int W1 = 20;
            Console.WriteLine("W = " + W1);

            watch = Stopwatch.StartNew();
            ans = F2(W, w1, v1,save1);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 3 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F2(W, w2, v2, save2);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 6 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F2(W, w3, v3, save3);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 9 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F2(W, w4, v4, save4);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 12 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F2(W, w5, v5, save5);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 15 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            watch.Reset();
            watch.Start();
            ans = F2(W, w6, v6, save6);
            watch.Stop();
            Console.WriteLine("Atsakymas, kai n = 18 : " + ans + "  užtruko : " + watch.ElapsedMilliseconds.ToString() + " ms");

            Console.ReadKey();
        }

        static int F1(int W, int[] w, int[] v)
        {
            int max = 0;

            if (W == 0)
                return 0;

            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] <= W)
                {
                    int temp = F1(W - w[i], w, v) + v[i];
                    if (temp > max)
                        max = temp;
                }
            }
            return max;
        }

        public static int F2(int W, int[] w, int[] v, int[] memo)
        {
            int max = 0;
            if (W <= 0)
            {
                return 0;
            }

            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] <= W)
                {
                    int temp;
                    if (memo[i] != -1 && memo[i] < w[i])
                    {
                        temp = memo[i];
                    }
                    else
                    {
                        temp = F2(W - w[i], w, v, memo) + v[i];
                        if (memo[i] == -1)
                        {
                            memo[i] = temp;
                        }
                    }
                    if (temp > max)
                    {
                        max = temp;
                    }
                }
            }
            return max;
        }
    }
}
