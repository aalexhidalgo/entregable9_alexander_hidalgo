using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Paneles
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;

    //DROPDOWN: Cada skin irá acompañada por una previsualización de esta
    public Image Skin;
    public Sprite[] SkinArray;
    public int CurrentSkin;
    public TMP_Dropdown SkinDropdown;

    //SLIDER: Se encargará de controlar el volumen de música en el juego
    private AudioSource GameManagerAudioSource;
    public Slider SliderVolume;

    //Panel principal

    //Iniciaríamos el juego y pasaríamos a la escena de juego
    public void StartButton()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("Juego");
    }

    //Pasamos al panel de opciones con aquellas que podrá configurar el jugador
    public void OptionsButton()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    //Salimos del juego
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    //Panel de opciones

    public void ReturnButton()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    //Dropdown de selección de personajes

    public void SkinSelection()
    {
       CurrentSkin = SkinDropdown.value;
       Skin.sprite = SkinArray[CurrentSkin];
    }

    //Slider de volumen de música

    public void UpdateVolume()
    {
        GameManagerAudioSource.volume = SliderVolume.value;
    }

    void Start()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);

        GameManagerAudioSource = GetComponent<AudioSource>();
        Skin = GameObject.Find("Skin").GetComponent<Image>();
    }
}
