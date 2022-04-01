using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    [SerializeField] Toggle LeftToggle, RightToggle;
    [SerializeField] GameObject EventCard;// ,LeftChoice, RightChoice;
    [SerializeField] Text leftText, rightText, EventText;

    [SerializeField] GameManager manager;
public Image[] images;
public Image mainImage;

    bool isEvent;

    public int EventNumber;
    void Start()
    {
          
    }
    public void Left()
    {
        switch (EventNumber)
        {
            case 0:
                Debug.Log(0);
                manager.Food += 6;
                
                EventCard.SetActive(false);

                break;
            case 1:
                manager.Population += 3;
                EventCard.SetActive(false);
                Debug.Log(1);
                break;
            case 2:
                manager.Water -= 6;
                EventCard.SetActive(false);
                Debug.Log(2);
                break;
            case 3:
                manager.Food += 6;
                manager.Water -= 5;
                EventCard.SetActive(false);
                Debug.Log(3);
                break;
            
        }
        LeftToggle.isOn = false;
        
    }
    public void Right()
    {
        switch (EventNumber)
        {
            case 0:
                Debug.Log(0);
                
                manager.Water += 5;
                EventCard.SetActive(false);

                break;
            case 1:
                manager.Happiness += 1;
                EventCard.SetActive(false);
                Debug.Log(1);
                break;
            case 2:
                manager.Food -= 5;
                EventCard.SetActive(false);
                Debug.Log(2);
                break;
            case 3:
                manager.Food -= 6;
                manager.Water += 5;
                EventCard.SetActive(false);
                Debug.Log(3);
                break;
           
        }
        RightToggle.isOn = false;

    }
    public void EventChoose()
    {
        EventNumber = Random.Range(0, 4);
        switch (EventNumber)
        {
            case 0:
                EventText.text = "Koloninden birkaç kişi bir yardım paketi buldu";
                leftText.text = "Suyu al (su +)";
                rightText.text = "Yemeği al (yemek +)";
                mainImage = images[EventNumber];
                break;
            case 1:
                EventText.text = "Dışarda yaralı insanlar buldun";
                leftText.text = "İnsanları sığınağa al (insan +)";
                rightText.text = "İnsanları dışarıda bırak (mutluluk +)";
                mainImage = images[EventNumber];
                break;
            case 2:
                EventText.text = "Yemek deponda yangın çıktı";
                leftText.text = "Söndür (su -)";
                rightText.text = "Söndürme (yemek -)";
                mainImage = images[EventNumber];
                break;
            case 3:
                EventText.text = "Deprem oluyor";
                leftText.text = "İnsanları güvenli alana ulaştır (yemek -)";
                rightText.text = "Yemekleri kurtar (insan -)";
                mainImage = images[EventNumber];
                break; 
            
        }
    }
    public void isEventDay()
    {
        EventChoose();
        Debug.Log(31);
        int x = Random.Range(0,4);
        if (x == 2)
        {
            EventCard.SetActive(true);
        }
        else
        {
            EventCard.SetActive(false);
        }
    }
    
    void Update()
    {
        //EventChoose();
    }
}
