using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesPersonajes : MonoBehaviour
{
    [SerializeField] private GameObject _selectedA;
    [SerializeField] private GameObject _selectedB;
    [SerializeField] private GameObject _selectedC;
    [SerializeField] private GameObject _selectedD;

    public void SeleccionPersonajeA()
    {
        if(ControladorJuego.instancia._personajeA)
        {
            _selectedA.SetActive(true);
            _selectedB.SetActive(false);
            _selectedC.SetActive(false);
            _selectedD.SetActive(false);
            ControladorJuego.instancia._personaje = 0;
        }
    }

    public void SeleccionPersonajeB()
    {
        if (ControladorJuego.instancia._personajeB)
        {
            _selectedB.SetActive(true);
            _selectedA.SetActive(false);
            _selectedC.SetActive(false);
            _selectedD.SetActive(false);
            ControladorJuego.instancia._personaje = 1;
        }
    }

    public void SeleccionPersonajeC()
    {
        if (ControladorJuego.instancia._personajeC)
        {
            _selectedC.SetActive(true);
            _selectedB.SetActive(false);
            _selectedA.SetActive(false);
            _selectedD.SetActive(false);
            ControladorJuego.instancia._personaje = 2;
        }
    }

    public void SeleccionPersonajeD()
    {
        if (ControladorJuego.instancia._personajeD)
        {
            _selectedD.SetActive(true);
            _selectedB.SetActive(false);
            _selectedA.SetActive(false);
            _selectedC.SetActive(false);
            ControladorJuego.instancia._personaje = 3;
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
