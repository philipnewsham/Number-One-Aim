using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerLasers : MonoBehaviour
{
    public GameObject[] fixedLasers;
    public float[] waitTimes;
    public GameObject miniLaser;
    public Transform cannon;

    public void StartThreeLasers()
    {
        StartCoroutine(ThreeLasers());
    }
    public float tempWait;
    IEnumerator ThreeLasers()
    {
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(true);
        fixedLasers[1].SetActive(true);
        fixedLasers[2].SetActive(true);
        yield return new WaitForSeconds(14.0f);
        fixedLasers[0].SetActive(false);
        fixedLasers[1].SetActive(false);
        fixedLasers[2].SetActive(false);
    }
    public void StartTwoLasers()
    {
        StartCoroutine(TwoLasers());
    }
    IEnumerator TwoLasers()
    {
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(true);
        fixedLasers[3].SetActive(true);
        yield return new WaitForSeconds(12.0f);
        fixedLasers[0].SetActive(false);
        fixedLasers[3].SetActive(false);
    }

    public void StartRandomLasers(int laserAmount, float onTime, float offTime, int loopAmount)
    {
        StartCoroutine(RandomLasers(laserAmount, onTime, offTime, loopAmount));
    }
    IEnumerator RandomLasers(int laserAmount, float onTime, float offTime, int loopAmount)
    {
        List<GameObject> randLaser = new List<GameObject>();
        randLaser.Clear();
        for (int i = 0; i < loopAmount; i++)
        {
            for (int j = 0; j < laserAmount; j++)
            {
                GameObject laserClone = Instantiate(miniLaser, cannon);
                randLaser.Add(laserClone);
            }
            yield return new WaitForSeconds(onTime);
            for (int j = 0; j < laserAmount; j++)
            {
                Destroy(randLaser[j]);
            }
            randLaser.Clear();
            yield return new WaitForSeconds(offTime);
        }
    }
    
    float GetWaitTime(int currentNumber)
    {
        return (waitTimes[currentNumber] - waitTimes[currentNumber - 1]);
    }
}