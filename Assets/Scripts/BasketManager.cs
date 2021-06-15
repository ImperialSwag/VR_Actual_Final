using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketManager : MonoBehaviour
{

    public int score = 0;

    public bool started = false;

    public GameObject balls;
    List<Vector3> ballLocations = new List<Vector3>();

    public TextMeshProUGUI start, scoretxt;

    public float timer = 60;
    private float timeRemaining;

    private void Start()
    {
        timeRemaining = timer;
        for (int i = 0; i < balls.transform.childCount; i++)
        {
            ballLocations.Add(balls.transform.GetChild(i).position);
        }
    }

    private void Update()
    {
        if (started)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                started = false;
                start.text = "Start Game";
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        if (started)
        {
            score += amount;
            scoretxt.text = "Score\n" + score;
        }
    }

    public void StartGame()
    {
        if (!started)
        {
            score = 0;
            scoretxt.text = "Score\n" + score;
            
            timeRemaining = timer;
            DisplayTime(timeRemaining);
            started = true;
        }
    }

    public void ResetBalls()
    {
        for(int i = 0; i < balls.transform.childCount; i++)
        {
            balls.transform.GetChild(i).position = ballLocations[i];
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        start.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
