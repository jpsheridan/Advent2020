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
    
    public class Day14:DayClass
    {
        
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day14.txt");

            string ln = "";
            long[] mem = new long[75000];


            //Dictionary <long, long> mask = new Dictionary<long, long>();
            string mask = "";
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln.StartsWith("mask"))
                {
                    //mask = GetMask(ln);
                    mask = ln.Substring(ln.IndexOf("=") + 2);
                }
                else if (ln.StartsWith("mem"))
                {
                    int p1 = ln.IndexOf("[") + 1;
                    int p2 = ln.IndexOf("]");
                    int memloc = int.Parse(ln.Substring(p1, p2 - p1));
                    ulong memval = ulong.Parse(ln.Substring(ln.IndexOf("=") + 1));

                    string memstr = GetStr(memval);

                    string newmem = AddMask(mask, memstr);
                    mem[memloc] = GetStringVal(newmem);
                }

            }

            long retval = 0;
            for (int i = 0; i < 75000; i++)
            {
                retval += mem[i];
            }

            sw.Stop();
            sr.Close();
            string ret = retval.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day14.txt");
            //long[] mem = new long[75000];
            Dictionary<ulong, ulong> mem = new Dictionary<ulong, ulong>();
            string ln = "";

            //Dictionary <long, long> mask = new Dictionary<long, long>();
            string mask = "";
            int lc = 0;
            while ((ln = sr.ReadLine()) != null)
            {
                lc++;
               // Debug.WriteLine(lc.ToString());
                if (ln.StartsWith("mask"))
                {
                    //mask = GetMask(ln);
                    mask = ln.Substring(ln.IndexOf("=") + 2);
                }
                else if (ln.StartsWith("mem"))
                {
                    int p1 = ln.IndexOf("[") + 1;
                    int p2 = ln.IndexOf("]");
                    ulong  memloc = ulong.Parse(ln.Substring(p1, p2 - p1));
                    ulong memval = ulong.Parse(ln.Substring(ln.IndexOf("=") + 1));

                    string memstr = GetStr(memloc);

                    string nm = AddMask2(mask, memstr);
                    List<string> newmasks = new List<string>();

                    //newmasks = GetStringValFloat(nm);

                    GetAddrVals(nm, newmasks);

                    foreach (string s in newmasks)
                    {
                        ulong thisloc = (ulong)GetStringVal(s);
                        mem[thisloc] = (ulong)memval;
                    }

                }
            }


            ulong retval = 0;
            foreach (KeyValuePair<ulong, ulong> kvp in mem)
            {
                retval += kvp.Value;
            }

            sw.Stop();
            sr.Close();
            string ret = retval.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }


        Dictionary<long, long> GetMask(string ln)
        {
            Dictionary<long, long> mv = new Dictionary<long, long>();
            
            string maskval = ln.Substring(ln.IndexOf("=") + 2);
            int pow = 0;
            for (int i = maskval.Length - 1; i >= 0; i--)
            {
                if (maskval.Substring(i, 1) != "X")
                {
                    mv.Add(i, (long)Math.Pow(2, pow));
                }
                pow++;
            }

            return mv;
        }

        string GetStr(ulong val)
        {
            string memstr = "";

            for (int i = 35; i >= 0; i--)
            {
               ulong p = (ulong)Math.Pow(2, i);

                if ((p & val)==0)
                {
                    memstr += "0";
                }
                else
                {
                    memstr += "1";
                }

            }


            return memstr;
        }

        string AddMask(string mask, string mem)
        {
            string outstr = "";
            for (int i = 0; i < mask.Length; i++)
            {
                
                if (mask.Substring(i, 1)=="0")
                {
                    outstr += "0";
                }
                else if (mask.Substring(i, 1)=="1")
                {
                    outstr += "1";
                }
                else
                {
                    outstr += mem.Substring(i,1);
                }

            }
            return outstr;
        }

        string AddMask2(string mask, string mem)
        {
            string outstr = "";
            for (int i = 0; i < mask.Length; i++)
            {

                if (mask.Substring(i, 1) == "0")
                {
                    outstr += mem.Substring(i, 1); 
                }
                else
                {
                    outstr += mask.Substring(i,1);
                }
                

            }
            return outstr;
        }

        long GetStringVal(string mem)
        {
            long retval = 0;
            int pow = 0;
            for (int i = mem.Length-1; i >= 0; i--)
            {
                if (mem.Substring(i,1)=="1")
                {
                    retval += (long)Math.Pow(2, pow);
                }
                pow++;
            }
            return retval;
        }

       
        void GetMemVals(int startpos, string mem, List<string> memvals)
        {
            bool bdone = false;
            //List<string> newmem = new List<string>();
            for (int i = startpos; i < mem.Length; i++)
            {
                StringBuilder sb = new StringBuilder(mem);


                if (mem.Substring(i, 1) == "X")
                {
                    sb[i] = '0';
                    string m = sb.ToString();
                    if (!m.Contains("X"))
                    {
                        if (!memvals.Contains(m))
                        {
                            memvals.Add(m);
                            bdone = true;
                        }
                        

                    }
                    else
                    {
                        GetMemVals(i, m, memvals);
                        //memvals.AddRange(newmem);
                    }
                    
                    sb[i] = '1';
                    m = sb.ToString();
                    
                    if (!m.Contains("X"))
                    {
                        if (!memvals.Contains(m))
                        {
                            memvals.Add(m);
                            bdone = true;
                        }
                    }
                    else
                    {
                        GetMemVals(i, m, memvals);
                        //memvals.AddRange(newmem);
                    }

                }

                if (bdone)
                {
                    break;
                }

            }
         //   return memvals;
        }

        void GetAddrVals(string addr, List<string> memvals)
        {
            int pos = addr.IndexOf("X");

            if (pos < 0)
            {

                if (!memvals.Contains(addr))
                {
                    memvals.Add(addr);
                }

                return;
            }

            StringBuilder sb = new StringBuilder(addr);
            sb[pos] = '0';
            string m = sb.ToString();

            GetAddrVals(m, memvals);

            sb[pos] = '1';
            m = sb.ToString();

            GetAddrVals(m, memvals);
            
        }
    }
}
