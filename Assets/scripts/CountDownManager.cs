using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public enum countDownState {
    idle,
    play,
    strategy
}
public class CountDownManager : MonoBehaviour
{
    public countDownState currentState;
    public float countDown = 0;
    public TMP_Text timeText;
    public Boolean goRun = false;
    public Boolean gameOver = false;
    public boat boat;
    public Boolean count0 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeState(countDownState.idle);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("countDownmanager state is " + currentState);
        switch (currentState) {
            case countDownState.play:
                playTimer();
                break;
            case countDownState.strategy:
                strategyTimer();
                break;
        }
    }


    public void changeState(countDownState newState) {
        Debug.Log((currentState == newState) + " " + currentState);
        if (newState == currentState) return;

        Debug.Log("Befor : currentState is " + currentState + " newState is " + newState);
        currentState = newState;
        Debug.Log("After : currentState is " + currentState + " newState is " + newState);
        enterState(currentState);
    }
    void enterState(countDownState state) {
        switch (state)
        {   case countDownState.play:
                setCountDown(boat.getRefSpeed());
                break;
            case countDownState.strategy:
            setStrategyTimer();
            break;
        }
    }

    public void playTimer() {
        countDown -= Time.deltaTime;

        timeText .text = countDown.ToString("f1") + " play";

        if (countDown <= 0) {
            count0 = true;
            Debug.Log(gameOver);
            if (boat.gameOver()) {
                timeText.text = "Game Over";
                return;
            }
        }
    }

    public void strategyTimer() {
        countDown -= Time.deltaTime;
        timeText .text = countDown.ToString("f1") + " strategy";
        if (countDown <= 0) {
            goRun = true;
            setCountDown(boat.getRefSpeed());
        }
    }

    public void setCountDown(float speed) {
        count0 = false;
        countDown = 3.5f + 160 / (Math.Abs(speed) * 60);
    }

    public void setStrategyTimer() {
        countDown += 3;
        // Debug.Log("countDown is " + countDown);
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
        return countDown;
    }

    public Boolean getCount0() {
        return count0;
    }
}