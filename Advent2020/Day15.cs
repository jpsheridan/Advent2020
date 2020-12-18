using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day15:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day15b.txt");


            List<long> nums = new List<long> { 0, 3, 6 };
            Dictionary<long, long> num = new Dictionary<long, long>();

            num.Add(1, 1);
            num.Add(20, 2);
            num.Add(11, 3);
            num.Add(6, 4);
            num.Add(12, 5);



            int pos = 6;
            long lastnum = 0;


            long lastpos = 0;
            long thispos = 0;
            while (pos < 2020)
            {
                if (num.ContainsKey(lastnum))
                {
                    lastpos = num[lastnum];
                    thispos = pos - lastpos;
                }
                else
                {
                    thispos = 0;
                }
                num[lastnum] = pos;
                lastnum = thispos;
                pos++;
            }




            sw.Stop();
            sr.Close();
            string ret = "Answer: " + lastnum.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day15b.txt");


            Dictionary<long, long> num = new Dictionary<long, long>();

            num.Add(1, 1);
            num.Add(20, 2);
            num.Add(11, 3);
            num.Add(6, 4);
            num.Add(12, 5);



            int pos = 6;
            long lastnum = 0;

            long lastpos = 0;
            long thispos = 0;
            while (pos < 30000000)
            {
                if (num.ContainsKey(lastnum))
                {
                    //lastpos = num[lastnum];
                    //thispos = pos - lastpos;
                    thispos = pos - num[lastnum];
                }
                else
                {
                    thispos = 0;
                }
                num[lastnum] = pos;
                lastnum = thispos;
                pos++;
            }

            //long[] num = new long[30000000];

            //num[1] = 1;
            //num[20] = 2;
            //num[11] = 3;
            //num[6] = 4;
            //num[12] = 5;

            //int pos = 6;
            //long lastnum = 0;

            //long thispos = 0;
            //while (pos < 30000000)
            //{
            //    if (num[lastnum] == 0)
            //    {
            //        thispos = 0; 
            //    }
            //    else
            //    {
            //        thispos = pos - num[lastnum];
            //    }
            //    num[lastnum] = pos;
            //    lastnum = thispos;
            //    pos++;
            //}



            sw.Stop();
            sr.Close();
            string ret = "Answer: " + lastnum.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

    }
}
