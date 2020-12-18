using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace AdventCode
{
    class Day23:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day23.txt");

            string ln = "";
            string code = "";

            while ((ln = sr.ReadLine()) != null)
            {

            }
            sw.Stop();

            sr.Close();
            string ret = code;
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day23.txt");
            string ln = "";

            while ((ln = sr.ReadLine()) != null)
            {

            }
            sw.Stop();

            sr.Close();
            string ret = "Answer:";
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }
    }
}
