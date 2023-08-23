using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public bool movedir = true;
    public float movespeed;

    void Update()
    {
        if(gameObject.transform.position.x > 8)
        {
            movedir = false;
        }
        else if(gameObject.transform.position.x < -8)
        {
            movedir = true;
        }

        if (movedir)
        {
            Vector3 oldpos = gameObject.transform.position;
            Vector3 newpos = new Vector3(oldpos.x + movespeed, oldpos.y);
            gameObject.transform.position = newpos;
        }
        else
        {
            Vector3 oldpos = gameObject.transform.position;
            Vector3 newpos = new Vector3(oldpos.x - movespeed, oldpos.y);
            gameObject.transform.position = newpos;
        }
    }
}
