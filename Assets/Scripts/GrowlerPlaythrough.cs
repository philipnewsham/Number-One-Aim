using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerPlaythrough : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject panelParent;
    private Vector3[] startPositions = new Vector3[8];
    float eighth;

	void Start ()
    {
        eighth = 1.0f / 8.0f;
        StartCoroutine(A());
	}
	
	IEnumerator A ()
    {
        for (int i = 0; i < 8; i++)
        {
            panels[i].GetComponent<Animator>().SetTrigger("Enter");
            yield return new WaitForSeconds(eighth);
        }
        yield return new WaitForSeconds(1.0f);

        panelParent.GetComponent<Animator>().SetTrigger("Eight");

        yield return new WaitForSeconds(13.0f);

        panelParent.GetComponent<Animator>().SetTrigger("Stop");

	}
}
