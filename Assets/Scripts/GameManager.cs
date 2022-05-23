using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Script donde aplicaremos los cambios guardados en la escena de Menu ("Options")

    public static GameManager sharedInstance;

    //Variables a las que vamos a conectar los valores guardados
    
    //Skin (String)
    public TextMeshProUGUI SkinName;
    public string SkinNameSelected;

    //Skin (INT)
    public Image Skin;
    public Image PCSkin;
    public Sprite[] SkinArray;
    public int SkinSelected;
    private int EnemySelected;

    //Musica (Float)
    private AudioSource BackgroundMusic;
    public float MusicVolumeValue;

    //Escenas
    public TextMeshProUGUI ActualSesion;
    public TextMeshProUGUI LastSesion;
    public int Actual;
    public int Last;

    public void ReturnButton()
    {
        SceneManager.LoadScene("Options");
        DataPersistence.PlayerStats.ActualSesion++;
        DataPersistence.PlayerStats.SaveForFutureGames();
    }

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        BackgroundMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //Accedemos a la imagen del personaje elegido
        Skin.GetComponent<Image>();

        //Si no hemos aplicado cambios
        SkinSelected = 0;
        SkinName.text = SkinNameSelected;

        // Aplicamos esos cambios
        UpdatePlayerSkin();
        UpdatePlayerName();
        UpdatePlayerMusicVolume();
        UpdatePlayerMusic();
        //Accedemos a la imagen del Rival
        PCSkin.GetComponent<Image>();
        RandomizeRival();

        UpdateCounter();
    }

    public void UpdatePlayerSkin()
    {
        SkinSelected = DataPersistence.PlayerStats.SkinSelected;
        Skin.sprite = SkinArray[SkinSelected];
    }

    public void UpdatePlayerName()
    {
        SkinNameSelected = DataPersistence.PlayerStats.SkinName;
        SkinName.text = SkinNameSelected;      
    }

    public void UpdatePlayerMusicVolume()
    {
        BackgroundMusic.volume = DataPersistence.PlayerStats.VolumeSlider;
    }
    public void UpdatePlayerMusic()
    {
        if (DataPersistence.PlayerStats.MusicToggle == 1)
        {
            BackgroundMusic.UnPause();
        }
        else
        {
            BackgroundMusic.Pause();
        }
    }

    public void UpdateCounter()
    {
        Actual = DataPersistence.PlayerStats.ActualSesion;
        ActualSesion.text = $"{Actual}";
        Last = DataPersistence.PlayerStats.LastSesion;
        LastSesion.text = $"{Last}";
    }

    /*EXTRA: Cada vez que entramos es peleamos contra un rival distinto (máquina) por defecto 
    o bien podemos hacer un "Shuffle" para pelear contra otro enemigo de manera aleatoria*/

    public void RandomizeRival()
    {
        EnemySelected = Random.Range(0, SkinArray.Length);
        PCSkin.sprite = SkinArray[EnemySelected];
    }

}
