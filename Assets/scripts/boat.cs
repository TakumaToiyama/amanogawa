using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Build.Content;
using UnityEngine;

    public enum boatState {
        idle, // waiting start
        moving, // moving constant speed
        crash, // crash and penalty
        boost,
        waitNextRound, // waiting when countdown is 0
        gameOver // twice if countdown is 0 but boat doesnt touch wall 
    }

public class boat : MonoBehaviour
{
    public boatState currentState;
    public GameManager gameManager;
    public GameObject boatPrefab;
    private GameObject currentBoat;
    float refSpeed = 0.2f; // reference speed
    float speed;
    public camera cameraObj;
    private Vector3 currentPosition;
    public ObjectManager objectManager;
    public UIManager uIManager;
    Boolean nowCrash = false;

    void Start()
    {
        // start position
        currentBoat = Instantiate(boatPrefab, new Vector3(-79, (float)-2.5, 0), Quaternion.identity);
        changeState(boatState.idle);
        speed = refSpeed; // initialize speed

    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log("speed: " + speed + " refSpeed: " + refSpeed);
        // if (GameManager.Instance.currentState != GameState.play) return;
        switch (currentState) {
            case boatState.idle:
                idle();
                break;
            case boatState.moving:
                move();
                break;
            case boatState.crash:
                crash();
                break;
            case boatState.waitNextRound:
                readyNextRound();
                break;
            case boatState.gameOver:
                break;
        }
        gameOver();

        currentPosition = currentBoat.transform.position;

        
    }//end of main

    public void changeState(boatState newState) {
        if (currentState == newState && currentState == boatState.gameOver) return;
        Debug.Log(newState);

        exitState(newState);
        currentState = newState;
        enterState(newState);
    }

    void enterState(boatState state) {

    }

    void exitState(boatState state) {

    }

    public void idle() {
        changeState(boatState.moving);
    }

    // moving boat at a constant speed
    public void move() {
        currentBoat.transform.position += Vector3.right * speed * Time.deltaTime * 60;
        keyPress();
        isTouch();

        if (objectManager.isCrash()) {
            changeState(boatState.crash);
        }

    }

    public void isTouch() {
        if ((currentBoat.transform.position.x >= 79 && speed > 0) || (currentBoat.transform.position.x <= -79 && speed < 0)) {
            uIManager.addScore();

            objectManager.randomPosition();
            changeSpeed();
            changeState(boatState.waitNextRound);
        }
    }

    public void keyPress() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentBoat.transform.position.y < 7.5f) {
            currentBoat.transform.Translate(Vector3.up * 5);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentBoat.transform.position.y > -7.5f) {
            currentBoat.transform.Translate(Vector3.down * 5);
        }
    }

    public void crash() {
        // if boat already under crash penalty, crash penalty will doesnt work
        if (!nowCrash) {
            StartCoroutine(setSpeedCrash());
            nowCrash = true;
        }
        Debug.Log("work crash");
    }
    // change speed when boat collision stars
    private IEnumerator setSpeedCrash() {
        // crash penalty
        if (speed > 0) {
            speed = 0.03f;
        } else {
            speed = -0.03f;
        }

        // wait 3 seconds
        yield return new WaitForSeconds(3);
        nowCrash = false;
        
        // if boat touch the wall during crash penalty, speed will change default speed
        speed = refSpeed;
    }

    public void readyNextRound() {
        keyPress();
        if (speed != 0) {
            refSpeed = -refSpeed;
        }

        
        // if boat touch wall && cowntDown isnt 0, boat speed will 0
        if (uIManager.getGoRun()) {
            speed =refSpeed;
            uIManager.setGoRun();
            changeState(boatState.moving);
        } else {
            speed = 0;
        }
    }
    public Boolean gameOver() {
        if (currentPosition.x < 79 && currentPosition.x > -79 && uIManager.getGoRun()) {
            uIManager.setGameOver();
            Debug.Log("work set gameover");
            speed = 0;
            changeState(boatState.gameOver);
            return true;
        }
        return false;
    }

    public void changeSpeed() {
        if (uIManager.getScore() % 5 == 0) {
            if (refSpeed > 0) {
                refSpeed += 0.1f;
            } else {
                refSpeed -= 0.1f;
            }
        }
    }


    // helper methods

    public float getSpeed() {
        return speed;
    }
    public float GetPositioX() {
        return currentPosition.x;
    }
    public float GetPositioY() {
        return currentPosition.y;
    }

    public float getRefSpeed() {
        return refSpeed;
    }



}