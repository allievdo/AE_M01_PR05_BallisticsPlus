using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isThird = false;
    public bool check = false;

    bool miHasPlayed;
    private int miSteppedOn;

    public AudioSource mi;

    private void OnTriggerEnter (Collider collider)
    {
        if (gameObject.tag == "mi")
        {
            mi.Play();

            if (check == true)
            {
                isThird = true;
                miHasPlayed = true;
                miSteppedOn++;
            }

            if (isThird)
            {
                ren.material.color = Color.green;
                miHasPlayed = true;
            }

            if (miHasPlayed == true && miSteppedOn > 1)
            {
                mi.Stop();
            }

            else
            {
                //reset scene??? IDK
            }
        }
    }

    private void Update ()
    {
        if (ReScript.isFirst == true && FaScript.isSecond == true && isThird == false && SolScript.isFourth == false)
        {
            check = true;
        }
    }
}
