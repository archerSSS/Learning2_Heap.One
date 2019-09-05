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
            if (depth > 0)
            {
                HeapArray = new int[2 << depth - 1];
                Array.Sort(a);
                Array.Reverse(a);
                HeapArray = a;                          // Внедрить элементы из заданного в кучу
                //AddChild(CutArray(a, false), 1);
                //AddChild(CutArray(a, true), 2);
            } 
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...
        }

        public int GetMax()
        {
            int index = 0;
            if (HeapArray != null || HeapArray[index] != 0)
            {
                int prevMax = HeapArray[index];
                HeapArray[index] = 0;
                while (index < HeapArray.Length)
                {
                    if (HeapArray[index * 2 + 1] >= HeapArray[index * 2 + 2])
                    {
                        HeapArray[index] = HeapArray[index * 2 + 1];
                        HeapArray[index * 2 + 1] -= HeapArray[index];
                        index = index * 2 + 1;
                    }
                    else if (HeapArray[index * 2 + 1] < HeapArray[index * 2 + 2])
                    {
                        HeapArray[index] = HeapArray[index * 2 + 2];
                        HeapArray[index * 2 + 2] -= HeapArray[index];
                        index = index * 2 + 2;
                    }
                    if (index > HeapArray.Length) return prevMax;
                }
            }
            
            // вернуть значение корня и перестроить кучу
            return -1; // если куча пуста
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            int index = 0;
            while (index < HeapArray.Length)
            {
                if (HeapArray[index] == 0)
                {
                    HeapArray[index] = 0;
                    ExchangeParentKey(index);
                    return true;
                }
                else index++;
            }
            
            return false; // если куча вся заполнена
        }

        // Добавляет из заданного массива элементы по индексу в имеющуюся кучу
        // 
        // !! Исправить либо Удалить метод. Не обрезать заданный массив. !!
        //
        public void AddChild(int[] a, int index)
        {
            HeapArray[index] = a[a.Length];
            AddChild(CutArray(a, false), index * 2 + 1);
            AddChild(CutArray(a, true), index * 2 + 2);
        }


        // Обрезает заданный массив оставляя указанную "половинную" часть, 
        //    избавляясь от середины (Одного элемента) и второй оставшейся части. 
        //      (Если элементов 7, то остается 3)
        //  Возвращает обрезанную часть в виду нового массива (заданный не меняет)
        //
        // Предполагается что элементов должно быть нечетное количество -- для корректной работы.
        //
        private int[] CutArray(int[] a, bool rightHalf)
        {
            int[] b = new int[a.Length / 2];
            if (rightHalf) Array.Copy(a, a.Length / 2 + 1, b, 0, b.Length);
            else Array.Copy(a, 0, b, 0, b.Length);
            return b;
        }

        // Меняет местами элемент с большим ключом с элементом с меньшим ключом.
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
                HeapArray[(index - 1) / 2] += HeapArray[index];
                HeapArray[index] = HeapArray[index] - HeapArray[(index - 1) / 2];
                ExchangeParentKey((index - 1) / 2);
            }
        }
    }
}