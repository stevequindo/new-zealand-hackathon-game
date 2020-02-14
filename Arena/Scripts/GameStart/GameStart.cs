using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    bool HasChangedScene = false;
 

    private void Start()
    {

    }

    private void Update()
    {
        if (HasChangedScene)
        {
            //Reference's Character  - Add's component when Arena Scene starts
            GameObject character = GameObject.Find("Dummy");
            character.AddComponent<CharacterController>();

            HasChangedScene = !HasChangedScene;
        }

        
    }

    void Awake()
    {
        //Character ("Dummy") remains in next scene
        DontDestroyOnLoad(transform.gameObject);

    }

    public void ChangeScene()
    {
        HasChangedScene = !HasChangedScene;
        //When button is ON, scene changes
        SceneManager.LoadScene("Arena");
    }

}
