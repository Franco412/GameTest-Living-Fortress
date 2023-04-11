using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    GameObject[] spawnPoints;
    [SerializeField] float velocidad=100;
     float posicionFinal;    // posicion de ataque de la fortaleza
    [SerializeField] int vidaMax =100;
    [SerializeField] int vidaActual;
   
    [SerializeField] TiposEnemigo tipoEnemigo;
    void Start()
    {
        vidaActual = vidaMax; 
        posicionFinal = GameObject.Find("FinalPositionEnemy").transform.position.x; 
    }

   
    void Update()
    {
        if (transform.position.x >= posicionFinal)
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        if (vidaActual <= 0)
        {
            Destroy(gameObject); 
        }   
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ataque")){
            if (tipoEnemigo == TiposEnemigo.NoMuerto)
            { 
                if (other.gameObject.GetComponent<Ataques_Generico>().tipoDaño == tiposDaño.Sagrado)
                {
                    vidaActual -= 50;
                } else if (other.gameObject.GetComponent<Ataques_Generico>().tipoDaño == tiposDaño.Normal) {

                    vidaActual -= 10;
                }
            }
            else if (tipoEnemigo == TiposEnemigo.PielVerde)
            {
                if (other.gameObject.GetComponent<Ataques_Generico>().tipoDaño == tiposDaño.Perforante)
                {
                    vidaActual -= 50;
                }
                else if (other.gameObject.GetComponent<Ataques_Generico>().tipoDaño == tiposDaño.Normal)
                {

                    vidaActual -= 10;
                }
            }

            Destroy(other.gameObject);
        }

    }
}
