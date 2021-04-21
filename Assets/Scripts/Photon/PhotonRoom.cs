using System.Collections;
using System.Collections.Generic;

using System.IO;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room info
    public static PhotonRoom room; //singleton instance
    private PhotonView view;

    // public bool isGameLoaded;
    public int currentScene;
    public int multiplayerScene;

    //Player info
    // Player[] photonUsers;
    // public int usersInRoom;
    // public int myNumberInRoom;

    // public int usersInGame;

    private void Awake() {
        //setup singleton
        if(PhotonRoom.room == null){
            PhotonRoom.room = this;
        }
        else{
            if(PhotonRoom.room != this){
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room= this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnEnable() {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    public override void OnDisable() {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        view =  GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        Debug.Log("Connected to a room");
        // photonUsers = PhotonNetwork.PlayerList;
        // usersInGame = photonUsers.Length;
        // myNumberInRoom = usersInGame;
        // PhotonNetwork.NickName = myNumberInRoom.ToString();

        StartGame();
    }

    void StartGame(){
        if(!PhotonNetwork.IsMasterClient){
            return;
        }
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode){
        currentScene =scene.buildIndex;
        if(currentScene == multiplayerScene){
            CreateUser();
        }
    }

    private void CreateUser(){
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkUser"), transform.position, Quaternion.identity, 0);
    }
}
