using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FaScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isSecond = false;

    public bool check = false;

    bool faHasPlayed;
    public int faSteppedOn;

    public AudioSource fa;

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "fa")
        {
            fa.Play();

            if (check == true)
            {
                isSecond = true;
                faHasPlayed = true;
                faSteppedOn++;
            }

            if (isSecond)
            {
                ren.material.color = Color.green;
                faHasPlayed = true;
            }

            if (faHasPlayed == true && faSteppedOn > 1)
            {
                fa.Stop();
            }

            else
            {
                //reset scene??? IDK
            }
        }
    }

    private void Update()
    {
        if (ReScript.isFirst == true && isSecond == false && MiScript.isThird == false && SolScript.isFourth == false)
        {
            check = true;
        }
    }
}
