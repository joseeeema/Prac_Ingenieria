using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorOpciones : MonoBehaviour
{
    public AudioMixer mezclador;

    public GameObject panel;
    public GameObject botones;

    [SerializeField] private Slider sliderBrillo;
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderSonido;

    public TMP_Text autoGuardado;

    private void Start()
    {
        sliderBrillo.value = OpcionesEscenas.instance._nivelBrillo;
        sliderMusica.value = OpcionesEscenas.instance._volumenMusica;
        sliderSonido.value = OpcionesEscenas.instance._volumenSonido;
    }

    public void CambiarVolumenMusica(float volumenMusica)
    {
        mezclador.SetFloat("volumenMusica", volumenMusica);
    }

    public void CambiarVolumenSonido(float volumenSonido)
    {
        mezclador.SetFloat("volumenSonido", volumenSonido);
    }

    public void CambiarBrillo(float intensidad)
    {
        OpcionesEscenas.instance._nivelBrillo = intensidad;
    }

    public void MostrarOpciones()
    {
        botones.SetActive(false);      
        panel.SetActive(true);
    }

    public void OcultarOpciones()
    {
        botones.SetActive(true);     
        panel.SetActive(false);
    }

    public void ModificarDirtyFlag()
    {
        ControladorJuego.instancia._dirtyFlag = !ControladorJuego.instancia._dirtyFlag;
        if(ControladorJuego.instancia._dirtyFlag)
        {
            autoGuardado.text = "Desactivar";
            ControladorJuego.instancia.GuardarDatos();
        }
        else
        {
            autoGuardado.text = "Activar";
        }
    }
}
