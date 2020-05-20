//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NonStandartRequests
//{
//    class Rib
//    {
//        public string from;
//        public string to;
//        public Rib(string from, string to)
//        {
//            this.from = from;
//            this.to = to;
//        }
//    }

//    static class OstoveTree
//    {
//       private static string[] reachableVertices(string node, List<Rib> allWays)
//        {
//            return allWays.Where(x => x.from == node).Select(x => x.to).Union(allWays.Where(x => x.to == node).Select(x => x.from)).ToArray();
//        }

//        public static List<Rib> GetOstoveListToConnect(List<Rib> allWays)
//        {
//            List<Rib> res = new List<Rib>();
//            List<string> visited = new List<string>();
//            Queue<string> queue = new Queue<string>();
//            queue.Enqueue(allWays[0].from);
//            visited.Add(allWays[0].from);

//            while (queue.Count > 0)
//            {
//                string node = queue.Dequeue();
//                var rv = reachableVertices(node, allWays);
//                foreach (var child in rv)
//                {
//                    if (!visited.Contains(child))
//                    {
//                        queue.Enqueue(child);
//                        visited.Add(child);
//                        res.Add(new Rib(node, child));
//                    }
//                }
//            }
//            return res;
//        }
//    }
//}
