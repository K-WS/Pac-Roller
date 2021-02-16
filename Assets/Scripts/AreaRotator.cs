using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRotator : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float rotation;

    private void Awake()
    {
        Events.OnSetSpeed += OnSetSpeed;
        Events.OnRequestSpeed += OnRequestSpeed;

        Events.OnSetRotation += OnSetRotation;
        Events.OnRequestRotation += OnRequestRotation;
    }

    private void OnDestroy()
    {
        Events.OnSetSpeed -= OnSetSpeed;
        Events.OnRequestSpeed -= OnRequestSpeed;

        Events.OnSetRotation -= OnSetRotation;
        Events.OnRequestRotation -= OnRequestRotation;
    }

    private void OnSetSpeed(float obj) { speed = obj; }
    private float OnRequestSpeed() { return speed; }

    private void OnSetRotation(float obj) { rotation = obj; }
    private float OnRequestRotation() { return rotation; }


    public void Rotate(float spin)
    {
        transform.Rotate(0, 0, -spin * Time.deltaTime * speed);
        Events.SetRotation(Mathf.Round(transform.rotation.eulerAngles.z*10)/10.0f);
    }

    public void Speedify(float sp)
    {
        speed += sp;
        Events.SetSpeed(Mathf.Round(speed*100)/100.0f);
    }
}
