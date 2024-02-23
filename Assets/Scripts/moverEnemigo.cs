using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverEnemigo : MonoBehaviour
{
    public int velocidad;
    bool haciaIzquierda = true;
    private Rigidbody2D fisicas;
    public Animator animator;
    private bool chocarCabeza;
    public Transform pies;
    public float area;
    public LayerMask cabezaGoomba;

    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 0.03)
        {
            haciaIzquierda = true;
        }
        else if (transform.position.x < -4.526)
        {
            haciaIzquierda = false;
        }

        if (haciaIzquierda == true)
        {
            transform.Translate(velocidad * Vector2.left * Time.deltaTime);
        }
        else
        {
            transform.Translate(velocidad * Vector2.right * Time.deltaTime);
        }

        chocarCabeza = Physics2D.OverlapCircle(pies.position, area, cabezaGoomba);

        animator.SetBool("chocarCabeza", chocarCabeza);
    }
}   
