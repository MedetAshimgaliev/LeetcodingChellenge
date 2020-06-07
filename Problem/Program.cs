using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Problem
{
    class Program
    {
        #region First week
        public static int SingleNumber(int[] nums)
        {
            Array.Sort(nums);

            for(int i=0; i < nums.Length; i++)
            {
                int f = 1;
                for (int j=0;j<nums.Length;j++)
                {
                    if(nums[i] == nums[j] && i != j)
                    {
                        f = 0;
                        break;
                    }
                }
                if (f == 1)
                {
                    return nums[i];
                }
            }

            return 0;
        }

        public static bool isHappy(int n)
        {
            if (n == 0)
            {
                return false;
            }

            List<int> listTested = new List<int>();

            while (n != 1)
            {
                if (listTested.Contains(n))
                {
                    return false;
                }
                else
                {
                    listTested.Add(n);
                    n = SquareDigitSum(n);
                }
            }

            return true;
        }

        private static int SquareDigitSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int single = n % 10;
                sum += single * single;
                n = n / 10;
            }
            return sum;
        }

        public static int MaxSubArray(int[] nums)
        {
            int result = int.MinValue;
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i; j < nums.Length; j++)
                {
                    int sum = 0;
                    for(int k = i; k <= j; k++)
                    {
                        sum += nums[k];
                    }

                    if (sum > result)
                    {
                        result = sum;
                    }
                }
            }
            return result;
        }

        public static int getMaxSubarraySum(int[] nums)
        {
            int currentMax = int.MinValue;
            int totalMax = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                currentMax = Math.Max(currentMax, 0) + nums[i];
                totalMax = Math.Max(totalMax, currentMax);
            }

            return totalMax;
        }

        public static void MoveZeros(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[index++] = nums[i];
                }
            }

            for(int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        public static int maxProfit(int[] prices)
        {
            int maxProfit = 0;

            if (prices.Length <= 1)
            {
                return maxProfit;
            }

            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }

            return maxProfit;
        }

        public IList<IList<string>> Solution(string[] strs)
        {

            var keyResult = new Dictionary<string, IList<string>>();

            foreach (string s in strs)
            {
                var count = Enumerable.Repeat(0, 26).ToList();
                foreach (char c in s)
                {
                    count[c - 'a']++;
                }
                string key = "";

                for (int i = 0; i < count.Count; i++)
                {
                    char c = Convert.ToChar('a' + i);
                    key += new string(c, count[i]);
                }
                if (keyResult.ContainsKey(key))
                {
                    keyResult[key].Add(s);
                }
                else
                {
                    keyResult.Add(key, new List<string> { s });
                }
            }

            return keyResult.Values.ToList();
        }

        public static int countElements(int[] arr)
        {
            List<int> st = new List<int>();
            foreach(int val in arr)
            {
                st.Add(val);
            }

            int count = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                if (st.Contains(arr[i] + 1))
                {
                    count++;
                }
            }

            return count;

        }

        #endregion

        #region Second Week

        public class ListNode
        {
             public int val;
             public ListNode next;
             public ListNode(int x) { val = x; }
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode a = head;
            ListNode b = head;

            while(b!=null && b.next != null)
            {
                a = a.next;
                b = b.next.next;
            }

            return a;

        }

        public bool BackspaceCompare(string S, string T)
        {
            Stack<char> S1 = new Stack<char>();
            Stack<char> S2 = new Stack<char>();

            foreach(char c in S)
            {
                if (c != '#')
                {
                    S1.Push(c);
                }
                else
                {
                    if(S1.Count > 0)
                    {
                        S1.Pop();
                    }
                }
            }

            foreach(char c in T)
            {
                if(c != '#')
                {
                    S2.Push(c);
                }
                else
                {
                    if (S2.Count > 0)
                    {
                        S2.Pop();
                    }
                }
            }

            while(S1.Count > 0 && S2.Count > 0)
            {
                char c1 = S1.Peek();
                S1.Pop();
                char c2 = S2.Peek();
                S2.Pop();

                if (c1 != c2)
                {
                    return false;
                }
            }

            if (S1.Count > 0 || S2.Count > 0)
            {
                return false;
            }

            return true;
        }

        public static int FindMaxLength(int[] nums)
        {
            int[] arr = new int[(2 * nums.Length) + 1];
            Array.Fill(arr, -2);
            arr[nums.Length] = -1;
            int maxlen = 0, count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 0 ? -1 : 1);
                if (arr[count + nums.Length] >= -1)
                {
                    maxlen = Math.Max(maxlen, i - arr[count + nums.Length]);
                }
                else
                {
                    arr[count + nums.Length] = i;
                }
            }

            return maxlen;
        }

        #endregion

        public static long Factorial(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public static long Fibb(int i)
        {
            if (i <= 2)
            {
                return 1;
            }
            else
            {
                return Fibb(i - 1) + Fibb(i - 2);
            }
        }

        public static IList<int> Selection(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }
            return list;
        }


        public static int NumberOfSteps(int num)
        {
            int count = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                    count++;
                }
                if (num % 2 == 1)
                {
                    num = num - 1;
                    count++;
                }
            }
            return count;
        }

        public static string DefangIPaddr(string address)
        {
            string result = "";
            for(int i = 0; i < address.Length; i++)
            {
                if (address[i] == '.')
                {
                    result += "[.]";
                }
                else
                {
                    result = result + address[i];
                }
            }
            return result;
        }

        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] result = new int[nums.Length];

            int increment = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        counter++;
                    }
                }
                result[increment++] = counter;
            }

            return result;
        }

        public static int SubtractProductAndSum(int n)
        { 
            return getProd(n) - getSum(n) ;
        }

        public static int getSum(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum = sum + n % 10;
                n = n / 10;
            }
            return sum;
        }

        public static int getProd(int n)
        {
            int prod = 1;
            while (n > 0)
            {
                prod = prod * (n % 10);
                n = n / 10;
            }

            return prod;
        }

        public static int FindNumbers(int[] nums)
        {
            int result = 0;

            List<int> cntHolder = new List<int>();

            for(int i=0; i < nums.Length; i++)
            {
                cntHolder.Add(countDigit(nums[i]));   
            }

            foreach(int c in cntHolder)
            {
                if (c % 2 == 0)
                {
                    result++;
                }
            }

            return result;
        }

        public static int countDigit(long n)
        {
            int count = 0;
            while (n != 0)
            {
                n = n / 10;
                ++count;
            }
            return count;
        }

        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] result = null;
            for (int i = 0; i < nums.Length; ++i)
            {
                result = InsertIntoArray(result, nums[i], index[i]);
            }
            return result;
        }

        private static int[] InsertIntoArray(int[] arr, int val, int index)
        {
            if (arr == null)
                return new int[] { val };

            int[] tmp = new int[arr.Length + 1];
            for (int i = 0; i < tmp.Length; ++i)
            {
                if (i < index)
                    tmp[i] = arr[i];
                else if (i == index)
                    tmp[i] = val;
                else
                    tmp[i] = arr[i - 1];
            }
            return tmp;
        }

        public static int NumJewelsInStones(string J, string S)
        {
            int count = 0;
            for(int i = 0; i < J.Length; i++)
            {
                for(int h = 0; h < S.Length; h++)
                {
                    if (J[i] == S[h])
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        public static bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            foreach (char ch in ransomNote)
            {
                if (table.ContainsKey(ch))
                    table[ch]++;
                else
                    table.Add(ch, 1);
            }

            foreach (char ch in magazine)
            {
                if (table.ContainsKey(ch))
                    table[ch]--;
            }

            foreach (char key in table.Keys)
            {
                if (table[key] > 0) return false;
            }

            return true;
        }

        public static int MajorityElement(int[] nums)
        {
            // Sort the array 
            Array.Sort(nums);

            // find the max frequency using  
            // linear traversal 
            int max_count = 1, res = nums[0];
            int curr_count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = nums[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent 
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = nums[nums.Length - 1];
            }

            return res;

        }

       

        public static int FindMaxConsercutiveOnes(int[] nums)
        {
            int count = 0;
            int max = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    max = Math.Max(max, count);
                    count = 0;
                }
            }

            return Math.Max(max, count);
        }

        public static int[] SortedSquares(int[] A)
        {
            int[] result = new int[A.Length];

            for(int i = 0; i < A.Length ; i++)
            {
                result[i] = A[i] * A[i];
            }

            Array.Sort(result);
            return result;
        }

        public static void DuplicateZeros(int[] arr)
        {
            for(int i = 0; i < arr.Length-1;)
            {
                if (arr[i] == 0)
                {
                    for(int j = arr.Length-1; j > i; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    i = i + 2;
                }
                else
                {
                    i = i + 1;
                }
            }
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {


            
            for (int i = m; i <= nums1.Length - 1; i++)
            {
                nums1[i] = nums2[i-m];
            }
            

            Array.Sort(nums1);
            
        }

        public static int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int new_begin = 0;

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[new_begin] = nums[i];
                    new_begin++;
                }
            }

            return new_begin;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int i = 0;
            for(int j = 0; j < nums.Length; j++)
            {
                if(nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        public static bool CheckIfExist(int[] arr)
        {
            if (arr.Length == 0 || arr == null)
            {
                return false;
            }

            HashSet<int> set = new HashSet<int>();
            foreach (int num in arr)
            {
                if (set.Contains(num * 2) || (num % 2 == 0 && set.Contains(num / 2)))
                {
                    return true;
                }
                set.Add(num);
            }
            return false;
        }

        public static bool ValidMountainArray(int[] A)
        {
            int i = 0;
            
            while (A[i] < A[i + 1] && i+1 < A.Length)
                i++;

            if (i == 0 || i == A.Length - 1)
            {
                return false;
            }

            while (A[i] > A[i + 1] && i < A.Length)
                i++;

            return i == A.Length;
        }

        public static int[] ReplaceElements(int[] arr)
        {            
            for(int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    arr[i] = -1;
                }
                else
                {
                    int max = int.MinValue;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] > max)
                        {
                            max = arr[j];
                        }
                    }
                    arr[i] = max;
                }
                
                
            }


            return arr;
        }

        public static int[] SortArrayByParity(int[] A)
        {
            int start = 0;
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    int temp = A[start];
                    A[start]=A[i];
                    A[i] = temp;
                    start++;
                }
            }


            return A;
        }

        public static int[] SortedSquares2(int[] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                A[i] = A[i] * A[i];
            }
            Array.Sort(A);

            return A;
        }

        public static int HeightChecker(int[] heights)
        {
            int[] initial = new int[heights.Length];

            for(int i = 0; i < initial.Length; i++)
            {
                initial[i] = heights[i];
            }

            Array.Sort(heights);

            int count = 0;

            for(int i = 0; i < initial.Length; i++)
            {
                if (initial[i] != heights[i])
                {
                    count++;
                }
            }



            return count;
        }

        public static int? ThirdMax(int[] nums)
        {
            int? max = null;
            int? max2 = null;
            int? max3 = null;

            foreach (int num in nums)
            {
                if (num == max || num == max2 || num == max3)
                {
                    continue;
                }

                if(max==null || num > max)
                {
                    max3 = max2;
                    max2 = max;
                    max = num;
                }

                else if (max2 == null || num > max2)
                {
                    max3 = max2;
                    max2= num;
                }

                else if (max3 == null || num > max3)
                {
                    max3 = num;
                }
            }


            if (max3 == null)
            {
                return max;
            }

            return max3;

        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> ans = new List<int>();
            ISet<int> rangeSet = new HashSet<int>();


            ISet<int> numSet = new HashSet<int>();

            for (int i = 1; i <= nums.Length; i++)
                rangeSet.Add(i);
            foreach (int num in nums)
                numSet.Add(num);

            foreach (int n in rangeSet)
                if (!numSet.Contains(n))
                    ans.Add(n);
            return ans;

        }

        public static void Rotate(int[] nums, int k)
        {

            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }

        }

        public static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for(int i = 0; i < nums.Length-1; i++)
            {
                if(nums[i] == nums[i + 1])
                {
                    return true;
                }
            }
            return false;
        }


        public static void ReverseString(char[] s)
        {

            int start = 0;
            int end = s.Length - 1;

            while(start < end)
            {
                char temp = s[start];
                s[start] = s[end];
                s[end] = temp;
                start++;
                end--;
            }


            foreach(char c in s)
            {
                Console.WriteLine(c);
            }

        }

        public static IList<string> FizzBuzz(int n)
        {
            IList<string> result = new List<string>();

            for(int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }

            }

            return result;
        }

        public static bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length)
            {
                return true;
            }

            int[] char_count = new int[26];

            for(int i = 0; i < s.Length; i++)
            {
                char_count[s[i]-'a']++;
                char_count[t[i]-'a']--;
            }

            foreach(int count in char_count)
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;

        }

        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> result = new List<bool>();

            int max = candies.Max();

            foreach(int child in candies)
            {
                if(child + extraCandies >= max)
                {
                    result.Add(true);
                }
                else
                {
                    result.Add(false);
                }
            }

            return result;
        }

        public static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            foreach (int c in arr)
            {
                if (ht.ContainsKey(c))
                {
                    ht[c] = ht[c]+1;
                }
                else
                {
                    ht.Add(c, 1);
                }
            }

            if (ht.Values.Distinct().Count() == ht.Values.Count())
            {
                return true;
            }

            return false;
        }

        public static void checkMagazine(string[] magazine, string[] note)
        {
            Dictionary<string, int> ht = new Dictionary<string, int>();
            foreach(string word in magazine)
            {
                if (ht.ContainsKey(word))
                {
                    ht[word] = ht[word] + 1;
                }
                else
                {
                    ht.Add(word, 1);
                }

                foreach(string item in note)
                {
                    if(ht.ContainsKey(item))
                    {
                        ht[item] = ht[item] - 1;
                    }
                    else
                    {
                        Console.WriteLine("No");
                        break;
                    }
                }
                Console.WriteLine("Yes");
            }

        }

        public static IList<string> SubdomainVisits(string[] cpdomains)
        {
            IList<string> result = new List<string>();

            Dictionary<int, string> ht = new Dictionary<int, string>();

            foreach(string c in cpdomains)
            {
                int count = Int32.Parse(c.Split(" ")[0]);
                string mainDomain = c.Split(" ")[1];
                ht.Add(count, mainDomain);
                if(mainDomain.Split(".").Length > 2)
                {
                    foreach (char subdom in mainDomain)
                    {

                    }
                }
            }


            return result;
        }

        public static void bonAppetit(List<int> bill, int k, int b)
        {
            int total = 0;
            foreach(int c in bill)
            {
                total += c;
            }

            int decline = (total - bill[k])/2;

            Console.WriteLine(total / 2 - decline);

        }


        public static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int currentMax = -1;

            foreach(int c in keyboards)
            {
                foreach(int d in drives)
                {
                    if(c+d<=b && c + d > currentMax)
                    {
                        currentMax = c + d;
                    }
                }
            }

            return currentMax;


        }

        public static int hurdleRace(int k, int[] height)
        {
            Array.Sort(height);

            if (height.All(x => x < k))
            {
                return 0;
            }
            else
            {
                return height[height.Length-1] - k;
            }


        }

        public static int utopianTree(int n)
        {
            int heigth = 0;
            for(int i = 0; i < n+1; i++)
            {
                if (i % 2 == 1)
                {
                    heigth = heigth * 2;
                }
                else
                {
                    heigth += 1;
                }
            }
            
            return heigth;
        }


        static string angryProfessor(int k, int[] a)
        {
            return ((Array.FindAll(a, x => x <= 0)).Length >= k ? "NO" : "YES");

        }

        public static int ReverseInt(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        public static int beautifulDays(int i, int j, int k)
        {
            List<double> list = new List<double>();
            for(int number = i; number <= j; number++)
            {
                //list.Add(Math.Abs((number - ReverseInt(number)) / k));
                if (Math.Abs(number - ReverseInt(number)) % k == 0)
                {
                    list.Add(Math.Abs(number - ReverseInt(number))/k);
                }
            }
            return list.Count();
        }

        public static int viralAdvertising(int n)
        {

            int shared = 5;
            int liked = 0;
            int cum = 0;


            for (int i = 1; i <= n; i++)
            {
                liked = (shared / 2);
                shared = (shared / 2) * 3;
                cum += liked;
                
            }

            return cum;
        }

        public static int squares(int a, int b)
        {
            int start = (int)Math.Sqrt(a);
            int end = (int)Math.Sqrt(b);

            int dif = end - start;

            dif += (Math.Pow(start, 2) >= a) ? 1 : 0;
            return dif;
        }

        public static int equalizeArray(int[] arr)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();

            foreach(int c in arr)
            {
                if (ht.ContainsKey(c))
                {
                    ht[c] = ht[c] + 1;
                }
                else
                {
                    ht.Add(c, 1);
                }
            }

            return arr.Length-ht.Values.Max();
        }

        public static int findDigits(int n)
        {
            string nStr = n.ToString();
            int count = 0;
            foreach (char c in nStr.ToCharArray())
            {
                if (c == '0')
                    continue;
                int rem = n % (c - '0');
                if (rem == 0)
                    count++;
            }
            return count;
        }

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            if (y2 < y1)
            {
                return 10000;
            }
            if (y1 < y2)
            {
                return 0;
            }
            if (m2 < m1)
            {
                return (m1 - m2) * 500; 
            }
            if (d1>d2)
            {
                return 15 * (d1 - d2);
            }
            return 0;
        }

        // 9 6 2015
        // 6 6 2015

            // 45


        static void Main(string[] args)
        {
            // 1 1 2 2 3 3 3 3
            // 

            string[] magazine = new string[] { "two", "times", "three", "is", "not", "four" };
            string[] note = new string[] { "two", "times", "two", "is", "four" };


            
            //int[] nums = new int[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 };
            int[] keyboards = new int[] { 3,1 };
            int[] drives = new int[] { 1, 2, 3, 4, 3, 3, 2, 1 };

            //Console.WriteLine(utopianTree(5));
            Console.WriteLine(libraryFine(2,7,1014,1,1,1015));

            string[] cpdomains = new string[] { "9001 discuss.leetcode.com" };

            

            //Console.Write(cpdomains[0].Split(" ")[0]);

            //Console.WriteLine(SubdomainVisits(cpdomains));

            

            //foreach(string str in FizzBuzz(15))
            //{
            //    Console.WriteLine(str);
            //}
            //Console.WriteLine(ContainsDuplicate(nums));









        }

        
    }
}
