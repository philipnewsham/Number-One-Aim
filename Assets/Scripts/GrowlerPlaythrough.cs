using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowlerPlaythrough : MonoBehaviour
{
    public GameObject[] panelNodes;
    public GameObject[] parentNodes;
    public GameObject[] fixedLasers;
    public GameObject randomLaser;
    public GameObject cannon;
    public AudioSource audioSource;

    public GoToNode[] panelScripts;
	public void BeginSong()
    {
        audioSource.Play();
        StartCoroutine(A());
	}
	
	IEnumerator A ()
    {
        float eighth = 1.0f / 8.0f;
        
        for (int i = 0; i < 8; i++)
        {
            panelNodes[(3 * i) + 1].SetActive(true);
            yield return new WaitForSeconds(eighth);
        }

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FigureEight());
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(ShrinkHole());
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FigureEight());
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(ExpandHole());
        yield return new WaitForSeconds(1.0f);
        //StartCoroutine(B());
	}

    IEnumerator B()
    {
        StartCoroutine(ExpandHole());
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(true);
        fixedLasers[1].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 1 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 1 + 2].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 3 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 3 + 2].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 7 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 7 + 2].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(false);
        fixedLasers[1].SetActive(false);
        StartCoroutine(C());
    }

    IEnumerator C()
    {
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(true);
        fixedLasers[3].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 0 + 0].SetActive(true);
        panelNodes[3 * 4 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 0 + 2].SetActive(true);
        panelNodes[3 * 4 + 2].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 2 + 0].SetActive(true);
        panelNodes[3 * 6 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 2 + 2].SetActive(true);
        panelNodes[3 * 6 + 2].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 1 + 0].SetActive(true);
        panelNodes[3 * 5 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 1 + 2].SetActive(true);
        panelNodes[3 * 5 + 2].SetActive(true);

        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 3 + 0].SetActive(true);
        panelNodes[3 * 7 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 3 + 2].SetActive(true);
        panelNodes[3 * 7 + 2].SetActive(true);
        fixedLasers[0].SetActive(false);
        fixedLasers[3].SetActive(false);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(D());
    }

    IEnumerator D()
    {
        StartCoroutine(FigureEight());
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FireRandomLasers(3,1));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(FireRandomLasers(3,1));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(E());
    }

    IEnumerator E()
    {
        StartCoroutine(ExpandHole());
        yield return new WaitForSeconds(1.0f);
        panelNodes[(3 * 1) + 1].SetActive(true);
        panelNodes[(3 * 3) + 1].SetActive(true);
        panelNodes[(3 * 6) + 1].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FigureEight());
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FireRandomLasers(2,1));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(FireRandomLasers(2,1));
        yield return new WaitForSeconds(3.0f);
        StartCoroutine(ExpandHole());
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(F());
    }

    IEnumerator F()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(FireRandomLasers(3,1));
        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 1 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 1 + 2].SetActive(true);

        StartCoroutine(FireRandomLasers(3,1));
        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 3 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 3 + 2].SetActive(true);

        StartCoroutine(FireRandomLasers(3,1));
        yield return new WaitForSeconds(1.0f);
        panelNodes[3 * 7 + 0].SetActive(true);
        yield return new WaitForSeconds(2.0f);
        panelNodes[3 * 7 + 2].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(G());
    }

    IEnumerator G()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(MexicanWave(0.4f, 0));
        yield return new WaitForSeconds(1.4f);
        StartCoroutine(MexicanWave(0.4f, 2));
        yield return new WaitForSeconds(3.2f);
        StartCoroutine(G());
    }

    IEnumerator H()
    {
        yield return new WaitForSeconds(1.0f);
        fixedLasers[0].SetActive(true);
        fixedLasers[1].SetActive(true);
        fixedLasers[2].SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1.0f);
            panelNodes[3 * 1 + 1].SetActive(true);
            panelNodes[3 * 3 + 1].SetActive(true);
            panelNodes[3 * 6 + 1].SetActive(true);
            yield return new WaitForSeconds(2.0f);
            panelNodes[3 * 1 + 2].SetActive(true);
            panelNodes[3 * 3 + 2].SetActive(true);
            panelNodes[3 * 6 + 2].SetActive(true);

            yield return new WaitForSeconds(1.0f);
            panelNodes[3 * 2 + 1].SetActive(true);
            panelNodes[3 * 5 + 1].SetActive(true);
            panelNodes[3 * 7 + 1].SetActive(true);
            yield return new WaitForSeconds(2.0f);
            panelNodes[3 * 2 + 2].SetActive(true);
            panelNodes[3 * 5 + 2].SetActive(true);
            panelNodes[3 * 7 + 2].SetActive(true);
        }
        StartCoroutine(I());
    }

    IEnumerator I()
    {
        StartCoroutine(RandomPanels(7));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(FireRandomLasers(1, 4));
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(RandomMovement(0, 7));
        yield return new WaitForSeconds(10.0f);
        parentNodes[0].SetActive(true);
        StartCoroutine(ExpandHole());
    }

    IEnumerator FigureEight()
    {
        for (int i = 1; i < 4; i++)
        {
            parentNodes[i].SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
        parentNodes[0].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        for (int i = 4; i < 7; i++)
        {
            parentNodes[i].SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
        parentNodes[0].SetActive(true);
    }

    IEnumerator ShrinkHole()
    {
        for (int i = 0; i < 8; i++)
        {
            panelNodes[(3 * i) + 0].SetActive(true);
            yield return null;
        }
    }

    IEnumerator MiddleHole()
    {
        for (int i = 0; i < 8; i++)
        {
            panelNodes[(3 * i) + 1].SetActive(true);
            yield return null;
        }
    }

    IEnumerator ExpandHole()
    {
        for (int i = 0; i < 8; i++)
        {
            panelNodes[(3 * i) + 2].SetActive(true);
            yield return null;
        }
    }

    IEnumerator FireRandomLasers(int laserAmount, int loopAmount)
    {
        for (int j = 0; j < loopAmount; j++)
        {
            GameObject[] randomLasers = new GameObject[laserAmount];
            for (int i = 0; i < laserAmount; i++)
            {
                randomLasers[i] = Instantiate(randomLaser, cannon.transform);
            }
            yield return new WaitForSeconds(2.0f);
            for (int i = 0; i < laserAmount; i++)
            {
                Destroy(randomLasers[i]);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator MexicanWave(float waveDelay, int size)
    {
        for (int i = 0; i < 8; i++)
        {
            panelNodes[(3 * i) + size].SetActive(true);
            yield return new WaitForSeconds(waveDelay);
        }
    }

    IEnumerator RandomPanels(int loopAmount)
    {
        for (int i = 0; i < loopAmount; i++)
        {
            int panel = Random.Range(0, 8);
            int size = Random.Range(0, 2);
            panelNodes[(3 * panel) + size].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            panelNodes[(3 * panel) + 2].SetActive(true);
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator RandomMovement(int startPosition, int loopAmount)
    {
        int startingPos = startPosition;
        for (int j = 0; j < loopAmount; j++)
        {
            int[] otherPos = new int[7];
            int countCheck = 0;
            for (int i = 0; i < 8; i++)
            {
                if (i != startingPos)
                {
                    otherPos[countCheck] = i;
                    countCheck += 1;
                }
            }

            int nextPos = otherPos[Random.Range(0, 7)];
            parentNodes[nextPos].SetActive(true);
            startingPos = nextPos;
            yield return new WaitForSeconds(2.0f);
        }
    }
}