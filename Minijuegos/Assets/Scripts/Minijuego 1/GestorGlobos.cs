using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GestorGlobos : MonoBehaviour
{
    // Patrón Singleton para hacer este objeto accesible desde cualquier script de la escena
    public static GestorGlobos instancia { get; private set; }
    public int limiteInflar;

    [SerializeField] 
    private GameObject _pantallaVictoria;
    [SerializeField] 
    private TMP_Text _porcentajeExito;
    [SerializeField]
    private TMP_Text _comentario;
    [SerializeField]
    private GameObject _pantallaDerrota;
    [SerializeField]
    private GameObject _panelPausa;

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

    [SerializeField]
    private AudioSource _reproductor;
    [SerializeField]
    private AudioClip _clipAudio;
    [SerializeField]
    private AudioMixer mezclador;

    private void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        mezclador.SetFloat("volumenMusica", OpcionesEscenas.instance._volumenMusica);
        mezclador.SetFloat("volumenSonido", OpcionesEscenas.instance._volumenSonido);
        GenerarLimite();
        StartCoroutine(CuentaAtras());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
        if(ControladorJuego.instancia._triatlon)
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

    private void GenerarLimite()
    {
        limiteInflar = Random.Range(25, 40);
    }

    public void Derrota()
    {
        _pantallaDerrota.SetActive(true);
        juegoBloqueado = true;
    }

    public void Victoria(int puntuacion)
    {
        juegoBloqueado = true;
        _pantallaVictoria.SetActive(true);

        float porcentaje = ((float) ((float) puntuacion / (float) (limiteInflar - 1)) * 100);
        int porcentajeRedondeado = Mathf.RoundToInt(porcentaje);
        _porcentajeExito.text = porcentajeRedondeado.ToString()+"%";

        if(ControladorJuego.instancia._triatlon)
        {
            ControladorJuego.instancia.porcentajeJ1 = porcentajeRedondeado;
        }

        if(porcentaje < 65)
        {
            _comentario.text = "Aunque no hayas explotado el globo, tampoco has hecho un gran trabajo... ¡Trata de esforzarte más la próxima vez!";
        }
        if(porcentaje >= 65 && porcentaje < 85)
        {
            _comentario.text = "¡Enhorabuena! A la próxima puedes intentar arriesgarte un poco más...";
        }
        if(porcentaje >=85 && porcentaje < 95)
        {
            _comentario.text = "¡Buen trabajo, felicidades! Has estado cerca de inflar el globo al máximo.";
        }
        if(porcentaje >= 95)
        {
            _comentario.text = "¡Impecable, eres un as! Casi la lías, pero has sabido cuando parar, ¡qué control tan ideal!";
            if(porcentaje == 100)
            {
                ControladorJuego.instancia.datosGuardado._desbloqueado2 = true;
                ControladorJuego.instancia.GuardarDatos();
            }
        }
    }

    IEnumerator CuentaAtras()
    {
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        yield return new WaitForSeconds(1f);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        _tres.SetActive(false);
        _dos.SetActive(true);
        yield return new WaitForSeconds(1f);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        _dos.SetActive(false);
        _uno.SetActive(true);
        yield return new WaitForSeconds(1f);
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        _uno.SetActive(false);
        _objetivo.SetActive(true);
        yield return new WaitForSeconds(1f);
        _objetivo.SetActive(false);
        juegoBloqueado = false;
    }


}
