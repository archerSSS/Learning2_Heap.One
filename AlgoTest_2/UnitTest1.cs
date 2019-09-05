using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace AlgoTest_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 5, 12, 9, 3, 2, 1, 55 };

            heap.MakeHeap(array, 3);
        }
    }
}
