using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program
{
    public class Graph
    {
        private int size; // количество вершин в графе
        private bool[,] adjacency; // матрица смежности (ссылка)
        private bool[,] achievement; // матрица достижимости (ссылка)
        private bool[] vector; // вектор посещенных вершин для обхода (ссылка)

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
        public bool[,] Adjacency
        {
            get { return adjacency; }
            set { adjacency = value; }
        }
        public bool[,] Achievement
        {
            get { return achievement; }
            set { achievement = value; }
        }
        public bool[] Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        public Graph(int size, bool[,] G) 
        {
            adjacency = G; 
            achievement = new bool[size, size];  
                                               
            vector = new bool[size]; 
            for (int i = 0; i < size; i++) vector[i] = false;
            Size = size;
        }
        public bool[,] CopyMatrix(bool[,] matr1)
        {
            bool[,] matr2 = new bool[size, size]; ;
            for (int i = 0; i < size; i++)
            {
                for (int j=0; j < size; j++)
                {
                    matr2[i,j] = matr1[i,j];
                }
            }
            return matr2;
        }
        public bool[,] SummMatrix(bool[,] matr1, bool[,] matr2)
        {
            bool[,] result = new bool[size, size]; ;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i,j] = (matr1[i, j] || matr2[i, j]);
                }
            }
            return result;
        }
        public bool[,] MultMatrix(bool[,] matr1, bool[,] matr2)
        {
            bool[,] result = new bool[size, size]; ;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = false;
                    for (int k = 0; k < size; k++) result[i, j] = result[i, j] || (matr1[i, k] && matr2[k, i]);
                }
            }
            return result;
        }
        public void Achieve()
        {
            bool[,] T = new bool[size, size];
            Achievement = CopyMatrix(Adjacency);
            T = CopyMatrix(Adjacency);
            for (int i=0; i<size; i++)
            {
                T = MultMatrix(Achievement, T);
                Achievement = SummMatrix(Achievement, T) ;
            }
        }
        public void Depth(int i)
        {
            Vector[i] = true;
            Console.WriteLine(i);
            for(int k =0; k<size; k++) if ((Adjacency[i, k]) && (!Vector[k]))Depth(k);
        }
        public void DepthAll()
        {
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++) Vector[j] = false;
                Depth(i);
                Console.WriteLine("======");
            }
        }
    }
    public class Program
    {
        static void Main()
        {
            bool[,] M = new bool[4, 4];
            {
 
            }

        }
    }
}