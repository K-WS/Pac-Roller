using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    //Score Events
    public static event Action<int> OnSetScore;
    public static void SetScore(int val) => OnSetScore.Invoke(val);
    public static event Func<int> OnRequestScore;
    public static int RequestScore() => OnRequestScore?.Invoke() ?? 0; //?? means nullable

    //Lives Events
    public static event Action<int> OnSetLives;
    public static void SetLives(int val) => OnSetLives.Invoke(val);
    public static event Func<int> OnRequestLives;
    public static int RequestLives() => OnRequestLives?.Invoke() ?? 0;

    //Speed Events
    public static event Action<float> OnSetSpeed;
    public static void SetSpeed(float val) => OnSetSpeed.Invoke(val);
    public static event Func<float> OnRequestSpeed;
    public static float RequestSpeed() => OnRequestSpeed?.Invoke() ?? 0;

    //Rotation Events
    public static event Action<float> OnSetRotation;
    public static void SetRotation(float val) => OnSetRotation.Invoke(val);
    public static event Func<float> OnRequestRotation;
    public static float RequestRotation() => OnRequestRotation?.Invoke() ?? 0;
}
