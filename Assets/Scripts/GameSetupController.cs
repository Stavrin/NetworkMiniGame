using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;
public class GameSetupController : MonoBehaviour
{
    [SerializeField]
    private GameObject SpawnPoint;
    public int ID = null;

    // This script will be added to any multiplayer scene
    void Start()
    {
        ID = Random.Range(1, 5)
        CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
    }
    private void CreatePlayer(int ID)
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer" + ID), SpawnPoint.transform.position, Quaternion.identity);
    }
}