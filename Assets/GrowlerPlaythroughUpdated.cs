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
        StartCoroutine(PanelAnimation());
    }

    void StartSong()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator PanelAnimation()
    {
        yield return new WaitForSeconds(waitTimes[0]);
        StartCoroutine(PanelSlideIn());
        yield return new WaitForSeconds(GetWaitTime(1));
        StartCoroutine(ShrinkIn());
        yield return new WaitForSeconds(GetWaitTime(2));
        StartCoroutine(ExpandOut());
        yield return new WaitForSeconds(GetWaitTime(3));
        StartCoroutine(SinglePanels());
        yield return new WaitForSeconds(GetWaitTime(4));
        StartCoroutine(DoublePanels());
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
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(0, 4.0f);
            yield return null;
        }
    }

    IEnumerator ExpandOut()
    {
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(2, 1.0f);
            yield return null;
        }
    }

    IEnumerator SinglePanels()
    {
        int[] panelNo = new int[3] { 1, 3, 6 };
        for (int i = 0; i < 3; i++)
        {
            panelScripts[panelNo[i]].StartMove(0, 3.0f);
            yield return new WaitForSeconds(3.2f);
            panelScripts[panelNo[i]].StartMove(2, 1f);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator DoublePanels()
    {
        yield return new WaitForSeconds(2.2f);
        panelScripts[1].StartMove(0, 1.0f);
        panelScripts[5].StartMove(0, 1.0f);
        yield return new WaitForSeconds(2.0f);
        panelScripts[1].StartMove(2, 1.0f);
        panelScripts[5].StartMove(2, 1.0f);

        yield return new WaitForSeconds(3.2f);
        panelScripts[3].StartMove(0, 1.0f);
        panelScripts[7].StartMove(0, 1.0f);
        yield return new WaitForSeconds(2.0f);
        panelScripts[3].StartMove(2, 1.0f);
        panelScripts[7].StartMove(2, 1.0f);


        /*
        int[] panelNo = new int[4] { 1, 3, 0, 2 };
        for (int i = 0; i < 4; i++)
        {
            panelScripts[panelNo[i]].StartMove(0, 1.0f);
            panelScripts[panelNo[i]+4].StartMove(0, 1.0f);
            yield return new WaitForSeconds(3.5f);
            panelScripts[panelNo[i]].StartMove(2, 1.0f);
            panelScripts[panelNo[i]+4].StartMove(2, 1.0f);
            yield return new WaitForSeconds(1.5f);
        }
        */

    }

    float GetWaitTime(int currentNumber)
    {
        return (waitTimes[currentNumber] - waitTimes[currentNumber - 1]);
    }
}