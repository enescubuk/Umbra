using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameManager manager;
    [SerializeField] Slider FoodSlider;
    [SerializeField] Slider WateSlider;
    [SerializeField] Slider HappsSlider;
    [SerializeField] Slider PopuonSlider;

    public GameObject foodToggle, waterToggle, happnessToggle, killToggle;

    public Image Image;

    void Start()
    {
        
    }
    void Update()
    {
        if (killToggle.GetComponent<Toggle>().isOn == false && foodToggle.GetComponent<Toggle>().isOn == false && waterToggle.GetComponent<Toggle>().isOn == false && happnessToggle.GetComponent<Toggle>().isOn == false)
        {
            FoodSlider.value = manager.Food;
            WateSlider.value = manager.Water;
            HappsSlider.value = manager.Happiness;
            PopuonSlider.value = manager.Population;
            Image.fillAmount = (manager.Population * 0.01f * 1.333333333333333f);
        }
        
    }
}
