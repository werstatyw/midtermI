using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtelm_example
{
    class Program
    {
        static Random R = new Random();
        const int N = 2, M = 6;
        // generate data: Task 1
       static int[,] generateData(int numberOfWeeks, int numberOfSubjects, int scale)
        {
            int[,] A = new int[numberOfWeeks, numberOfSubjects];
            for (int i = 0; i < numberOfWeeks; i++)
            {
                //w1 and  w2 denote then unsuccessful tests
                int w1 = R.Next(3, numberOfSubjects);
                //make sure that w2 is different from w1
                int w2;
                do
                {
                    w2 = R.Next(3, numberOfSubjects);
                    Console.WriteLine("w2=" + w2);
                } while (w2 == w1);
                //subjects 0,1,2
                for(int j =0; j< 3; j++)
                {
                    A[i, j] = R.Next(15, 21);
                }
                //other subjects
                for (int j = 3; j < numberOfSubjects; j++)
                {
                    A[i, j] = R.Next(0, 17);
                    if (j == w2 || j == w2) A[i, j] = 0;
                    else A[i, j] = R.Next(0, 17);
                }
            }
            return A;
        } //***
        static string printData(int[,] data)
        {
            string s = "";
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)

                {
                    s += data[i, j] + ";"; // console.write( + "   ")
                }//endfor j
                s = s.Substring(0, s.Length - 1);
                //
                s += "\n";
            } //endfor i
            return s;
        }//***
        static void dataModify(int weekIndex, int subjectIndex, int[,] data, int element)
            {
            data[weekIndex, subjectIndex] = element;
          //   return null;
            } //***
        static int totalScores(int[,] data)
        {
            int sum = 0;
            foreach (int e in data) sum += e; // Task 4: All the scores added up
            return sum;
        } //***
        static int goodResults(int[,] data) // task 5
        {
            int sum = 0;
            foreach (int e in data)
            {
                if (e > 15) sum++;
            }
            return sum;
        }//***
        // subject for the whole schoolyear
        static double [] subjectAverage(int[,] data) // task 6
        {
            double[] AV = new double[data.GetLength(1)];
            for(int j = 0; j < data.GetLength(1); j++)
            {
                int sum = 0;
                for(int i=0; i< data.GetLength(0); i++)
                {
                    sum += data[i, j];
                }//endfor i
                AV[j] = (double)sum / data.GetLength(0);
            }//endfor j
            return AV;
        }//***
        static bool isIncreasing(int[,] data) //Task 7
        {
            double avOld = 0;
            for(int i=0; i < data.GetLength(0); i++)
            {
                    int sum = 0;
                    for(int j=0; j < data.GetLength(1); j++)
                    {
                        sum += data[i, j];
                    }// endfor j
                    double avNew = (double)sum / data.GetLength(1);
                    if (avOld >= avNew) return false;
                    avOld = avNew;
                } // endfor i
            
            return true;
        }//***
        static int favouriteSubject (int[,] data) //Task 8
        {
            double[] AV = subjectAverage(data);
            int maxIndex = 0; double temp = AV[0];
            for(int i=0; i < AV.Length; i++)
            {
                if(AV[i] > temp) { maxIndex = i;  temp = AV[i]; }
            }//endfor
            return maxIndex;
        }//
        static int hatedSubject(int[,] data)
        {
            double[] AV = subjectAverage(data);
            int minIndex = 0; double temp = AV[0];
            for (int i = 0; i < AV.Length; i++)
            {
                if (AV[i] < temp) { minIndex = i; temp = AV[i]; }
            }//endfor
            return minIndex;
        }//
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1: generate data");
            int[,] A = generateData(N, M, 20);
            Console.WriteLine("Task 2: print data");
            Console.WriteLine("*" + printData(A)+ "*");
        Console.WriteLine("Task 3: modify data, test it, redo");
        int temp = A[A.GetLength(0) -1, 1];
            dataModify(A.GetLength(0) - 1, 1, A, -10);
            Console.WriteLine("*" + printData(A) + "*");
            dataModify(A.GetLength(0) - 1, 1, A, temp);
            Console.WriteLine("Task 4: add up all scores= " + totalScores(A));
            Console.WriteLine("Task 5: Number of results better than 15 = " + goodResults(A));
            Console.WriteLine("Task 6: subject averages");
            foreach (double d in subjectAverage(A))  Console.Write(d + " ");
            Console.WriteLine("Task 7: weekly averages increasing " + isIncreasing(A));
            Console.WriteLine("Task 8: index of favourite subject is " + favouriteSubject(A));
            Console.WriteLine("Task 9: index of hated subject is " + hatedSubject(A));
            Console.WriteLine();
            Console.WriteLine("The end");
            Console.ReadKey();
        }
    }
}