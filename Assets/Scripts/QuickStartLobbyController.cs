using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Unity.VisualScripting;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject StartButton;
    private int RoomSize;

    void Awake()
    {
        StartButton.onClick.AddListener(ClickStart); //makes the function ClickStart happen when StartButton is clicked.

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        StartButton.SetActive(true);

    }

    public void ClickStart()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick start")



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
