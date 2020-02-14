using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimations : MonoBehaviour
{
	void Update ()
    {
        SpriteRenderer lastbackground = gameObject.GetComponent<SpriteRenderer>();

        if (WorldManager.nextenemy.Counter > 4125)
        {
            Color color = lastbackground.color;
            color.a = Mathf.Lerp(color.a, 1f, 0.0055f);
            lastbackground.color = color;
        }

        
	}
}
