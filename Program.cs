using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabRab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set S1 = new Set() { c = { 0, 2, 4 } };
            Set S2 = new Set() { c = { 2, 0, 7 } };
            Set S3 = new Set() { c = { 1 } };
            Set S4 = S1 + S2;
            Set S5 = S1 + S3;
            Set S6 = S1 * S2;
            Console.WriteLine("Объединение множеств S1 и S2:");
            foreach (var i in S4.c)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Объединение множеств S1 и S3:");
            foreach (var i in S5.c)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Пересечение множеств S1 и S2:");
            foreach (var i in S6.c)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Мощность множества S4:");
            var x = (int)S4;
            Console.Write(x);
            Console.WriteLine();
            Console.WriteLine("принадлежность к диапазону множества S1:");
            if (S1)
            {
                Console.WriteLine("Принадлежит");
            }
            else
            {
                Console.WriteLine("Не принадлежит");
            }
            Console.WriteLine("принадлежность к диапазону множества S4:");
            if (S4)
            {
                Console.WriteLine("Принадлежит");
            }
            else
            {
                Console.WriteLine("Не принадлежит");
            }
            Console.WriteLine();
            Set.Owner obj = new Set.Owner();
            Console.WriteLine(obj.Id);
            Console.WriteLine(obj.Name);
            Console.WriteLine(obj.LastName);
            Console.WriteLine(obj.Organization);
            Console.WriteLine();
            Set.Date date = new Set.Date();
            Console.WriteLine(date.dt.ToString("d"));
            Console.ReadLine();
        }
    }
    public class Set
    {
        public List<short> c = new List<short> { };
        public bool Check(int length = 4)
        {
            var counter = 0;
            foreach (var i in c)
            {
                counter++;
            }
            if (counter == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Set operator +(Set S1, Set S2)
        {
            Set S3 = new Set() { };
            if ((S1.c != null && S1.c.Count > 0) && (S2.c != null && S2.c.Count > 0))
            {

                S3.c.AddRange(S1.c);
                S3.c.AddRange(S2.c);
            }
            S3.c = S3.c.Distinct().ToList();
            return S3;
        }
        public static Set operator *(Set S1, Set S2)
        {
            Set S3 = new Set() { };
            if ((S1.c != null && S1.c.Count > 0) && (S2.c != null && S2.c.Count > 0))
            {
                foreach (var i in S1.c)
                {
                    foreach (var j in S2.c)
                    {
                        if (i == j)
                        {
                            S3.c.Add(j);
                        }
                    }
                }
            }
            S3.c = S3.c.Distinct().ToList();
            return S3;
        }
        public static explicit operator int(Set set)
        {
            var x = set.c.Count();
            return x;
        }
        public static bool operator true(Set set)
        {
            return set.Check();
        }
        public static bool operator false(Set set)
        {
            return set.Check();
        }
        public class Owner
        {
            public int Id = 123;
            public string Name = "Roman";
            public string LastName = "Zayats";
            public string Organization = "BGTU";
        }
        public class Date
        {
            public DateTime dt = new DateTime(2001, 03, 05);
        }
    }
    public static class StatisticOperation
    {
        public static int Summ(this Set S1)
        {
            int sum = 0;
            foreach (var i in S1.c)
            {
                sum += i;
            }
            return sum;
        }
        public static int DifferenceBetweenMaxAndMin(this Set S1)
        {

            int difference = 0;
            int min = 999999999;
            int max = -999999999;
            foreach (var i in S1.c)
            {
                if (i < min)
                {
                    min = i;
                }
                if (i > max)
                {
                    max = i;
                }
            }
            return difference = max - min;
        }
        public static int Count(this Set S1)
        {
            var counter = 0;
            foreach (var i in S1.c)
            {
                counter++;
            }
            return counter;
        }
        public static string Str(this string str)
        {
            return str.Replace(" ", ", ");
        }
        public static void DDV(this Set S1)
        {
            S1.c.Distinct();
        }
    }

}