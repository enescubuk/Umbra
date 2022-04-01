using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    GameManager manager;
    dayController day;
    // Start is called before the first frame update
    void Start()
    {
        day = GameObject.Find("NextDay").GetComponent<dayController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Happiness <= 0)
        {
            SceneManager.LoadScene(1);
        }
        if (manager.Population <= 0)
        {
            SceneManager.LoadScene(2);
        }
        if (day.gunSayac <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
