using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoints : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] private LineController line;

    public Game_Manager gameM;
    public GameObject enemyTarget;

    private void Start()
    {
        line.SetUpLine(points);
    }

    private void Update()
    {
        points[0] = gameM.Current_Char.transform;
        points[1] = enemyTarget.transform;
    }
}
