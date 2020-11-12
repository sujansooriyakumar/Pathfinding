using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node: MonoBehaviour, IComparable<Node>
{
    public Vector3 position;
    public Node parent;
    public int priority;
    public Connection[] connections;
    public void Start()
    {
        FindConnections();
    }

    private void Update()
    {

    }

    public int CompareTo(Node other)
    {
        if(this.priority < other.priority)
        {
            return -1;
        }

        else if (this.priority > other.priority){
            return 1;
        }
        else 
        {
            return 0;
        }
    }

    public void FindConnections()
    {
        connections = GetComponentsInChildren<Connection>();

    }
}
