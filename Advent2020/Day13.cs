using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day13:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day13.txt");

            long mytime = 1001938;
            long[] buses = new long[]{ 41, 37, 431, 23, 13, 17, 19, 863, 29 };

            //mytime = 939;
            //long[] buses = new long[]{ 7,13,59,31,19};
            long mint = mytime * 10;
            long minbus = 0;

            foreach (long bus in buses)
            {
                long t = findnext(mytime, bus);
                if (t < mint)
                {
                    mint = t;
                    minbus = bus;
                }
            }
            
                
            


            sw.Stop();
            //sr.Close();
            string ret = "Answer = " + ((mint-mytime) * minbus).ToString() ;
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day13.txt");
            string ln = sr.ReadLine();

            string[] busline = ln.Split(',');
            List<(int, int)> buses = new List<(int, int)>();

            for (int i = 0; i < busline.Length; i++)
            {
                if (busline[i] != "x")
                {
                    Debug.WriteLine(i.ToString() + " - " + busline[i]);
                    buses.Add((int.Parse(busline[i]), i));
                }
                
            }

            long a = findconsecutive(buses);
            sw.Stop();
            //sr.Close();
            string ret = "Answer: " + a.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }
        long findnext(long time, long bus)
        {
            long t =  (time / bus) * bus;
            if (t < time)
            {
                t += bus;
            }
            return t;
        }

        long findconsecutive(List<(int time, int offset)> buses)
        {

            long n = buses[0].time;
            long step = buses[0].time;
            long lastn = 0;


            for (int i = 1; i < buses.Count; i++)
            {
                while (((n + buses[i].offset) % buses[i].time) != 0)
                {
                    n += step;
                }
                step *= buses[i].time;
            }

            return n;

        }
    }
}
