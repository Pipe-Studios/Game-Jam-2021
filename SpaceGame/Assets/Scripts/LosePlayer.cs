using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePlayer : MonoBehaviour
{
    public SpaceBoganMovement spaceBoganMovement;

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Player lost");
            spaceBoganMovement.playerSpotted = false;
        }
    }
}
