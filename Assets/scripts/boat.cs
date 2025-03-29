using System;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{

    public GameObject boatPrefab;
    private GameObject currentBoat;
    float speed = 0.2f;
    public camera cameraObj;
    private Vector3 currentPosition;

    public ObjectManager objectManager;


    void Start()
    {
        currentBoat = Instantiate(boatPrefab, new Vector3(-79, (float)-2.5, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        currentBoat.transform.position += Vector3.right * speed * Time.deltaTime * 60;

        // change speed when touch the wall
        if (currentBoat.transform.position.x >= 79) {
            speed = -speed;
            objectManager.randomPosition();
            objectManager.addCountTouch();

        } else if (currentBoat.transform.position.x <= -79) {
            speed = -speed;
            objectManager.randomPosition();
            objectManager.addCountTouch();
        }
   
        // cahnge the lane
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentBoat.transform.position.y < 7.5f) {
            currentBoat.transform.Translate(Vector3.up * 5);

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentBoat.transform.position.y > -7.5f) {
            currentBoat.transform.Translate(Vector3.down * 5);
        }

        currentPosition = currentBoat.transform.position;
        
    }//end of main

    public float getSpeed() {
        return speed;
    }
    public float GetPositioX() {
        return currentPosition.x;
    }
     public float GetPositioY() {
        return currentPosition.y;
    }
}