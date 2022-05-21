using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    //Paneles
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;

    //Elementos UI:

    //DROPDOWN: Cada skin ir� acompa�ada por una previsualizaci�n de esta
    public Image Skin;
    public Sprite[] SkinArray;
    public int CurrentSkin;
    public TMP_Dropdown SkinDropdown;

    //SLIDER: Se encargar� de controlar el volumen de los efectos de sonido en el juego
    private AudioSource MenuManagerAudioSource;
    public Slider SliderVolume;
    public AudioClip[] AudioVoiceArray;

    //BOTONES: Nos mostrar�n las estad�sticas de cada arma al seleccionarlas
    public TextMeshProUGUI WeaponsStats;

    //EXTRAS: Botones del panel principal, slider de m�sica de fondo + toogle, tanto con script como a mano!

    //PANEL PRINCIPAL

    //Iniciar�amos el juego y pasar�amos a la escena de juego
    public void StartButton()
    {
        Debug.Log("Start");
        //En esta escena se muestran las opciones que hemos elegido previamente en el men� de opciones
        SceneManager.LoadScene("Game");
        //Guardamos los datos que hemos cambiado en el men� de opciones
        DataPersistence.PlayerStats.SaveForFutureGames();
    }

    //Pasamos al panel de opciones con aquellas que podr� configurar el jugador
    public void OptionsButton()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);

        //Al abrir el panel se activa autom�ticamente la voz del personaje preseleccionado, al igual que aparecer� el sprite y la opci�n en el dropdown
        MenuManagerAudioSource.PlayOneShot(AudioVoiceArray[CurrentSkin], 1.0f);
    }

    //Salimos del juego
    public void ExitButton()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    //PANEL DE OPCIONES

    //Volvemos al panel anterior
    public void ReturnButton()
    {
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        MenuManagerAudioSource.Stop();
    }

    //Dropdown de selecci�n de personaje
    public void SkinSelection()
    {
       CurrentSkin = SkinDropdown.value;
       Skin.sprite = SkinArray[CurrentSkin];
        
       //Extra: Actualizamos las voces de los personajes al que hemos seleccionado
       MenuManagerAudioSource.Stop();
       MenuManagerAudioSource.PlayOneShot(AudioVoiceArray[CurrentSkin], 1.0f);
    }

    //Slider de volumen de efectos de sonido (acompa�ado de toogle, A MANO!)
    public void UpdateVolume()
    {
        MenuManagerAudioSource.volume = SliderVolume.value;
    }

    //Botones que muestran las stats de las ramas
    public void ShowStats_1()
    {
        WeaponsStats.text = "ATQ: 46  DEF: 12 CRIT: 110";
    }

    public void ShowStats_2()
    {
        WeaponsStats.text = "ATQ: 44  DEF: 15 CRIT: 105";
    }

    public void ShowStats_3()
    {
        WeaponsStats.text = "ATQ: 42  DEF: 17 CRIT: 100";
    }

    void Start()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);

        MenuManagerAudioSource = GetComponent<AudioSource>();
        Skin = GameObject.Find("Skin").GetComponent<Image>();
    }
}
