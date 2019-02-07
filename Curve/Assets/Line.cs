using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Line : MonoBehaviour {

    /*LineRenderer line;
    EdgeCollider2D edgeCollider;

    //Eine Liste für die Punkte der Linie
    List<Vector2> linePoints;

    //--------------------------------- Funktionen -------------------------------------------------------

    //In der Awake-Funktion werden LineRenderer & EdgeCollider aufgesetzt und die linePoints-Liste initialisiert
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(0);
        line.useWorldSpace = true;

        linePoints = new List<Vector2>();

        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    //Die UpdateTail-Funktion fügt neue Punkte in die linePoint-Liste hinzu und gleichzeitig beim LineRenderer & EdgeCollider
    public void UpdateTail(Vector2 position)
    {
        //Fügt Punkte in die linePoint-Liste ein
        linePoints.Add(position);

        //Fügt die Positionskoordinaten beim LineRenderer hinzu (orintiert sich an der linePoints-Liste) 
        line.SetVertexCount(linePoints.Count);
        line.SetPosition(linePoints.Count - 1, linePoints[linePoints.Count - 1]);

        //Fügt die Positionskoordinaten beim EdgeCollider hinzu, indem es die Punkte aus der linePoints-Liste verwendet
        if (linePoints.Count > 1)
        {
            edgeCollider.points = linePoints.ToArray();
        }
    }
    */

}
