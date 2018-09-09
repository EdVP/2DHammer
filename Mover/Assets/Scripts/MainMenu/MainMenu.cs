using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviourPunCallbacks

{
    public Text connectionStatus;

    [Header("Login UI")]
    public InputField playerNameInput;

    public GameObject loginPanel;

    [Header("Room Selection UI")]

    public GameObject joinRoomPanel;

    [Header("In Room UI")]

    public GameObject inRoomPanel;

    public GameObject startGameButton;

    public Dictionary<int, Photon.Realtime.Player> playersInRoom;

    public Text playerListTxt;


    private void Awake()
    {
        
        playerNameInput.text = "player" + Random.Range(0, 1000);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    //Connection Funcitons//////
    #region Connection_Funcitons

    public void OnLoginButtonClicked() //Gets called when we click on the login button:
    {

        string playerName = playerNameInput.text;

        if (!playerName.Equals(""))
        {
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.LogError("Player Name is invalid.");
        }
    }

    public void OnRandomRoomButtonClicked() //Gets called when we click the join room button:
    {

        PhotonNetwork.JoinRandomRoom(); //Join a random room;
    }


    public void OnLeaveRoomButtonClicked() //Gets called when we click the leave room button:
    {
 
        PhotonNetwork.LeaveRoom();  //Will leave the current room:


    }

    public void OnStartGameBottonClicked() //Gets called when we click the start game button as the host:
    {
        PhotonNetwork.CurrentRoom.IsOpen = true;
        PhotonNetwork.CurrentRoom.IsVisible = true;


        PhotonNetwork.LoadLevel("Level1");
    }
    #endregion


    //////CallBack////////
    #region Network_CallBack_Functions

    public override void OnConnectedToMaster() //Will get called once connect to the maser server:
    {
        loginPanel.SetActive(false); //Once connected to master server then we will set the ui to login to false;

        connectionStatus.text = "ConnectedToMaster"; //Update the conneciton status;

        joinRoomPanel.SetActive(true); //Set the join room option pannel to true so we can now pick a room to join;
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Will get called if we failed to connect ot a room because there was no rooms aviablie:
    {
        string roomName = "Room: " + Random.Range(0, 1000); //Create a room name with random number:

        RoomOptions options = new RoomOptions { MaxPlayers = 8 }; //Set the max room size to 8;

        PhotonNetwork.CreateRoom(roomName, options, null); //Create the room with the name and options we set:

    }

    public override void OnJoinedRoom() //Called when we have joined a room sucessfuly
    {
        joinRoomPanel.SetActive(false);
        inRoomPanel.SetActive(true);
        UpdatePlayerList();

        if(!PhotonNetwork.IsMasterClient)
        {
            startGameButton.SetActive(false);
            connectionStatus.text = "Joined Room: " + PhotonNetwork.CurrentRoom.GetPlayer(PhotonNetwork.CurrentRoom.masterClientId).NickName;
        }
        else
        {
            startGameButton.SetActive(true);
            connectionStatus.text = "Hosting Current Room";
        }
        
    }

    private void OnPlayerConnected(NetworkPlayer player)
    {
       
    }

    public override void OnLeftRoom()
    {
        inRoomPanel.SetActive(false);
        connectionStatus.text = "Left Room";

    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            startGameButton.SetActive(true);
            connectionStatus.text = "Hosting Current Room";
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
      
            UpdatePlayerList();
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       
            UpdatePlayerList();
        
    }


    #endregion


    public void UpdatePlayerList()
    {
       playersInRoom = PhotonNetwork.CurrentRoom.Players;

        playerListTxt.text = "Player: " + "\n";

        foreach (KeyValuePair<int, Photon.Realtime.Player> kvp in playersInRoom)
        {
            playerListTxt.text += "\n" + kvp.Value.NickName + "\n";

        }



    }


}
