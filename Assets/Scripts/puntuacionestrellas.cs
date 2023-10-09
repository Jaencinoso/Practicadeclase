using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntuacionestrellas : MonoBehaviour
{
    private int puntaje;
    public Text puntajeText;
    // Start is called before the first frame update
    void Start()
    {
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Estrellas")
        {
            puntaje++;
            puntajeText.text = "" + puntaje;
        }
    }
}
