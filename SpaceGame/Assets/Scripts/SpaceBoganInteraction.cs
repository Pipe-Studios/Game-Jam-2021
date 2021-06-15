using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBoganInteraction : MonoBehaviour
{
    public bool ropeContact = false;
    public GameObject playerRope;
    public SpringJoint2D spring;
    public PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if (playerRope && playerRope.tag == "PlayerRope")
        {
            if (playerMovement.ropeContact)
            {
                CutRope();
            }
        }
    }

    void CutRope()
    {
        // // make two new ropes
        // GameObject bjPlayerRope = Instantiate(playerRope);
        // bjPlayerRope.GetComponent<Rope2D>().endPoint.position = transform.position;

        // GameObject ropeBoganBJ = Instantiate(playerRope);
        // ropeBoganBJ.GetComponent<Rope2D>().startPoint.position = transform.position;

        Destroy(playerRope);
        Destroy(spring);
    }
}
