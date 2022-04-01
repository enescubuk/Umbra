using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dayController : MonoBehaviour
{
    //public EventController eventmanager;
    public int gunSayac;
    public Text takvim;
    public GameManager gameManager;

    public GameObject foodToggle, waterToggle, happnessToggle, killToggle;
    public humanController humanController;

    // Start is called before the first frame update
    private void Awake()
    {
       // eventmanager = GameObject.Find("EventManager").GetComponent<EventController>();
    }
    void Start()
    {
        
        humanController = GameObject.Find("humanController").GetComponent<humanController>();
        ////////////////////////////
        gunSayac = 60;
        
        takvim.text =gunSayac+" .gun";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nnextDay()
    {
       // eventmanager.isEventDay();
                
        if (killToggle.GetComponent<Toggle>().isOn == false && foodToggle.GetComponent<Toggle>().isOn == false && waterToggle.GetComponent<Toggle>().isOn == false && happnessToggle.GetComponent<Toggle>().isOn == false)
        {
            gameManager.NextDay();
        }
        if (foodToggle.GetComponent<Toggle>().isOn == true)
        {
            gameManager.FoodSearch();
            foodToggle.GetComponent<Toggle>().isOn = false;
        }
        if (waterToggle.GetComponent<Toggle>().isOn == true)
        {
            gameManager.WaterSearch();
            waterToggle.GetComponent<Toggle>().isOn = false;
        }
        if (happnessToggle.GetComponent<Toggle>().isOn == true)
        {
            gameManager.FreeTime();
            happnessToggle.GetComponent<Toggle>().isOn = false;
        }
        if (killToggle.GetComponent<Toggle>().isOn == true)
        {
            gameManager.KillPopulation();
            killToggle.GetComponent<Toggle>().isOn = false;
        }
        

        gameManager.PopulationUpdate();
        
        ////////////////////////////////////////
        gunSayac--;
        if (gunSayac == 0)
        {
            Debug.Log("gün bitti");
        }
        takvim.text = gunSayac+" .gun";

    }
}
