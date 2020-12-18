using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day06:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day6.txt");

            string ln = "";
            List<string> ans = new List<string>();
            int sumc = 0;
            string a = "";
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln=="")
                {
                    sumc += a.Length;
                    a = "";
                }
                
                for (int i=0; i<ln.Length;i++)
                {
                    if (!a.Contains(ln.Substring(i,1)))
                    {
                        a += ln.Substring(i, 1);
                    }
                }

            }

            sumc += a.Length;
            a = "";

            sw.Stop();

            sr.Close();
            string ret = sumc.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day6.txt");

            string ln = "";
            List<string> ans = new List<string>();
            int sumc = 0;
            int gs = 0;
            string a = "";
            string a2 = "";
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln == "")
                {
                    sumc += a.Length;
                    a = "";
                    a2 = "";
                    gs = 0;
                }
                else
                {
                    gs++;
                }
                
                if (gs == 1)
                {
                    a = ln;
                }
                else
                {
                    for (int i = 0; i < ln.Length; i++)
                    {
                        if (a.Contains(ln.Substring(i, 1)))
                        {
                            a2 += ln.Substring(i, 1);
                        }
                    }
                    a = a2;
                    a2 = "";
                }

            }

            sumc += a.Length;
            a = "";

            sw.Stop();

            sr.Close();
            string ret = sumc.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

    }
}
