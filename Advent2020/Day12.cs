using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day12:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day12.txt");
            string ln = "";

            List<string> course = new List<string>();
            
            while ((ln = sr.ReadLine()) != null)
            {
                course.Add(ln);
            }

            int dist = Navigate(course);


            sw.Stop();
            sr.Close();
            string ret = "Answer: " + dist.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day12.txt");
            string ln = "";

            List<string> course = new List<string>();

            while ((ln = sr.ReadLine()) != null)
            {
                course.Add(ln);
            }

            int dist = Navigate2(course);


            sw.Stop();
            sr.Close();
            string ret = "Answer: " + dist.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        int Navigate(List<string> course)
        {

            int x = 0;
            int y = 0;
            int dir = 90;
            foreach(string c in course)
            {
                string key = c.Substring(0, 1);
                int val = int.Parse(c.Substring(1));
                switch(key)
                {
                    case "N":
                        y -= val;
                        break;
                    case "S":
                        y += val;
                        break;
                    case "E":
                        x += val;
                        break;
                    case "W":
                        x -= val;
                        break;
                    case "L":
                        dir -= val;
                        while (dir < 0)
                        {
                            dir += 360;
                        }
                        dir %= 360;
                        break;
                    case "R":
                        dir += val;
                        dir %= 360;

                        break;
                    case "F":
                        switch(dir)
                        {
                            case 0:
                                y -= val;
                                break;
                            case 90:
                                x += val;
                                break;
                            case 180:
                                y += val;
                                break;
                            case 270:
                                x -= val;
                                break;
                        }
                        break;


                }

            }

            return Math.Abs(x) + Math.Abs(y);
        }

        int Navigate2(List<string> course)
        {

            int x = 0;
            int y = 0;
            int wayx = 10;
            int wayy = -1;
            foreach (string c in course)
            {
                string key = c.Substring(0, 1);
                int val = int.Parse(c.Substring(1));
                switch (key)
                {
                    case "N":
                        wayy -= val;
                        break;
                    case "S":
                        wayy += val;
                        break;
                    case "E":
                        wayx += val;
                        break;
                    case "W":
                        wayx -= val;
                        break;

                    case "L":
                        for (int i = 90; i <= val; i += 90)
                        {
                            int t = wayx;
                            wayx =  wayy;
                            wayy = -1 * t;
                        }
                        break;

                    case "R":
                        if (val > 0)
                        {
                            for (int i = 90; i <= val; i += 90)
                            {
                                int t = wayx;
                                wayx = -1* wayy;
                                wayy = t;
                            }
                        }
                        break;
                    case "F":
                        x += val * wayx;
                        y += val * wayy;
                        break;
                }

            }

            return Math.Abs(x) + Math.Abs(y);
        }

    }
}
