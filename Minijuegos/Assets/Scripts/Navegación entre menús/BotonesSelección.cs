using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesSelección : MonoBehaviour
{
    [SerializeField] private GameObject _infoLibre;
    [SerializeField] private GameObject _infoTriatlon;
    [SerializeField] private GameObject _botones;
    public void InfoJuegoLibre()
    {
        _infoLibre.SetActive(true);
        _botones.SetActive(false);
    }

    public void OcultarInfoJuegoLibre()
    {
        _infoLibre.SetActive(false);
        _botones.SetActive(true);
    }

    public void InfoTriatlon()
    {
        _infoTriatlon.SetActive(true);
        _botones.SetActive(false);
    }

    public void OcultarInfoTriatlon()
    {
        _infoTriatlon.SetActive(false);
        _botones.SetActive(true);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }

    public void InicioJuegoLibre()
    {
        ControladorJuego.instancia._triatlon = false;
        SceneManager.LoadScene(2);
    }

    public void InicioTriatlon()
    {
        ControladorJuego.instancia._triatlon = true;
        SceneManager.LoadScene(2);
    }
}
