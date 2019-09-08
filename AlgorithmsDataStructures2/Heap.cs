using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            if (depth > -1)
            {
                HeapArray = new int[(2 << depth) - 1];
                if (a != null)
                {
                    Array.Sort(a);
                    Array.Reverse(a);

                    for (int i = 0; i < a.Length; i++)
                        HeapArray[i] = a[i];
                }
            } 
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...
        }

        public int GetMax()
        {
            int index = 0;
            if (HeapArray != null && HeapArray[index] != 0)
            {
                int prevMax = HeapArray[0];
                index = LastValueIndex();
                HeapArray[0] = HeapArray[index];
                HeapArray[index] = 0;
                index = 0;

                while (index * 2 + 1 < HeapArray.Length && (HeapArray[index] < HeapArray[index * 2 + 1] || HeapArray[index] < HeapArray[index * 2 + 2]))
                {
                    if (HeapArray[index * 2 + 1] >= HeapArray[index * 2 + 2])
                    {
                        ExchangeHeapValues(index, index * 2 + 1);
                        index = index * 2 + 1;
                    }
                    else if (HeapArray[index * 2 + 1] < HeapArray[index * 2 + 2])
                    {
                        ExchangeHeapValues(index, index * 2 + 2);
                        index = index * 2 + 2;
                    }
                    else break;
                }
                return prevMax;
            }
            
            // вернуть значение корня и перестроить кучу
            return -1; // если куча пуста
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (HeapArray == null) return false;
            int index = FirstEmptyIndex();
            if (index != -1)
            {
                HeapArray[index] = key;
                ExchangeParentKey(index);
                return true;
            }
            return false; // если куча вся заполнена
        }

        // Находит индекс ячейки кучи имеющая значение больше 0 и возвращает его.
        //
        // Если в куче такого значения не было найдено, то возвращает -1.
        //
        private int LastValueIndex()
        {
            int index = HeapArray.Length - 1;
            for (; index > -1 && HeapArray[index] == 0; index--) {}
            return index;
        }

        // Находит первый индекс ячейки кучи имеющая значение равное 0 и возвращает его.
        //
        // Если в куче такого значения не было найдено, то возвращает -1.
        //
        private int FirstEmptyIndex()
        {
            int index = 0;
            for (; index < HeapArray.Length && HeapArray[index] != 0; index++) { }
            if (index >= HeapArray.Length) return -1;
            return index;
        }

        // Меняет местами элементы в ячейках по указанным индексам
        //
        private void ExchangeHeapValues(int a, int b)
        {
            HeapArray[a] += HeapArray[b];
            HeapArray[b] = HeapArray[a] - HeapArray[b];
            HeapArray[a] -= HeapArray[b];
        }

        // Меняет местами элемент с бОльшим ключом с элементом с меньшим ключом.
        // (П.С: Я использовал три буквы С случайно, а не потому что мой ник содержит SSS)
        //
        // Из кучи по заданному индексу определяется потомок и вычисляется его родитель с которым обменивается ключами
        // Если индекс == 0, значит родителя у него нет (корневой) и метод прекращает работу.
        //
        private void ExchangeParentKey(int index)
        {
            if (index == 0) return;
            if (HeapArray[(index-1)/2] < HeapArray[index])
            {
                HeapArray[index] += HeapArray[(index - 1) / 2];
                HeapArray[(index - 1) / 2] = HeapArray[index] - HeapArray[(index - 1) / 2];
                HeapArray[index] -= HeapArray[(index - 1) / 2];
                ExchangeParentKey((index - 1) / 2);
            }
        }
    }
}