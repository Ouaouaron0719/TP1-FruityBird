using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc : MonoBehaviour
{
    public float speed = 5f; 
    public float destroyPoint = -8.5f; 

    void Update()
    {
        
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        
        if (transform.position.x < destroyPoint)
        {
            Destroy(gameObject);
        }
    }
}
