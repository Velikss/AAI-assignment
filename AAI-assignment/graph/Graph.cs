using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiswerk6
{
    public class Graph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        private Dictionary<string, Node> NodeMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            NodeMap = new Dictionary<string, Node>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public Node GetVertex(string name)
        {
//            Node v = NodeMap[name];
            if (!NodeMap.ContainsKey(name))
            {
                NodeMap.Add(name, new Node(name));
            }

            return NodeMap[name];
        }

        public void AddEdge(string source, string dest, double cost)
        {
            Node srcNode = GetVertex(source);
            Node destNode = GetVertex(dest);
            srcNode.adj.Add(new Edge(destNode, cost));
        }
    
        public void ClearAll()
        {
            foreach (Node v in NodeMap.Values)
                v.Reset();
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Node v in NodeMap.Values)
                sb.AppendLine(v.ToString());
            return sb.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void Unweighted(string name)
        {
            ClearAll();

            Node startNode = NodeMap[name];
            if (startNode == null)
                return; // starting node not found

            Queue<Node> queue = new Queue<Node>();

            startNode.dist = 0;
            queue.Enqueue(startNode);

            while (queue.Count != 0)
            {
                Node v1 = queue.Dequeue();

                foreach(Edge e in v1.adj)
                {
                    Node v2 = e.dest;

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

            Node startNode = NodeMap[name];
            if (startNode == null)
                return; // starting node not found

            ClearAll();
            queue.Add(new Edge(startNode, 0));
            startNode.dist = 0; 

            while (queue.Size() != 0)
            {
                Edge edge = queue.Remove();

                Node node = edge.dest;

                if(node.visited && node.dist != 0) continue;

                foreach (Edge vertexEdge in node.adj)
                {
                    Node neighbor = vertexEdge.dest;
                    double vertexEdgeCost = vertexEdge.cost;

                    if (vertexEdgeCost < 0)
                        return;

                    if (neighbor.dist > node.dist + vertexEdgeCost)
                    {
                        neighbor.dist = node.dist + vertexEdgeCost;
                        neighbor.prev = node;
                        queue.Add(new Edge(neighbor, neighbor.dist));
                    }
                }
            }
        }

        public bool IsConnected()
        {
            foreach (Node v in NodeMap.Values)
            {
                int count = NodeMap.Count;
                foreach (Edge e in v.adj)
                {
                    if (NodeMap.ContainsKey(e.dest.name))
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