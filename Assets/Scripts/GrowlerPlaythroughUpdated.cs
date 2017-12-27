using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerPlaythroughUpdated : MonoBehaviour
{
    public GoToNode[] panelScripts;
    public float[] waitTimes;
    public bool testing;
    private GrowlerLasers laserController;

    void Start()
    {
        laserController = GetComponent<GrowlerLasers>();
    }

    public void BeginSong()
    {
        if (!testing)
        {
            Invoke("StartSong", 1.0f);
            StartCoroutine(PanelAnimation());
        }
        else
        {
            StartSong();
            StartCoroutine(SinglePanelsTwo());
        }
    }

    void StartSong()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator PanelAnimation()
    {
        StartSpeed();
        yield return new WaitForSeconds(waitTimes[0]);
        StartCoroutine(PanelSlideIn());
        yield return new WaitForSeconds(GetWaitTime(1));
        StartCoroutine(ShrinkIn());
        yield return new WaitForSeconds(GetWaitTime(2));
        StartCoroutine(ExpandOut());
        yield return new WaitForSeconds(GetWaitTime(3));
        laserController.StartThreeLasers();
        StartCoroutine(SinglePanels());
        yield return new WaitForSeconds(GetWaitTime(4));
        laserController.StartTwoLasers();
        StartCoroutine(DoublePanels());
        StopSpeed();
        yield return new WaitForSeconds(GetWaitTime(5));
        laserController.StartRandomLasers(3, 1, 1, 3);
        StartCoroutine(ExpandOut());
        yield return new WaitForSeconds(GetWaitTime(6));
        laserController.StartRandomLasers(2, 1, 1, 3);
        StartCoroutine(Triangle());
        yield return new WaitForSeconds(GetWaitTime(7));
        StartCoroutine(ExpandOut());
        yield return new WaitForSeconds(GetWaitTime(8));
        Debug.Log(GetComponent<AudioSource>().time);
        StartCoroutine(SinglePanelsTwo());
        yield return new WaitForSeconds(GetWaitTime(9));
        StartCoroutine(MexicanWave());
        yield return new WaitForSeconds(GetWaitTime(10));
        StartCoroutine(SwappingTriangles());
        yield return new WaitForSeconds(GetWaitTime(11));
        StartCoroutine(RandomPanels());
        yield return new WaitForSeconds(GetWaitTime(12));
        StartCoroutine(ExpandOut());
    }

    void StartSpeed()
    {
        Time.timeScale = 3.0f;
        GetComponent<AudioSource>().pitch = 3.0f;
    }

    void StopSpeed()
    {
        Time.timeScale = 1.0f;
        GetComponent<AudioSource>().pitch = 1.0f;
    }

    IEnumerator PanelSlideIn()
    {
        yield return new WaitForSeconds(.46f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(1,(2.0f-0.46f)/8.0f);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ShrinkIn()
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(0, 3.0f);
            yield return null;
        }
    }

    IEnumerator ExpandOut()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(2, 1.0f);
            yield return null;
        }
    }

    IEnumerator SinglePanels()
    {
        yield return new WaitForSeconds(2.0f);
        int[] panelNo = new int[4] { 1, 3, 5,7 };
        int i = panelNo[0];
        panelScripts[i].StartMove(0, 1.0f);
        yield return new WaitForSeconds(1.0f);
        panelScripts[i].StartMove(2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(2.0f);

        i = panelNo[1];
        panelScripts[i].StartMove(1, 1.0f);
        yield return new WaitForSeconds(1.0f);
        panelScripts[i].StartMove(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(2, 1.0f);
        yield return new WaitForSeconds(1.0f);

        i = panelNo[2];
        panelScripts[i].StartMove(0, 1.5f);
        yield return new WaitForSeconds(1.5f);
        panelScripts[i].StartMove(2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(2.0f);

        i = panelNo[3];
        panelScripts[i].StartMove(1, 1.0f);
        yield return new WaitForSeconds(1.0f);
        panelScripts[i].StartMove(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(2, 1.0f);
        yield return new WaitForSeconds(1.0f);
    }
    public float tempWait;
    IEnumerator DoublePanels()
    {
        yield return new WaitForSeconds(1f);
        panelScripts[1].StartMove(1, 2.5f);
        panelScripts[5].StartMove(1, 2.5f);
        yield return new WaitForSeconds(2.5f);
        panelScripts[1].StartMove(0, .5f);
        panelScripts[5].StartMove(0, .5f);
        yield return new WaitForSeconds(2.0f);
        panelScripts[1].StartMove(2, 2.0f);
        panelScripts[5].StartMove(2, 2.0f);

        yield return new WaitForSeconds(2.0f);
        panelScripts[3].StartMove(1, 2.5f);
        panelScripts[7].StartMove(1, 2.5f);
        yield return new WaitForSeconds(2.5f);
        panelScripts[3].StartMove(0, .5f);
        panelScripts[7].StartMove(0, .5f);
        yield return new WaitForSeconds(2.0f);
        panelScripts[3].StartMove(2, 2.0f);
        panelScripts[7].StartMove(2, 2.0f);
    }

    IEnumerator Triangle()
    {
        panelScripts[1].StartMove(1, 1.0f);
        panelScripts[3].StartMove(1, 1.0f);
        panelScripts[6].StartMove(1, 1.0f);
        yield return new WaitForSeconds(5.0f);
        panelScripts[1].StartMove(2, .2f);
        panelScripts[3].StartMove(2, .2f);
        panelScripts[6].StartMove(2, .2f);
    }

    IEnumerator SinglePanelsTwo()
    {
        yield return new WaitForSeconds(1.0f);
        int[] panelNo = new int[2] { 0, 4};
        int i = panelNo[0];
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(2, 0.5f);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(5.0f);

        i = panelNo[1];
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        panelScripts[i].StartMove(2, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator MexicanWave()
    {
        yield return new WaitForSeconds(2.0f);
        for (int k = 0; k < 2; k++)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    panelScripts[i].StartMove(j, (2.0f - 0.46f) / 8.0f);
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < 8; i++)
                {
                    panelScripts[i].StartMove(2, (2.0f - 0.46f) / 8.0f);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }

    IEnumerator SwappingTriangles()
    {
        for (int i = 0; i < 2; i++)
        {
            panelScripts[1].StartMove(1, 1.0f);
            panelScripts[3].StartMove(1, 1.0f);
            panelScripts[6].StartMove(1, 1.0f);
            yield return new WaitForSeconds(2.0f);
            panelScripts[1].StartMove(2, 1.0f);
            panelScripts[3].StartMove(2, 1.0f);
            panelScripts[6].StartMove(2, 1.0f);
            yield return new WaitForSeconds(2.0f);

            panelScripts[2].StartMove(1, 1.0f);
            panelScripts[5].StartMove(1, 1.0f);
            panelScripts[7].StartMove(1, 1.0f);
            yield return new WaitForSeconds(2.0f);
            panelScripts[2].StartMove(2, 1.0f);
            panelScripts[5].StartMove(2, 1.0f);
            panelScripts[7].StartMove(2, 1.0f);
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator RandomPanels()
    {
        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < 4; i++)
        {
            int a = Random.Range(0, 8);
            int b = Random.Range(0, 8);
            while(b==a)
            {
                b = Random.Range(0, 8);
                yield return null;
            }

            panelScripts[a].StartMove(Random.Range(0,2), 0.5f);
            panelScripts[b].StartMove(Random.Range(0,2), 0.5f);
            yield return new WaitForSeconds(2.0f);
            panelScripts[a].StartMove(2, 0.5f);
            panelScripts[b].StartMove(2, 0.5f);
            yield return new WaitForSeconds(1.0f);
        }
    }

    float GetWaitTime(int currentNumber)
    {
        return (waitTimes[currentNumber] - waitTimes[currentNumber - 1]);
    }
}