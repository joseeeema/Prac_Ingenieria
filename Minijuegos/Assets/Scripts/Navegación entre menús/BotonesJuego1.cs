using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesJuego1 : MonoBehaviour
{
    public void Continuar()
    {
        if(ControladorJuego.instancia._triatlon)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
