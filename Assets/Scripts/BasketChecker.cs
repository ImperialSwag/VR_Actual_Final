using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketChecker : MonoBehaviour
{
    public int score = 1;
    public BasketManager basketManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            basketManager.IncreaseScore(score);
        }
    }
}
