using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{

    public int score = 0;

    public bool started = false;

    public GameObject balls;
    List<Transform> ballLocations;

    public float timer = 60;
    private float timeRemaining;

    private void Start()
    {
        timeRemaining = timer;
        foreach(Transform child in balls.transform)
        {
            ballLocations.Add(child);
        }
    }

    private void Update()
    {
        if (started)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                started = false;
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        if (started)
        {
            score += amount;
        }
    }

    public void StartGame()
    {
        if (!started)
        {
            score = 0;
            timeRemaining = timer;
            started = true;
        }
    }

    public void ResetBalls()
    {
        for(int i = 0; i < balls.transform.childCount; i++)
        {
            balls.transform.GetChild(i).position = ballLocations[i].position;
        }
    }
}
