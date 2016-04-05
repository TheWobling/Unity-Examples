using UnityEngine;
using System.Collections;

public class ExampleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.name + " has collided with " + collision.transform.name);
    }
}
