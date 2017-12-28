using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCheck : MonoBehaviour
{
    private GameController gameController;
    private bool isHit;

    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameController.AddLaserOut();
            isHit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            gameController.RemoveLaserOut();
            isHit = false;
        }
    }

    public void DestroyLaser()
    {
        if(isHit)
            gameController.RemoveLaserOut();
        Destroy(transform.parent.gameObject);
    }

    public void SetActiveFalse()
    {
        if (isHit)
            gameController.RemoveLaserOut();
        transform.parent.gameObject.SetActive(false);
    }
}
