﻿using System;
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


        static void Main(string[] args)
        {

            int[] nums = new int[] { 0, 1, 2, 3, 4 };
            int[] index = new int[] { 0, 1, 2, 2, 1 };

            //foreach (int item in CreateTargetArray(nums,index))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(String.Join(",", CreateTargetArray(nums,index)));
            Console.Write(NumJewelsInStones("z", "ZZ"));
        }

        
    }
}
