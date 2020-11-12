using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Node currentNode;
    public GameObject npc;

  


   public Connection[] GetConnections(Node fromNode_)
    {
        return fromNode_.connections;
        
    }

    public int GetCost(Node current, Node next)
    {
        int result = 0;
        for(int i = 0; i < current.connections.Length; i++)
        {
            if(current.connections[i].toNode == next)
            {
                result = current.connections[i].cost;
            }
        }
        return result;
    }
}
