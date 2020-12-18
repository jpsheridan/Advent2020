using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day08 : DayClass
    {
        public long acc;
        public bool exit = false;
        
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day8.txt");

            string ln = "";
            
            List<(string, int)> prog = new List<(string op, int val)>();

            while ((ln = sr.ReadLine()) != null)
            {
                string[] p = ln.Split(' ');
                prog.Add((p[0], int.Parse(p[1])));
            }

            RunProg(prog);
            sw.Stop();

            sr.Close();
            string ret = "Accumulator: " + acc.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day8.txt");

            string ln = "";
            List<(string, int)> prog = new List<(string op, int val)>();

            while ((ln = sr.ReadLine()) != null)
            {
                string[] p = ln.Split(' ');
                prog.Add((p[0], int.Parse(p[1])));
            }

            TestProg(prog);
            sw.Stop();

            sr.Close();
            string ret = "Accumulator: " + acc.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        void RunProg(List<(string op, int val)> prog)
        {
            int curinst = 0;
            List<int> exec = new List<int>();

            while (true)
            {
                if (exec.Contains(curinst))
                {
                    
                    return;
                }
                else
                {
                    if (curinst >= prog.Count)
                    {
                        exit = true;
                        return;
                    }
                    exec.Add(curinst);
                    switch(prog[curinst].op)
                    {
                        case "acc":
                            acc += prog[curinst].val;
                            curinst++;
                            break;
                        case "jmp":
                            curinst += prog[curinst].val;
                            break;
                        case "nop":
                            curinst++;
                            break;
                    }
                }

            }
        
            
        }

        void TestProg( List<(string op, int val)> prog)
        {
            
            List<int> exec = new List<int>();
            

            for (int i = 0; i < prog.Count; i++)
            {
                List<(string, int)> newprog = new List<(string, int)>(prog);
                if (prog[i].op == "nop")
                {
                    newprog[i] = ("jmp", prog[i].val);
                }
                else if (prog[i].op == "jmp")
                {
                    newprog[i] = ("nop", prog[i].val);
                }
                acc = 0;
                RunProg(newprog);
                if (exit)
                {
                    return;
                }
            }


        }

        void TestProg2(List<(string op, int val)> prog)
        {

            List<int> exec = new List<int>();

            List<(string, int)> newprog = new List<(string, int)>(prog);

            for (int i = 0; i < prog.Count; i++)
            {
                

                if (prog[i].op == "nop")
                {
                    newprog[i] = ("jmp", prog[i].val);
                }
                else if (prog[i].op == "jmp")
                {
                    newprog[i] = ("nop", prog[i].val);
                }
                acc = 0;
                RunProg(newprog);
                if (exit)
                {
                    return;
                }

                newprog[i] = prog[i];
            }


        }

    }
}
