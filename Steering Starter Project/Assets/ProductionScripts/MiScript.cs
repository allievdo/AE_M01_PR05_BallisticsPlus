using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isThird = false;
    public static bool isFourth = false;

    public bool check = false;
    public bool check2 = false;


    public GameObject winUI; //for when you win

    bool miHasPlayed;
    private int miSteppedOn;

    public AudioSource mi;

    private void OnTriggerEnter (Collider collider)
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (gameObject.tag == "mi")
            {
                mi.Play();
                if (check2 == true)
                {
                    isFourth = true;
                    miHasPlayed = true;
                }

                if (isFourth)
                {
                    ren.material.color = Color.green;
                    miHasPlayed = true;
                }

                if (miHasPlayed == true && miSteppedOn > 1)
                {
                    mi.Stop();
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

                if (!check)
                {
                    ren.material.color = Color.red;
                    StartCoroutine(resetLevel1());
                }
            }
        }
    }

    IEnumerator resetLevel1()
    {
        yield return new WaitForSeconds(1f);

        ReScript.isFirst = false;
        FaScript.isSecond = false;
        isThird = false;
        SolScript.isFourth = false;

        SceneManager.LoadScene("Level01");
    }

    IEnumerator resetLevel2()
    {
        yield return new WaitForSeconds(1f);

        ReScript.isFirst = false;
        SolScript.isSecond = false;
        FaScript.isThird = false;
        isFourth = false;

        SceneManager.LoadScene("Level02");
    }

    private void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (ReScript.isFirst == true && FaScript.isSecond == true && isThird == false && SolScript.isFourth == false)
            {
                check = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (ReScript.isFirst == true && SolScript.isSecond == true && FaScript.isThird == true && isFourth == false)
            {
                check2 = true;
            }

            if (ReScript.isFirst == true && SolScript.isSecond == true && FaScript.isThird == true && isFourth == true)
            {
                winUI.SetActive(true);
            }

        }
    }
}
