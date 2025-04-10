using System;
using UnityEngine;


    public enum GameState {
        titleScreen, // UI, title, startButton, log, howToPlay
        waitingStart, // waiting start
        play, // game play follow to boat object
        gameOver // game over

    }
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    void Awake()
    {
        Instance = this;
    }

    public GameState currentState;
    public ScoreManager scoreManager;
    public CountDownManager countDownManager;
    public camera cameraObj;
    public boat boat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiChangeState(GameState.waitingStart);
        scoreManager.showScore();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState + " in UIManager");
        switch (currentState) {
            case GameState.titleScreen:
                break;
            case GameState.waitingStart:
                gameStartReady();
                changeStrategy();
                break;
            case GameState.play:
                changePlay();
                break;
            case GameState.gameOver:
                break;
        }
    }

    public void uiChangeState(GameState newState) {
        if (currentState == newState) return;
        currentState = newState;
        enterState(currentState);
    }

    public void enterState(GameState state) {
        switch(state) {
            case GameState.waitingStart:
                break;
        }
    }

    public void gameStartReady() {
        Debug.Log("getGoRun is " + countDownManager.getGoRun());
        if (countDownManager.getGoRun()) {
            uiChangeState(GameState.play);
            boat.changeState(boatState.moving);
        }
    }

    public void changeStrategy() {
        countDownManager.changeState(countDownState.strategy);
        cameraObj.changeStatus(cameraStatus.strategy);
    }

    public void changePlay() {
        countDownManager.changeState(countDownState.play);
        cameraObj.changeStatus(cameraStatus.play);
    }

    public void addScore() {
        scoreManager.addScore();
    }

    public int getScore() {
        return scoreManager.getScore();
    }

    public Boolean getGoRun() {
        return countDownManager.getGoRun();
    }

    public void setGameOver() {
        countDownManager.setGameOver();
    }
    public void cameraHomePosition(){
        cameraObj.homePosition();
    }

    public void setGoRunFalse() {
        countDownManager.setGoRun();
    }

    public Boolean getCount0() {
        return countDownManager.getCount0();
    }


}
