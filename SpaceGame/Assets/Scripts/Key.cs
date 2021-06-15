using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour
{
    private KeyTypes Type;
    public Sprite keySprite;
    Player player;
    public Key()
    {
        
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Planet"))
        {
            GameObject planet = other;
            Debug.Log(planet.GetComponent<Planet>().keyRequired + "-" + player.currentKey);
            if (planet.GetComponent<Planet>().keyRequired == player.currentKey)
            {
                planet.GetComponent<Planet>().isConnected = true;
                PlanetController.lastConnectedObject = planet.transform;
                if (player.currentKey == KeyTypes.ANTENNA) SceneManagement.PlayGame();
                planet.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keySprite;

                player.currentKey = KeyTypes.NONE;
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else if (other.CompareTag("Wunnings"))
        {
            keySprite = other.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprite;
            player.currentKey = other.GetComponent<SpaceBunnings>().keyToGive;
        }
        else
        {
            return;
        }
    }

    public bool IsSameType(KeyTypes otherKey)
    {
        return this.Type == otherKey;
    }
}

public enum KeyTypes
{
    NONE,
    CROSS,
    CIRCLE,
    SQUARE,
    ANTENNA
}

