using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pac_Collider : MonoBehaviour
{

    //Also a point collector, because why not give a player this statistic...
    private int points = 0;
    public GameObject pList;

    //And why not let it have access to the enemies to reset their positions as well
    public GameObject Blinky;
    public GameObject Inky;
    public GameObject Pinky;
    public GameObject Clyde;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            gameObject.transform.parent.rotation = new Quaternion(0, 0, 0, 0);

            gameObject.transform.localPosition = new Vector3(0, -2.125f, -0.25f);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Blinky.transform.localPosition = new Vector3(2.5f, 3.25f, -0.25f);
            Blinky.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Blinky.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Inky.transform.localPosition = new Vector3(-2.5f, 3.25f, -0.25f);
            Inky.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Inky.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Pinky.transform.localPosition = new Vector3(-1f, 1.4375f, -0.25f);
            Pinky.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Pinky.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            Clyde.transform.localPosition = new Vector3(1f, 1.4375f, -0.25f);
            Clyde.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Clyde.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //Reduce Life, if 0, reset stats
            int livesLeft = Events.RequestLives() - 1;
            
            if(livesLeft <= 0)
            {
                Events.SetLives(3);
                Events.SetScore(0);

                //Reset all points
                for (int i = 0; i < pList.transform.childCount; i++)
                {
                    pList.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else
                Events.SetLives(livesLeft);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            Events.SetScore(Events.RequestScore() + 10);
            other.gameObject.SetActive(false);

            points++;
            if(points >= 244)
            {
                Events.SetScore(Events.RequestScore() + 1000);
                points = 0;

                //Reset all points
                for (int i = 0; i < pList.transform.childCount; i++)
                {
                    pList.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }
}
