using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentController : MonoBehaviour
{
    public float[] waitTimes;
    public ParentMove parentMove;

	public void BeginSong()
    {
        StartCoroutine(Animation());
	}

    public void Reset()
    {
        StopAllCoroutines();
        parentMove.StartMove(0, 1.0f);
    }

    IEnumerator Animation()
    {
        yield return new WaitForSeconds(waitTimes[0]);
        StartCoroutine(FigureEight(1.5f));
        yield return new WaitForSeconds(GetWaitTime(1));
        StartCoroutine(RandomMove(2.0f,6));
        yield return new WaitForSeconds(GetWaitTime(2));
        StartCoroutine(RandomMove(3.0f, 3));
    }

    IEnumerator FigureEight(float speed)
    {
        int[] no = new int[8] { 1, 2, 3, 0, 4, 5, 6, 0 };
        for (int i = 0; i < 8; i++)
        {
            parentMove.StartMove(no[i], speed);
            yield return new WaitForSeconds(speed);
        }
        yield return null;
    }

    IEnumerator RandomMove(float speed, int amount)
    {
        int no = Random.Range(1, 7);
        int ln = no;
        for (int i = 0; i < amount; i++)
        {
            parentMove.StartMove(no, speed);
            yield return new WaitForSeconds(speed);
            no = Random.Range(0, 7);
            if (no == ln)
            {
                no = Random.Range(0, 7);
                yield return null;
            }
            else
            {
                ln = no;
            }
        }

        parentMove.StartMove(0, speed);
    }

    float GetWaitTime(int currentNumber)
    {
        return (waitTimes[currentNumber] - waitTimes[currentNumber - 1]);
    }
}
