using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    int priority;
    Node start;
    Graph graph;
    Node current;
    public Node goal;
    PriorityQueue<Node> frontier = new PriorityQueue<Node>();
    Dictionary<Node, Node> came_from;
    Dictionary<Node, int> cost_so_far;


    private void Start()
    {
        start.priority = 0;
        frontier.Enqueue(start);
        came_from[start] = null;
        cost_so_far[null] = 0;
        
    }

    void PerformAlgorithm()
    {
        while(frontier.Count > 0)
        {
            current = frontier.Peek();

            if(current == goal)
            {
                break;
            }

            foreach(Connection c in graph.GetConnections(current))
            {
                int new_cost = cost_so_far[current] + graph.GetCost(current, c.toNode);
                if(cost_so_far.ContainsKey(c.toNode) == false || new_cost < cost_so_far[c.toNode])
                {
                    cost_so_far[c.toNode] = new_cost;
                    priority = new_cost;
                    c.toNode.priority = priority;
                    frontier.Enqueue(c.toNode);
                    came_from[c.toNode] = current;
                    
                }
            }

            }
            
        }
    }

