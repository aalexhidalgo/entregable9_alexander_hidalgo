using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        // Aplicamos esos cambios
        UpdatePlayerSkin();
        UpdatePlayerName();
        UpdatePlayerMusic();
        //Accedemos a la imagen del Rival
        PCSkin.GetComponent<Image>();
        RandomizeRival();
    }

    void Update()
    {

    }

    //Randomizamos imagen que elige el rival (cada vez que entramos es un rival distinto)
    public void RandomizeRival()
    {
        EnemySelected = Random.Range(0, SkinArray.Length);
        PCSkin.sprite = SkinArray[EnemySelected];
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

    public void UpdatePlayerMusic()
    {
        BackgroundMusic.volume = DataPersistence.PlayerStats.VolumeSlider;
    }
}
