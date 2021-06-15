using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyTypes currentKey;
    public bool gottenAntenna = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gottenAntenna);
        //if (GameManager.instance.allPlanets) currentKey = KeyTypes.ANTENNA; else return;
    }
}
