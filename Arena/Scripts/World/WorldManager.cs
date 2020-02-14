using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public static Timer nextenemy;

    private void Start()
    {
        nextenemy = new Timer(0);
    }

    void Update()
    {
        DestroyInstantiations(); //Destroys all "hidden" gameobjects with tag "Enemy" - after game is finished
        TimerForNextEnemy();
        NextWaveOfEnemies();
    }
    private void TimerForNextEnemy()
    {
        nextenemy.RunForever();
    }
    private void NextWaveOfEnemies()
    {        
        DestroyFirstWave();

        SpawnSecondWave();
        DestroySecondWave();

        SpawnThirdWave();
        DestroyThirdWave();

        SpawnFourthWave();
        DestroyFourthWave();

        SpawnFinalWave();
        DestroyFinalWave();

    }

    private void DestroyFirstWave()
    {
        if (nextenemy.Counter > 750 && nextenemy.Counter < 800)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.transform.localScale = Vector3.Lerp(enemy.transform.localScale, new Vector3(55f, 55f, 0), 0.1f * Timer.DeltaTimeMod);
                if (enemy.transform.localScale.x < 56f)
                {
                    enemy.GetComponent<SpriteRenderer>().enabled = false;
                    enemy.GetComponent<Enemy>().enabled = false;
                }
            }
        }
    }
  
    private void SpawnSecondWave()
    {
        if (nextenemy.Counter > 800 && nextenemy.Counter < 1550)
        {
            GameObject secondEnemy = GameObject.Find("PurplePins2");
            secondEnemy.GetComponent<Enemy>().enabled = true;
            secondEnemy.tag = "Enemy";
        }
    }
    private void DestroySecondWave()
    {
        if (nextenemy.Counter > 1550 && nextenemy.Counter < 1600)
        {
            GameObject nextbackground = GameObject.Find("BackgroundWave2");
            nextbackground.GetComponent<SpriteRenderer>().enabled = true;
            GameObject lastbackground = GameObject.Find("BackgroundWave1");
            GameObject.Destroy(lastbackground);

            DestroyEnemiesInArena();
        }
    }

    private void SpawnThirdWave()
    {
        if (nextenemy.Counter > 1600 && nextenemy.Counter < 2600)
        {
            GameObject secondEnemy = GameObject.Find("ThreeAngryCubes");
            secondEnemy.GetComponent<Enemy>().enabled = true;
            secondEnemy.tag = "Enemy";
        }
    }
    private void DestroyThirdWave()
    {
        if (nextenemy.Counter > 2600 && nextenemy.Counter < 2650)
        {
            GameObject nextbackground = GameObject.Find("BackgroundWave3");
            nextbackground.GetComponent<SpriteRenderer>().enabled = true;
            GameObject lastbackground = GameObject.Find("BackgroundWave2");
            GameObject.Destroy(lastbackground);

            DestroyEnemiesInArena();
        }
    }

    private void SpawnFourthWave()
    {
        if (nextenemy.Counter > 2650 && nextenemy.Counter < 3400)
        {
            GameObject secondEnemy = GameObject.Find("DeadlyCaterpillar");
            secondEnemy.GetComponent<Enemy>().enabled = true;
            secondEnemy.tag = "Enemy";
        }
    }
    private void DestroyFourthWave()
    {
        if (nextenemy.Counter > 3400 && nextenemy.Counter < 3450 )
        {
            //BackgroundAnimations will handle lastbackground appearance
            //No need to destroy 3 background, lastbackground will overlap it slowly

            /*
            GameObject nextbackground = GameObject.Find("BackgroundWave4");
            nextbackground.GetComponent<SpriteRenderer>().enabled = true;
            GameObject lastbackground = GameObject.Find("BackgroundWave3");
            GameObject.Destroy(lastbackground);
            */

            DestroyEnemiesInArena();
        }
    }

    private void SpawnFinalWave()
    {
        if (nextenemy.Counter > 3450 && nextenemy.Counter < 3500)
        {
            GameObject secondEnemy = GameObject.Find("JellyBoss");
            secondEnemy.GetComponent<Enemy>().enabled = true;
            secondEnemy.tag = "Enemy";
        }
    }
    private void DestroyFinalWave()
    {
        if (nextenemy.Counter > 4450 && nextenemy.Counter < 4500)
        { 
            DestroyEnemiesInArena();
        }
    }

    private void DestroyEnemiesInArena()
    {
        //Lerps down enemies in arena and disables their scripts
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {            
            enemy.transform.localScale = Vector3.Lerp(enemy.transform.localScale, new Vector3(20f, 20f, 0), 0.1f * Timer.DeltaTimeMod);
            if (enemy.transform.localScale.x < 23f)
            {
                enemy.GetComponent<SpriteRenderer>().enabled = false;
                enemy.GetComponent<Enemy>().enabled = false;               
            }
        }
    }
   
    private void DestroyInstantiations()
    {
        //Changes tags, "Enemy" to "Delete" to destroy and clean up
        if (nextenemy.Counter > 4550)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.tag = "Delete";
                Destroy(enemy);
            }
        }
    }

}
