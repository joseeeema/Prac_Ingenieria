using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador3 : MonoBehaviour
{
    private int _numVidas = 3;
    public GameObject[] skins;
    [SerializeField] private GameObject[] _vidas;
    [SerializeField]
    private AudioSource _reproductor;
    [SerializeField]
    private AudioClip _clipAudio;

    // Start is called before the first frame update
    void Start()
    {
        skins[ControladorJuego.instancia._personaje].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GestorJuguetes.instancia.juegoBloqueado)
        {
            Desplazamiento();
        }
        transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
    }

    private void Desplazamiento()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.x>=-3)
            {
                transform.position = new Vector3(transform.position.x - 10, 4.5f, transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x <= 1)
            {
                transform.position = new Vector3(transform.position.x + 10, 4.5f, transform.position.z);
            }
        }
    }

    private void FinJuego()
    {
        GestorJuguetes.instancia.FinJuego();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstáculo")
        {
            Destroy(collision.gameObject);
            ReducirVidas();
        }
        if(collision.gameObject.tag == "Peluche")
        {
            // Desbloquear el personaje 3
            ControladorJuego.instancia.datosGuardado._desbloqueado3 = true;
            ControladorJuego.instancia.GuardarDatos();
            Destroy(collision.gameObject);
        }
    }

    public void ReducirVidas()
    {
        GestorMúsica.PonerMusica(_clipAudio, _reproductor, false);
        _numVidas--;
            _vidas[_numVidas].SetActive(false);
            if(_numVidas == 0)
            {
                FinJuego();
            }

    }


}
