using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day07:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day7.txt");

            string ln = "";
            Dictionary<string, List<string>> bags = new Dictionary<string, List<string>>();
            List<string> holders = new List<string>();
            while ((ln = sr.ReadLine()) != null)
            {
                int p = ln.IndexOf("bags");

                string c = ln.Substring(0, p-1);


                string[] baglist = ln.Substring(p + 13).Replace(".", "").Replace(", ", ",").Replace(" bags", "").Replace(" bag", "").Split(',');

                List<string> l = new List<string>();
                foreach (string bl in baglist)
                {
                    l.Add(bl.Substring(bl.IndexOf(" ")+1));
                }
                
                //l.Add();

                bags.Add(c, l);
                if(l.Contains("shiny gold"))
                {
                    holders.Add(c);
                }

            }

            List<string> newh = BagSearch(holders, bags);

            newh.AddRange(holders);
            List<string> deduped = newh.Distinct().ToList();
            sw.Stop();

            sr.Close();
            string ret = "Bag count = " + (deduped.Count).ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day7.txt");
            string ln = "";

            Dictionary<string, List<string>> bags = new Dictionary<string, List<string>>();
            List<string> holders = new List<string>();
            while ((ln = sr.ReadLine()) != null)
            {
                int p = ln.IndexOf("bags");

                string c = ln.Substring(0, p - 1);


                List<string> l = ln.Substring(p + 13).Replace(".", "").Replace(", ", ",").Replace(" bags", "").Replace(" bag", "").Split(',').ToList();


                bags.Add(c, l);

            }

            int bagcount = BagCount("shiny gold", bags);
            sw.Stop();

            sr.Close();
            string ret = "Answer: " + bagcount.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        List<string> BagSearch(List<string> col, Dictionary<string, List<string>> bagdict)
        {
            List<string> newc = new List<string>();
            foreach (string c in col)
            {
                foreach (KeyValuePair<string, List<string>> b in bagdict)
                {
                    if (b.Value.Contains(c))
                    {
                        newc.Add(b.Key);
                        
                    }

                }
            }

            List<string> new2 = new List<string>();
            if (newc.Count > 0)
            {
                new2 = BagSearch(newc, bagdict);
            }
            

            new2.AddRange(newc);


            return new2;
        }

        int BagCount(string col, Dictionary<string, List<string>> baglist)
        {
            int c = 0;


            if(baglist.ContainsKey(col))
            {
                foreach(string s in baglist[col])
                {
                    if (s != "no other")
                    {
                        int p = s.IndexOf(" ");

                        int n = int.Parse(s.Substring(0, p));
                        string newcol = s.Substring(p + 1);
                        
                        int bc = BagCount(newcol, baglist);
                        if (bc > 0)
                        {
                            c += n +  n * bc;
                        }
                        else
                        {
                            c += n;
                        }
                        
                    }

                }
            }


            return c;

        }
    }
}
