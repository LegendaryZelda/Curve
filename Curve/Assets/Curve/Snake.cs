using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Snake : NetworkBehaviour
{
    public Transform headTransform;
    public Transform headColliderTransform;
    public SnakeTail snakeTailPrefab;

    [SyncVar]
    public float speed;
    [SyncVar]
    public float angularSpeed;
    [SyncVar]
    public float width;
    [SyncVar]
    public float lineTime;
    [SyncVar]
    public float breakTime;
    [SyncVar]
    public float globalTimer;
    [SyncVar]
    public float headAngle;
    [SyncVar]
    public Vector3 headPosition;

    List<SnakeTail> snakeTails;
    public int snakeID;
    public Color color;
    bool tailActive = true;
    bool gameOver = false;
    bool isReady = false;
    public int snakeCounter;
    public int thinCounter = 0;
    public Collider2D colliders;

    void Start()
    {
        headPosition = transform.position;
        AddTail();
        if(isLocalPlayer)
            CmdGaps();
        isReady = true;
    }

    void Awake()
    {
        snakeID = Random.Range(0, 1000);
        snakeTails = new List<SnakeTail>();  
    }

    void AddTail()
    {
        SnakeTail tail = Instantiate(snakeTailPrefab, Vector3.zero, Quaternion.identity) as SnakeTail;
        tail.SetColor(color);
        tail.SetWidth(width);
        snakeTails.Add(tail);
        snakeCounter++;
    }

    [Command]
    void CmdGaps()
    {
        lineTime = 2f;
        breakTime = 0.25f;
        globalTimer = 3f;
        StartCoroutine(TailDrawer());
    }

    IEnumerator TailDrawer()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(lineTime);
            tailActive = false;
            RpcOff();
            yield return new WaitForSeconds(breakTime);
            AddTail();
            RpcOn();
            tailActive = true;
        }
    }

    [ClientRpc]
    void RpcOff()
    {
        tailActive = false;
    }

    [ClientRpc]
    void RpcOn()
    {
        AddTail();
        tailActive = true;
    }

    void FixedUpdate()
    {
        if (gameOver || !isReady)
        {
            return;
        }

        if (isLocalPlayer)
        {            
            headAngle += angularSpeed * GetSteerDirection();
            headPosition.x += speed * Mathf.Cos(headAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;
            headPosition.y += speed * Mathf.Sin(headAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;
            CmdServer();
        }
    }

    [Command]
    void CmdServer()
    {
        if (tailActive && !gameOver)
        {
            GetCurrentSnakeTail().UpdateTail(headTransform.position);
            RpcClients();
        }
    }

    [ClientRpc]
    void RpcClients()
    {
            GetCurrentSnakeTail().UpdateTail(headTransform.position);
    }

    void Update()
    {
        if (gameOver || !isReady)
        {
            return;
        }

        if (isLocalPlayer == true)
        {
            headTransform.position = headPosition;
            headTransform.localRotation = Quaternion.Euler(0, 0, headAngle);
        }     

        colliders = Physics2D.OverlapCircle(headColliderTransform.position, width * 0.4f);
        if (isLocalPlayer)
            CmdColliders();
    }

    [Command]
    void CmdColliders()
    {
        OnTriggerEnter2D(colliders);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("speed"))
            {
                StartCoroutine(EnableSpeedBonus());
                Destroy(collision.gameObject);
            }

            if (collision.CompareTag("thin"))
            {
                StartCoroutine(EnableThinBonus());
                RpcThin();
                Destroy(collision.gameObject);
            }

            if (collision.CompareTag("eraser"))
            {
                for (int i = 0; i < snakeTails.Count; i++)
                {
                    GameObject.Destroy(snakeTails[i].gameObject);
                }

                snakeTails.Clear();
                Destroy(collision.gameObject);
                AddTail();
                RpcEraser();
            }

            if (collision.CompareTag("death"))
            {
                //speed = 0;
                //angularSpeed = 0;
                //gameOver = true;
            }
        }
    }

    [ClientRpc]
    void RpcEraser()
    {
        for (int i = 0; i < snakeTails.Count; i++)
        {
            GameObject.Destroy(snakeTails[i].gameObject);
        }

        snakeTails.Clear();
        AddTail();
    }

    [ClientRpc]
    void RpcThin()
    {
        StartCoroutine(EnableThinBonus());
    }

    IEnumerator EnableThinBonus()
    {
        if(thinCounter <= 4)
        {
            width = width / 1.5f;
            thinCounter++;
            AddTail();
            yield return new WaitForSeconds(15);
            width = width * 1.5f;
            thinCounter--;
            AddTail();
        }
    }

    IEnumerator EnableSpeedBonus()
    {
        speed = speed * 2f;
        angularSpeed = angularSpeed * 2f;
        breakTime /= 2;
        yield return new WaitForSeconds(globalTimer);
        speed /= 2f;
        angularSpeed /=2f;
        breakTime = breakTime * 2;
    }

    void GameOver()
    {
        gameOver = true;

        for (int i = 0; i < snakeTails.Count; i++)
        {
            GameObject.Destroy(snakeTails[i].gameObject);
        }

        snakeTails.Clear();
        GameObject.Destroy(headTransform.gameObject);
    }

    float GetSteerDirection()
    {
        if (!isLocalPlayer)
        {
            return 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return 1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return -1f;
        }
        else
        {
            return 0;
        }
    }

    SnakeTail GetCurrentSnakeTail()
    {
        return snakeTails[snakeTails.Count - 1];
    }
}