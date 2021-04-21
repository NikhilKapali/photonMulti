using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    public static GameSetup gs;

    // public Text healthDisplay;

    public Transform[] spawnPoints;
    

    private void OnEnable(){
        if(GameSetup.gs == null){
            GameSetup.gs = this;
        }
    }

    // public void DisconnectPlayer(){
    //     StartCoroutine(DisconnectAndLoad());
    // }
    // IEnumerator DisconnectAndLoad(){
    //     PhotonNetwork.Disconnect();
    //     while(PhotonNetwork.IsConnected)
    //         yield return null;
    //     SceneManager.LoadScene(MultiplayerSetting.multiplayerSetting.menuScene);
    // }
}
