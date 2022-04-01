using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;

    [Header("Volume Settings")] 
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject comfirmationPromtp = null;

    void Update()
    {
        
    }

    public void start()
    {
        SceneManager.LoadScene("kadir5");
    }

    public void option()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void back()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void volumeDown()
    {
        AudioListener.volume = 0;
    }
    public void volumeUp()
    {
        AudioListener.volume = 1;
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume",AudioListener.volume);
        StartCoroutine(CorfirmationBox());
    }

    public IEnumerator CorfirmationBox()
    {
        comfirmationPromtp.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPromtp.SetActive(false);
    }
}
