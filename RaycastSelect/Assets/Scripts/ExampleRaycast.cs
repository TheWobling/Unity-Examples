using UnityEngine;
using System.Collections;

public class ExampleRaycast : MonoBehaviour
{
	private void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
	        {
	            if (raycastHit.transform.GetComponent<Renderer>().material.color == Color.red)
	            {
                    raycastHit.transform.GetComponent<Renderer>().material.color = Color.white;
                }
	            else
	            {
                    raycastHit.transform.GetComponent<Renderer>().material.color = Color.red;
                }
	        }               
	    }
    }
}
