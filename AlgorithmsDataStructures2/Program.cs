using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] a = new int[] { 4, 17, 5, 0, 0};
            Array.Sort(a);
            Array.Reverse(a);

            int o = a[Array.IndexOf(a, 2) - 1];
        }
    }
}
