using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
	void Update ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
                transform.position = hit.point;
        }
	}
}