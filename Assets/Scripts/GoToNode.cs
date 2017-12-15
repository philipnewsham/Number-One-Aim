using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNode : MonoBehaviour
{
    public string findTag;
    private bool isMoving;
    private GameObject targetNode;

    void Update()
    {
        if(!isMoving && GameObject.FindGameObjectWithTag(findTag)!=null)
        {
            isMoving = true;
            targetNode = GameObject.FindGameObjectWithTag(findTag);
            StartCoroutine(MoveToNode());
        }
    }

    IEnumerator MoveToNode()
    {
        float lerpTime = 0.0f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetNode.transform.position;

        while (lerpTime < 1.0f)
        {
            endPosition = targetNode.transform.position;
            float posX = Mathf.Lerp(startPosition.x, endPosition.x, lerpTime);
            float posY = Mathf.Lerp(startPosition.y, endPosition.y, lerpTime);
            float posZ = Mathf.Lerp(startPosition.z, endPosition.z, lerpTime);
            transform.position = new Vector3(posX, posY, posZ);
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        targetNode.SetActive(false);
        isMoving = false;
    }
}
