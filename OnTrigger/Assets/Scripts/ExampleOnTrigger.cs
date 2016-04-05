using UnityEngine;
using System.Collections;

public class ExampleOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(transform.name + " has entered a trigger with " + collider.transform.name);
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log(transform.name + " has exited a trigger with " + collider.transform.name);
    }
}
