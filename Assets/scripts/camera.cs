using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class camera : MonoBehaviour
{
    public boat boat;
    float cameraSpeed = 0;

    void Start()
    {
    
    }

    void Update()
    {
        getSpeed();
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime * 60;
    }

    public void getSpeed(){
        cameraSpeed = boat.getSpeed(); 
    }
}