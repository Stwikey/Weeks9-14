using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;



public class FishSpawner : MonoBehaviour
{
    public List<GameObject> fishes;
    public List<GameObject> fishType;
    public GameObject player;
    public Vector3 playerSize;
    public float fishSize;
    public Vector2 fishLocation;
    int fishSide;
    int fishScale = -1;
    float fishSpeed = -3;
    public Vector3 scale;
    public UnityEvent<float> OnEatFish;
    Coroutine spawner;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //starting the spawner coroutine
        spawner = StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        //getting the current player size
        playerSize = player.transform.localScale;

        //checks for collision with all the fishes and the player
        checkAllFishes();

    }

    //spawning fish
    void spawnFish()
    {
        //getting the player size without changing it
        scale = new Vector3(player.transform.localScale.z, player.transform.localScale.z, player.transform.localScale.z);
        fishSide = Random.Range(0, 2);
        fishSpeed = 3;
        if(fishSide == 0)
        {
            //pick a random location on the left
            fishLocation = new Vector2(-10f, Random.Range(-5, 5));
        }
        else
        {
            //pick a random location on the right
            fishLocation = new Vector2(10f, Random.Range(-5, 5));
            scale.x = scale.x * -1;
            fishSpeed *= -1;
           

        }
        //spawning a fish
        GameObject spawnedFish = Instantiate(fishType[0], fishLocation, Quaternion.identity);
        //changing the scale based on player scale
        spawnedFish.transform.localScale = scale;
        spawnedFish.GetComponent<FishMovement>().speed = fishSpeed;
        fishes.Add(spawnedFish);
    }

    public IEnumerator Spawn()
    {
        while (true){
            //spawns fish every 2 seconds
           spawnFish();
           yield return new WaitForSeconds(2);

        }
    }
    
    //checks for collisions
    public void checkAllFishes()
    {
        //checks if any of the indexes are null, then deletes them
        for (int i = 0; i < fishes.Count; i++)
        {
            if (fishes[i] == null)
            {
                fishes.RemoveAt(i);
                i--;
            }

        }

        //checks if any of the fish are colliding with the player, the invokes a unity event
        for (int i = 0; i < fishes.Count; i++)
        {
            
            if (checkCollision(fishes[i], player))
            {
                OnEatFish.Invoke(fishes[i].transform.localScale.x);
                //destroys the eaten fish and removes it from the list
                Destroy(fishes[i]);
                fishes.RemoveAt(i);
                i--;
            }
        }
    }

    //checks collision with the player
    bool checkCollision(GameObject fish, GameObject player)
    {
        Vector2 fishPos = fish.transform.position;
        Vector2 playerPos = player.transform.position;

        float fishLength = Mathf.Abs(fish.transform.localScale.x);
        float playerLength = Mathf.Abs(player.transform.localScale.x); 

        float fishWidth = Mathf.Abs(fish.transform.localScale.x / 2);
        float playerWidth = Mathf.Abs(player.transform.localScale.x / 2);

        //Debug.Log("x" + Mathf.Abs(fishPos.x - playerPos.x));
        //sDebug.Log("y" + (Mathf.Abs(fishPos.y - playerPos.y)));

        //if the distance from the player to the fish is smaller than half of the sum of both their lengths/width combined then return true
        if (Mathf.Abs(fishPos.x - playerPos.x) <= ((fishLength + playerLength)/2)&& Mathf.Abs((fishPos.y - playerPos.y)/2) <= (fishWidth + playerWidth))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //stops the spawner if the game is over
    public void gameOver()
    {
        StopCoroutine(spawner);
    }
}
