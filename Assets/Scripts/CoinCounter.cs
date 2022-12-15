using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Prometheus")
        {
            float score = PlayerPrefs.GetFloat("Score", 0);
            score += 5;
            PlayerPrefs.SetFloat("Score", score);

            source.Play();
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }
    }
}
