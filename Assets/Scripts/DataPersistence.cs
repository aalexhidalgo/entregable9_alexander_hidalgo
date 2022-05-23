using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    //Instancia compartida

    public static DataPersistence PlayerStats;

    //Variables

    //Musica general (no sonido personajes)
    public float VolumeSlider;
    public int MusicToggle; //(bool, activamos 1, desactivamos 0)

    //Dropdown
    public string SkinName;
    public int SkinSelected;

    public int ActualSesion = 0;
    public int LastSesion = 0;

    void Awake()
    {
        // Si la instancia no existe
        if (PlayerStats == null)
        {
            // Configuramos la instancia
            PlayerStats = this;
            // Nos aseguramos de que no sea destruida con el cambio de escena
            DontDestroyOnLoad(PlayerStats);
        }
        else
        {
            // Como ya existe una instancia, destruimos la copia
            Destroy(this);
        }
    }

    public void SaveForFutureGames()
    {
        //Preferencias del Player
        PlayerPrefs.SetInt("Skin_Selected", SkinSelected);
        PlayerPrefs.SetString("Skin_Name", SkinName);
        PlayerPrefs.SetFloat("Volume_Slider", VolumeSlider);
        PlayerPrefs.SetInt("Music_Toggle", MusicToggle);
        PlayerPrefs.SetInt("Actual_Sesion", ActualSesion);
        PlayerPrefs.SetInt("Last_Sesion", LastSesion);

    }

    //EXTRA:
    public void OnApplicationQuit()
    {
        LastSesion = DataPersistence.PlayerStats.ActualSesion;
        DataPersistence.PlayerStats.ActualSesion = 0;
        SaveForFutureGames();
    }

}
