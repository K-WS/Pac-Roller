using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int lives;
    private int score;
    

    private void Awake()
    {
        lives = 3;
        score = 0;

        Events.OnSetScore += OnSetScore;
        Events.OnRequestScore += OnRequestScore;

        Events.OnSetLives += OnSetLives;
        Events.OnRequestLives += OnRequestLives;  
    }

    private void OnSetScore(int obj) { score = obj; }
    private int OnRequestScore() { return score; }

    private void OnSetLives(int obj) 
    { 
        lives = obj; 
        if(lives == 0)
        {
             //Trigger Game Over
        }
    }
    private int OnRequestLives() { return lives; }


    private void OnDestroy()
    {
        Events.OnSetScore -= OnSetScore;
        Events.OnRequestScore -= OnRequestScore;

        Events.OnSetLives -= OnSetLives;
        Events.OnRequestLives -= OnRequestLives; 
    }
}
