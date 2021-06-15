using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactRope : MonoBehaviour
{
    public SpaceBoganInteraction spaceBoganInteraction;
    public PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "PlayerRope")
        {
            Debug.Log("Rope contacted");
            playerMovement.ropeContact = true;
        }
    }
}
