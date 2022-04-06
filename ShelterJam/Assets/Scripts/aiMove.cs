using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aiMove : MonoBehaviour
{
    public GameObject[] human;
    public GameObject[] movePoints;
    public bool isMove;
    private Vector3 nextPos;
    private float nextActionTime,period;
    private float speed = 75;
    private int randomArrayNumber, nextArrayNumber;
    private int counterSix = 1,counterOne = 1;
    private int location;
    


    // Start is called before the first frame update
    void Start()
    {
        randomArrayNumber = Random.Range(1,6);
        nextPos = movePoints[randomArrayNumber].transform.position;
        nextPos.x = Random.Range(movePoints[randomArrayNumber].transform.position.x -25 , movePoints[randomArrayNumber].transform.position.x +25);
        transform.position = nextPos;
        period = Random.Range(1.5f,3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        human = GameObject.FindGameObjectsWithTag("human");
        if (Vector3.Distance(nextPos, transform.position) != 0f)
        {
            if (isMove == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            }
            else
            {
                isMove = false;
            }
        }

        if (Time.time > nextActionTime ) 
        {
            nextActionTime += period;
            
            if (Vector2.Distance(nextPos , transform.position) == 0)
            {
                if (randomArrayNumber == 1)
                {
                    counterOne++;
                    nextArrayNumber = Random.Range(1,3);
                    nextPos = movePoints[nextArrayNumber].transform.position;
                    if (counterOne == 2)
                    {
                        counterOne = 0;
                        nextPos = movePoints[2].transform.position;
                        nextPos.x = Random.Range(movePoints[2].transform.position.x -25 , movePoints[2].transform.position.x +25);
                        isMove = true;
                        //Debug.Log(2);
                    }
    
                }
                else if (randomArrayNumber == 5)
                {
                    counterSix++;
                    nextArrayNumber = Random.Range(4,6);
                    nextPos = movePoints[nextArrayNumber].transform.position;
                    nextPos.x = Random.Range(movePoints[nextArrayNumber].transform.position.x -25 , movePoints[nextArrayNumber].transform.position.x +25);
                    if (counterSix == 2)
                    {
                        counterSix = 0;
                        nextPos = movePoints[4].transform.position;
                        nextPos.x = Random.Range(movePoints[movePoints.Length-1].transform.position.x -25 , movePoints[movePoints.Length-1].transform.position.x +25);
                        isMove = true;
                        //Debug.Log(4);
                    }
                }
                
                else
                {
                    nextArrayNumber = Random.Range(randomArrayNumber-1,randomArrayNumber+2);
                    nextPos = movePoints[nextArrayNumber].transform.position;
                    nextPos.x = Random.Range(movePoints[nextArrayNumber].transform.position.x -25 , movePoints[nextArrayNumber].transform.position.x +25);
    
                    isMove =true;
                    randomArrayNumber = nextArrayNumber;
                    //Debug.Log(nextArrayNumber);
                }
                randomArrayNumber = nextArrayNumber;
            }
        }
    }
    public void oda0Button()
    {
        //nextPos = movePoints[0].transform.position;
        Debug.Log(0);
    }
    public void oda1Button()
    {
        //nextPos = movePoints[1].transform.position;
        Debug.Log(1);
    }
    public void oda2Button()
    {
        //nextPos = movePoints[2].transform.position;
        Debug.Log(2);
    }
    public void oda3Button()
    {
        //nextPos = movePoints[3].transform.position;
        Debug.Log(3);
    }
    public void oda4Button()
    {
        //nextPos = movePoints[4].transform.position;
        Debug.Log(4);
    }
    public void oda5Button()
    {
        //nextPos = movePoints[5].transform.position;
        Debug.Log(5);
    }
    
}
