using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador2 : MonoBehaviour, IMovible
{
    public float _velocidad;
    private bool _enMovimiento;
    private Vector3 _direccionDestino;
    private Vector3 _destino;

    public GameObject _camara;
    private Camara _camaraMovible;
    public Vector3 _offset;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _camara = GameObject.FindWithTag("MainCamera");
        _camaraMovible = _camara.GetComponent<Camara>();
        _offset = transform.position - _camara.transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool enMovimiento()
    {
        return _enMovimiento;
    }

    public void Mover(Vector3 direccion)
    {
        if (!_enMovimiento)
        {
            _direccionDestino = new Vector3(direccion.x * transform.right.x, 0, direccion.z * transform.forward.z).normalized;
            _destino = transform.position + _direccionDestino * 1.05f;
            _enMovimiento = true;
        }
    }

    private void FixedUpdate()
    {
        if (_enMovimiento)
        {
            transform.position += _direccionDestino * _velocidad * Time.fixedDeltaTime;
        }
        if (Vector3.Distance(transform.position, _destino) <= 0.05f)
        {
            transform.position = _destino;
            _enMovimiento = false;
        }

        _rigidbody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _enMovimiento = false;
        _camaraMovible._enMovimiento = false;
        _camaraMovible.transform.position = (transform.position - _offset);
    }

    private void OnCollisionStay(Collision collision)
    {
        _enMovimiento = false;
        _camaraMovible._enMovimiento = false;
        _camaraMovible.transform.position = (transform.position - _offset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Llave")
        {
            other.gameObject.SetActive(false);
            GestorLaberinto.instancia.LlaveRecogida();
        }
    }
}

