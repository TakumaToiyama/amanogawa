using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public Lane[] lane;

                int choice1 = 0;
                int choice2 = 0;
                int choice3 = 0;


    public Lane[] maekSaftyArea(int numOfSaftyArea,int difficulty) {
        lane = new Lane[numOfSaftyArea * difficulty];

        int countSaftyArea = 0;
        for (int i = -50; i < 50; i+=(100/numOfSaftyArea)) {

            for (int j = 0; j < difficulty; j++) {
                lane[countSaftyArea] = new Lane (i,setRondomY(countSaftyArea,difficulty));
                countSaftyArea++;
            }
        }
        // for (int i = 0; i < lane.Length; i++) {
        //     Debug.Log(i + " x: " + lane[i].GetPositionX() + " y: " + lane[i].GetPositionY());
        // }
        return lane;
    } 

    public float setRondomY(int countSaftyArea, int difficulty ) {
        // Debug.Log(numOfSaftyArea);
        float randomY = 0;
        if (countSaftyArea < difficulty) {
            // int loopCount = 0;

            Boolean same;
            do {
                same = false;
                switch (UnityEngine.Random.Range(0,4)) {
                case 1 :
                    randomY = 7.5f;
                    break;
                case 2 :
                    randomY = -2.5f;
                    break;
                case 3 :
                    randomY = 2.5f;
                    break;
                default :
                    randomY = -7.5f;
                    break;
                }

                for (int i = 0; i < countSaftyArea; i++) {
                    if (lane[i].GetPositionY() == randomY) {
                        same = true;
                    }
                }
            } while (same);
        
        } else {
            float addFive;
            Boolean same;
            int loopCount = 0;
            do {
                same = false;
                addFive = 0;

                // Get ranodm number range 0 ~ 4 and add
                
                int randomNum = UnityEngine.Random.Range(0,5);
                switch (randomNum) {
                    case 0 :
                    case 1 :
                        addFive = lane[countSaftyArea-difficulty].GetPositionY() + 5;
                        choice1++;
                        break;
                    case 2 :
                    case 3 :
                        addFive = lane[countSaftyArea-difficulty].GetPositionY() - 5;
                        choice2++;
                        break;
                    default :
                        addFive = lane[countSaftyArea-difficulty].GetPositionY();
                        choice3++;
                        break;
                }


                    loopCount++;
                    if (loopCount > 1000) { 
                        Debug.LogError("infinite loop "+ countSaftyArea);
                        break;
                    }

                    

                    if (countSaftyArea > 0 && lane[countSaftyArea-1].GetPositionY() == addFive) {
                        same = true;
                    }
            } while ((addFive > 7.5f || addFive < -7.5f)  || same);
            randomY = addFive;
        }

        return randomY;
    }
}