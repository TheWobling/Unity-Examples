using UnityEngine;
using System.Collections;

public class RequestPooledObject : MonoBehaviour
{
    private float _distance = 10.0f;

	void Update ()
    {
	    if (Input.GetButtonDown("Fire1"))
	    {
	        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance));
	        GameObject obj = ObjectPooler.CurrentObjectPooler.GetObject();

	        if (obj == null) return;

	        obj.transform.position = targetPosition;
            obj.SetActive(true);
	    }
	}
}
