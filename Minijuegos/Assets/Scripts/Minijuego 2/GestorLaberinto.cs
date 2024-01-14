using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GestorLaberinto : MonoBehaviour
{
    public static GestorLaberinto instancia { get; private set; }
    public bool juegoBloqueado = true;

    // Mensajes que aparecen antes de comenzar el juego (cuenta atrás)
    [SerializeField]
    private GameObject _tres;
    [SerializeField]
    private GameObject _dos;
    [SerializeField]
    private GameObject _uno;
    [SerializeField]
    private GameObject _objetivo;

    // Llave recogida
    [SerializeField]
    private GameObject _llave;
    public bool _llaveRecogida = false;

    // Pantalla de final
    [SerializeField]
    private GameObject _pantallaFin;
    [SerializeField]
    private Temporizador tiempo;
    [SerializeField]
    private TMP_Text _resultado;
    [SerializeField]
    private TMP_Text _comentario;

    [SerializeField]
    private AudioSource _reproductor;
    [SerializeField]
    private AudioClip _clipAudio;
    [SerializeField]
    private AudioClip _clipAudio2;

    [SerializeField]
    private GameObject _panelPausa;
    [SerializeField]
    private AudioMixer mezclador;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mezclador.SetFloat("volumenMusica", OpcionesEscenas.instance._volumenMusica);
        mezclador.SetFloat("volumenSonido", OpcionesEscenas.instance._volumenSonido);
        StartCoroutine(CuentaAtras());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        juegoBloqueado = true;
        _panelPausa.SetActive(true);
    }

    public void VolverMenu()
    {
        if (ControladorJuego.instancia._triatlon)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Continuar()
    {
        juegoBloqueado = false;
        _panelPausa.SetActive(false);
    }

    IEnumerator CuentaAtras()
    {
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        yield return new WaitForSeconds(1f);
        _tres.SetActive(false);
        _dos.SetActive(true);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        yield return new WaitForSeconds(1f);
        _dos.SetActive(false);
        _uno.SetActive(true);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        yield return new WaitForSeconds(1f);
        _uno.SetActive(false);
        _objetivo.SetActive(true);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        yield return new WaitForSeconds(1f);
        _objetivo.SetActive(false);
        juegoBloqueado = false;
    }

    public void LlaveRecogida()
    {
        _llave.SetActive(true);
        _llaveRecogida = true;
        GestorMúsica.PonerMusica(_clipAudio2, _reproductor, false);
    }

    public void FinJuego()
    {
        _pantallaFin.SetActive(true);
        _llave.SetActive(false);
        tiempo.Desaparecer();
        juegoBloqueado = true;

        if (ControladorJuego.instancia._triatlon)
        {
            ControladorJuego.instancia.minutosJ2 = tiempo.minutosTranscurridos;
            ControladorJuego.instancia.segundosJ2 = tiempo.segundosTranscurridos;
        }

        if (tiempo.segundosTranscurridos < 10)
        {
            if (tiempo.minutosTranscurridos < 10)
            {
                _resultado.text = "0" + tiempo.minutosTranscurridos.ToString() + ":0" + tiempo.segundosTranscurridos.ToString();
            }
            else
            {
                _resultado.text = tiempo.minutosTranscurridos.ToString() + ":0" + tiempo.segundosTranscurridos.ToString();
            }
        }
        else
        {
            if (tiempo.minutosTranscurridos < 10)
            {
                _resultado.text = "0" + tiempo.minutosTranscurridos.ToString() + ":" + tiempo.segundosTranscurridos.ToString();
            }
            else
            {
                _resultado.text = tiempo.minutosTranscurridos.ToString() + ":" + tiempo.segundosTranscurridos.ToString();
            }
        }

        if(tiempo.minutosTranscurridos == 0)
        {
            _comentario.text = "¡Enhorabuena! Has conseguido escapar casi volando, te orientas perfectamente en la oscuridad...";
        }
        else if (tiempo.minutosTranscurridos == 1 && tiempo.segundosTranscurridos < 45)
        {
            _comentario.text = "¡Felicidades! Parece que se te da bien esto de los laberintos.";
        }
        else if ((tiempo.minutosTranscurridos == 1 && tiempo.segundosTranscurridos >= 45)||(tiempo.minutosTranscurridos == 2 && tiempo.segundosTranscurridos < 30))
        {
            _comentario.text = "¡Por fin fuera! Te ha costado un poco encontrar la salida...";
        }
        else
        {
            _comentario.text = "¡Vaya! Parecía que no ibas a salir nunca de aquí...";
        }
    }
    


}
