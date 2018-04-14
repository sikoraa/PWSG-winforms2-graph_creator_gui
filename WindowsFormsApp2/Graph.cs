using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Graph
    {
        public List<(int x, int y, int nr, Color c)> V;
        public List<(int v1, int v2)> E;

        public Graph()
        {
            V = new List<(int, int, int, Color)>();
            E = new List<(int, int)>();
        }
        public Point getPoint(int nr)
        {
            for (int i = 0; i < V.Count; ++i)
            {
                if (V[i].nr == nr)
                    return new Point(V[i].x, V[i].y);
            }
            return new Point(0, 0);
        }
        public int getIndex(int nr)
        {
            for (int i = 0; i < V.Count; ++i)
            {
                if (V[i].nr == nr)
                    return i;
            }
            return -1;
        }

        public bool AddEdge(int v1, int v2)
        {

            if (v1 < v2)
            {
                if (!E.Contains((v1, v2)))
                    E.Add((v1, v2));
                else
                    E.Remove((v1, v2));
            }
            else
            {
                if (!E.Contains((v2, v1)))
                    E.Add((v2, v1));
                else
                    E.Remove((v2, v1));
            }

            return true;
        }

        //public (int x, int y, int)

        public bool Add(int x, int y, int nr, Color c, int r)
        {
            bool contains = false;
            foreach (var v in V)
            {
                if (Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) <= Math.Pow(r, 2))
                {
                    contains = true; break;
                }

            }
            if (contains) return false;
            //if (V.Contains((x, y, nr)))
            //  return false;
            V.Add((x, y, nr, c));
            return true;
        }



        public bool Add(int v1, int v2)
        {
            if (E.Contains((v1, v2))) return false;
            E.Add((v1, v2));
            return true;
        }

        public void Remove(int nr)
        {

            fix(nr);
        }

        public int getNr(int x, int y, int r)
        {
            //bool contains = false;
            foreach (var v in V)
            {
                if (Math.Pow(x - v.x, 2) + Math.Pow(y - v.y, 2) < Math.Pow(r, 2))
                {
                    return v.nr;
                }
            }
            return -1;
        }

        public void fix(int nr)
        {
            int indexToRemove = 0;
            List<int> ind = new List<int>();
            for (int i = 0; i < V.Count; ++i) // przenumerowanie wierzcholkow
            {
                if (nr == V[i].nr) indexToRemove = i;
                if (V[i].nr > nr) V[i] = (V[i].x, V[i].y, V[i].nr - 1, V[i].c);
            }
            V.RemoveAt(indexToRemove); // usuniecie wierzcholka
            for (int i = 0; i < E.Count; ++i) // przenumerowanie krawedzi + zapamietanie krawedzi do wyrzucenia
            {
                if (E[i].v1 == nr || E[i].v2 == nr) ind.Add(i);
                if (E[i].v1 > nr && E[i].v2 > nr) E[i] = (E[i].v1 - 1, E[i].v2 - 1);
                else if (E[i].v1 > nr) E[i] = (E[i].v1 - 1, E[i].v2);
                else if (E[i].v2 > nr) E[i] = (E[i].v1, E[i].v2 - 1);
            }
            for (int i = 0; i < ind.Count; ++i) // usuwanie krawedzi
            {
                E.RemoveAt(ind[i] - i);
            }

        }

        public void Clear()
        {
            V.Clear();
            E.Clear();
        }

        public void Export(string s)
        {
            //using (var writer = new System.IO.StreamWriter(s))
            //{
            //    var serializer = new XmlSerializer(this.GetType());
            //    serializer.Serialize(writer, this);
            //    writer.Flush();
            //}

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(s, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static Graph Import(string s)
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.Read);
            Graph g = (Graph)formatter.Deserialize(stream);
            stream.Close();
            return g;
            //using (var stream = System.IO.File.OpenRead(s))
            //{

            //    var serializer = new XmlSerializer(typeof(Graph));
            //    return serializer.Deserialize(stream) as Graph;
            //}
        }
    }
}
