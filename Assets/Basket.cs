using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.Find("ScoreCounter");

        scoreText = scoreObject.GetComponent<Text>();

        scoreText.text = "0";   //Default score is always 0

    }

    // Update is called once per frame
    void Update()
    {
        //Movement controlled by mouse so we need mouse input
        Vector3 mousePos2D = Input.mousePosition;

        //Z position is based on the camera
        mousePos2D.z = -Camera.main.transform.position.z;

        //Has to be converted from 2D to 3D as Unity is 3D
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Make the basket follow the position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision check)
    {
        if (check.gameObject.tag == "Apple")
        {
            Destroy(check.gameObject);
            int score = int.Parse(scoreText.text);
            score += 100;
            scoreText.text = scoreText.ToString(); 
        }
    }
}
