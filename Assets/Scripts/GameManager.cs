using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public int SkinSelection;

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
    }

    public void ApplyUserOptions()
    {
        VolumeSlider = DataPersistence.PlayerStats.VolumeSlider;
        MusicToogle = DataPersistence.PlayerStats.MusicToogle;
        SkinSelection = DataPersistence.PlayerStats.SkinSelection;
        SkinName.text = DataPersistence.PlayerStats.SkinName;

        //Musica (activar/desactivar) BOOL
    }
}
