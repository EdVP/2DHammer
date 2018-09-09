using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManger : MonoBehaviour {


    public static GameManger instance = null;

    [Header("Player Pick UI")]

    public GameObject spawnPlayerButton;

    public Transform[] playerSpawn;

    private void Awake()
    {
        instance = this;
    }


    public void OnPlayerCreatedButtonClicked()
    {
        spawnPlayerButton.SetActive(false);
        PhotonNetwork.Instantiate("Player", playerSpawn[Random.Range(0, playerSpawn.Length)].position, Quaternion.identity, 0);
    }
}
