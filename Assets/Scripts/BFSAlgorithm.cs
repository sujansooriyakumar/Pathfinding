using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFSAlgorithm : MonoBehaviour
{
    public Graph graph;
    public Node startNode;
    public Queue<Node> frontier = new Queue<Node>();
    public List<Node> reached = new List<Node>();
    public Node goal;
    public Node currentNode;
    public List<Node> path = new List<Node>();
    public GameObject npc;
    int i;
    bool pathFound;

    private void Start()
    {
        pathFound = false;
        path.Add(goal);
        frontier.Enqueue(startNode);
        reached.Add(startNode);
    }
    private void Update()
    {

        if (currentNode != goal) PerformAlgorithm();
        else
        {
            FindPath();
        }

      
    }

    void PerformAlgorithm()
    {
        if (frontier.Count != 0)
        {
            currentNode = frontier.Dequeue();
            foreach (Connection c in graph.GetConnections(currentNode))
            {
                if (!reached.Contains(c.toNode))
                {
                    frontier.Enqueue(c.toNode);
                    reached.Add(c.toNode);
                    c.toNode.parent = currentNode;
                    
                }

            }
        }
    }

    void FindPath()
    {
        if (path.Contains(startNode) == false)
        {
            if (path[path.Count - 1].parent != startNode)
            {
                path.Add(path[path.Count - 1].parent);
            }

            

        }
        if (pathFound == false)
        {
            i = path.Count;
            pathFound = true;
        }
            MoveNPC();
        
        
       
            
        
    }

    void MoveNPC()
    {
        Debug.Log(i);
        if (i > 0)
        {
            Vector3 result = path[i-1].transform.position - npc.transform.position;
            if(result.magnitude < 0.1f)
            {
                Debug.Log("test");
                i--;
            }
            else{
                npc.transform.position += result.normalized *10.0f* Time.deltaTime;
            }
        }
    }

}
