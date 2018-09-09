using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviour {

    public GameObject barrel;
    public float speed;
    public GameObject bulletPrefab;

    private PhotonView photonView;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }



    private void Update()
    {
        if (!photonView.IsMine) return;
        

        if(Input.GetMouseButtonDown(0))
        {

            photonView.RPC("Fire1", RpcTarget.AllViaServer, barrel.transform.position, barrel.transform.rotation);

        }
    }

    [PunRPC]
    public void Fire1(Vector3 p, Quaternion r, PhotonMessageInfo info)
    {

        float lag = (float)(PhotonNetwork.Time - info.timestamp);
        GameObject bullet;

        /** Use this if you want to fire one bullet at a time **/
        bullet = Instantiate(bulletPrefab, p, r) as GameObject;
        bullet.GetComponent<BulletBehaviour>().SpawnBullet(photonView.Owner, (r * Vector3.right), Mathf.Abs(lag));
    }

}
