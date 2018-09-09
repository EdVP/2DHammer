using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMover2D : MonoBehaviour {

    [Header("Player Movement/Rotation Options")]

    public float speed;

    public float adjuster;

    public float roateSpeed = 0.25f;

    public float mouseDistanceFromPlayerToStopRotation = 10;

    [Header("Camera Options")]

    public GameObject playerCamera;

    public Camera playerCam;

    //Dynamically Set:
    private Vector3 newPos;

    private PhotonView photonView;


    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
      
        if (photonView.IsMine)
        {
            CameraSetup();
        }
      
  
    }

    private void CameraSetup() //Turns off the main camera and sets-up the player camera:
    {
        GameObject mainCamera = Camera.main.gameObject;
        mainCamera.SetActive(false);
        playerCamera.SetActive(true);
        playerCamera.transform.parent = null;
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        PlayerMovement();
     if(playerCamera.activeSelf == true)   PlayerRotate();

    }


   private void PlayerMovement()
    {
    
        newPos = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            newPos.x = 1 * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x = -1 * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newPos.y = 1 * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos.y = -1 * Time.deltaTime * speed;
        }

        transform.position = Vector3.Lerp(transform.position, newPos + transform.position, adjuster);
    }


    // Update is called once per frame
   private void PlayerRotate()
    {

        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = transform.position.z;
        Vector3 objectPos = playerCam.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        if (Vector3.Distance(transform.position, mousePos) > mouseDistanceFromPlayerToStopRotation)
        {
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), speed);
        }






    }
}
