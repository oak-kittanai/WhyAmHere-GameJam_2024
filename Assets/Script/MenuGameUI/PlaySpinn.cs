using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpinn : MonoBehaviour
{
    Vector2 posPlayButton;
    private void Start()
    {

    }

    private void Update()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        //posPlayButton = z;

        transform.Rotate(x, y, z);

        if (z == 0)
        {
            z++;
        }

        if (z <= -7)
        {
            z++;
        }

        if (z >= 7)
        {
            z--;
        }
    }
}
