using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaScript : MonoBehaviour
{
    public Renderer ren;

    public static bool isSecond = false;
    public static bool isThird = false;

    public bool check = false;
    public bool check2 = false;


    bool faHasPlayed;
    public int faSteppedOn;

    public AudioSource fa;

    private void OnTriggerEnter(Collider collider)
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (gameObject.tag == "fa")
            {
                fa.Play();
                if (check2 == true)
                {
                    isThird = true;
                    faHasPlayed = true;
                }

                if (isThird)
                {
                    ren.material.color = Color.green;
                    faHasPlayed = true;
                }

                if (faHasPlayed == true && faSteppedOn > 1)
                {
                    fa.Stop();
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
        Debug.Log("reset to level 1");

        yield return new WaitForSeconds(1f);
        ReScript.isFirst = false;
        SolScript.isSecond = false;
        MiScript.isThird = false;
        SolScript.isFourth = false;

        SceneManager.LoadScene("Level01");
    }

    IEnumerator resetLevel2()
    {
        Debug.Log("reset to level 2");
        yield return new WaitForSeconds(1f);

        ReScript.isFirst = false;
        isSecond = false;
        isThird = false;
        MiScript.isFourth = false;

        SceneManager.LoadScene("Level02");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (ReScript.isFirst == true && isSecond == false && MiScript.isThird == false && SolScript.isFourth == false)
            {
                check = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (ReScript.isFirst == true && SolScript.isSecond == true && isThird == false && MiScript.isFourth == false)
            {
                check2 = true;
            }
        }
    }
}
