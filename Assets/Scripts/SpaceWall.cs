using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWall : MonoBehaviour
{
    float rotate;
    public float spinSpeed;
	void Update ()
    {
        rotate += Time.deltaTime * spinSpeed;
        transform.eulerAngles = new Vector3(rotate, -90, 90);
	}
}
