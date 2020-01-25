using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public string playerName = string.Empty; //We want to have a default value
    // Start is called before the first frame update
    void Start()
    {
        score = 0;

        //             CONDITIONAL                IF TRUE            IF FALSE
        playerName = playerName == string.Empty ? gameObject.tag : playerName;
    }

    public float GetScore()
    {
        return score;
    }

    public void AddScore(float score)
    {
        this.score += score;
    }

    public void ResetScore()
    {
        this.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " +  score;
    }
}
