using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public static bool IsGameOver;
    public GameObject audioSource; 

	void Start ()
    {
        IsGameOver = false;
	}
	

	void Update ()
    {
        if (IsGameOver)
        {
            audioSource.GetComponent<AudioSource>().enabled = false;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Destroy(GameObject.Find("Dummy"));
                SceneManager.LoadScene("CharacterEditor");
            }

        }
	}
}
