using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPersonaje : MonoBehaviour
{
    public float movX, movY;
    public float fuerzaSalto = 4;
    public bool quiereSaltar = false;
    Rigidbody2D fisicas;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            quiereSaltar = true;
        }
    }
    void FixedUpdate()
    {
        Vector2 movimiento = new Vector2(movX * 2, fisicas.velocity.y);
        fisicas.velocity = movimiento;

        if (quiereSaltar)
        {
            fisicas.AddForce( Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            quiereSaltar = false;
        }
    }
}
