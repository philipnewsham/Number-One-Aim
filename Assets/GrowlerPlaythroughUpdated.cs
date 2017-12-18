using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerPlaythroughUpdated : MonoBehaviour
{
    public GoToNode[] panelScripts;
    public void BeginSong()
    {
        Invoke("StartSong", 1.0f);
        StartCoroutine(PanelSlideIn());
    }

    void StartSong()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator PanelSlideIn()
    {
        yield return new WaitForSeconds(.46f);
        for (int i = 0; i < 8; i++)
        {
            panelScripts[i].StartMove(1,1.0f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
