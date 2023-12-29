using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesJuego2 : MonoBehaviour
{
    public void Continuar()
    {
        if(ControladorJuego.instancia._triatlon)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
