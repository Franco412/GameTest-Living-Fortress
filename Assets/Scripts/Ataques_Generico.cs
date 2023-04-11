using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataques_Generico : MonoBehaviour
{
    [SerializeField] float velocidad =10;
   // public enum tipos {Normal,Perforante,Sagrado};
    public tiposDaño tipoDaño;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);

        if (transform.position.x>=16)
        {
            Destroy(gameObject); 

        }
    }
}
