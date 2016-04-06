using UnityEngine;

public class Node : MonoBehaviour
{
    public bool Walkable;
    public Vector3 WorldPosition;
    public int gCost;
    public int hCost;

    public int FCost
    {
        get { return gCost + hCost; }
    }

}
