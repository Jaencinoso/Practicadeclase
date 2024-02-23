using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moverPersonaje : MonoBehaviour
{
    public int velocidad = 2;
    public float movX, movY;
    public float fuerzaSalto = 4;
    public bool quiereSaltar = false;
    public bool estaSuelo = false;
    public bool damage = false;
    public bool hacersePequeño = false;
    public static bool fail = false;
    public AudioSource FX1;
    public AudioSource FX2;
    public AudioSource FX3;
    public AudioSource FX4;
    public AudioSource FX5;
    public GameObject puerta;
    private Rigidbody2D fisicas;
    SpriteRenderer rbsprite;
    private bool cambiarCara = true;
    public Animator animator;
    private bool estaSuelos;
    public Transform pies;
    public float area;
    public LayerMask aquiSuelos;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        rbsprite = GetComponent<SpriteRenderer>();
        FX1 = GameObject.Find("Monedas").GetComponent<AudioSource>();
        FX2 = GameObject.Find("Salto").GetComponent<AudioSource>();
        FX3 = GameObject.Find("Daño").GetComponent<AudioSource>();
        FX4 = GameObject.Find("Meta").GetComponent<AudioSource>();
        FX5 = GameObject.Find("Tema Principal").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");

        Vector2 direccion = new Vector2(movX, movY);

        if (Input.GetButtonDown("Jump"))
        {
            quiereSaltar = true;
            FX2.Play();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        if (movX < 0.0f && cambiarCara)
        {
            FlipPlayer();
        }

        if (movX > 0.0f && !cambiarCara)
        {
            FlipPlayer();
        }

        estaSuelos = Physics2D.OverlapCircle(pies.position, area, aquiSuelos);

        animator.SetBool("estaSuelos", estaSuelos);
    }
    void FixedUpdate()
    {
        animator.SetFloat("Velocidad", Mathf.Abs(movX));
       
        Vector2 movimiento = new Vector2(movX * velocidad, fisicas.velocity.y);
        fisicas.velocity = movimiento;

        if (quiereSaltar && estaSuelo)
        {
            fisicas.AddForce( Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            quiereSaltar = false;
            estaSuelo = false;
        }
    }
    void Cooldown()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        rbsprite.color = Color.white; 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            estaSuelo |= true;
        }
        else if (collision.gameObject.tag == "Pinchos")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Cooldown", 2f);
            rbsprite.color = Color.red;
            FX3.Play();
        }
        else if (collision.gameObject.tag == "Giroscopio")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Cooldown", 2f);
            rbsprite.color = Color.red;
            FX3.Play();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monedas")
        {
            Destroy(collision.gameObject);
            FX1.Play();
        }
        else if (collision.gameObject.tag == "Estrellas")
        {
            Destroy(collision.gameObject);
            FX1.Play();
        }
        else if (collision.gameObject.tag == "Powerup")
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector2(0.25f, 0.25f);
            FX1.Play();
        }
        else if (collision.gameObject.tag == "Llave")
        {
            Destroy(collision.gameObject);
            Destroy(puerta);
            FX1.Play();
        }
        else if (collision.gameObject.tag == "Meta")
        {
            Time.timeScale = 0;
            FX4.Play();
            FX5.Stop();

        }
    }
    void FlipPlayer()
    {
        cambiarCara = !cambiarCara;
        Vector2 playerScale = gameObject.transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
 

}
