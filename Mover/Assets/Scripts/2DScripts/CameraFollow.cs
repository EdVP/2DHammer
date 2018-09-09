using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraFollow : MonoBehaviour {


    public GameObject follower;

    public PhotonView photonV;

    [Header("Camera Properties")]

    public Vector3 cameraOffset;

    public float maxCameraHeight = -3; //Close to object:

    public float minCameraHeight = -10; //Fare away from object:

    public float scrollWeelAdjuster = 1f; //Use this to make there be more steps when using the scroll wheel

    public float cameraLerp = 0.1f;


    private void LateUpdate()
    {
        if (!photonV.IsMine) return;


        float scrollAxis = Input.mouseScrollDelta.y * scrollWeelAdjuster; //Get the scroll weel delta:

        cameraOffset.z += scrollAxis;

        cameraOffset.z = Mathf.Clamp(cameraOffset.z, minCameraHeight, maxCameraHeight); //Clamp offset to a certain bounds:
        
        Vector3 newPos = (follower.transform.position + cameraOffset);

        transform.position = Vector3.Lerp(transform.position, newPos, cameraLerp);

       
    }
}
