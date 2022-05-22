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
    public float VolumeSlider;
    public int MusicToogle;
    private AudioSource BackgroundMusic; //Bool
    public TextMeshProUGUI SkinName;

    //Skin (INT)
    public Image Skin;
    public Image PCSkin;
    public Sprite[] SkinArray;
    public int SkinSelected;
    private int EnemySelected;

    //Musica


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
        // Aplicamos esos cambios
        ApplyUserOptions();

        //Accedemos a la imagen del Rival
        PCSkin.GetComponent<Image>();
        RandomizeRival();
    }

    //Randomizamos imagen que elige el rival (cada vez que entramos es un rival distinto)
    public void RandomizeRival()
    {
        EnemySelected = Random.Range(0, SkinArray.Length);
        PCSkin.sprite = SkinArray[EnemySelected];
    }

    public void ApplyUserOptions()
    {
        SkinName.text = DataPersistence.PlayerStats.SkinName;
        SkinSelected = DataPersistence.PlayerStats.SkinSelected;

        //Musica (activar/desactivar) BOOL
    }

}
