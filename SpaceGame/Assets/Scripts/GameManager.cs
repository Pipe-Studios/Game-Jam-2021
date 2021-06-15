using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KeyTypes currentKey;
    public GameObject[] connectedPlanets;
    public GameObject[] planets;
    public GameObject lastConnectedPlanet;
    public GameObject antenna;
    public GameObject linePrefab;
    public GameObject player;
    public bool allPlanets;
    bool hasDrawn;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        planets = GameObject.FindGameObjectsWithTag("Planet").Where(e => e.GetComponent<Planet>().name != "Antenna").ToArray();
    }

    void Update()
    {
        connectedPlanets = GameObject.FindGameObjectsWithTag("Planet").Where(e => e.GetComponent<Planet>().isConnected == true).ToArray();
        if (connectedPlanets.Length == planets.Length)
        {
            allPlanets = true;
            player.GetComponent<Player>().currentKey = KeyTypes.ANTENNA;

        }
        //lastConnectedPlanet = connectedPlanets[connectedPlanets.Length - 1];
        //LineRenderer line = connectedPlanets[0].GetComponent<LineRenderer>();
        //line.positionCount = 0;
        //for (int i = 0; i < connectedPlanets.Length - 1; i++)
        //{
        //    line.positionCount++;

        //    line.startWidth = 0.2f;
        //    line.endWidth = 0.2f;
        //    line.SetPosition(i, connectedPlanets[i].transform.position);
        //    line.useWorldSpace = true;
        //}

        //for (int j = 0; j < lines.Length - 1; j++)
        //{
        //    Debug.Log(j);
        //    lines[j].startWidth = 0.2f;
        //    lines[j].endWidth = 0.2f;

        //    lines[j].SetPosition(j, connectedPlanets[j].transform.position);
        //    lines[j].SetPosition(j + 1, connectedPlanets[j + 1].transform.position);

        //    lines[j].useWorldSpace = true;
        //}
    }

    public void SpawnRope(GameObject ropePrefab, Transform startPoint, Transform endPoint)
    {
        GameObject rope = Instantiate(ropePrefab, startPoint);

        rope.name = $"Cable between {startPoint.name} & {endPoint.name}";

        if (GameObject.Find(rope.name) != null)
        {
            rope.GetComponent<Rope2D>().startPoint = startPoint;
            rope.GetComponent<Rope2D>().endPoint = endPoint;

        }

    }

    public static GameManager instance;


}
