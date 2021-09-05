using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = QuickSort(new int[5] { 4, 2, 42, 8, 5 });
            foreach (int i in test)
                Console.Write(i + " ");
            
            //int [] a = SelectSort(new int[9] { 14, 8, 3, -6, -7, 2, 3, 4, 4 });
            //int[] mas = new int[100];
            //for (int i = 0;i<mas.Length;i++)
            //{
            //    mas[i] = i * 2;
            //}

            //DateTime time1 = System.DateTime.Now;
            //Console.WriteLine(BinSearch(mas, 160));
            //Console.WriteLine((DateTime.Now.Subtract(time1)).Seconds + " " + (DateTime.Now.Subtract(time1)).Milliseconds);
            
            //for (int i = 0; i < 1000000000; i++)
            //{
            //    long g = 4 * i;
            //}

            //DateTime time2 = System.DateTime.Now;
            //Console.WriteLine(SimpleSearch(mas, 160));
            //Console.WriteLine((DateTime.Now.Subtract(time2)).Seconds + " " + (DateTime.Now.Subtract(time2)).Milliseconds);

        }

        //Бинарный поиск
        static int BinSearch(int [] mas, int item)
        {
            int low = 0, 
                high = mas.Length - 1, 
                mid;

            while(low <= high)
            {
                mid = (low + high) / 2;
                if (mas[mid] == item) return mid;
                else if (mas[mid] < item) low = mid + 1;
                else high = mid - 1;
            }
            return -1;
        }

        //Простой поиск перебором
        static int SimpleSearch(int[] mas, int item)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == item) return i;
            }
            return -1;
        }

       //Сортировка выбором
        static int[] SelectSort (int [] mas)
        {
            int[] sortMas = new int[mas.Length];
            int min;
            int minIndex = 0;
            int[] newMass = mas;

            for (int i = 0; i < mas.Length;i++)
            {
                min = newMass[0];
                for (int j = 0;j < newMass.Length;j++)
                {
                    if (newMass[j] < min)
                    {
                        min = newMass[j];
                        minIndex = j;
                    }
                }
                sortMas[i] = min;
                if (newMass.Length > 1) newMass = DeleteArrElem(newMass, minIndex);
            }
            return sortMas;
        }

        //Быстрая сортировка
        static int[] QuickSort(int [] mas)
        {
            if (mas.Length < 2) return mas;
            else
            {
                int opora = mas[0];
                int[] leftMas = getLeftMas(mas, opora);
                int[] rightMas = getRightMas(mas, opora);
                return sumMas(sumMas(QuickSort(leftMas), new int[1] { opora }), QuickSort(rightMas));
            }
        }

        static int[] sumMas(int[] mas1, int[] mas2)
        {
            int[] masRet = new int[mas1.Length + mas2.Length];
            for(int i = 0;i<mas1.Length;i++) masRet[i] = mas1[i];
            for (int i = 0; i < mas2.Length; i++) masRet[i + mas1.Length] = mas2[i];
            return masRet;
        }

        static int[] getLeftMas(int[] mas, int opora)
        {
            int count = 0;
            foreach (int i in mas) if (i < opora) count++;
            int[] leftMas = new int[count];
            count = 0;
            foreach (int i in mas) if (i < opora) leftMas[count++] = i;
            return leftMas;
        }

        static int[] getRightMas(int[] mas, int opora)
        {
            int count = 0;
            foreach (int i in mas) if (i > opora) count++;
            int[] rightMas = new int[count];
            count = 0;
            foreach (int i in mas) if (i > opora) rightMas[count++] = i;
            return rightMas;
        }

        //Удаление элемента из массива
        static int[] DeleteArrElem(int [] mas, int index)
        {
            int[] newMas = new int[mas.Length - 1];
            int counter = 0;

            for (int i = 0;i<mas.Length;i++)
            {
                if (i == index) continue;
                newMas[counter] = mas[i];
                counter++;
            }
            return newMas;
        }

        //Рекурсивное суммирование массива
        static int RecSum(int [] mas)
        {
            if (mas.Length == 0) return 0;
            else return mas[0] + RecSum(DeleteArrElem(mas, 0));
        }

        //Рекурсивный поиск максимума в массиве
        static int RecMax(int[] mas)
        {
            if (mas.Length == 0) return 0;
            else return Max(mas[0], RecMax(DeleteArrElem(mas, 0)));
        }

        static int Max (int x1, int x2)
        {
            return x1 > x2 ? x1 : x2;
        }
    }
}
