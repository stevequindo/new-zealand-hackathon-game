using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float Speed;

    GameObject CharacterReference;
    Vector3 CharacterRefPosition;
    Vector3 Distance;

    Timer SpawnTimer;
    public int SpawnInterval;
    public int EnemyCount = 0;

    void Start()
    {
        CharacterReference = GameObject.Find("Dummy");
        Speed = 7.5f;

        SpawnTimer = new Timer(0);
    }

    void Update()
    {
        Movement();
        EnemyProximity();
        DuplicateSpawn();
    }

    private void EnemyProximity()
    {
        //Check Distance between Character & Enemy
        float x = transform.position.x - CharacterRefPosition.x;
        float y = transform.position.y - CharacterRefPosition.y;
        Distance = new Vector2(x, y);

        float proximityDistance = 40f;

        //If Occupying same space as you, you've been eaten!!!
        if (((Distance.x < proximityDistance) && (Distance.x > -proximityDistance)) && ((Distance.y < proximityDistance) && (Distance.y > -proximityDistance)))
        {
            //So it checks these statements once
            if (CharacterReference.GetComponent<CharacterController>().enabled == true)
            {
                GameObject deathSound = GameObject.Find("gameOverManager");
                deathSound.GetComponent<AudioSource>().Play();
            }

            //Disabled CharacterController Script, can't move
            CharacterReference.GetComponent<CharacterController>().enabled = false;

            //Character gets "swallowed up" by the sphere
            CharacterReference.transform.localScale = Vector3.Lerp(CharacterReference.transform.localScale, new Vector3(0.01f, 0.01f, 0), 0.05f * Timer.DeltaTimeMod);

            GameOverManager.IsGameOver = true;

        }

        if (CharacterReference.transform.localScale.y < 0.011f)
        {
            //Disables all enemies scripts, in arena 
            foreach (GameObject idle in GameObject.FindGameObjectsWithTag("Idle")) 
            {
                idle.GetComponent<SpriteRenderer>().enabled = false;
            }
            CharacterReference.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void Movement()
    {
        CharacterRefPosition = CharacterReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, CharacterRefPosition, Speed * Timer.DeltaTimeMod);
    }

    private void DuplicateSpawn()
    {
        //Spawn Duplicates every 250 ticks            
        if (SpawnTimer.Counter > SpawnInterval)
        {
            float x = Random.Range(-700f, 700f);
            float y = Random.Range(-205f, 205f);
            float z = transform.position.z;
            GameObject.Instantiate(this.gameObject, new Vector3(x, y, z), transform.rotation);
            this.EnemyCount++;
        }
        SpawnTimer.RunForwardTo(SpawnInterval);

    }
}  
