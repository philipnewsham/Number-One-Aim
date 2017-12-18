using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerPlaythroughUpdated : MonoBehaviour
{
    public GoToNode[] panelScripts;
    public float[] waitTimes;
    public void BeginSong()
    {
        Invoke("StartSong", 1.0f);
        StartCoroutine(PanelSlideIn());
    }

    void StartSong()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator PanelAnimation()
    {
        StartCoroutine(PanelSlideIn());
        yield return new WaitForSeconds(waitTimes[0]);
        StartCoroutine(ShrinkIn());
    }

    IEnumerator PanelSlideIn()
    {
        yield return new WaitForSeconds(.46f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(1,(2.0f-0.46f)/8.0f);
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(ShrinkIn());
    }

    IEnumerator ShrinkIn()
    {
        yield return new WaitForSeconds(6.0f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(0, 7.0f);
            yield return null;
        }
        StartCoroutine(ExpandOut());
    }

    IEnumerator ExpandOut()
    {
        yield return new WaitForSeconds(7.0f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(2, 7.0f);
        }
    }
}