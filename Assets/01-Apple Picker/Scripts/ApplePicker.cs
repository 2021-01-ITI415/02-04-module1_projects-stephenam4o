using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;

    //Number of baskets or lives left, start with 3 always
    public int lives = 3;
    //Lower basket limit
    public float bottomY = -15f;
    //Space between baskets
    public float spaceY = 2f;

    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        //Creates the baskets with the proper spacing
        basketList = new List<GameObject>();    //List is the combined basket objects or your remaining lives
            for(int i = 0;  i < 3; i++)
            {
                GameObject basketO = Instantiate(basketPrefab) as GameObject;
                Vector3 pos = Vector3.zero;
                pos.y = bottomY + (spaceY * i);
                basketO.transform.position = pos;
                basketList.Add(basketO);
            }
    }

    public void LoseLife()
    {

        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject a in apples)
        {
            Destroy(a);
        }
        //Lose a life
        int index = basketList.Count - 1;

        //Reference basket object
        GameObject basketO = basketList[index];

        //Delete the lost life from the game
        basketList.RemoveAt(index);
        Destroy(basketO);

        //If no more lives, replay
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("Scenes_");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
