using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;

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
    public void SkinSlection()
    {
        //Que vaya cambiando el sprite del personaje
    }

    void Start()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }
}
