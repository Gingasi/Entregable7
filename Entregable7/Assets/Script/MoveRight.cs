using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 6f;
    private float Xlimit = 19f;
    

    
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // Movimiento Continuo de derecha a izquierda

        if (transform.position.x >= Xlimit)
        {
            Destroy(gameObject);
        }
    }
}
