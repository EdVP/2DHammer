using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CameraFollow : MonoBehaviour {


    public GameObject follower;

    public Vector3 cameraOffset;

    public PhotonView photonV;


    private void LateUpdate()
    {
        if (!photonV.IsMine) return;


        if(follower != null)
        {
            Vector3 newPos = (follower.transform.position + cameraOffset);


            transform.position = newPos;
        }
  
    }
}
