using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLaser : MonoBehaviour
{
    float rotX;
    float rotY;
    
	void Start ()
    {
        rotX = Random.Range(-30.0f, 30.0f);
        rotY = Random.Range(-30.0f, 30.0f);
        transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
	}
}