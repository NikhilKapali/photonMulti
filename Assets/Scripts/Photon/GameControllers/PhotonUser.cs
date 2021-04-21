using System.Collections;
using System.Collections.Generic;

using System.IO;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonUser : MonoBehaviour
{
    private PhotonView view;
    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        view=GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.gs.spawnPoints.Length);

        if(view.IsMine){
           myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "UserAvatar"), 
                    GameSetup.gs.spawnPoints[spawnPicker].position, GameSetup.gs.spawnPoints[spawnPicker].rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
