using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PlayerrigidBody;
    public float jumpForce = 10f;
    public float YLim = 16f;
    public bool gameOver;
    public GameObject explosioneffect;
    public GameObject fireffect;
    private int Price;
    public AudioSource Catching;
    public AudioSource Kaboom;
    public AudioSource Wosh;
    public AudioSource Back;
    public AudioClip coger;
    public AudioClip boom;
    public AudioClip impulse;
    public AudioClip Music;
    private bool isOnTheGround = true; 

    void Start()
    {
        gameOver = false;
        // A continuación indicamos que busque dentro de la escena y del gameObject los distintos AudioSource que hemos colocado con su respectivo nombre
        Catching = GameObject.Find("Catching").GetComponent<AudioSource>();
        Kaboom = GameObject.Find("Kaboom").GetComponent<AudioSource>();
        Wosh = GameObject.Find("Wosh").GetComponent<AudioSource>();
        Back = GameObject.Find("Back").GetComponent<AudioSource>();

        isOnTheGround = false;
    }

    
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && !isOnTheGround) // En este comando instamos al objeto a que cuando se presione el boton espacio este tenga una fuerza que lo impulse hacia arriba
                                                               // + Con esta variable evitaremos el  salto una vez muertos
        {
            PlayerrigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Wosh.PlayOneShot(impulse, 2f);
        }

        if (transform.position.y > YLim)
        {
            PlayerrigidBody.AddForce(Vector3.down, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider otherCollider) // Indicamos que el juego termine cuando el player toque el suelo 
    {
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
            Explode();
            isOnTheGround = true;
        }

        if (otherCollider.gameObject.CompareTag("Bomb")) //o choque con una bomba
        {
            GameOver();
            Explode();
            isOnTheGround = true;
        }
        if (otherCollider.gameObject.CompareTag("Money"))// Indicamos que el jugador obtenga +1 al tocar la moneda
        {
            Destroy(otherCollider.gameObject);
            Fireworks();
            Debug.Log(Price += 1);
        }
    }



        void Explode() //En esta función almacenamos todo lo relacionado con la explosioón o las bombas
    {
        Instantiate(explosioneffect, transform.position, transform.rotation);
        
        Kaboom.PlayOneShot(boom, 1f);
    }


     private void GameOver()// Lo mismo pero para lo que ocurre cuando hay game over
      {
           gameOver = true;
           Back.Pause();
           Debug.Log("JA, PERDISTE!!");
      } 

    void Fireworks ()// Instanciamos la animación y el efecto sonoro de la moneda
    {
       
        Instantiate(fireffect, transform.position, transform.rotation);
        Catching.PlayOneShot(coger, 5f);
    }
    
}

