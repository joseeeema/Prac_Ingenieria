using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinTriatlon : MonoBehaviour
{
    public TMP_Text _resultado1;
    public TMP_Text _resultado2;
    public TMP_Text _resultado3;

    public GameObject _record1;
    public GameObject _record2;
    public GameObject _record3;
    public GameObject _recordFinal;

    public TMP_Text _puntuacion1;
    public TMP_Text _puntuacion2;
    public TMP_Text _puntuacion3;

    public TMP_Text _puntuacionTotal;
    public int puntuacionTotal;

    public GameObject[] skins;


    // Start is called before the first frame update
    void Start()
    {
        // Se muestra al personaje correcto
        skins[ControladorJuego.instancia._personaje].SetActive(true);

        _resultado1.text = ControladorJuego.instancia.porcentajeJ1.ToString() + "%";
        if(ControladorJuego.instancia.segundosJ2<10)
        {
            _resultado2.text = ControladorJuego.instancia.minutosJ2.ToString() + ":0" + ControladorJuego.instancia.segundosJ2.ToString();
        }
        else
        {
            _resultado2.text = ControladorJuego.instancia.minutosJ2.ToString() + ":" + ControladorJuego.instancia.segundosJ2.ToString();
        }
        if(ControladorJuego.instancia.segundosJ3<10)
        {
            _resultado3.text = ControladorJuego.instancia.minutosJ3.ToString() + ":0" + ControladorJuego.instancia.segundosJ3.ToString();
        }
        else
        {
            _resultado3.text = ControladorJuego.instancia.minutosJ3.ToString() + ":" + ControladorJuego.instancia.segundosJ3.ToString();
        }

        // Asignación de puntuaciones

        int puntos1 = 0;

        if(ControladorJuego.instancia.porcentajeJ1 <=50)
        {
            puntos1 = ControladorJuego.instancia.porcentajeJ1 * 5;
        }
        if(ControladorJuego.instancia.porcentajeJ1 > 50 && ControladorJuego.instancia.porcentajeJ1 <= 80)
        {
            int aux;
            aux = ControladorJuego.instancia.porcentajeJ1 - 50;
            aux *= (int) 11.66;
            puntos1 = aux + 250;
        }
        if(ControladorJuego.instancia.porcentajeJ1 > 80)
        {
            int aux;
            aux = ControladorJuego.instancia.porcentajeJ1 - 80;
            aux *= 20;
            puntos1 = aux + 600;
        }

        _puntuacion1.text = "+" + puntos1.ToString() + " puntos";

        int puntos2 = 0;
        int aux2;

        aux2 = ControladorJuego.instancia.minutosJ2 * 60 + ControladorJuego.instancia.segundosJ2;
        if(aux2 <= 40)
        {
            puntos2 = 1000;
        }
        else
        {
            puntos2 = 1000 - (int)((aux2 - 40) * 8.33);
            if(puntos2<0)
            {
                puntos2 = 0;
            }
        }

        _puntuacion2.text = "+" + puntos2.ToString() + " puntos";

        int puntos3 = 0;
        int aux3;

        aux3 = ControladorJuego.instancia.minutosJ3 * 60 + ControladorJuego.instancia.segundosJ3;
        if(aux3 <= 30)
        {
            puntos3 = aux3 * 5;
        }
        if(aux3 <= 90 && aux3 >30)
        {
            puntos3 = (int) ((aux3 - 30) * 7.5 + 150);
        }
        if(aux3 >90)
        {
            puntos3 = (int)((aux3 - 90) * 3.3333 + 600);
            if(puntos3 > 1000)
            {
                puntos3 = 1000;
            }
        }

        _puntuacion3.text = "+" + puntos3.ToString() + " puntos";

        puntuacionTotal = puntos1 + puntos2 + puntos3;
        _puntuacionTotal.text = "Puntos totales - " + puntuacionTotal.ToString();

        // Control de records
        if(ControladorJuego.instancia.porcentajeJ1 > ControladorJuego.instancia.datosGuardado._recordPuntosJ1)
        {
            _record1.SetActive(true);
            ControladorJuego.instancia.datosGuardado._recordPuntosJ1 = ControladorJuego.instancia.porcentajeJ1;
        }
        if( (ControladorJuego.instancia.minutosJ2 < ControladorJuego.instancia.datosGuardado._recordMinutosJ2)||
                ((ControladorJuego.instancia.minutosJ2==ControladorJuego.instancia.datosGuardado._recordMinutosJ2)&& (ControladorJuego.instancia.segundosJ2<ControladorJuego.instancia.datosGuardado._recordSegundosJ2)))
        {
            _record2.SetActive(true);
            ControladorJuego.instancia.datosGuardado._recordMinutosJ2 = ControladorJuego.instancia.minutosJ2;
            ControladorJuego.instancia.datosGuardado._recordSegundosJ2 = ControladorJuego.instancia.segundosJ2;
        }
        if ((ControladorJuego.instancia.minutosJ3 > ControladorJuego.instancia.datosGuardado._recordMinutosJ3) ||
                ((ControladorJuego.instancia.minutosJ3 == ControladorJuego.instancia.datosGuardado._recordMinutosJ3) && (ControladorJuego.instancia.segundosJ3 > ControladorJuego.instancia.datosGuardado._recordSegundosJ3)))
        {
            _record3.SetActive(true);
            ControladorJuego.instancia.datosGuardado._recordMinutosJ3 = ControladorJuego.instancia.minutosJ3;
            ControladorJuego.instancia.datosGuardado._recordSegundosJ3 = ControladorJuego.instancia.segundosJ3;
        }
        if(puntuacionTotal > ControladorJuego.instancia.datosGuardado._recordTriatlon)
        {
            _recordFinal.SetActive(true);
            ControladorJuego.instancia.datosGuardado._recordTriatlon = puntuacionTotal;
        }
        // Se guardan los records sobreescritos sobre el fichero si dirtyFlag == true
        ControladorJuego.instancia.GuardarDatos();
    }

    
    public void VolverMenu()
    {
        SceneManager.LoadScene(0);
    }
}
