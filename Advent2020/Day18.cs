using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day18 : DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day18.txt");

            string ln = "";
            long sum = 0;

//5 + (8 * 3 + 9 + 3 * 4 * 3)
//5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
//((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2

            while ((ln = sr.ReadLine()) != null)
            {
                ln = ln.Replace(" ", "");
                sum += CalcLine(ln);
            }



            sw.Stop();

            sr.Close();
            string ret = "Answer: " + sum.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day18.txt");

            string ln = "";
            long sum = 0;

            //5 + (8 * 3 + 9 + 3 * 4 * 3)
            //5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
            //((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2

            while ((ln = sr.ReadLine()) != null)
            {
                ln = ln.Replace(" ", "");
                sum += CalcLine2(ln);
            }



            sw.Stop();

            sr.Close();
            string ret = "Answer: " + sum.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        long CalcLine(string ln)
        {
            long sum = 0;


            while (ln.Contains("("))
            {
                int p1 = ln.IndexOf("(");
                int p2 = ln.IndexOf("(", p1 + 1);
                int e = ln.IndexOf(")");

                while (p2 < e && p2 > 0)
                {
                    p1 = p2;
                    p2 = ln.IndexOf("(", p1 + 1);
                }
                long thissum = CalcLine(ln.Substring(p1 + 1, e - p1 - 1));

                ln = ln.Substring(0, p1) + thissum.ToString() + ln.Substring(e + 1);

            }

            string num = "";
            string op = "";
            for (int i = 0; i < ln.Length; i++)
            {

                if (ln.Substring(i, 1) == "+")
                {
                    sum = DoMath(op, sum, num);

                    op = "+";
                    num = "";
                }
                else if (ln.Substring(i, 1) == "*")
                {
                    sum = DoMath(op, sum, num);
                    op = "*";
                    num = "";
                }
                else
                {
                    num += ln.Substring(i, 1);
                }
            }

            sum = DoMath(op, sum, num);

            return sum;
        }

        long DoMath(string op, long sum, string num)
        {
            long calc;

            if (op == "")
            {
                calc = int.Parse(num);
            }
            else if (op == "+")
            {
                calc = sum + int.Parse(num);
            }
            else
            {
                calc = sum * int.Parse(num);
            }
            return calc;

        }

        long CalcLine2(string ln)
        {
            long sum = 0;


            while (ln.Contains("("))
            {
                int p1 = ln.IndexOf("(");
                int p2 = ln.IndexOf("(", p1 + 1);
                int e = ln.IndexOf(")");

                while (p2 < e && p2 > 0)
                {
                    p1 = p2;
                    p2 = ln.IndexOf("(", p1 + 1);
                }
                long thissum = CalcLine2(ln.Substring(p1 + 1, e - p1 - 1));

                ln = ln.Substring(0, p1) + thissum.ToString() + ln.Substring(e + 1);

            }


            while (ln.Contains("+"))
            {

                ln = ReplaceOneSum(ln);
                
            }


            string num = "";
            string op = "";
            for (int i = 0; i < ln.Length; i++)
            {

                if (ln.Substring(i, 1) == "+")
                {
                    sum = DoMath(op, sum, num);

                    op = "+";
                    num = "";
                }
                else if (ln.Substring(i, 1) == "*")
                {
                    sum = DoMath(op, sum, num);
                    op = "*";
                    num = "";
                }
                else
                {
                    num += ln.Substring(i, 1);
                }
            }

            sum = DoMath(op, sum, num);

            return sum;
        }
        string ReplaceOneSum(string ln)
        {
            string newln = "";

            int p1 = ln.IndexOf("+");
            string num1 = "";
            string num2 = "";
            int b1 = 0;
            int b2 = -1;
            for (int i= p1-1; i>=0; i--)
            {
                if(ln.Substring(i,1)=="*")
                {
                    b1 = i;
                    break;
                }
                else
                {
                    num1 = ln.Substring(i, 1) + num1;
                }

            }

            for (int i = p1+1; i < ln.Length; i++)
            {
                if (ln.Substring(i, 1) == "*" || ln.Substring(i, 1) == "+")
                {
                    b2 = i;
                    break;
                }
                else
                {
                    num2 += ln.Substring(i, 1);
                }
            }

            int ans = int.Parse(num1) + int.Parse(num2);

            if (b1 > 0)
            {
                newln = ln.Substring(0, b1+1);
            }
            newln += ans.ToString();
            
            
            if (b2 > 0)
            {
                newln += ln.Substring(b2);
            }

            return newln;
           
        }
            

    }
}
