using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLaser : MonoBehaviour
{
    float rotX;
    float rotY;
    private float range = 15f;
	void Start ()
    {
        rotX = Random.Range(-range, range);
        rotY = Random.Range(-range, range);
        transform.eulerAngles = new Vector3(rotX, rotY, 0.0f);
	}
}