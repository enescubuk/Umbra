using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject foodToggle, waterToggle, happnessToggle,killToggle,nextDayButton;

    public Text nextRoundFood;
    public Text nextRoundWater;
    public Text nextRoundFreeTime;
    public Text nextRoundKill;
    
    [Header("Variables")]
    public int Food;
    public int Water;
    public int Happiness;
    public int Population;

    private int lastFood;
    private int nextFood;
    private int lastWater;
    private int nextWater;
    private int lastFreeTime;
    private int nextFreeTime;
    private int lastKill;
    private int nextKill;
    

    [Header("Values")]
    public int FoodDecrease;
    public int FoodIncraese;
    //
    public int WaterDecrease;
    public int WaterIncrease;
    //
    public int HappinessIncrease;
    public int HappinessDecrease;
    [SerializeField] int HappinessKill;
    //
    public int PopulationDecrease;
    [SerializeField] int PopulationIncrease;


    public dayController Day;


    private void Start()
    {
        foodToggle = GameObject.Find("Food");
        waterToggle = GameObject.Find("Water");
        happnessToggle=GameObject.Find("Free Time");
        killToggle=GameObject.Find("Kill2");
    }

    private void FoodUpdate()
    {
        if (Happiness >= 70)
        {
            Food += FoodDecrease + Population* 2 / 10;
        }
        else if (Happiness <= 25)
        {
            Food += FoodDecrease - Population * 2 / 10;
        }
        else
        {
            Food += FoodDecrease;
        }
    }
    private void WaterUpdate()
    {
        if (Happiness >= 70)
        {
            Water +=WaterIncrease + Population* 2 / 10;
        }
        else if (Happiness <= 25)
        {
            Water += WaterIncrease - Population * 2 / 10;
        }
        else
        {
            Water += WaterIncrease;
        }
    }
    public void FoodSearch()
    {
        //(FoodIncraese - FoodDecrease)
        HappinessCheck();
        FoodUpdate();
        lastKill = Population;
        CalculateKill();
        nextKill = Population;
        lastWater = Water;
        Water -=CalculateWater();
        nextWater = Water;
        lastFreeTime = Happiness;
        Happiness -= HappinessDecrease;
        nextFreeTime = Happiness;
        int rand = Random.Range(0, 100);
        if (rand <= 25)
        {
            CalculateKill();
        }
    }

    public void CalculateFoodSearch(Text foodText, Text waterText, Text happinessText)
    {
        int food, water, happiness;
        happiness = HappinessDecrease;
        if (Food == 0 || Water == 0)
        {
            happiness= HappinessDecrease + HappinessDecrease * 4 / 10;
        }
        if (Water == 0 && Food == 0)
        {
            happiness= HappinessDecrease + HappinessDecrease * 6 / 10;
        }
        if (Happiness >= 70)
        {
            food = FoodDecrease + Population* 2 / 10;
        }
        else if (Happiness <= 25)
        {
            food= FoodDecrease - Population * 2 / 10;
        }
        else
        {
            food= FoodDecrease;
        }

        water = Population * 8 / 10;
        
        foodText.text = ""+food;
        foodText.color =Color.green;
        waterText.text = "" + water;
        
        happinessText.text = "" + happiness;
        
    }
    
    public void CalculateWaterSearch(Text foodText, Text waterText, Text happinessText)
    {
        int food, water, happiness;
        happiness = HappinessDecrease;
        if (Food == 0 || Water == 0)
        {
            happiness= HappinessDecrease + HappinessDecrease * 4 / 10;
        }
        if (Water == 0 && Food == 0)
        {

            happiness= HappinessDecrease + HappinessDecrease * 6 / 10;
        }
        if (Happiness >= 70)
        {
            water =WaterIncrease + Population* 2 / 10;
        }
        else if (Happiness <= 25)
        {
            water= WaterIncrease - Population * 2 / 10;
        }
        else
        {
            water= WaterIncrease;
        }

        food = Population * 6 / 10;
        
        foodText.text = ""+food;
        foodText.color =Color.red;
        waterText.text = "" + water;
        waterText.color=Color.green;
        happinessText.text = "" + happiness;
        happinessText.color=Color.red;
        
    }
    
    public void CalculateFreeTimeSearch(Text foodText, Text waterText, Text happinessText, Text popText)
    {
        int food, water, happiness,pop;
        happiness= HappinessIncrease;
        if (Food == 0 || Water == 0)
        {
            happiness= HappinessDecrease * 4 / 10;
        }
        if (Water == 0 && Food == 0)
        {
            happiness= HappinessDecrease * 6 / 10;
        }
        food= Population * 6 / 10;
        water= Population * 8 / 10;
        
        pop = PopulationIncrease;

        
        foodText.text = ""+food;
        foodText.color =Color.red;
        waterText.text = "" + water;
        waterText.color=Color.green;
        happinessText.text = "" + happiness;
        happinessText.color=Color.red;
        popText.text = ""+pop;
        popText.color =Color.red;
        
    }
    
    public void CalculateKillSearch(Text foodText, Text waterText, Text happinessText, Text popText)
    {
        int food, water, happiness,pop;
        happiness= HappinessIncrease;
        if (Food == 0 || Water == 0)
        {
            happiness=  HappinessDecrease * 4 / 10;
        }
        if (Water == 0 && Food == 0)
        {
            happiness= HappinessDecrease * 6 / 10;
        }
        pop= PopulationDecrease;
        food = Population * 6 / 10;
        water= Population * 8 / 10;
        happiness= HappinessKill*3/2;

        
        foodText.text = ""+food;
        foodText.color =Color.red;
        waterText.text = "" + water;
        waterText.color=Color.green;
        happinessText.text = "" + happiness;
        happinessText.color=Color.red;
        popText.text = ""+pop;
        popText.color =Color.red;
        
    }

    void CalculateValues()
    {
        
    }
    private int CalculateHappiness()
    {
        return HappinessDecrease;
    }

    private int CalculateKill()
    {
        return Population * 3 / 100;
    }

    private int CalculateWater()
    {
        return Population * 8 / 10;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.J)){
            SceneManager.LoadScene("End_Win");
        }
        if(Input.GetKey(KeyCode.T)){
            SceneManager.LoadScene("EndIsyan");
        }
        if(Input.GetKey(KeyCode.K)){
            SceneManager.LoadScene("EndOlum");
        }
        if(Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene("Starttttt");
        }


        if (foodToggle.GetComponent<Toggle>().isOn == true)
        {
            CalculateFoodSearch(nextRoundFood,nextRoundWater,nextRoundFreeTime);
        }
        else
        {
            nextRoundFood.text = "";
            nextRoundWater.text = "";
            nextRoundFreeTime.text = "";
        }
        if (waterToggle.GetComponent<Toggle>().isOn == true)
        {
           CalculateWaterSearch(nextRoundFood,nextRoundWater,nextRoundFreeTime);
        }
        if (happnessToggle.GetComponent<Toggle>().isOn == true)
        {
            CalculateFreeTimeSearch(nextRoundFood,nextRoundWater,nextRoundFreeTime,nextRoundKill);
        }
        if (killToggle.GetComponent<Toggle>().isOn == true)
        {
            CalculateKillSearch(nextRoundFood,nextRoundWater,nextRoundFreeTime,nextRoundKill);
        }
        
        FoodDecrease = (int)(-0.055f * ((Population - 31.5) * (Population - 31.5)) + 30);
        WaterIncrease = (int)(-0.1f * ((Population - 29) * (Population - 29)) + 31);
        if (Food <=0)
        {
            Food = 0;
        }
        if (Water <= 0)
        {
            Water = 0;
        }
        if (Food >= 100)
        {
            Food = 100;
        }
        if (Water >= 100)
        {
            Water = 100;
        }
        if (Happiness <=0)
        {
            Happiness = 0;
        }
        if (Population <= 0)
        {
            Population = 0;
        }
        if (Population <= 10)
        {
            FoodDecrease = 4;
        }
        if (Population <= 12)
        {
            WaterIncrease = 4;
        }
    }

    public void HappinessCheck()
    {
        if (Food == 0 || Water == 0)
        {
            Happiness -= HappinessDecrease + HappinessDecrease * 4 / 10;
        }
        if (Water == 0 && Food == 0)
        {
            Happiness -= HappinessDecrease + HappinessDecrease * 6 / 10;
        }
    }
    
    public void WaterSearch()
    {
        HappinessCheck();
        Happiness -= HappinessDecrease;
        Food -= Population * 6 / 10;
        WaterUpdate();
        int rand = Random.Range(0, 100);
        if (rand <= 8)
        {
            Population -= Population * 3 / 100;
        }
    }
    public void KillPopulation()
    {
        HappinessCheck();
        Population -= PopulationDecrease;
        Food -= Population * 6 / 10;
        Water -= Population * 8 / 10;
        Happiness -= HappinessKill*3/2;
    }
    public void FreeTime()
    {
        HappinessCheck();
        Food -= Population * 6 / 10;
        Water -= Population * 8 / 10;
        Happiness += HappinessIncrease;
        Population += PopulationIncrease;
    }
    public void NextDay()
    {
        HappinessCheck();
        /* Debug.Log(31);
        Food -= Population*6/10;
        Water -= Population * 8 / 10;
        Happiness += HappinessIncrease / 3;
       */
    }
    public void PopulationUpdate()
    {

        int x;
        if (Day.gunSayac % 3 == 0)
        {
            x = Population / 15;
            Population += x;
        }
    }

    
}