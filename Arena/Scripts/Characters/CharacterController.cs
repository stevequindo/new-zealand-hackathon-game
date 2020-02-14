using Assets.FantasyHeroes.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    Vector3 Move;
    public static float Speed;
    float Teleport;
    public static Timer TeleportCool { get; private set; }

    const float EdgeX = 700f;
    const float EdgeY = 205f;

    float LeftSide;
    float RightSide;
    float TopSide;
    float BottomSide;

    private void Start()
    {
        Speed = 12.5f;

        LeftSide = EdgeX * -1;
        RightSide = EdgeX * 1;
        TopSide = EdgeY * 1;
        BottomSide = 369 * -1;

        //Overloaded version of PlayAnimation to play run
        GameObject animation = GameObject.Find("AnimationManager");
        animation.GetComponent<AnimationManager>().PlayAnimation(0, 0);

        TeleportCool = new Timer(0);
    }  

    void Update()
    {
       
        Movement();
        BoundaryCheck();
        TeleportCheck();
    }

    private void Movement()
    {
        //Movement of the player
        if (Input.GetKey(KeyCode.LeftArrow))     
            Move.x -= Speed * Timer.DeltaTimeMod + Teleport;       
        if (Input.GetKey(KeyCode.RightArrow))
            Move.x += Speed * Timer.DeltaTimeMod + Teleport;
        if (Input.GetKey(KeyCode.UpArrow))
            Move.y += Speed * Timer.DeltaTimeMod + Teleport;         
        if (Input.GetKey(KeyCode.DownArrow))
            Move.y -= Speed * Timer.DeltaTimeMod + Teleport;

        transform.position = Move;
    }

    private void BoundaryCheck()
    {
        //Check if at the edge of screen and constrain movement if reached
        if (transform.position.x < LeftSide)
            Move.x = LeftSide;
        if (transform.position.x > RightSide)
            Move.x = RightSide;
        if (transform.position.y < BottomSide)
            Move.y = -369;
        if (transform.position.y > TopSide)
            Move.y = TopSide;

        transform.position = Move;
    }

    private void TeleportCheck()
    {
        //Cooldown for teleport
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TeleportCool.Counter == 0)
            {
                Teleport = 150f;
                TeleportCool.Counter = 150;
            }
        }
        else
        {
            Teleport = 0;
        }

        TeleportCool.RunReverse();

        if (TeleportCool.Counter < 0)
            TeleportCool.Counter = 0;
    }

}
