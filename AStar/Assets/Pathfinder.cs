using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour
{

    private void Awake()
    {
        // Get the Grid, generated or pre defined
    }

    private void FindPath(Vector3 startPosition, Vector3 endPosition)
    {
        GameObject startNode = new GameObject();
        GameObject endNode = new GameObject();

        startNode.transform.position = startPosition;
        endNode.transform.position = endPosition;

        List<GameObject> openSet = new List<GameObject>();
        HashSet<GameObject> closedSet = new HashSet<GameObject>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            GameObject currentNodeObj = openSet[0];
            Node currentNode = currentNodeObj.GetComponent<Node>();

            for (var i = 0; i < openSet.Count; i++)
            {
                Node node = openSet[i].GetComponent<Node>();
                if (node.FCost < currentNode.FCost || node.FCost == currentNode.FCost && node.hCost < currentNode.hCost)
                {
                    currentNodeObj = openSet[i];
                }
            }

            openSet.Remove(currentNodeObj);
            closedSet.Add(currentNodeObj);

            if (currentNode == endNode) return;



        }



    }
}
