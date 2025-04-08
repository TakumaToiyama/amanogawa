using System;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public ScoreManager scoreManagerUI;
    public CountDownManager countDownManagerUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManagerUI.showScore();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void addScore() {
        scoreManagerUI.addScore();
    }

    public int getScore() {
        return scoreManagerUI.getScore();
    }

    public Boolean getGoRun() {
        return countDownManagerUI.getGoRun();
    }

    public void setGoRun() {
        countDownManagerUI.setGoRun();
    }

    public void setGameOver() {
        countDownManagerUI.setGameOver();
    }


}
