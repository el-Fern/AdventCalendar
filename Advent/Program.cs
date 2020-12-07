using System;
using System.Collections.Generic;

namespace Advent
{
    class Program
    {
        public static List<string> passports = new List<string>();

        static void Main(string[] args)
        {
            UpdatePassports();

            var validCount = 0;
            var attributesToLookFor = new List<string>() { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };

            foreach (var passport in passports)
            {
                var valid = true;
                if (passport.Contains("byr:"))
                {
                    try
                    {
                        var byr = Convert.ToInt32(passport.Substring(passport.IndexOf("byr:") + 4, passport.Substring(passport.IndexOf("byr:")).IndexOf(" ") - 4));

                        if (byr < 1920 || byr > 2002)
                        {
                            valid = false;
                            continue;
                        }
                    }
                    catch
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (passport.Contains("iyr:"))
                {
                    try
                    {
                        var iyr = Convert.ToInt32(passport.Substring(passport.IndexOf("iyr:") + 4, passport.Substring(passport.IndexOf("iyr:")).IndexOf(" ") - 4));

                        if (iyr < 2010 || iyr > 2020)
                        {
                            valid = false;
                            continue;
                        }
                    }
                    catch
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (passport.Contains("eyr:"))
                {
                    try
                    {
                        var eyr = Convert.ToInt32(passport.Substring(passport.IndexOf("eyr:") + 4, passport.Substring(passport.IndexOf("eyr:")).IndexOf(" ") - 4));

                        if (eyr < 2020 || eyr > 2030)
                        {
                            valid = false;
                            continue;
                        }
                    }
                    catch
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (passport.Contains("hgt:"))
                {
                    try
                    {
                        var hgt = passport.Substring(passport.IndexOf("hgt:") + 4, passport.Substring(passport.IndexOf("hgt:")).IndexOf(" ") - 4);

                        if (hgt.Contains("in"))
                        {
                            var inches = Convert.ToInt32(hgt.Substring(0, hgt.Length - 2));

                            if (inches < 59 || inches > 76)
                            {
                                valid = false;
                                continue;
                            }
                        }
                        else if (hgt.Contains("cm"))
                        {
                            var cms = Convert.ToInt32(hgt.Substring(0, hgt.Length - 2));

                            if (cms < 150 || cms > 193)
                            {
                                valid = false;
                                continue;
                            }
                        }
                        else
                        {
                            valid = false;
                            continue;
                        }
                    }
                    catch
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (passport.Contains("hcl:"))
                {
                    var hcl = passport.Substring(passport.IndexOf("hcl:") + 4, passport.Substring(passport.IndexOf("hcl:")).IndexOf(" ") - 4);

                    if (!hcl.StartsWith("#") || hcl.Length != 7)
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (passport.Contains("ecl:"))
                {
                    var ecl = passport.Substring(passport.IndexOf("ecl:") + 4, passport.Substring(passport.IndexOf("ecl:")).IndexOf(" ") - 4);

                    if (ecl != "amb" && ecl != "blu" && ecl != "brn" && ecl != "gry" && ecl != "grn" && ecl != "hzl" && ecl != "oth")
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }


                if (passport.Contains("pid:"))
                {
                    try
                    {
                        var pid = passport.Substring(passport.IndexOf("pid:") + 4, passport.Substring(passport.IndexOf("pid:")).IndexOf(" ") - 4);

                        if(pid.Length != 9)
                        {
                            valid = false;
                            continue;
                        }

                        Convert.ToInt32(pid);
                    }
                    catch
                    {
                        valid = false;
                        continue;
                    }

                }
                else
                {
                    valid = false;
                    continue;
                }

                if (valid)
                    validCount++;
            }

            Console.WriteLine("Valid Count: " + validCount);
        }

        private static void UpdatePassports()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:/Users/ah3353/source/repos/Advent/Advent/Inputs/Passports.txt");

            var newString = "";
            foreach (var line in lines)
            {
                if (line != "")
                    newString += " " + line;
                else
                {
                    newString += " ";
                    passports.Add(newString);
                    newString = "";
                }
            }
        }

        
    }
}
