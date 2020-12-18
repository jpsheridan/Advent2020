using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Numerics;

namespace AdventCode
{
    class Day16 : DayClass
    {
            public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day16.txt");

            string ln = "";
            
            Dictionary<string, List<int>> fields = new Dictionary<string, List<int>>();
            int[] myticket = new int[0];
            List<int[]> nearby = new List<int[]>();
            bool bNear = false;
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln == "")
                {
                    ln = sr.ReadLine();
                    ln = sr.ReadLine();
                    myticket = ln.Split(',').Select(n=>int.Parse(n)).ToArray();
                    ln = sr.ReadLine();
                    ln = sr.ReadLine();
                    bNear = true;
                }
                else if (bNear)
                {
                    int[] t;
                    nearby.Add(ln.Split(',').Select(n => int.Parse(n)).ToArray());
                }
                else
                {
                    int p1 = ln.IndexOf(":");
                    int p2 = ln.IndexOf("or ");

                    string f = ln.Substring(0, p1);
                    string r1 = ln.Substring(p1 + 2, p2 - p1 - 2);
                    string r2 = ln.Substring(p2 + 3);

                    int[] s = r1.Split('-').Select(n => int.Parse(n)).ToArray();

                    List<int> vals = new List<int>();
                    for (int i = s[0]; i <= s[1]; i++)
                    {
                        vals.Add(i);
                    }

                    s = r2.Split('-').Select(n => int.Parse(n)).ToArray();

                    for (int i = s[0]; i <= s[1]; i++)
                    {
                        vals.Add(i);
                    }
                    fields.Add(f, vals);
                }
            }
            int err = CompareTickets(myticket, fields);

            foreach (int[] ticket in nearby)
            {
                err += CompareTickets(ticket, fields);
            }


            sw.Stop();

            sr.Close();
            string ret = "Errors: " + err.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day16.txt");

            string ln = "";
            string code = "";

            Dictionary<string, List<int>> fields = new Dictionary<string, List<int>>();
            int[] myticket = new int[0];
            List<int[]> nearby = new List<int[]>();
            bool bNear = false;
            while ((ln = sr.ReadLine()) != null)
            {
                if (ln == "")
                {
                    ln = sr.ReadLine();
                    ln = sr.ReadLine();
                    myticket = ln.Split(',').Select(n => int.Parse(n)).ToArray();
                    ln = sr.ReadLine();
                    ln = sr.ReadLine();
                    bNear = true;
                }
                else if (bNear)
                {
                    int[] t;
                    nearby.Add(ln.Split(',').Select(n => int.Parse(n)).ToArray());
                }
                else
                {
                    int p1 = ln.IndexOf(":");
                    int p2 = ln.IndexOf("or ");

                    string f = ln.Substring(0, p1);
                    string r1 = ln.Substring(p1 + 2, p2 - p1 - 2);
                    string r2 = ln.Substring(p2 + 3);

                    p1 = r1.IndexOf("-");
                    int s1 = int.Parse(r1.Substring(0, p1));
                    int s2 = int.Parse(r1.Substring(p1 + 1));
                    List<int> vals = new List<int>();
                    for (int i = s1; i <= s2; i++)
                    {
                        vals.Add(i);
                    }

                    p1 = r2.IndexOf("-");
                    s1 = int.Parse(r2.Substring(0, p1));
                    s2 = int.Parse(r2.Substring(p1 + 1));

                    for (int i = s1; i <= s2; i++)
                    {
                        vals.Add(i);
                    }
                    fields.Add(f, vals);
                }
            }

            int err = CompareTickets(myticket, fields);

            for (int i = nearby.Count-1; i >= 0; i--)
            {
                if (CompareTickets(nearby[i], fields) > 0)
                {
                        nearby.RemoveAt(i);
                }
            }


            List<(string, List<int>)> fld = new List<(string, List<int>)>();
            List<(string, List<int>)> fld2 = new List<(string, List<int>)>();

            //List<(string, string)> fld = new List<(string, string)>();

            foreach (KeyValuePair<string, List<int>> f in fields)
            {
                string r = MatchCol(f.Value, nearby);
                Debug.WriteLine(f.Key + " - " + r);


                fld.Add((f.Key, r.Split(',').Select(n => int.Parse(n)).ToList()));
            }

            

            while (fld.Count > 0)
            {
                for (int i = fld.Count-1; i>=0; i--)
                {
                    if (fld[i].Item2.Count() == 1)
                    {
                        fld2.Add((fld[i].Item1, fld[i].Item2));
                        int thisnum = fld[i].Item2[0];
                        fld.RemoveAt(i);

                        for (int j = 0; j < fld.Count(); j++)
                        {
                            if (fld[j].Item2.Contains(thisnum))
                            {
                                fld[j].Item2.Remove(thisnum);
                            }
                                
                        }
                    }
                }
            }
            long num = 1;
            for (int i = 0; i < fld2.Count; i++)
            {
                if (fld2[i].Item1.StartsWith("departure"))
                {
                    num *= myticket[fld2[i].Item2[0]];
                }
            }
            //long num = (long)myticket[3] * (long)myticket[11] * (long)myticket[18] * (long)myticket[12] * (long)myticket[13] * (long)myticket[6];

            sw.Stop();

            sr.Close();
            string ret = "Errors: " + num.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        int CompareTickets(int[] ticket, Dictionary<string, List<int>> fields)
        {
            int err = 0;

            for (int i = 0; i < ticket.Length; i++)
            {
                bool bvalid = false;
                foreach(KeyValuePair<string, List<int>> f in fields)
                {
                    if (f.Value.Contains(ticket[i]))
                    {
                        bvalid = true;
                        break;
                    }
                }
                if (!bvalid)
                {
                    err += ticket[i];
                }

            }

            return err;
        }

        string MatchCol(List<int> vals, List<int[]> nearby)
        {
            List<int> ValidCols = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                ValidCols.Add(i);
            }
            foreach(int[] ticket in nearby)
            {
                for (int i = 0; i < ticket.Length; i++)
                {
                    if (ValidCols.Contains(i))
                    {
                        if (!vals.Contains(ticket[i]))
                        {
                            ValidCols.Remove(i);
                            if (ValidCols.Count == 1)
                            {
                                //return ValidCols[0];
                            }
                        }
                    }
                }
            }

            string r = "";
            foreach(int i in ValidCols)
            {
                r += i.ToString() + ",";
            }
            return r.Substring(0, r.Length-1);
        }

    }
}
