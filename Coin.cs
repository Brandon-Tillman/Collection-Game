using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Keeps track of total coin count in scene
    public static int CoinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Incrementing coin count
        ++Coin.CoinCount;
    }

    void OnDestroy()
    {
        --Coin.CoinCount;

        if (Coin.CoinCount <= 0)
        {
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);
            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            if (FireworkSystems.Length <= 0) 
            {
                return;
            }
            foreach(GameObject GO in FireworkSystems)
            {
                GO.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    void OnTriggerEnter(Collider Col)
    {
        //If the player collect the coin then destroy the object
        if (Col.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
