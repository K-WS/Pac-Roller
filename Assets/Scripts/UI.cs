using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI Lives;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI Rotation;


    private void Awake()
    {
        Events.OnSetScore += OnSetScore;
        Events.OnSetLives += OnSetLives;
        Events.OnSetSpeed += OnSetSpeed;
        Events.OnSetRotation += OnSetRotation;
    }

    private void OnSetScore(int obj) { Score.text = obj.ToString(); }
    private void OnSetLives(int obj) { Lives.text = obj.ToString(); }
    private void OnSetSpeed(float obj) { Speed.text = obj.ToString(); }
    private void OnSetRotation(float obj) { Rotation.text = obj.ToString(); }

    private void OnDestroy()
    {
        Events.OnSetScore -= OnSetScore;
        Events.OnSetLives -= OnSetLives;
        Events.OnSetSpeed -= OnSetSpeed;
        Events.OnSetRotation -= OnSetRotation;
    }
}
