using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map : NetworkBehaviour {

    [SyncVar]
    public GameObject speed, eraser;
    GameObject speed_instantiated, eraser_instantiated;
    [SyncVar]
    public Vector3 position1;
    [SyncVar]
    public Vector3 position2;

    void Start()
    {
        StartCoroutine(SpawnSpeed());
        StartCoroutine(SpawnEraser());
    }

    private IEnumerator SpawnSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            position1 = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            speed_instantiated = (GameObject)Instantiate(speed, position1, this.transform.rotation);
            NetworkServer.Spawn(speed_instantiated);
        }
    }

    private IEnumerator SpawnEraser()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            position2 = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            eraser_instantiated = (GameObject)Instantiate(eraser, position2, this.transform.rotation);
            NetworkServer.Spawn(eraser_instantiated);
        }
    }
}
