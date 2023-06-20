using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChaosMode : ClassicMode //i believe inheritence can inherit monobehavior like this
{
    protected float speed;
    protected float minRandom;
    protected float maxRandom;

    new void Start()
    {
        base.Start();

        speed = 0f;
        minRandom = 0.005f;
        maxRandom = 0.02f;
    }

    new void Update()
    {
        base.Update();
    }

    protected override void AddSpeed() //randomize speed because chaos mode
    {
        if (scoreboard.GetScore() % 5 == 0)
        {
            if (speed < 0.01f)
            {
                speed += 0.001f;
            }
        }
        growthRate = Random.Range(speed + minRandom, speed + maxRandom);
    }

}