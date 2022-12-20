using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // The time to complete the level
    public float MaxTime = 60f;

    [SerializeField] private float CountDown = 0;

    void Start ()
    {
        CountDown = MaxTime;
    }

    void Update ()
    {
        // Reduce time
        CountDown -= Time.deltaTime;

        //Restart level if the time runs out
        if (CountDown <= 0)
        {
            //Resets coin count
            Coin.CoinCount=0;
            UnityEngine.SceneManagement.SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }
}
