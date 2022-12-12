using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class TimingManager : MonoBehaviour //timing manager is required for gamemodes with multiple bars
{
    
    public List<ClassicMode> gamesList;
    private List<float> timers;

    private bool isAnyGameStarted;
    private float timeLeft = 3f; //3 seconds

    public GameOverScreen gameOverScreen;
    public Scoreboard scoreboard;

    void Start()
    {
        timers = new List<float>();
        for (int i = 0; i < gamesList.Count; i++)
        {
            var index = i; //use terminating variable to set delegates so that the iteration variable does not overwrite previous delegate
            timers.Add(timeLeft);

            gamesList[i].gameButton.triggers.Add(CreateTrigger(EventTriggerType.PointerDown, index));

            gamesList[i].gameButton.triggers.Add(CreateTrigger(EventTriggerType.PointerUp, index));
        }
    }

    void Update()
    {
        if (!isAnyGameStarted)
        {
            isAnyGameStarted = CheckGameStarted();
        }
        else
        {
            for (int i = 0; i < gamesList.Count; i++)
            {
                timers[i] -= Time.deltaTime;
                if(timers[i] <= 0)
                {
                    gameOverScreen.Setup(scoreboard.GetScore());
                }
            }
        }
    }

    private EventTrigger.Entry CreateTrigger(EventTriggerType type, int index)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(delegate { ResetTimer(index); });
        return entry;
    }

    private bool CheckGameStarted()
    {
        foreach(var game in gamesList)
        {
            if (game.gameStarted)
            {
                return true;
            }
        }
        return false;
    }

    private void ResetTimer(int index)
    {
        timers[index] = timeLeft;
        
    }


}
