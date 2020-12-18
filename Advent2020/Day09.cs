using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day09:DayClass
    {
        public override string Part1()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day9.txt");


            string ln = sr.ReadToEnd();
            
            long ans = 0;
            List<long> nums = new List<long>();
            

            while ((ln = sr.ReadLine()) != null)
            {
                nums.Add(long.Parse(ln)); 
            }

            
            
            int step = 25;
             
            for (int i = step; i < nums.Count; i++)
            {
                if (!FindSum(nums, i, step))
                {
                    ans = nums[i];
                    break;
                }
            }
            sr.Close();

            sw.Stop();
            string ret = "answer: " + ans.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day9.txt");

            string ln = "";
            long ans = 0;
            List<long> nums = new List<long>();
            while ((ln = sr.ReadLine()) != null)
            {
                nums.Add(long.Parse(ln));
            }


            int step = 25;

            //373803594

            ans = FindBlock(nums, 373803594);

            sr.Close();

            sw.Stop();
            string ret = "Answer: " + ans.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        bool FindSum(List<long> nums, int pos, int step)
        {
            for (int i = pos-step; i < pos-1; i++)
            {
                for (int j = pos-step+1; j < pos;j++)
                {
                    if (nums[i] + nums[j] == nums[pos])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        long FindBlock(List<long> nums, long blocksum)
        {
            long thissum;
            for (int i = 0; i < nums.Count-1; i++)
            {
                thissum = nums[i];
                long min = nums[i];
                long max = nums[i];
                for (int j = i + 1; j < nums.Count; j++)
                {
                    thissum += nums[j];
                    if (nums[j]> max)
                    {
                        max = nums[j];
                    }
                    if (nums[j] < min)
                    {
                        min = nums[j];
                    }
                    if (thissum == blocksum)
                    {
                        return min+max;
                    }
                        
                }
            }

            return 0;
        }
    }
}
