using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    public Player player;

    void Update()
    {
        if (player.currentKey == KeyTypes.ANTENNA)
        {
            player.gottenAntenna = true;
        }
    }
}
