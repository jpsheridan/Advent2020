using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day10 : DayClass
    {
        Dictionary<int, long> joltcount = new Dictionary<int, long>();
        public override string Part1()
        {
            ////long[] nums2 = ln.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(n => (long.Parse(n))).ToArray();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day10.txt");

            string ln = "";
            List<int> jolts = new List<int>();
            while ((ln = sr.ReadLine()) != null)
            {
                jolts.Add(int.Parse(ln));
            }

            int mult = ParseList(jolts);



            sw.Stop();
            sr.Close();
            string ret = "Answer: " + mult.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day10.txt");
            string ln = "";

            List<int> jolts = new List<int>();

            while ((ln = sr.ReadLine()) != null)
            {
                    jolts.Add(int.Parse(ln));
            }
            jolts.Add(0);
            jolts.Sort();
            jolts.Add(jolts[jolts.Count()-1] + 3);

            long adapts = ListCount(jolts, 0, "");
            long t = ScottsMethod(jolts);




            sw.Stop();

            sr.Close(); 
            string ret = "Answer:" + adapts.ToString()  + " - " + t.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        int ParseList(List<int> jolts)
        {

            jolts.Sort();
            int ones = 0;
            int threes = 0;
            int lastj = 0;

            foreach(int j in jolts)
            {
                int diff = j - lastj;
                if (diff == 1)
                {
                    ones++;
                }
                else if (diff==3)
                {
                    threes++;
                }
                else
                {
                    int help = 0;
                }
                lastj = j;
            }
            threes++;
            return ones * threes;
        }

        long ListCount(List<int> jolts, int curpos, string curstr)
        {

            int cur = jolts[curpos];
            long c = 0;

            for (int i = curpos + 1; i < jolts.Count; i++)
            {
                
                if ((jolts[i] - cur) < 4)
                {
                    if (i == jolts.Count-1)
                    {
                       //Debug.WriteLine(curstr);
                        c++;
                    }
                    else
                    {
                       // curstr += "-" + jolts[i];
                        if (joltcount.ContainsKey(i))
                        {
                            c += joltcount[i];
                        }
                        else
                        {
                            long tc = ListCount(jolts, i, curstr);
                            joltcount.Add(i, tc);
                            c += tc;
                        }
                        
                    }
                    
                }
                else
                {
                    break;
                }
                
            }
            return c;
        }
        
        long ScottsMethod(List<int> jolts)
        {
            jolts.Reverse();
            
            joltcount = new Dictionary<int, long>();
            joltcount[jolts[0]] = 1;
            for (int j = 1; j <  jolts.Count; j++)
            {
                int cur = jolts[j];
                joltcount[cur] = (joltcount.ContainsKey(cur + 1) ? joltcount[cur + 1] : 0)
                           
                           + (joltcount.ContainsKey(cur + 3) ? joltcount[cur + 3] : 0);
            }

            return joltcount[0];
        }
    }
}
