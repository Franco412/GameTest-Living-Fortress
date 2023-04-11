using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocidad;
    SpriteRenderer limiteJugadorMesh;
    Vector3 limiteJugadorMax;
    Vector3 limiteJugadorMin;

    Animator playerAnim;

    Rigidbody PlayerRB;

    void Start()
    {
        limiteJugadorMesh = GameObject.Find("LimiteJugador").GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

        PlayerRB = GetComponent<Rigidbody>(); 
        // limites del Mesh Render
        limiteJugadorMax = limiteJugadorMesh.bounds.max;
        limiteJugadorMin = limiteJugadorMesh.bounds.min;
        Debug.Log(limiteJugadorMax);
        Debug.Log(limiteJugadorMin);
    }

    
    void Update()
    {
        MovimientoJugador();
        LimitarMovimientoJugador();

    }

    // Movimiento Vertical y Horizontal del jugador
    void MovimientoJugador()
    {
        float Movimiento_Horizontal = Input.GetAxisRaw("Horizontal");  
        float Movimiento_Vertical = Input.GetAxisRaw("Vertical");

        //PlayerRB.AddForce(new Vector3(Movimiento_Horizontal, 0, Movimiento_Vertical) * velocidad); //por fuerzas
        transform.Translate(new Vector3(Movimiento_Horizontal, Movimiento_Vertical, 0) * velocidad * Time.deltaTime,Space.World); // Por cordenadas
        /*if (Movimiento_Horizontal!=0 || Movimiento_Vertical!=0)
        {
            playerAnim.SetFloat("Caminar", 1);
        }
        else
        {
            playerAnim.SetFloat("Caminar", -1);
        }*/
        //playerAnim.Play("Player_Caminar");
    }


    // Condicionales que limitan al jugador 
    void LimitarMovimientoJugador()  
    {
        
        if (transform.position.y >= limiteJugadorMax.y)
        {
            transform.position = new Vector3(transform.position.x, limiteJugadorMax.y, transform.position.z);
            
        }
        if (transform.position.x >= limiteJugadorMax.x)
        {
            transform.position = new Vector3(limiteJugadorMax.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y <= limiteJugadorMin.y)
        {
            transform.position = new Vector3(transform.position.x, limiteJugadorMin.y, transform.position.z);
        }
        if (transform.position.x <= limiteJugadorMin.x)
        {
            transform.position = new Vector3(limiteJugadorMin.x, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Poder"))
        {

            Destroy(other.gameObject); 
        }
    }
}
