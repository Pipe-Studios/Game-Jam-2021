using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicRope : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform joinPoint;
    public Transform endPoint;

    GameObject rope;

    // Start is called before the first frame update
    void Start()
    {
        rope = Instantiate(linePrefab, joinPoint);
        rope.name = $"Mechanic's Cable";
        rope.tag = "Untagged";
        rope.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlanetController.lastConnectedObject != null)
        {
            rope.SetActive(true);
            endPoint = PlanetController.lastConnectedObject.GetChild(0).GetChild(0);

            rope.GetComponent<Rope2D>().startPoint = joinPoint;
            rope.GetComponent<Rope2D>().endPoint = endPoint;
            rope.GetComponent<PolygonCollider2D>().enabled = false;

        } else
        {
            return;
        }

    }
}
