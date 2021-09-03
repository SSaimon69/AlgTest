using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(64 / 5);
            //Console.WriteLine(RecMax(new int[5] { 4, 2, 42, 8, 5 }));
            
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

        static int SimpleSearch(int[] mas, int item)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] == item) return i;
            }
            return -1;
        }

       
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

        static int RecSum(int [] mas)
        {
            if (mas.Length == 0) return 0;
            else return mas[0] + RecSum(DeleteArrElem(mas, 0));
        }

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
