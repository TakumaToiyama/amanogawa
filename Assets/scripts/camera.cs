using UnityEngine;
using UnityEngine.UIElements.Experimental;

    public enum cameraStatus{
        idle,
        strategy,
        play

    }
public class camera : MonoBehaviour
{
    cameraStatus currentStatus;
    public boat boat;
    float cameraSpeed = 0;


    void Start()
    {
        changeStatus(cameraStatus.idle);
    }

    void Update()
    {
        switch(currentStatus) {
            case cameraStatus.strategy:
                break;
            case cameraStatus.play:
                cameraMoving();
                break;
        }
    }
    public void changeStatus(cameraStatus newStatus) {
        if (currentStatus == newStatus) return;
        
        exitState(currentStatus);
        currentStatus = newStatus;
        enterState(currentStatus);
    }

    void enterState(cameraStatus state) {
        switch(state) {
            case cameraStatus.strategy :
                strategyPosition();
                break;
            case cameraStatus.play :
                homePosition();
                break;
        }
    }

    void exitState(cameraStatus state) {
        switch(state) {
            case cameraStatus.strategy:
                break;
        }
    }

    public void cameraMoving() {
        getSpeed();
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime * 60;
    }

    public void strategyPosition() {
        Camera.main.orthographicSize = 50f;
        Camera.main.transform.position = new Vector3(0,0,-12);
    }
    public void homePosition() {
        Camera.main.orthographicSize = 12f;
        Camera.main.transform.position = new Vector3(boat.GetPositioX(),0,-12);
        changeStatus(cameraStatus.play);
    }

    public void getSpeed(){
        cameraSpeed = boat.getSpeed(); 
    }

    public void getBoatPosition() {

    }
}