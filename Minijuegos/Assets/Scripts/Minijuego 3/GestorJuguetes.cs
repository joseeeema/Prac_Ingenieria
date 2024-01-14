using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GestorJuguetes : MonoBehaviour
{
    public static GestorJuguetes instancia;

    [SerializeField] private GameObject obstaculo_caballo;
    [SerializeField] private GameObject obstaculo_cohete;
    [SerializeField] private GameObject obstaculo_pato;
    [SerializeField] private GameObject obstaculo_coche;
    [SerializeField] private GameObject oso_peluche;

    private float _tiempoGeneracion = 4f;
    private int semilla;
    private int obstaculo;

    public int numObstaculosGenerados = 0;

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

    // Pantalla de final
    [SerializeField]
    private GameObject _pantallaFin;
    [SerializeField]
    private Temporizador2 tiempo;
    [SerializeField]
    private TMP_Text _resultado;
    [SerializeField]
    private TMP_Text _comentario;

    [SerializeField]
    private AudioSource _reproductor;
    [SerializeField]
    private AudioClip _clipAudio;
    [SerializeField]
    private AudioMixer mezclador;

    [SerializeField]
    private GameObject _panelPausa;


    private void Awake()
    {
        instancia = this;
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
        if(numObstaculosGenerados>10)
        {
            _tiempoGeneracion = 3.75f;
        }
        if(numObstaculosGenerados>20)
        {
            _tiempoGeneracion = 3.5f;
        }
        if(numObstaculosGenerados>30)
        {
            _tiempoGeneracion = 3.25f;
        }
        if (numObstaculosGenerados > 40)
        {
            _tiempoGeneracion = 3f;
        }
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

    IEnumerator GenerarObstaculo()
    {
        semilla = Random.Range(0, 3);
        float _ejeX = 0;
        switch (semilla) {
            case 0:
                _ejeX = -10;
                break;
            case 1:
                _ejeX = 0;
                break;
            case 2:
                _ejeX = 10;
                break;
        }
        obstaculo = Random.Range(0, 61);
        if(obstaculo < 15 && !GestorJuguetes.instancia.juegoBloqueado)
        {
            Instantiate(obstaculo_caballo, new Vector3(_ejeX, 2.5f, -45f), Quaternion.EulerRotation(-3.1419f / 2f, 0f, 0f));
        }
        else if(obstaculo < 30 && !GestorJuguetes.instancia.juegoBloqueado)
        {
            Instantiate(obstaculo_cohete, new Vector3(_ejeX, 8f, -45f), Quaternion.EulerRotation(0f, -3.1419f, 0f));
        }
        else if(obstaculo < 45 && !GestorJuguetes.instancia.juegoBloqueado)
        {
            Instantiate(obstaculo_pato, new Vector3(_ejeX, 0f, -45f), Quaternion.identity);
        }
        else if(obstaculo < 60 && !GestorJuguetes.instancia.juegoBloqueado)
        {
            Instantiate(obstaculo_coche, new Vector3(_ejeX, 0f, -45f), Quaternion.identity);
        }
        else if(obstaculo >= 60 && !GestorJuguetes.instancia.juegoBloqueado)
        {
            Instantiate(oso_peluche, new Vector3(_ejeX, 0f, -45f), Quaternion.identity);
            Debug.Log("Oso de peluche");
        }

        numObstaculosGenerados++;
        yield return new WaitForSeconds(_tiempoGeneracion);
        StartCoroutine(GenerarObstaculo());
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
        StartCoroutine(GenerarObstaculo());
    }

    public void FinJuego()
    {
        _pantallaFin.SetActive(true);
        tiempo.Desaparecer();
        juegoBloqueado = true;

        if (ControladorJuego.instancia._triatlon)
        {
            ControladorJuego.instancia.minutosJ3 = tiempo.minutosTranscurridos;
            ControladorJuego.instancia.segundosJ3 = tiempo.segundosTranscurridos;
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

        if (tiempo.minutosTranscurridos == 0)
        {
            _comentario.text = "¡Mala suerte! No has podido seguirle el ritmo a estos juguetes...";
        }
        else if (tiempo.minutosTranscurridos == 1)
        {
            _comentario.text = "¡No está mal! A la próxima intenta ser más espabilado.";
        }
        else if (tiempo.minutosTranscurridos == 2)
        {
            _comentario.text = "¡Vaya, felicidades! Has cogido soltura con esto de esquivar los juguetes, buen trabajo.";
        }
        else
        {
            _comentario.text = "¡Increíble, enhorabuena! Has obtenido un resultado admirable. ¿Has conseguido encontrar el oso de peluche?";
        }
    }
}
