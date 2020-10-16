using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public Node fromNode;
    public Node toNode;
    public float cost;

    private float GetCost()
    {
        return cost;
    }
}
