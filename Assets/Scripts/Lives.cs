using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Lives : object
{
    public static int health = 3;
    public static GameObject[] hearts;




    public static void Start()
    {
        health = 2;
        hearts = new GameObject[2];
    }

    public static int LoseHealth()
    {
        health--;
        return health;
    }

    public static void SetHealth(int h)
    {
        health = h;
    }

    public static int GetHealth()
    {
        return health;
    }



    
}
