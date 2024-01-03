using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesJuego3 : MonoBehaviour
{
    public void Continuar()
    {
        if (ControladorJuego.instancia._triatlon)
        {
            // Si se completa el triatlon 3 veces, se desbloquea el personaje 2
            ControladorJuego.instancia.datosGuardado._vecesTriatlon++;
            if(ControladorJuego.instancia.datosGuardado._vecesTriatlon>=3)
            {
                ControladorJuego.instancia.datosGuardado._desbloqueado4 = true;
            }
            ControladorJuego.instancia.GuardarDatos();
            SceneManager.LoadScene(8);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
