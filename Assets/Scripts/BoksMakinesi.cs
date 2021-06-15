using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoksMakinesi : MonoBehaviour
{
    public TextMeshProUGUI score;
    public bool started = false;
    public float speed = 5f;
    public float animTime = 2f;
    public float scoreTime = 2f;

    private bool rotationFinStart = false;
    private bool rotationFinEnd = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ControllerLeft") || other.CompareTag("ControllerRight"))
        {
            if (!started)
            {
                started = true;
                rotationFinStart = false;
                score.text = "Score\n0";
                StartCoroutine(MoveHandle());
            }
        }
    }

    private void Update()
    {
        if (started && !rotationFinStart)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * speed);
        }
        if(started && !rotationFinEnd)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed/2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!started)
            {
                started = true;
                rotationFinStart = false;
                StartCoroutine(MoveHandle());
            }
        }
    }

    private IEnumerator MoveHandle()
    {
        yield return new WaitForSeconds(animTime);
        rotationFinStart = true;
        StartCoroutine(Score());
        yield return null;
    }

    private IEnumerator Score()
    {
        int score = Random.Range(700, 900);
        int tempScore = 0;
        float tempTime = 1f / (float)(score - 50f);

        while (tempScore <= score)
        {
            if (tempScore >= score - 50f) tempTime = 1f / 20f;
            yield return new WaitForSeconds(tempTime);
            tempScore++;
            Debug.Log(tempTime);
            this.score.text = "Score\n"+tempScore.ToString();
        }

        rotationFinEnd = false;
        StartCoroutine(MoveHandleToStart());
        yield return null;
    }

    private IEnumerator MoveHandleToStart()
    {
        yield return new WaitForSeconds(animTime*2);
        rotationFinEnd = true;
        started = false;
        yield return null;
    }
}
