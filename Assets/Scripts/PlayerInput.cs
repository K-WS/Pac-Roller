using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private AreaRotator rot;

    void Awake()
    {
        rot = GetComponent<AreaRotator>();
    }

    // Update is called once per frame
    void Update()
    {

        float spin = Input.GetAxis("Horizontal");
        rot.Rotate(spin);

        float speed = Input.GetAxis("Vertical");
        rot.Speedify(speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
