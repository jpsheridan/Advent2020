using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AdventCode
{
    public class Day05 : DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day5.txt");

            string ln = "";
            long max = 0;

            string seat = "FBFBBFFRLR";
            int st = (Decode7(seat.Substring(0, 7)) * 8) + Decode3(seat.Substring(7, 3));


            while ((ln = sr.ReadLine()) != null)
            {
                int s = (Decode7(ln.Substring(0, 7)) * 8) +  Decode3(ln.Substring(7, 3));
                if (s > max)
                {
                    max = s;
                }

            }
            sw.Stop();

            sr.Close();
            string ret = "Answer: " + max.ToString();

            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day5.txt");
            string ln = "";
            List<int> seats = new List<int>();

            while ((ln = sr.ReadLine()) != null)
            {
                int s = (Decode7(ln.Substring(0, 7)) * 8) + Decode3(ln.Substring(7, 3));
                seats.Add(s);
            }

            seats.Sort();
            for (int i = 3; i < seats.Count; i++)
            {
                if (seats[i] != (seats[i-1]+1))
                {
                    int k = 0;
                }
            }

            sw.Stop();

            sr.Close();
            string ret = "Answer:";
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        int Decode7(string rowcode)
        {
            int low = 0;
            int high = 127;
            for (int i = 0; i < 6; i++)
            {
                string fb = rowcode.Substring(i, 1);

                if (fb == "F")
                {
                    high = high - (((high + 1) - low) / 2);
                }
                else
                {
                    low = low + (((high + 1) - low) / 2);
                }
            }

            if (rowcode.Substring(6,1)=="F")
            {
                return low;
            }
            else
            {
                return high;
            }

        }

        int Decode3(string seatcode)
        {
            int low = 0;
            int high = 7;
            for (int i = 0; i < 2; i++)
            {
                string fb = seatcode.Substring(i, 1);

                if (fb == "L")
                {
                    high = high - (((high + 1) - low) / 2);
                }
                else
                {
                    low = low + (((high + 1) - low) / 2);
                }
            }

            if (seatcode.Substring(2, 1) == "L")
            {
                return low;
            }
            else
            {
                return high;
            }
        }
    }
}
