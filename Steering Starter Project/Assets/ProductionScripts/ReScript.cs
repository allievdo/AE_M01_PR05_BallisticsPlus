using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isFirst = false;

    bool reHasPlayed;

    private int reSteppedOn;

    public AudioSource re;

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "re")
        {
            re.Play();
            if (isFirst == false && FaScript.isSecond == false && MiScript.isThird == false && SolScript.isFourth == false)
            {
                isFirst = true;
                reHasPlayed = true;
            }

            if (isFirst)
            {
                ren.material.color = Color.green;
                reHasPlayed = true;
            }

            if (reHasPlayed == true && reSteppedOn > 1)
            {
                re.Stop();
            }

            else
            {
                //reset scene??? IDK
            }
        }
    }
}
