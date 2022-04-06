using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class humanController : MonoBehaviour
{
    [SerializeField] GameManager manager;
    public GameObject human;
    private GameObject[] movePointArray;
    public aiMove aiMove;
    // Start is called before the first frame update
    void Start()
    {
        aiMove = human.GetComponent<aiMove>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        movePointArray = GameObject.FindGameObjectsWithTag("movePoint");
    }

    // Update is called once per frame
    void Update()
    {
        humanBalance();
    }

    public void humanBalance()
    {
        
        if (aiMove.human.Length < manager.Population)
        {
            for (int i = aiMove.human.Length; i < manager.Population; i++)
            {
                Instantiate(human,GameObject.Find("game canvas").transform);
            }
        }
        else if(aiMove.human.Length > manager.Population)
        {
            for (int i = manager.Population; i < aiMove.human.Length; i++)
            {
                aiMove.human[i].GetComponent<Image>().color = Color.red;
                aiMove.human[i].transform.position = aiMove.movePoints[0].transform.position;
                aiMove.human[i].GetComponent<aiMove>().enabled = false;
                Destroy(aiMove.human[i],5);
            }
        }
        else
        {
            
        }
    }
}
