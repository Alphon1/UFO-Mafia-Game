using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    public Game_Manager gameM;
    public GameObject enemyTarget;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        points[0] = gameM.Current_Char.transform;
        points[1] = enemyTarget.transform;

        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i].position);
        }
    }
}
