using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CheckSumSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            string sas = "abcbaba";

             sas = sas.Remove( sas.IndexOf('a'), 1);
            Console.WriteLine(sas);
            long pal = substrCount(7, sas);
            Console.WriteLine(sas.Substring(0,2));
            var files = Directory.GetFiles(@"D:\Downloads02282019");
            int[] ar = new int[] { 3,3,1,2,3 };
            //long xl = repeatedString("aab", 882787);
            int[] arr1 = new int[] { 4, 3, 1, 2};

            int swap = minimumSwaps(arr1);
            // Linq query to find duplicates
            Dictionary <string, string> hashFiles = new Dictionary<string, string>();
            foreach(var file in files)
            {
                hashFiles.Add(file,getCheckSum(file));
            }

            var duplicates = hashFiles.GroupBy(s => s.Value, s => s.Key).Where(g => g.Count() > 1).Select(x => x).ToList();

            string str = string.Empty;
        }

        
        public static string getCheckSum(string file)
        {
            if (File.Exists(file))
            {
                using (FileStream fs = File.OpenRead(file))
                {
                    var sha = new SHA256Managed();
                    byte[] bytes = sha.ComputeHash(fs);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
            else
                return null;

        }

        public static int getNumberOfPairs (int[] arr)
        {
            int pairs = 0;
            HashSet<int> colors = new HashSet<int>();

            for(int i = 0; i < arr.Length; i ++)
            {
                if(!colors.Contains(arr[i]))
                {
                    colors.Add(arr[i]);
                }
                else
                {
                    pairs++;
                    colors.Remove(arr[i]);
                }
            }
            return pairs;
        }

        static int jumpingOnClouds(int[] c)
        {
            int count = 0;
            int i = 0;
            while( i < c.Length -2)
            {
                if(c[i + 2] == 0)
                {
                    i = i + 2;
                    count++;
                }
                else if (c[i + 1] == 0)
                {
                    i = i + 1;
                    count++;
                }
                else
                    return count;
            }

            return count;

        }
        static int equalizeArray(int[] arr)
        {
            
            int max = 1;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i< arr.Length; i++)
            {


                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(i, 1);
                }
                else
                {
                    int k = 0;
                    dict.TryGetValue(i, out k);
                    dict[arr[i]] = k + 1;

                    if( max < k + 1)
                    {
                        max = k + 1;
                    }
                }

            }
            return arr.Length - max;


            
        }

        static int countingValleys(int n, string s)
        {
            int v = 0;
            int lvl = 0;
            char[] st = s.ToCharArray();
            foreach (char c in st)
            {
                if (c == 'U')
                    ++lvl;
                if (c == 'D')
                    --lvl;

                if (lvl == 0 && c == 'U')
                    ++v;
            }
            return v;
        }

        static long repeatedString(string s, long n)
        {
            if (s.Length == 1 && s[0] == 'a')
                return n;
            long count = 0;
            int rcount = 0;
            //if(s.Length < n)
            //{
            long k = n / s.Length;
            long r = n % s.Length;
            //    {
            //        s += s;
            //    }

            //}
           
            char[] ch = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
               
                if (ch[i] == 'a')
                    count++;

            }
            count = count * k;
            for (int i = 0; i < r; i++)
            {

                if (ch[i] == 'a')
                    rcount++;

            }
            count = count + rcount;

            return count;
        }

        static int hourglassSum(int[][] arr)
        {
            int max = 0;

            for(int i = 0; i < 5; i ++)
            {
                int j = 0;
                int sum = 0;
                while (j < 5)
                {
                    sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                }
                if (max < sum)
                    max = sum;
            }

            return max;
        }

        static int minimumSwaps(int[] arr)
        {
            int swap = 0;
            for(int i = 0; i < arr.Length - 1; i ++)
            {
                if(arr[i] != i + 1)
                {
                    for (int j = i + 1; j < arr.Length ; j++)
                    {
                        int temp = 0;
                        if (arr[j] == i + 1)
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                            swap++;
                            break;
                        }
                    }
                }
                
            }
            return swap;

        }

        static void checkMagazine(string[] magazine, string[] note)
        {
            Array.Sort(magazine);
            List<string> mag = magazine.ToList();
            foreach( string s in note)
            {
                if(!mag.Remove(s))
                {
                   
                    Console.WriteLine("No");
                    
                    return;
                }
            }
            Console.WriteLine("Yes");

        }
        static string twoStrings(string s1, string s2)
        {
            var distS1 = s1.Distinct();
            var dist2 = s2.Distinct();
            if (distS1.Intersect(dist2).Any())
            {
                return "YES";

            }
            else
                return "NO";

        }


        static int activityNotifications(int[] expenditure, int d)
        {
            Queue<int> medians = new Queue<int>();
            int j = 0;
            for(int i = expenditure.Length - d; i < expenditure.Length; i ++ )
            {
                //int med = (i - j) % 2 == 0 ? (i )
            }

            return 0;

        }

        static long substrCount(int n, string s)
        {
            long count = s.Length;
            count += subsets(s);
            return count;
        }

        static bool ispalindrome(string s)
        {
            char[] str = s.ToCharArray();
            Array.Reverse(str);
            string st = new string(str);
            if (s.Equals(st))
            {
                if(s.Distinct().Count() > 2)
                       return false;

                return true;
            }
                

            else
                return false;
        }

        static long subsets(string s)
        {
            long count = 0;
            if (s.Length < 2)
                return count;

            if (ispalindrome(s))
                count++;
            string s1 = s.Substring(0, s.Length - 1);
            string s2 = s.Substring(1, s.Length);
            count += subsets(s1);

            count += subsets(s2);

            return count;
        }

        static int makeAnagram(string a, string b)
        {
            int stringLength2 = b.Length;
            int count = 0;
            foreach(char s in a)
            {
                if (b.Contains(s))
                {
                  b = b.Remove(b.IndexOf(s),1);
                    count = count + 2;
                }
                    
                
            }

            return a.Length + stringLength2 - count;

        }
    }
}
