using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;

    public float speed = 5f;

    public float leftAndRightEdge = 10f;

    public float chanceToChangeDirections = .1f;

    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Drop Apples
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);

    }

    void DropApple()
    {
        GameObject Apple = Instantiate(applePrefab) as GameObject;
        Apple.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Change Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);  // Move         
        } else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move
        } 
    }
    void FixedUpdate()  //Chane to change is random now
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;    //Change direction
        }
    }
}
