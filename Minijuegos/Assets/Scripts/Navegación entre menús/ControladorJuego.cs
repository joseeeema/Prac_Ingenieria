using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego instancia;
    // Controla el modo de juego seleccionado
    public bool _triatlon = false;
    // Personaje escogido
    public int _personaje = 0;
    // Personajes desbloqueados
    public bool _personajeA = true;
    public bool _personajeB = false;
    public bool _personajeC = false;
    public bool _personajeD = false;

    private void Awake()
    {
        if(instancia==null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // Este Singleton va a ser el gestor de todo el flujo del juego entre escenas
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
