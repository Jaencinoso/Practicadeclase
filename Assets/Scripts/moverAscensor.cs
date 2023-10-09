using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverAscensor : MonoBehaviour
{
    public int velocidad;
    bool haciaArriba = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1.5)
        {
            haciaArriba = false;
        }
        else if (transform.position.y < -1.5)
        {
            haciaArriba = true;
        }

        if (haciaArriba == true)
        {
            transform.Translate(velocidad * Vector2.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(velocidad * Vector2.down * Time.deltaTime);
        }
    }
}
