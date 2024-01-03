using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador3 : MonoBehaviour
{
    private int _numVidas = 3;
    [SerializeField] private GameObject[] _vidas;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (transform.position.x <= 0)
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
            // Desbloquear el personaje 4
            ControladorJuego.instancia._personajeD = true;
            Destroy(collision.gameObject);
        }
    }

    public void ReducirVidas()
    {
            _numVidas--;
            _vidas[_numVidas].SetActive(false);
            if(_numVidas == 0)
            {
                FinJuego();
            }

    }


}
