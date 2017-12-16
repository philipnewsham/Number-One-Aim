using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject lookAt;
    private float rotationZ;
    public float rotateSpeed;
	void Update ()
    {
        Vector3 position = lookAt.transform.position;
        transform.LookAt(position);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationZ);

        if (Input.GetMouseButton(0))
            rotationZ = rotationZ + (Time.deltaTime * rotateSpeed);
        if (Input.GetMouseButton(1)) 
            rotationZ = rotationZ - (Time.deltaTime * rotateSpeed);
    }
}
