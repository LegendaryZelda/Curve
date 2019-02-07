using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour {

    /*System.Random rg;
    public float speed = 1.3f;
    public float rotationSpeed = 200f;
    public float angularSpeed;
    float horizontal = 0f;

    public float lineTime;
    public float breakTime;

    //Die Curve hat ein Kopf-Objekt und einen Collider (Movement, Visualisierung/Collision)
    public Transform headTransform;
    public Transform headColliderTransform;

    //Die Sphere ganz knapp über Graphics, um als Ursprung für den Kollisionsradius zu dienen, damit der Touch gefixt wird
    //public Transform headConMon;

    //Referenz für das SnakeTail-Prefab
    public Line snakeTailPrefab;

    //Die Ausrichtung der Curve und die momentane Position
    public float headAngle;
    public Vector3 headPosition;

    //Die Linien der Curve werden in einer Liste gespeichert
    List<Line> snakeTails;


    //Der Countdowntimer der runtergezählt wird, bevor die neue Runde startet
    public float specialTimer = 3f;

    //Ein Boolean, der angibt, ob die Linien gezeichnet werden oder nicht für die Lücken
    bool tailActive = true;



    //Die Zustände, ob das Spiel vorbei oder bereit ist
    bool gameOver = false;
    bool isReady = false;

    Collider2D colliders;

    void Awake()
    {

        rg = new System.Random();
        snakeTails = new List<Line>();

        AddTail();

        //Startet die Funktionsroutine TailDrawer, die die Gaps in den Linien erzeugt
        StartCoroutine(TailDrawer());

    }

    void AddTail()
    {
        Line tail = NewMethod();

        snakeTails.Add(tail);
    }

    private Line NewMethod()
    {

        return Instantiate(snakeTailPrefab, Vector3.zero, Quaternion.identity) as Line;

    }

    IEnumerator TailDrawer()
    {
        while (!gameOver)
        {
            float randomLineTime = (float)rg.NextDouble();
            yield return new WaitForSeconds(1);

            tailActive = false;

            //float randomBreakTime = (float)rg.NextDouble() * (breakTime * 0.5f) - (breakTime * 0.5f);
            //yield return new WaitForSeconds(breakTime + randomBreakTime);
            yield return new WaitForSeconds(1);

            AddTail();

            tailActive = true;
        }
    }

    // Use this for initialization
    void FixedUpdate()
    {
        headAngle += angularSpeed;

        headPosition.x += speed * Mathf.Cos(headAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;
        headPosition.y += speed * Mathf.Sin(headAngle * Mathf.PI / 180f) * Time.fixedDeltaTime;

        if (tailActive)
        {
            GetCurrentSnakeTail().UpdateTail(headPosition);
        }
    }

    Line GetCurrentSnakeTail()
    {
        return snakeTails[snakeTails.Count - 1];
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //speed = 0;
        Debug.Log("Tot.");
    }
    */
}
