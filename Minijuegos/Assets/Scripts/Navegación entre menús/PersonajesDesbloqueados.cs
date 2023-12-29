using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajesDesbloqueados : MonoBehaviour
{
    public GameObject _personajeA;
    public GameObject _personajeB;
    public GameObject _personajeC;
    public GameObject _personajeD;

    private Image _imgA;
    private Image _imgB;
    private Image _imgC;
    private Image _imgD;

    // Start is called before the first frame update
    void Start()
    {
        _imgA = _personajeA.GetComponent<Image>();
        _imgB = _personajeB.GetComponent<Image>();
        _imgC = _personajeC.GetComponent<Image>();
        _imgD = _personajeD.GetComponent<Image>();

        BloquearSilueta();
    }

    private void BloquearSilueta()
    {
        if(!ControladorJuego.instancia._personajeA)
        {
            _imgA.color = Color.black;
        }
        if(!ControladorJuego.instancia._personajeB)
        {
            _imgB.color = Color.black;
        }
        if (!ControladorJuego.instancia._personajeC)
        {
            _imgC.color = Color.black;
        }
        if (!ControladorJuego.instancia._personajeD)
        {
            _imgD.color = Color.black;
        }
    }
}
