using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    int RandRotateDir;
    float RandRotateSpeed;

    void Start()
    {
        RandRotateDir = Random.Range(0, 2) * 2 - 1;
        RandRotateSpeed = Random.Range(3.0f, 9.0f);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, (RandRotateSpeed * RandRotateDir) * Timer.DeltaTimeMod);
    }
}
