using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isFourth = false;
    public static bool isSecond = false;

    private bool check = false;
    private bool nextLevel = false;

    bool solHasPlayed;
    private int solSteppedOn;

    public AudioSource sol;

    private void OnTriggerEnter(Collider collider)
    {
        if (gameObject.tag == "sol")
        {
            sol.Play();

            if (check == true)
            {
                isFourth = true;
                solHasPlayed = true;
                solSteppedOn++;
            }

            if (isFourth)
            {
                ren.material.color = Color.green;
                solHasPlayed = true;
            }

            if (solHasPlayed == true && solSteppedOn > 1)
            {
                sol.Stop();
            }

            else
            {
                //reset scene??? IDK
            }
        }
    }
    private void Update()
    {
        if (ReScript.isFirst == true && FaScript.isSecond == true && MiScript.isThird == true && isFourth == false)
        {
            check = true;
        }

        if (ReScript.isFirst == true && FaScript.isSecond == true && MiScript.isThird == true && isFourth == true)
        {
            StartCoroutine(nextLevelTimer());
            ReScript.isFirst = false;
            FaScript.isSecond = false;
            MiScript.isThird = false;
            isFourth = false;
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (ReScript.isFirst == true && isSecond == true)
            {
                //blah
            }
        }

    }

    private IEnumerator nextLevelTimer()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level02");
    }
}
