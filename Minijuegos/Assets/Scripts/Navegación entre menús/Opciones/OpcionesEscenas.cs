using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesEscenas : MonoBehaviour
{
    public static OpcionesEscenas instance;

    public float _nivelBrillo = 1f;
    public float _volumenMusica = 0.8f;
    public float _volumenSonido = -8f;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
