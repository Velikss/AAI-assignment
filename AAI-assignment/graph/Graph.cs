using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiswerk6
{
    public class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        private Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public Vertex GetVertex(string name)
        {
//            Vertex v = vertexMap[name];
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.Add(name, new Vertex(name));
            }

            return vertexMap[name];
        }

        public void AddEdge(string source, string dest, double cost)
        {
            Vertex srcVertex = GetVertex(source);
            Vertex destVertex = GetVertex(dest);
            srcVertex.adj.Add(new Edge(destVertex, cost));
        }
    
        public void ClearAll()
        {
            foreach (Vertex v in vertexMap.Values)
                v.Reset();
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Vertex v in vertexMap.Values)
                sb.AppendLine(v.ToString());
            return sb.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void Unweighted(string name)
        {
            ClearAll();

            Vertex startVertex = vertexMap[name];
            if (startVertex == null)
                return; // starting vertex not found

            Queue<Vertex> queue = new Queue<Vertex>();

            startVertex.dist = 0;
            queue.Enqueue(startVertex);

            while (queue.Count != 0)
            {
                Vertex v1 = queue.Dequeue();

                foreach(Edge e in v1.adj)
                {
                    Vertex v2 = e.dest;

                    if (v2.dist == Graph.INFINITY)
                    {
                        v2.dist = v1.dist + 1;
                        v2.prev = v1;
                        queue.Enqueue(v2);
                    }
                }
            }
        }

        public void Dijkstra(string name)
        {
            PriorityQueue<Edge> queue = new PriorityQueue<Edge>();

            Vertex startVertex = vertexMap[name];
            if (startVertex == null)
                return; // starting vertex not found

            ClearAll();
            queue.Add(new Edge(startVertex, 0));
            startVertex.dist = 0; 

            while (queue.Size() != 0)
            {
                Edge edge = queue.Remove();

                Vertex vertex = edge.dest;

                if(vertex.visited && vertex.dist != 0) continue;

                foreach (Edge vertexEdge in vertex.adj)
                {
                    Vertex neighbor = vertexEdge.dest;
                    double vertexEdgeCost = vertexEdge.cost;

                    if (vertexEdgeCost < 0)
                        return;

                    if (neighbor.dist > vertex.dist + vertexEdgeCost)
                    {
                        neighbor.dist = vertex.dist + vertexEdgeCost;
                        neighbor.prev = vertex;
                        queue.Add(new Edge(neighbor, neighbor.dist));
                    }
                }
            }
        }

        public bool IsConnected()
        {
            foreach (Vertex v in vertexMap.Values)
            {
                int count = vertexMap.Count;
                foreach (Edge e in v.adj)
                {
                    if (vertexMap.ContainsKey(e.dest.name))
                        count--;
                }

                if (count > 0)
                    return false;
            }

            return true;
        }

    }


    public class PriorityQueue<T> where T : IComparable<T>
    {
        public static int DEFAULT_CAPACITY = 100;
        public int size;   // Number of elements in heap
        public T[] array;  // The heap array

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public PriorityQueue()
        {
            array = new T[DEFAULT_CAPACITY + 1];
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            size = 0;
        }

        public void Add(T x)
        {
            AddFreely(x);

            int hole = Size();

            while (x.CompareTo(array[hole / 2]) < 0)
            {
                Swap(hole, hole / 2);
                hole /= 2;
            }
        }



        // Removes the smallest item in the priority queue
        public T Remove()
        {
            if (Size() == 0) return default(T);

            var returnVal = array[1];
            array[1] = array[Size()];

            PercolateDown(1);

            size--;

            return returnVal;
        }

        public override string ToString()
        {
            return string.Join(" ", array.Where((comparable, i) => i > 0 && i <= Size()));
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void AddFreely(T x)
        {
            if (Size() + 1 >= array.Length)
            {
                int newCapacity = this.array.Length << 1 >= 0 ? this.array.Length << 1 : int.MaxValue;

                Array.Resize(ref this.array, newCapacity);
            }

            size++;
            array[size] = x;
        }

        public void BuildHeap()
        {
            PercolateDown(Size() / 2);
        }

        private void PercolateDown(int v)
        {
            for (int i = v; i > 0; i--)
            {
                for (int x = i; i < Size();)
                {
                    int leftIndex = x * 2;
                    int rightIndex = leftIndex + 1;

                    if (leftIndex > Size()) { break; }

                    int smallestChildIndex = rightIndex;

                    if (rightIndex > Size() || array[rightIndex].CompareTo(array[leftIndex]) > 0)
                    {
                        smallestChildIndex = leftIndex;
                    }

                    if (array[x].CompareTo(array[smallestChildIndex]) <= 0)
                    {
                        break;
                    }

                    Swap(x, smallestChildIndex);
                    x = smallestChildIndex;
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

        }
    }
}