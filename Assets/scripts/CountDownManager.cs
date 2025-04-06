using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class CountDownManager : MonoBehaviour
{
    public float cowntDown;
    public TMP_Text timeText;
    public Boolean goRun = false;
    public Boolean gameOver = false;
    public boat  boat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cowntDown = 16f;
    }

    // Update is called once per frame
    void Update()
    {
        cowntDown -= Time.deltaTime;

        timeText .text = cowntDown.ToString("f1");

        if (cowntDown <= 0) {
            goRun = true;
            Debug.Log(gameOver);
            if (boat.gameOver()) {
                timeText.text = "Game Over";
                return;
            }
            cowntDown = 16;
        }
    }

    public void setGoRun() {
        goRun = false;
    }

    public Boolean getGoRun() {
        // Debug.Log(goRun);
        return goRun;
    }

    public void setGameOver() {
        gameOver = true;
    }

    public float getCountDown() {
        return cowntDown;
    }


}
