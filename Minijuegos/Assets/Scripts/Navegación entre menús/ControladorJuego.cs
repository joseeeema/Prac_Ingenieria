using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public static ControladorJuego instancia;
    // Controla el modo de juego seleccionado
    public bool _triatlon = false;
    // Personaje escogido
    public int _personaje = 0;
    // Puntuaciones obtenidas en los minijuegos en el triatlon
    public int porcentajeJ1;
    public int minutosJ2;
    public int segundosJ2;
    public int minutosJ3;
    public int segundosJ3;

    // Implementación del patrón dirtyFlag
    public bool _dirtyFlag = true;

    public EstructuraGuardado datosGuardado;

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
        // Al comienzo de cada partida, se cargan los datos de guardado del fichero de texto
        string ruta = Directory.GetCurrentDirectory() + "/Save";
        datosGuardado = JsonUtility.FromJson<EstructuraGuardado>(File.ReadAllText(ruta));
    }

    public void GuardarDatos()
    {
        // En el caso de que la variable dirtyFlag sea false, se evita todo el proceso de autoguardado cada vez que se intente
        if(!_dirtyFlag)
        {
            return;
        }
        else
        {
            // Crear ruta de guardado
            string ruta = Directory.GetCurrentDirectory() + "/Save";
            // Escribimos todo el texto en un archivo externo
            File.WriteAllText(ruta, JsonUtility.ToJson(datosGuardado, true));
        }
    }
}

[System.Serializable]
public class EstructuraGuardado
{
    // Records minijuegos
    public int _recordPuntosJ1 = 0;
    public int _recordMinutosJ2 = 10;
    public int _recordSegundosJ2 = 0;
    public int _recordMinutosJ3 = 0;
    public int _recordSegundosJ3 = 0;

    // Personajes desbloqueados
    public bool _desbloqueado2 = false;
    public bool _desbloqueado3 = false;
    public bool _desbloqueado4 = false;

    // Variables desbloqueo
    public int _vecesTriatlon = 0;

    // Record triatlón
    public float _recordTriatlon = 0;
}
