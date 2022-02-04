using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    // A continuación los datos que limitan y establecen los lugares de instanciación de laos prefabs que instanciaremos según una lista 
    public GameObject[] FlipFlapprefabs;
    private Vector3 spawnPosition;
    private float xRange = -19f;
    private float yUp = 14f;
    private float yDown = 5;
    private float startTime = 2f;
    private float repeatRate = 1.5f;
    private float randomX;
    private float randomY;
    private int randomIndex;

    private PlayerController PlayerControllerScript;


    void Start()
    {
        InvokeRepeating("SpawnFlipFlap", startTime, repeatRate); // Cada cuanto tiempo queremos que repita la instanciación
        PlayerControllerScript = FindObjectOfType<PlayerController>();
    }

   

    public Vector3 RandomSpawnPosition()
    {
        randomY = Random.Range(yDown, yUp);
        return new Vector3(xRange, randomY, 0);
    }

    public void SpawnFlipFlap()
    {
        randomIndex = Random.Range(0, FlipFlapprefabs.Length);
        spawnPosition = RandomSpawnPosition();
        Instantiate(FlipFlapprefabs[randomIndex], spawnPosition,
            FlipFlapprefabs[randomIndex].transform.rotation);

        if (PlayerControllerScript.gameOver)
        {
            CancelInvoke();
        }
    }
}
