using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet : MonoBehaviour
{
    [Range(0, 20)]
    public float rotationSpeed = 15f;
    [Range(1, 3)]
    public float sizeMultiplier = 2f;
    private Vector3 scaleChange;

    public Transform baseLayer;
    public Transform cloudLayer;
    public Transform shadowLayer;
    public bool isConnected;
    public KeyTypes keyRequired;

    public GameObject linePrefab;
    public Player player;
	
    GameObject line;
    bool hasSpawned = false;
    void Awake()
    {
        // scaleChange = new Vector3(sizeMultiplier, sizeMultiplier);
        // this.transform.localScale = scaleChange;
    }

    void LateUpdate()
    {
        RotatePlanet();

        if (PlanetController.lastConnectedObject == this.transform)
        {
            return;
        } 
        else 
        {
            if (!isConnected) 
            { 
                return; 
            } 
            else
            {
                if (!hasSpawned) 
                {
                    SpawnRope(linePrefab, this.transform.GetChild(0).GetChild(0)); hasSpawned = true; 
                }
            }

        }
    }

    public void SpawnRope(GameObject ropePrefab, Transform startPoint)
    {
        GameObject rope = Instantiate(ropePrefab, startPoint);

        rope.name = $"{startPoint.name} & {PlanetController.lastConnectedObject.name}";

        if (GameObject.Find(rope.name) != null)
        {
            rope.GetComponent<Rope2D>().startPoint = startPoint;
            rope.GetComponent<Rope2D>().endPoint = PlanetController.lastConnectedObject.GetChild(0).GetChild(0).transform;
            rope.GetComponent<PolygonCollider2D>().enabled = false;
        }

    }

    void RotatePlanet()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
}
