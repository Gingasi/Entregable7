using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    // A continuación los datos que limitan y establecen los lugares de instanciación de laos prefabs que instanciaremos según una lista 
    public GameObject[] FlipFlapprefabs;
    private Vector3 spawnPosition;
    private float xRight = 19f;
    private float xLeft = -19f;
    private float yUp = 14f;
    private float yDown = 5;
    private float startTime = 2f;
    private float repeatRate = 1.5f;
    private float randomX;
    private float randomY;
    private int randomIndex;
    private Quaternion Rotte180 = Quaternion.Euler(0, 180, 0);


    private PlayerController PlayerControllerScript;


    void Start()
    {
        InvokeRepeating("SpawnFlipFlap", startTime, repeatRate); // Cada cuanto tiempo queremos que repita la instanciación
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

    

    public Vector3 RandomSpawnPosition() //Con esta función indicamos que queremos que se spawneen en lugares aleatorios pero siempre en los extremos, nunca en el centro
    {

       int RandomSpawn = Random.Range(0, 2);
        randomY = Random.Range(yDown, yUp);
        randomX = Random.Range(xLeft, xRight);

        if (RandomSpawn == 0)
        {
            return new Vector3(xLeft, randomY, 0);
        }
        else 
        {
            return new Vector3(xRight, randomY, 0);
        }

    }

    public void SpawnFlipFlap() // Esta función es la que dice que se instancie los objetos previamente metidos en el array. Así como también indicamos que queremos que dependiendo del lado del que salga rote su eje en Y para moverse dentro del mapa hacia la derecha
    {
        randomIndex = Random.Range(0, FlipFlapprefabs.Length);
        spawnPosition = RandomSpawnPosition();
        



        if (spawnPosition.x <= 0)  
        {
            Instantiate(FlipFlapprefabs[randomIndex], spawnPosition,
            FlipFlapprefabs[randomIndex].transform.rotation);
        }
        else
        {
            Instantiate(FlipFlapprefabs[randomIndex], spawnPosition,
            Rotte180);
        }


        if (PlayerControllerScript.gameOver)
        {
            CancelInvoke();
        }
    }
}
