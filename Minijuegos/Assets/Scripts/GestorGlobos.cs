using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorGlobos : MonoBehaviour
{
    public static GestorGlobos instancia;
    public int limiteInflar;
    // De esta forma, se controlan los globos que siguen activos y los que no
    public bool globoA = true;
    public bool globoB = true;
    public bool globoC = true;
    public bool globoD = true;

    private void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        GenerarLimite();
    }

    private void GenerarLimite()
    {
        limiteInflar = Random.Range(25, 40);
    }


}
