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
    public UnityEvent<GameObject> OnEatFish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        //getting the current player size
        playerSize = player.transform.localScale;
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
        GameObject spawnedFish = Instantiate(fishType[0], fishLocation, Quaternion.identity);
        spawnedFish.transform.localScale = scale;
        spawnedFish.GetComponent<FishMovement>().speed = fishSpeed;
        fishes.Add(spawnedFish);
    }

    public IEnumerator Spawn()
    {
        while (true){
           spawnFish();
           yield return new WaitForSeconds(2);

        }
    }
    
    public void checkAllFishes()
    {
        for (int i = 0; i < fishes.Count; i++)
        {
            if (fishes[i] == null)
            {
                fishes.RemoveAt(i);
                i--;
            }

        }

        for (int i = 0; i < fishes.Count; i++)
        {
            
            if (checkCollision(fishes[i], player))
            {
                OnEatFish.Invoke(fishes[i]);
                Destroy(fishes[i]);
                fishes.RemoveAt(i);
                i--;
            }
        }
    }

 
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


        if (Mathf.Abs(fishPos.x - playerPos.x) <= (fishLength + playerLength)&& Mathf.Abs(fishPos.y - playerPos.y) <= (fishWidth + playerWidth))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
