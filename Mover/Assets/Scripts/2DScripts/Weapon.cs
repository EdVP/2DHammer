using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject barrel;
    public GameObject bullet;
    public float speed;



    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Debug.Log("Fire");

        }
    }
}
