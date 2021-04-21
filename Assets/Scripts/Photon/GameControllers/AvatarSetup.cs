using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class AvatarSetup : MonoBehaviour
{

    private PhotonView view;

    public int PlayerHealth;
    public int PlayerDamage;

    public int characterValue;
    public GameObject myCharacter;

    public Camera myCamera;
    public AudioListener myAl;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();

        if(view.IsMine){
            view.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
        }
        else{
            Destroy(myCamera);
            Destroy(myAl);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter){
        characterValue = whichCharacter;  
        myCharacter = Instantiate(PlayerInfo.PI.allCharacters[whichCharacter], transform.position, transform.rotation,
        transform );
         
    }
}
