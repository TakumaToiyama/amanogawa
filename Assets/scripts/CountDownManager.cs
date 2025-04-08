using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public enum countDownState {
    play,
    strategy
}
public class CountDownManager : MonoBehaviour
{
    public countDownState currentState;
    public float cowntDown;
    public TMP_Text timeText;
    public Boolean goRun = false;
    public Boolean gameOver = false;
    public boat boat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setCountDown(boat.getRefSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState) {
            case countDownState.play:
                timer();
                break;
            case countDownState.strategy:
                break;
        }
    }


    public void changeState(countDownState newState) {
        if (newState == currentState) return;

        currentState = newState;
    }

    public void timer() {
        cowntDown -= Time.deltaTime;

        timeText .text = cowntDown.ToString("f1");

        if (cowntDown <= 0) {
            goRun = true;
            Debug.Log(gameOver);
            if (boat.gameOver()) {
                timeText.text = "Game Over";
                return;
            }
            // cowntDown = 16;
            setCountDown(boat.getRefSpeed());
        }
    }
    public void setCountDown(float speed) {
        cowntDown = 3.5f + 160 / (Math.Abs(speed) * 60);

    }
    public void setGoRun() {
        goRun = false;
    }

    public Boolean getGoRun() {
        return goRun;
    }

    public void setGameOver() {
        gameOver = true;
    }

    public float getCountDown() {
        return cowntDown;
    }


}
