using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesPersonajes : MonoBehaviour
{
    [SerializeField] private GameObject _selectedA;
    [SerializeField] private GameObject _selectedB;
    [SerializeField] private GameObject _selectedC;
    [SerializeField] private GameObject _selectedD;
    [SerializeField] private TMP_Text pistaBlocked;

    public void SeleccionPersonajeA()
    {
         _selectedA.SetActive(true);
         _selectedB.SetActive(false);
         _selectedC.SetActive(false);
         _selectedD.SetActive(false);
         pistaBlocked.text = "";
         ControladorJuego.instancia._personaje = 0;        
    }

    public void SeleccionPersonajeB()
    {
        if (ControladorJuego.instancia.datosGuardado._desbloqueado2)
        {
            _selectedB.SetActive(true);
            _selectedA.SetActive(false);
            _selectedC.SetActive(false);
            _selectedD.SetActive(false);
            pistaBlocked.text = "";
            ControladorJuego.instancia._personaje = 1;
        }
        else
        {
            pistaBlocked.text = "Consigue inflar un globo al máximo en La Avaricia rompe el Globo";
        }
    }

    public void SeleccionPersonajeC()
    {
        if (ControladorJuego.instancia.datosGuardado._desbloqueado3)
        {
            _selectedC.SetActive(true);
            _selectedB.SetActive(false);
            _selectedA.SetActive(false);
            _selectedD.SetActive(false);
            pistaBlocked.text = "";
            ControladorJuego.instancia._personaje = 2;
        }
        else
        {
            pistaBlocked.text = "Obtén un oso de peluche en Asedio de Jueguetes";
        }
    }

    public void SeleccionPersonajeD()
    {
        if (ControladorJuego.instancia.datosGuardado._desbloqueado4)
        {
            _selectedD.SetActive(true);
            _selectedB.SetActive(false);
            _selectedA.SetActive(false);
            _selectedC.SetActive(false);
            pistaBlocked.text = "";
            ControladorJuego.instancia._personaje = 3;
        }
        else
        {
            pistaBlocked.text = "Participa varias veces en el Triatlón";
        }
    }

    public void Volver()
    {
        SceneManager.LoadScene(1);
    }

    public void Continuar()
    {
        if(ControladorJuego.instancia._triatlon)
        {
            SceneManager.LoadScene(7);
        }
        else
        {
           SceneManager.LoadScene(3);
        }
    }


}
