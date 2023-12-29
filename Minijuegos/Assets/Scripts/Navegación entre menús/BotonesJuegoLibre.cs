using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesJuegoLibre : MonoBehaviour
{
    [SerializeField] private GameObject _controles1;
    [SerializeField] private GameObject _controles2;
    [SerializeField] private GameObject _controles3;

    public void MostrarControles1()
    {
        _controles1.SetActive(true);
        _controles2.SetActive(false);
        _controles3.SetActive(false);
    }

    public void MostrarControles2()
    {
        _controles2.SetActive(true);
        _controles1.SetActive(false);
        _controles3.SetActive(false);
    }

    public void MostrarControles3()
    {
        _controles3.SetActive(true);
        _controles2.SetActive(false);
        _controles1.SetActive(false);
    }

    public void OcultarControles1()
    {
        _controles1.SetActive(false);
    }

    public void OcultarControles2()
    {
        _controles2.SetActive(false);
    }

    public void OcultarControles3()
    {
        _controles3.SetActive(false);
    }

    public void Minijuego1()
    {
        SceneManager.LoadScene(4);
    }

    public void Minijuego2()
    {
        SceneManager.LoadScene(5);
    }

    public void Minijuego3()
    {
        SceneManager.LoadScene(6);
    }

    public void Volver()
    {
        SceneManager.LoadScene(2);
    }

}
