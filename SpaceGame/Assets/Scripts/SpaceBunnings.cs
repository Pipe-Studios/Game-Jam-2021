using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBunnings : MonoBehaviour
{
    public KeyTypes keyToGive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"COLLIDED WITH {collision.gameObject.name}");
        //GameObject other = collision.gameObject;

        //if (other.CompareTag("Mechanic"))
        //{
        //    GameManager.instance.currentKey = keyToGive;
        //    Debug.Log($"COLLECTED KEY {keyToGive}");
        //    //other.transform.Find("Key").GetComponent<SpriteRenderer>().enabled = true;
        //    //other.GetComponentInChildren<SpriteRenderer>().enabled = true;
        //} else
        //{
        //    Debug.Log("NO COLLISION");
        //}
    }
}
