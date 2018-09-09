using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{


    Camera cam;
    public float speed;
    public float lerpSpeed;


    private void Start()
    {
        cam = Camera.main;
        InputManager.Forward += ForwardMover;
        InputManager.Backward += BackWardMover;
        InputManager.Left += LeftMover;
        InputManager.Right += RightMover;
        InputManager.Boost += BoostOn;
        InputManager.BoostOff += BoostOff;
    }


 
       void ForwardMover()
    {
        //Vector3 direction = cam.transform.forward;//  use this if u want the y axis to change with direciton like a ghost flying

        Vector3 direction = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);

        transform.position += direction * speed * Time.deltaTime;
    }

    void BackWardMover()
    {
       //  Vector3 direction = cam.transform.forward; //use this if u want the y axis to change with direciton like a ghost flying

        Vector3 direction = new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z);

        transform.position += -direction * speed * Time.deltaTime;
    }

    void LeftMover()
    {
         Vector3 direction = cam.transform.right; //use this if u want the y axis to change with direciton like a ghost flying

       

       transform.position += -direction * speed * Time.deltaTime;
    }

    void RightMover()
    {
        Vector3 direction = cam.transform.right; //use this if u want the y axis to change with direciton like a ghost flying

       

        Vector3 newpos = direction * speed + transform.position;

        transform.position = Vector3.Lerp(transform.position, newpos, lerpSpeed);

        

    }

    void BoostOn()
    {
        speed = 5;
    }

    void BoostOff()
    {
        speed = 1;
    }







}
