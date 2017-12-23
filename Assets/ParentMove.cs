using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentMove : MonoBehaviour
{
    public GameObject[] nodes;
    private int currentNode;

    void Start()
    {
        currentNode = 0;
    }

    public void StartMove(int nodeNo, float moveTime)
    {
        StartCoroutine(MoveToNode(nodeNo, moveTime));
    }

    IEnumerator MoveToNode(int nodeNo, float moveTime)
    { 
        float lerpTime = 0.0f;
        float lerpAmount = (1.0f / 7.0f)*Time.deltaTime;
        while (lerpTime <= 1.0f)
        {
            Vector3 startPosition = nodes[currentNode].transform.position;
            Vector3 endPosition = nodes[nodeNo].transform.position;

            float posX = Mathf.Lerp(startPosition.x, endPosition.x, lerpTime);
            float posY = Mathf.Lerp(startPosition.y, endPosition.y, lerpTime);
            float posZ = Mathf.Lerp(startPosition.z, endPosition.z, lerpTime);

            transform.position = new Vector3(posX, posY, posZ);

            lerpTime += Time.deltaTime / moveTime;
            yield return new WaitForEndOfFrame();
        }
        currentNode = nodeNo;
        transform.position = nodes[nodeNo].transform.position;
    }
}
