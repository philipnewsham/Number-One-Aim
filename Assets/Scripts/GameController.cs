using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    bool hasStarted;
    public GameObject mainLaser;
    public GameObject clickText;
    private int laserOutCount;

    public Text healthText;
    private float health;
    private bool isAlive = true;

    public float speedUp;

    public GameObject cannon;
    public GameObject miniLaser;

    private AudioSource audioSource;

    private GrowlerPlaythroughUpdated playthroughController;
    private ParentController parentController;
    
	void Start ()
    {
        health = 100;
        healthText.text = string.Format("Health: {0}", health);
        audioSource = GetComponent<AudioSource>();
        playthroughController = GetComponent<GrowlerPlaythroughUpdated>();
        parentController = GetComponent<ParentController>();
    }
	
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && !hasStarted)
        {
            StartGame();
        }

        if (hasStarted)
        {
            if (isAlive)
            {
                health -= laserOutCount * Time.deltaTime * speedUp;
                healthText.text = string.Format("Health: {0}", Mathf.FloorToInt(health));
                if (health <= 0.0f)
                {
                    isAlive = false;
                    healthText.text = string.Format("Health: {0}", 0);
                }
            }
            else
            {
                StartCoroutine(Reset());
            }
        }
    }

    void StartGame()
    {
        hasStarted = true;
        mainLaser.SetActive(true);
        clickText.SetActive(false);
        playthroughController.BeginSong();
        parentController.BeginSong();
    }

    IEnumerator Reset()
    {
        Debug.Log("reset");
        isAlive = true;
        mainLaser.SetActive(false);
        clickText.GetComponent<Text>().text = "Game Over\nClick to try again";
        PositionLaser[] miniLasers = FindObjectsOfType<PositionLaser>();
        foreach (PositionLaser laser in miniLasers)
            Destroy(laser.gameObject);
        clickText.SetActive(true);
        hasStarted = false;
        health = 100;
        laserOutCount = 0;

        playthroughController.Reset();
        parentController.Reset();
        float lerpTime = 0.0f;

        while(lerpTime <= 1.0f)
        {
            audioSource.volume = 1 - lerpTime;
            lerpTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        audioSource.Stop();
        audioSource.volume = 1;
    }

    public void AddLaserOut()
    {
        laserOutCount += 1;
    }

    public void RemoveLaserOut()
    {
        laserOutCount -= 1;
    }

    IEnumerator AddLaserBeam()
    {
        while (hasStarted&&isAlive)
        {
            float waitTime = Random.Range(3.0f, 20.0f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(miniLaser, cannon.transform);
            yield return new WaitForEndOfFrame();
        }
    }
}