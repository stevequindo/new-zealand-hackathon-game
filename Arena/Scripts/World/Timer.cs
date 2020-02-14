using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public static float DeltaTimeMod
    {
        get { return Time.deltaTime * 60; }
    }

    public float Counter;

    public Timer(float startingPoint)
    {
        Counter = startingPoint;
    }

    public void RunReverse()
    {
        Counter = (Counter > 0) ? Counter -= DeltaTimeMod : 0;
    }

    public void RunForwardTo(float limit)
    {
        Counter = (Counter < limit) ? Counter += DeltaTimeMod : 0;
    }

    public void RunReverseFrom(float resetTo)
    {
        Counter = (Counter > 0) ? Counter -= DeltaTimeMod : resetTo;
    }

    public void RunForever()
    {
        Counter = Counter + DeltaTimeMod;
    }
}
