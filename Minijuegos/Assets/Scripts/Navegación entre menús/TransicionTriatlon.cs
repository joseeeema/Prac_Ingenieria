using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionTriatlon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transicion());
    }

    IEnumerator Transicion()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene(4);
    }

}
