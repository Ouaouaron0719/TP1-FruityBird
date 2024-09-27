using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]public float speed = 5f;
    [SerializeField] public GameObject applePrefab;
    [SerializeField] public GameObject bananaPrefab;
    [SerializeField] public GameObject kiwiPrefab;
    private GameObject currentFruit;

    public Transform fruitSpawnPoint;

    void Start()
    {
        
        GenerateRandomFruit();
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector3 nextPosition = transform.position;

        nextPosition += new Vector3(x, y, 0) * Time.deltaTime * speed;

        nextPosition.y = Mathf.Clamp(nextPosition.y, 2.5f, 4.5f);
        nextPosition.x = Mathf.Clamp(nextPosition.x, -7.1f, 7.1f);
        transform.position = nextPosition;



        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropFruit();
        }
    }


    void GenerateRandomFruit()
    {

        Vector3 spawnPosition = fruitSpawnPoint.position;
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                currentFruit = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
                currentFruit.tag = "Apple";
                break;
            case 1:
                currentFruit = Instantiate(bananaPrefab, spawnPosition, Quaternion.identity);
                currentFruit.tag = "Banana"; 
                break;
            case 2:
                currentFruit = Instantiate(kiwiPrefab, spawnPosition, Quaternion.identity);
                currentFruit.tag = "Kiwi"; 
                break;
        }
        currentFruit.GetComponent<Rigidbody2D>().isKinematic = true;
        currentFruit.transform.parent = fruitSpawnPoint;
    }
    void DropFruit()
    {
        
        currentFruit.transform.parent = null;
  
        Rigidbody2D rb = currentFruit.GetComponent<Rigidbody2D>();
        rb.isKinematic = false; 
        rb.velocity = Vector2.zero; 
        
        GenerateRandomFruit();
    }

}
