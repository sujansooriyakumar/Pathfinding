using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public Node fromNode;
    public Node toNode;
    public int cost;

    private int GetCost()
    {
        return cost;
    }
}
