using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/* Documentation: https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro
Scripting API: https://doc-api.photonengine.com/en/pun/v2/index.html
*/

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are connected to the " + PhotonNetwork.CloudRegion + " server!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
