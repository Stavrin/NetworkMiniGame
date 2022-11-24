using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using Unity.VisualScripting;
using Unity.UI;
using UnityEngine.UI;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    
    [SerializeField]
    private GameObject quickStartButton; //button used for creating and joining a game.
    [SerializeField]
    private Button StartButton;
    [SerializeField]
    private Button CancelButton; //button used to stop searing for a game to join.
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int RoomSize;
    private bool start;

    void Awake()
    {
        StartButton.onClick.AddListener(ClickStart); //makes the function ClickStart happen when StartButton is clicked.
        CancelButton.onClick.AddListener(QuickCancel); //makes the function QuickCancel happen when StartButton is clicked.

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        //StartButton.SetActive(true);

    }

    public void ClickStart()
    {


        //start = !start; 
        
        //if (start)
        //{
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Quick start");
       // }

       // else QuickCancel();



    }
    public override void OnJoinRandomFailed(short returnCode, string message) //Callback function for if we fail to join a rooom
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }
    void CreateRoom() //trying to create our own room
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000); //creating a random name for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); //attempting to create a new room
        Debug.Log(randomRoomNumber);
    }
    public override void OnCreateRoomFailed(short returnCode, string message) //callback function for if we fail to create a room. Most likely fail because room name was taken.
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom(); //Retrying to create a new room with a different name.
    }
    public void QuickCancel() //Paired to the cancel button. Used to stop looking for a room to join.
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}//class
