using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverPersonaje : MonoBehaviour
{
    public float movX, movY;
    public float fuerzaSalto = 4;
    public bool quiereSaltar = false;
    public bool estaSuelo = false;
    public bool daño = false;
    Rigidbody2D fisicas;
    SpriteRenderer rbsprite;
    float tiempo = 30f;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        rbsprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo -1 * Time.deltaTime;
        movX = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            quiereSaltar = true;
        }
        Debug.Log(tiempo);
    }
    void FixedUpdate()
    {

       
        Vector2 movimiento = new Vector2(movX * 2, fisicas.velocity.y);
        fisicas.velocity = movimiento;

        if (quiereSaltar && estaSuelo)
        {
            fisicas.AddForce( Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            quiereSaltar = false;
            estaSuelo = false;
        }

        if (daño == true)
        {
            ;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            estaSuelo |= true;
        }
        else if (collision.gameObject.tag == "Pinchos")
        {
            daño = true;
        }
        else if (collision.gameObject.tag == "Giroscopio")
        {
            daño = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monedas")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Estrellas")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Meta")
        {
            Time.timeScale = 0;
        }
    }
    

}
