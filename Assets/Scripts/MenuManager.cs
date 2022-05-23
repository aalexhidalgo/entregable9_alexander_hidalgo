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

    //DROPDOWN: Cada skin irá acompañada por una previsualización de esta
    public Image SkinImage;
    public Sprite[] SkinArray;
    public int CurrentSkin;
    public TMP_Dropdown SkinDropdown;

    public TextMeshProUGUI DropdownText;
    public string SkinName;

    //SLIDER: Se encargará de controlar el volumen de los efectos de sonido en el juego
    private AudioSource MenuManagerAudioSource;
    public Slider SliderVolume;
    public AudioClip[] AudioVoiceArray;

    private AudioSource MainCameraAudioSource;
    public Slider SliderBackgroundVolume;
    public float MusicVolumeValue;

    //BOTONES: Nos mostrarán las estadísticas de cada arma al seleccionarlas
    public TextMeshProUGUI WeaponsStats;

    //EXTRAS: Botones del panel principal, slider de música de fondo + toogle, tanto con script como a mano!

    //PANEL PRINCIPAL

    //Iniciaríamos el juego y pasaríamos a la escena de juego
    public void StartButton()
    {
        Debug.Log("Start");
        //En esta escena se muestran las opciones que hemos elegido previamente en el menú de opciones
        SceneManager.LoadScene("Game");
        //Guardamos los datos que hemos cambiado en el menú de opciones
        DataPersistence.PlayerStats.SaveForFutureGames();
    }

    //Pasamos al panel de opciones con aquellas que podrá configurar el jugador
    public void OptionsButton()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);

        //Al abrir el panel se activa automáticamente la voz del personaje preseleccionado, al igual que aparecerá el sprite y la opción en el dropdown
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
        SaveUserOptions();
    }

    //Dropdown de selección de personaje
    public void SkinSelection()
    {
       CurrentSkin = SkinDropdown.value;
       SkinImage.sprite = SkinArray[CurrentSkin];
       SkinName = DropdownText.text;

       //Extra: Actualizamos las voces de los personajes al que hemos seleccionado
       MenuManagerAudioSource.Stop();
       MenuManagerAudioSource.PlayOneShot(AudioVoiceArray[CurrentSkin], 1.0f);

    }

    //Slider de volumen de efectos de sonido (acompañado de toogle, A MANO!)
    public void UpdateSoundVolume()
    {
        MenuManagerAudioSource.volume = SliderVolume.value;
    }

    //Slider de volumen de música (acompañado de toogle)
    public void UpdateMusicVolume()
    {
        MainCameraAudioSource.volume = SliderBackgroundVolume.value;
        SliderBackgroundVolume.value = MusicVolumeValue;
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
        SkinImage.GetComponent<Image>();
        LoadUserOptions();
        SaveUserOptions();

        MainCameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update()
    {
       
    }


    public void SaveUserOptions()
    {
        // Persistencia de datos entre escenas
        DataPersistence.PlayerStats.SkinSelected = CurrentSkin;
        DataPersistence.PlayerStats.SkinName = SkinName;
        DataPersistence.PlayerStats.VolumeSlider = MusicVolumeValue;

        // Persistencia de datos entre partidas
        DataPersistence.PlayerStats.SaveForFutureGames();
    }

    public void LoadUserOptions()
    {
        // Tal y como lo hemos configurado, si tiene esta clave, entonces tiene todas
        if (PlayerPrefs.HasKey("Skin_Selected"))
        {
            CurrentSkin = PlayerPrefs.GetInt("Skin_Selected");
            SkinName = PlayerPrefs.GetString("Skin_Name");
            MusicVolumeValue = PlayerPrefs.GetFloat("Volume_Slider");
            UpdateSkinImage();
            UpdateSkinName();
            //UpdateMusic();
        }
    }

    public void UpdateSkinImage()
    {
        SkinDropdown.value = CurrentSkin;
        SkinImage.sprite = SkinArray[CurrentSkin];
    }

    public void UpdateSkinName()
    {
        DropdownText.text = SkinName;
    }
    
    public void UpdateMusic(float Volume)
    {
        MusicVolumeValue = Volume;
    }

    public void UpdateActiveMusic()
    {

    }
    
}
