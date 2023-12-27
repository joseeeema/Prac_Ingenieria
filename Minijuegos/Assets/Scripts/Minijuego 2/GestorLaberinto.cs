using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GameObject _llave;
    public bool _llaveRecogida = false;

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
        StartCoroutine(CuentaAtras());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CuentaAtras()
    {
        yield return new WaitForSeconds(1f);
        _tres.SetActive(false);
        _dos.SetActive(true);
        yield return new WaitForSeconds(1f);
        _dos.SetActive(false);
        _uno.SetActive(true);
        yield return new WaitForSeconds(1f);
        _uno.SetActive(false);
        _objetivo.SetActive(true);
        yield return new WaitForSeconds(1f);
        _objetivo.SetActive(false);
        juegoBloqueado = false;
    }

    public void LlaveRecogida()
    {
        _llave.SetActive(true);
        _llaveRecogida = true;
    }
    


}
