using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemillaLaberinto : MonoBehaviour
{
    [SerializeField] private GameObject _laberintoA;
    [SerializeField] private GameObject _laberintoB;
    [SerializeField] private GameObject _laberintoC;
    [SerializeField] private Vector3[] _posicionesJugador;
    [SerializeField] private Vector3[] _posicionesLlave;

    private int _seed;

    public GameObject jugador;
    public GameObject llave;
    [SerializeField] private GameObject camara;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = jugador.transform.position - camara.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        _seed = Random.Range(0, 11);
        EscogerMapa();
        ColocarJugador();
        ColocarLlave();
    }

    private void EscogerMapa()
    {
        if(_seed<4)
        {
            _laberintoA.SetActive(true);
        }
        else if(_seed<8)
        {
            _laberintoB.SetActive(true);
        }
        else
        {
            _laberintoC.SetActive(true);
        }
    }

    private void ColocarJugador()
    {
        jugador.transform.position = _posicionesJugador[_seed];
        camara.transform.position = jugador.transform.position + _offset;
    }

    private void ColocarLlave()
    {
        llave.transform.position = _posicionesLlave[_seed];
    }
    
}
