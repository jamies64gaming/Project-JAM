using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Alive",0) == 1)
        {
            float score = PlayerPrefs.GetFloat("Score", 0);

            score += Time.deltaTime;

            scoreText.text = Mathf.RoundToInt(score).ToString();
            PlayerPrefs.SetFloat("Score", score);
        }
    }
}
