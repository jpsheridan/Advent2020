using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AdventCode
{
    public class Day02:DayClass
    {
        public override string Part1()
        {
            // Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan.
            // The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day. 
            // "Something's wrong with our computers; we can't log in!" You ask if you can take a look.
            // Their password database seems to be a little corrupted: some of the passwords wouldn't 
            // have been allowed by the Official Toboggan Corporate Policy that was in effect when they were chosen.
            // To try to debug the problem, they have created a list(your puzzle input) of passwords(according to the corrupted database) 
            // and the corporate policy when that password was set.

            // For example, suppose you have the following list:
            // 1 - 3 a: abcde
            // 1 - 3 b: cdefg
            // 2 - 9 c: ccccccccc

            //  Each line gives the password policy and then the password.
            // The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
            // For example, 1 - 3 a means that the password must contain a at least 1 time and at most 3 times.

            // In the above example, 2 passwords are valid.The middle password, cdefg, is not; it contains no instances of b,
            // but needs at least 1.The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.

            //How many passwords are valid according to their policies?

            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day2.txt");

            string ln = "";
            int valid = 0;

            while ((ln=sr.ReadLine())!=null)
            {
                int p1 = ln.IndexOf("-");
                int p2 = ln.IndexOf(" ");
                int p3 = ln.IndexOf(":");

                int min = int.Parse(ln.Substring(0, p1));
                int max = int.Parse(ln.Substring(p1 + 1, p2 - p1));
                char l = char.Parse(ln.Substring(p2 + 1, 1));

                string pass = ln.Substring(p3 + 2);

                int c = pass.Count(ch => ch == l);
                
                
                if (c >= min && c <= max)
                {
                    valid++;
                }
                

            }
            sw.Stop();

            sr.Close();
            string ret = "Valid Passes: " + valid.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }

        public override string Part2()
        {
            // While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.
            // The shopkeeper suddenly realizes that he just accidentally explained the password policy rules 
            // from his old job at the sled rental place down the street!The Official Toboggan Corporate Policy actually works a little differently.
            // Each policy actually describes two positions in the password, where 1 means the first character, 
            // 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) 
            // Exactly one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
            // Given the same example list from above:

            // 1 - 3 a: abcde is valid: position 1 contains a and position 3 does not.
            // 1 - 3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
            // 2 - 9 c: ccccccccc is invalid: both position 2 and position 9 contain c.

            // How many passwords are valid according to the new interpretation of the policies ?

            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader("c:\\temp\\advent_2020\\advent_2020_day2.txt");

            string ln = "";
            int valid = 0;

            while ((ln = sr.ReadLine()) != null)
            {
                int p1 = ln.IndexOf("-");
                int p2 = ln.IndexOf(" ");
                int p3 = ln.IndexOf(":");

                int min = int.Parse(ln.Substring(0, p1));
                int max = int.Parse(ln.Substring(p1 + 1, p2 - p1));
                string let = ln.Substring(p2 + 1, 1);
                string pass = ln.Substring(p3 + 2);

                string pos1 = pass.Substring(min-1, 1);
                string pos2 = pass.Substring(max-1, 1);

                if ((pos1 == let || pos2==let)  && (pos1!=pos2))
                {
                    valid++;
                }

                

            }
            sw.Stop();

            sr.Close();
            string ret = "Valid Passes: " + valid.ToString();
            ret += Environment.NewLine + "Time: " + sw.ElapsedMilliseconds.ToString();
            return ret;
        }
    

    }
}
