using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolScript : MonoBehaviour
{
    public Renderer ren;

    public GameObject winText;

    public static bool isFourth = false;
    public static bool isSecond = false;

    private bool check = false;
    private bool check2 = false;

    private bool nextLevel = false;

    bool solHasPlayed;
    private int solSteppedOn;

    public AudioSource sol;

    private void OnTriggerEnter(Collider collider)
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (gameObject.tag == "sol")
            {
                sol.Play();
                if (check2 == true)
                {
                    isSecond = true;
                    solHasPlayed = true;
                }

                if (isSecond)
                {
                    ren.material.color = Color.green;
                    solHasPlayed = true;
                }

                if (solHasPlayed == true && solSteppedOn > 1)
                {
                    sol.Stop();
                }

                if (!check2)
                {
                    ren.material.color = Color.red;
                    StartCoroutine(resetLevel2());
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Level01")
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

                if (!check)
                {
                    ren.material.color = Color.red;
                    StartCoroutine(resetLevel1());
                }
            }
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (ReScript.isFirst == true && isSecond == false && FaScript.isThird == false && MiScript.isFourth == false)
            {
                check2 = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (ReScript.isFirst == true && FaScript.isSecond == true && MiScript.isThird == true && isFourth == false)
            {
                check = true;
            }

            if (ReScript.isFirst == true && FaScript.isSecond == true && MiScript.isThird == true && isFourth == true)
            {

                StartCoroutine(nextLevelTimer());
                winText.SetActive(true);
                ReScript.isFirst = false;
                FaScript.isSecond = false;
                MiScript.isThird = false;
                isFourth = false;
                check = false;
            }
        }
    }

    IEnumerator resetLevel1()
    {
        yield return new WaitForSeconds(1f);

        ReScript.isFirst = false;
        FaScript.isSecond = false;
        MiScript.isThird = false;
        isFourth = false;

        SceneManager.LoadScene("Level01");
    }

    IEnumerator resetLevel2()
    {
        yield return new WaitForSeconds(1f);

        ReScript.isFirst = false;
        isSecond = false;
        FaScript.isThird = false;
        MiScript.isFourth = false;

        SceneManager.LoadScene("Level02");
    }

    private IEnumerator nextLevelTimer()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level02");
    }
}
