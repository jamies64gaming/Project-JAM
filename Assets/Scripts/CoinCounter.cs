using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Prometheus")
        {
            float score = PlayerPrefs.GetFloat("Score", 0);
            score += 5;
            PlayerPrefs.SetFloat("Score", score);
            
            Destroy(gameObject);
        }
    }
}
