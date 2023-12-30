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
            SceneManager.LoadScene(8);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
