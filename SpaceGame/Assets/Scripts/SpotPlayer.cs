using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{    
    public SpaceBoganMovement spaceBoganMovement;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player spotted");
            spaceBoganMovement.playerSpotted = true;
        }
    }
}