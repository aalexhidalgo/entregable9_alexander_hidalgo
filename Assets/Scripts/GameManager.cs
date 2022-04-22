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

    //Elementos UI:

    //DROPDOWN: Cada skin irá acompañada por una previsualización de esta
    public Image Skin;
    public Sprite[] SkinArray;
    public int CurrentSkin;
    public TMP_Dropdown SkinDropdown;

    //SLIDER: Se encargará de controlar el volumen de música en el juego
    private AudioSource GameManagerAudioSource;
    public Slider SliderVolume;

    //Extra
    private AudioSource MainCameraAudioSource;
    public AudioClip[] AudioVoiceArray;

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

    //Dropdown de selección de personaje

    public void SkinSelection()
    {
       CurrentSkin = SkinDropdown.value;
       Skin.sprite = SkinArray[CurrentSkin];
    }

    //Extra: Actualizar la voz del personaje por el elegido

    public void CharactersVoice()
    {
        GameManagerAudioSource.PlayOneShot(AudioVoiceArray[CurrentSkin]);
    }
    

    //Slider de volumen de música (acompañado de toogle, A MANO!)

    public void UpdateVolume()
    {
        GameManagerAudioSource.volume = SliderVolume.value;
    }

    //Extra: Slider + toogle de volumen de efectos de sonido (en este caso voces de los personajes) A MANO!

    void Start()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);

        GameManagerAudioSource = GetComponent<AudioSource>();
        Skin = GameObject.Find("Skin").GetComponent<Image>();

        MainCameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        MainCameraAudioSource.PlayOneShot(AudioVoiceArray[0]);
    }
}
