using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{

    /*public Snake snakePrefab;

    public Color[] snakeColors;
    public static int id;
    List<Snake> snakes;

    public static Vector3 randomStartCord;
    [SyncVar]
    public float serverAngle;

    public float angle;

    [Command]
    void CmdAngle()
    {
        angle = Random.Range(-90f, 90f);
        serverAngle = angle;
        RpcAngle();
    }

    [ClientRpc]
    void RpcAngle()
    {
        serverAngle = angle;
    }

    void Start()
    {
        id = Random.Range(0, 10000);
        snakes = new List<Snake>();
        randomStartCord = transform.position;
        CmdAngle();
        AddSnake(id, randomStartCord, serverAngle);
        for (int i = 0; i < snakes.Count; i++)
        {
           // snakes[i].StartSnake();
        }
    }


    void AddSnake(int snakeID, Vector3 headPosition, float headAngle)
    {
        Snake snake = Instantiate(snakePrefab, Vector3.zero, Quaternion.identity) as Snake;
        snake.headAngle = headAngle;
        snake.headPosition = headPosition;
        snake.snakeID = snakeID;
        

        snakes.Add(snake);
    }
    */
}