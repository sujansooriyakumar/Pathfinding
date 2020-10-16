using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSAlgorithm : MonoBehaviour
{
    Graph graph;
    Queue<Node> frontier = new Queue<Node>();
    SortedSet<Node> reached = new SortedSet<Node>();
    public Node goal;
    public Node currentNode;
    public Node A;

    void PerformAlgorithm()
    {
        frontier.Enqueue(currentNode);
        reached.Add(currentNode);

        while (frontier.Count != 0)
        {
            currentNode = frontier.Peek();
            for (int i = 0; i < graph.GetConnections(currentNode).Length; i++)
            {
                Connection c = graph.GetConnections(currentNode)[i];

                if (c.toNode == goal)
                {
                    break;
                }

                else if (reached.Contains(c.toNode) == false)
                {
                    frontier.Enqueue(c.toNode);
                    reached.Add(c.toNode);
                    c.toNode.parent = currentNode;
                }
            }
        }
    }

}
