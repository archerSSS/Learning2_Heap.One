using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace AlgoTest_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetMax_1()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 5, 12, 9, 3, 2, 1, 55 };
            heap.MakeHeap(array, 2);
            array = new int[] { 55, 12, 9, 5, 3, 2, 1 };

            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.AreEqual(array[i], heap.GetMax());
        }

        [TestMethod]
        public void TestGetMax_2()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 81, 29, 48 };
            heap.MakeHeap(array, 1);
            array = new int[] { 81, 48, 29 };

            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.AreEqual(array[i], heap.GetMax());
        }

        [TestMethod]
        public void TestGetMax_3()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 17 };
            heap.MakeHeap(array, 0);

            Assert.AreEqual(17, heap.GetMax());
            Assert.AreEqual(-1, heap.GetMax());
        }

        [TestMethod]
        public void TestGetMax_4()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 17, 92, 41, 40, 82, 44, 1, 7, 95, 63, 49, 32, 9, 11, 4 };
            heap.MakeHeap(array, 3);
            int[] array2 = new int[15];
            array.CopyTo(array2, 0);
            Array.Sort(array2);
            Array.Reverse(array2);

            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.AreEqual(array2[i], heap.GetMax());
        }

        [TestMethod]
        public void TestAdd_1()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 5, 12, 9, 3, 0, 0, 55 };
            heap.MakeHeap(array, 2);

            Assert.AreEqual(true, heap.Add(4));
            Assert.AreEqual(4, heap.HeapArray[5]);
        }

        [TestMethod]
        public void TestAdd_2()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 5, 12, 9, 3, 0, 0, 55 };
            heap.MakeHeap(array, 2);

            Assert.AreEqual(true, heap.Add(66));
            Assert.AreEqual(66, heap.HeapArray[0]);
            Assert.AreEqual(55, heap.HeapArray[2]);
            Assert.AreEqual(9, heap.HeapArray[5]);

            int zeros = 0;
            for (int i = 0; i < heap.HeapArray.Length; i++)
                if (heap.HeapArray[i] == 0) zeros++;

            Assert.AreEqual(1, zeros);
        }

        [TestMethod]
        public void TestAdd_3()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 5, 12, 9, 3, 0, 0, 55 };
            heap.MakeHeap(array, 2);

            Assert.AreEqual(true, heap.Add(8));
            Assert.AreEqual(true, heap.Add(13));
            Assert.AreEqual(false, heap.Add(6));
            Assert.AreEqual(false, heap.Add(1));
            Assert.AreEqual(false, heap.Add(20));

            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.IsTrue(heap.HeapArray[i] != 0);
        }

        [TestMethod]
        public void TestAdd_4()
        {
            Heap heap = new Heap();
            int[] array = new int[] { 0 };
            heap.MakeHeap(array, 2);

            int zeros = 0;
            for (int i = 0; i < heap.HeapArray.Length; i++)
                if (heap.HeapArray[i] == 0) zeros++;

            Assert.AreEqual(3, zeros);
            Assert.AreEqual(true, heap.Add(8));

            zeros = 0;
            for (int i = 0; i < heap.HeapArray.Length; i++)
                if (heap.HeapArray[i] == 0) zeros++;

            Assert.AreEqual(2, zeros);
            Assert.AreEqual(true, heap.Add(13));

            zeros = 0;
            for (int i = 0; i < heap.HeapArray.Length; i++)
                if (heap.HeapArray[i] == 0) zeros++;

            Assert.AreEqual(1, zeros);
            Assert.AreEqual(true, heap.Add(21));
            
            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.IsTrue(heap.HeapArray[i] != 0);

            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.IsTrue(heap.HeapArray[i] == 21 || heap.HeapArray[i] == 8 || heap.HeapArray[i] == 13);
        }


        [TestMethod]
        public void TestHeap_1()
        {
            Heap heap = new Heap();
            int[] array = null;
            heap.MakeHeap(array, 3);
            for (int i = 0; i < heap.HeapArray.Length; i++)
                Assert.IsTrue(heap.HeapArray[i] == 0);
        }
    }
}
