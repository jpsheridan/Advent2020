using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day04:DayClass
    {
        public struct pp
        {
            public bool byr;
            public bool iyr;
            public bool eyr;
            public bool hgt;
            public bool hcl;
            public bool ecl;
            public bool pid;
            public bool cid;
        }
        
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day4.txt");

            string ln = "";
            pp thispp = new pp();
            int validpp = 0;

            

            while ((ln = sr.ReadLine()) != null)
            {
                if (ln == "")
                {
                    if (thispp.byr && thispp.iyr && thispp.eyr && thispp.hgt &&
                           thispp.hcl && thispp.ecl && thispp.pid)
                    {
                        validpp++;
                    }

                    thispp = new pp();
                }

                if (ln.Contains("byr:"))
                    thispp.byr = true;
                if (ln.Contains("iyr:"))
                    thispp.iyr = true;
                if (ln.Contains("eyr:"))
                    thispp.eyr = true;
                if (ln.Contains("hgt:"))
                thispp.hgt = true; 
                if (ln.Contains("hcl:"))
                thispp.hcl = true;
                if (ln.Contains("ecl:"))
                thispp.ecl = true;
                if (ln.Contains("pid:"))
                thispp.pid = true; 
                if (ln.Contains("cid:"))
                thispp.cid = true; 


            }

            if (thispp.byr && thispp.iyr && thispp.eyr && thispp.hgt &&
                          thispp.hcl && thispp.ecl && thispp.pid)
            {
                validpp++;
            }


            sw.Stop();

            sr.Close();
            string ret = "Answer: " + validpp.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day4.txt");

            string ln = "";
            pp thispp = new pp();
            int validpp = 0;

            while ((ln = sr.ReadLine()) != null)
            {
                if (ln == "")
                {
                    if (thispp.byr && thispp.iyr && thispp.eyr && thispp.hgt &&
                           thispp.hcl && thispp.ecl && thispp.pid)
                    {
                        validpp++;
                    }

                    thispp = new pp();
                }

                int i = 0;

                if (ln.Contains("byr:"))
                {
                    string fld = GetFld(ln, "byr:");

                    if (fld.Length == 4)
                    {
                        if (int.TryParse(fld, out i))
                        {
                            if (i>=1920 & i <= 2002)
                            {
                                thispp.byr = true;
                            }
                        }
                    }
                    
                }

                if (ln.Contains("iyr:"))
                {
                    string fld = GetFld(ln, "iyr:");
                    if (fld.Length == 4)
                    {
                        if (int.TryParse(fld, out i))
                        {
                            if (i >= 2010 & i <= 2020)
                            {
                                thispp.iyr = true;
                            }
                        }
                    }
                }

                if (ln.Contains("eyr:"))
                {
                    string fld = GetFld(ln, "eyr:");
                    if (fld.Length == 4)
                    {
                        if (int.TryParse(fld, out i))
                        {
                            if (i >= 2020 & i <= 2030)
                            {
                                thispp.eyr = true;
                            }
                        }
                    }
                }

                if (ln.Contains("hgt:"))
                {
                    string fld = GetFld(ln, "hgt:");
                    string h = "";
                    if (fld.Contains("in"))
                    {
                        h = fld.Substring(0, fld.IndexOf("in"));
                        if (int.TryParse(h, out i))
                        {
                            if (i >= 59 & i <= 76)
                            {
                                thispp.hgt = true;
                            }
                        }
                    }
                    else if (fld.Contains("cm"))
                    {
                        h = fld.Substring(0, fld.IndexOf("cm"));
                        if (int.TryParse(h, out i))
                        {
                            if (i >= 150 & i <= 193)
                            {
                                thispp.hgt = true;
                            }
                        }
                    }
                }
                if (ln.Contains("hcl:"))
                {
                    string fld = GetFld(ln, "hcl:");
                    if (fld.StartsWith("#") && fld.Length==7)
                    {
                        
                        thispp.hcl = true;
                    }
                    
                }

                if (ln.Contains("ecl:"))
                {
                    string fld = GetFld(ln, "ecl:");
                    if (fld=="amb" || fld=="blu" || fld=="brn" || fld== "gry"
                        || fld=="grn" || fld == "hzl" || fld == "oth")
                    {
                            thispp.ecl = true;
                        
                    }
                    
                }

                if (ln.Contains("pid:"))
                {
                    string fld = GetFld(ln, "pid:");
                    if (fld.Length == 9)
                    {
                        if (int.TryParse(fld, out i))
                        {
                            thispp.pid = true;
                        }
                    }
                    
                }
                if (ln.Contains("cid:"))
                {
                    //string fld = GetFld(ln, "cid:");
                    thispp.cid = true;
                }
                    


            }

            if (thispp.byr && thispp.iyr && thispp.eyr && thispp.hgt &&
                          thispp.hcl && thispp.ecl && thispp.pid)
            {
                validpp++;
            }


            sw.Stop();

            sr.Close();
            string ret = "Answer: " + validpp.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        string GetFld(string ln, string fld)
        {
            string yr = "";

            if (ln.Contains(fld))
            {
                int spos = ln.IndexOf(fld) + 4;
                int epos = ln.IndexOf(" ", spos);

                
                if (epos > 0)
                {
                    yr = ln.Substring(spos, epos-spos);
                }
                else
                {
                    yr = ln.Substring(spos);
                }

            }
            return yr;
        }

    }
}
