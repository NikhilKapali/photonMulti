using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby; //singleton -> a single instance

    public GameObject startButton;
    public GameObject cancelButton;
    

    private void Awake() {
        lobby = this; //Creates the singleton, lives within the Main menu scene
    }

    // Start is called before the first frame update
    void Start()
    {

        PhotonNetwork.PhotonServerSettings.AppSettings.UseNameServer = false;
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = "192.168.1.221";
        PhotonNetwork.PhotonServerSettings.AppSettings.Port = 5055;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = null;
        PhotonNetwork.ConnectUsingSettings();


        // PhotonNetwork.ConnectToMaster("192.168.1.221", 5055, "91bed5cc-3fe6-4a3e-95b3-ec47626a6506");
        // PhotonNetwork.ConnectUsingSettings(); //Connects to master photon sever.
        // startButton.SetActive(false);

    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to the Server");
        PhotonNetwork.AutomaticallySyncScene = true;
        startButton.SetActive(true); //user connected to server. user can join the room
    }

    public void OnStartButtonClicked(){
        Debug.Log("Start Button was clicked");
        PhotonNetwork.JoinRandomRoom(); //Join a random room in the server

        startButton.SetActive(false);
        cancelButton.SetActive(true);

    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Random Room join failed");
        CreateRoom();
    }

    public void CreateRoom(){
        Debug.Log("Trying to Create a Room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions(){IsVisible = true, IsOpen= true, MaxPlayers = 6};

        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message){ //
        Debug.Log("Room creation failed. Room with the same name may exist");
        CreateRoom();
    }

    public void OnCancelButtonClicked(){
        Debug.Log("Canceled to connect to room");
        cancelButton.SetActive(false);
        startButton.SetActive(true);

        PhotonNetwork.LeaveRoom();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
