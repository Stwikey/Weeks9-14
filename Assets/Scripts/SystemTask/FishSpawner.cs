using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class FishSpawner : MonoBehaviour
{
    public List<GameObject> fish;
    public GameObject player;
    public float playerSize;
    public float fishSize;
    public Vector2 fishLocation;
    int fishSide;
    int fishScale = -1;
    public Vector3 scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnFish();
    }

    // Update is called once per frame
    void Update()
    {
        //getting the current player size
        playerSize = player.transform.localScale.x;

    }

    //spawning fish
    void spawnFish()
    {
        fishSide = Random.Range(0, 2);
        if(fishSide == 0)
        {
            //pick a random location on the left
            fishLocation = new Vector2(-10f, Random.Range(-5, 5));
        }
        else
        {
            //pick a random location on the right
            fishLocation = new Vector2(-10f, Random.Range(-5, 5));
        }
        GameObject spawnedFish = Instantiate(fish[0], fishLocation, Quaternion.identity);
    }

    /**public IEnumerator Spawn()
    {

    }**/
}
