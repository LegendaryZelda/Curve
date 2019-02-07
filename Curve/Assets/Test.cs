using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : NetworkBehaviour {

    [SyncVar]
    public GameObject test;
    [SyncVar]
    public Transform spawn;

	// Use this for initialization
	void Start () {
        ConnectionConfig myConfig = new ConnectionConfig();
        myConfig.AddChannel(QosType.Reliable);
        //spawn.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-4.5f, 3f), Random.Range(-5f, 5f));
        //test.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-4.5f, 3f), Random.Range(-5f, 5f));
    }
	
	// Update is called once per frame
	void Update () {

        //CmdSpawn();
    }

}
