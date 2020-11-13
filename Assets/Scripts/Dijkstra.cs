using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dijkstra : MonoBehaviour
{
    int priority, i;
    public Node start;
    public Graph graph;
    public Node current;
    public Node goal;
    public PriorityQueue<Node> frontier = new PriorityQueue<Node>();
    public Dictionary<Node, Node> came_from = new Dictionary<Node, Node>();
    public Dictionary<Node, int> cost_so_far = new Dictionary<Node, int>();
    public List<Node> path = new List<Node>();
    bool pathfound;

    private void Start()
    {
       
        pathfound = false;
        start.priority = 0;
        frontier.Enqueue(start);
        came_from[start] = null;
        cost_so_far[start] = 0;
        path.Add(goal);
  



    }

    private void Update()
    {
        if (current != goal)
        {
            PerformAlgorithm();
        }
        else if(current == goal)
        {
            FindPath();
        }

    }

    void PerformAlgorithm()
    {
        if (frontier.Count > 0)
        {
            current = frontier.Dequeue();
        


            foreach (Connection c in graph.GetConnections(current))
            {

                int new_cost = cost_so_far[current] + graph.GetCost(current, c.toNode);

                if (cost_so_far.ContainsKey(c.toNode) == false || new_cost < cost_so_far[c.toNode])
                {
                    cost_so_far[c.toNode] = new_cost;
                    c.toNode.priority = new_cost;
                    frontier.Enqueue(c.toNode);
                    came_from[c.toNode] = current;

                }


            }
        }
    }

    void FindPath()
    {
        if (!pathfound)
        {
            Node nextNode = came_from[goal];
            path.Add(nextNode);
            Debug.Log("Next Node is " + nextNode);
           
            while(nextNode != start)
            {
                Debug.Log("Next Node is " + nextNode);
                
                nextNode = came_from[nextNode];
                path.Add(nextNode);
            }
            Debug.Log("Next Node is " + nextNode);
            i = path.Count - 1;
            pathfound = true;
        }
        if (pathfound) MoveCharacter();
    }

    void MoveCharacter()
    {
        if (i > 0)
        {
            Vector3 result = path[i-1].transform.position - graph.npc.transform.position;
            result.y = 0;
            if (result.magnitude < 0.1f)
            {
                i--;
            }
            else
            {
                graph.npc.transform.position += result.normalized * 10.0f * Time.deltaTime;
            }
        }
    }
}

