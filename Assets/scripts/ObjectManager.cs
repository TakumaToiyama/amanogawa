using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject starObject;
    private List<GameObject> starClones = new List<GameObject>();
    public LaneManager laneManager;
    public boat boatObject;
    Boolean[] touchTrue;
    public int numOfSaftyArea;
    public int difficulty;

    void Start()
    {
        touchTrue = new bool[numOfSaftyArea * difficulty];
        for (int i = 0; i < touchTrue.Length; i++) {
            GameObject star = Instantiate(starObject);
            star.SetActive(false);
            starClones.Add(star);
        }
        randomPosition();
    }
    

    // Update is called once per frame
    void Update()
    {
        isCrash();
    }

    // set the object except safty area
        public void randomPosition() {
            
            Lane[] saftyArea = laneManager.maekSaftyArea(numOfSaftyArea,difficulty);

            for (int i = 0; i < saftyArea.Length; i++) {
                // Debug.Log(i + " x: " + saftyArea[i].GetPositionX() + " y: " + saftyArea[i].GetPositionY());
            }

            int countObject = 0;
            for (float x = -50; x < 50; x+=(100/numOfSaftyArea)) {
                for (float y = -7.5f; y <= 7.6; y+=5) {
                    for (int safAreaNum = countObject; safAreaNum < (numOfSaftyArea * difficulty); safAreaNum++) {
                        if (saftyArea[safAreaNum].GetPositionX() == x) {
                            // Debug.Log(x);
                            if (saftyArea[safAreaNum].GetPositionY() == y) {
                                // Debug.Log("X: " + saftyArea[safAreaNum].GetPositionX() + " Y: "+ y);
                                touchTrue[countObject] = true;
                                starClones[countObject].transform.position = new Vector2(x,y);
                                starClones[countObject].SetActive(true);
                                countObject++;
                            }
                        }
                    }
                }
            }
    }

     public Boolean isCrash() {
        
        float nowX = boatObject.GetPositioX();
        float nowY = boatObject.GetPositioY();

        for (int i = 0; i < touchTrue.Length; i++) {

            float CloneX = starClones[i].transform.position.x;
            float CloneY = starClones[i].transform.position.y;

            if (CloneX -1 < nowX && nowX < CloneX +1 && CloneY == nowY && touchTrue[i]) {
                Debug.Log("crash");
                boatObject.crash();
                touchTrue[i] = false;
                return true;
            }
        }
        return false;
    }

}
