using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text tMP_Text;
    private int score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        uppdateScore();
    }

    public void uppdateScore() {
        tMP_Text.text = "Score: " + score;
    }

    public void showScore() {
        gameObject.SetActive(true);
        tMP_Text.text = "Score: " + score;
    }

    public void hideScore() {
        gameObject.SetActive(false);
    }

    public void addScore() {
        score++;
    }
    public int getScore() {
        return score;
    }
}
