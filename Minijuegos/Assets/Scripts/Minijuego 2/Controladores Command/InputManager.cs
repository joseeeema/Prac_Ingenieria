using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private IMovible _jugador;
    private IMovible _camara;
    private List<IMovible> _movibles = new List<IMovible>();
    private CommandManager _commandManager;

    private void Awake()
    {
        // Asignación de variables
        _commandManager = new CommandManager();
        _jugador = GameObject.FindWithTag("Jugador").GetComponent<Jugador2>();
        _movibles.Add(_jugador);
        _camara = GameObject.FindWithTag("MainCamera").GetComponent<Camara>();
        _movibles.Add(_camara);
    }


    // Update is called once per frame
    void Update()
    {
        // Esta clase se encarga de recoger las entradas del usuario, para mandar ejecutar las acciones a CommandManager

        if((_jugador.enMovimiento()&&Input.anyKey)||(GestorLaberinto.instancia.juegoBloqueado))
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            ICommand comando = new MovimientoDelante(_movibles);
            _commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ICommand comando = new MovimientoAtrás(_movibles);
            _commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            ICommand comando = new MovimientoIzquierda(_movibles);
            _commandManager.EjecutarComando(comando);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ICommand comando = new MovimientoDerecha(_movibles);
            _commandManager.EjecutarComando(comando);
        }

    }
}
