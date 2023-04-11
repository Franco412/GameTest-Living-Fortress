using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemigosPrefab; 
    [SerializeField] Transform[] spawnEnemyPosition;
    [SerializeField] float tiempoGenerarEnemigos;
    void Start()
    {
        AsignarSpawnEnemigos();
        //InvokeRepeating("GenerarEnemigos", 2, 1);
        StartCoroutine(GenerarEnemigos(tiempoGenerarEnemigos));
    }

    
    void Update()
    {
       
        
    }



    void AsignarSpawnEnemigos()     // Selecionar los puntos de Spawn de los enemigos
    {
        spawnEnemyPosition = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnEnemyPosition[i] = transform.GetChild(i);

        }
    }

    IEnumerator GenerarEnemigos(float segundos)
    {

        while (true)
        {
            int numeroSpawn = Random.Range(0, transform.childCount);
            int numeroEnemigo = Random.Range(0, enemigosPrefab.Length);
            yield return new WaitForSeconds(segundos);
            Instantiate(enemigosPrefab[numeroEnemigo], spawnEnemyPosition[numeroSpawn].position, enemigosPrefab[numeroEnemigo].transform.rotation);
        }


    }
    
}
