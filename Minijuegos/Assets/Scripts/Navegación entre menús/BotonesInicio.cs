using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour
{
    [SerializeField] private GameObject _panelCreditos;
    [SerializeField] private GameObject _botones;

    public void ComenzarJuego()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Salir()
    {
        Application.Quit();
    }

    public void MostrarCreditos()
    {
        _botones.SetActive(false);
        _panelCreditos.SetActive(true);
    }

    public void OcultarCreditos()
    {
        _botones.SetActive(true);
        _panelCreditos.SetActive(false);
    }
}
