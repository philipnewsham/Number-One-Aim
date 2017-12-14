using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCheck : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
            gameController.AddLaserOut();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
            gameController.RemoveLaserOut();
    }
}
