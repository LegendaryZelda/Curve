using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class lol : NetworkBehaviour {

    [SyncVar]
    public GameObject test;

    [SyncVar]
    public Vector3 vector;

    [SyncVar]
    GameObject instantiated;

    // Use this for initialization
    void Start () {
        
        instantiated = Instantiate(test);
        NetworkServer.Spawn(instantiated);
        vector = transform.position;
        CmdPosition();
        

    }
	
    [Command] 
    void CmdPosition()
    {
       
        //test.transform.position = vector;
        instantiated.transform.position = vector;
        RpcPosition();
    }

    [ClientRpc]
    void RpcPosition()
    {
        //test.transform.position = vector;
        instantiated.transform.position = vector;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
