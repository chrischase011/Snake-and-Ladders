using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question3 : MonoBehaviour
{
    public GameObject questions;
    [SerializeField]
    private AudioSource qMSource;
    [SerializeField]
    private AudioClip qMCorrectClip, qMWrongClip;

    [SerializeField]
    private Button a, b, c;
    [SerializeField]
    private Main main;

    [SerializeField]
    private GameObject qCont;
    [SerializeField]
    private GameObject qOrigin;
    bool isRight;

    public void right3()
    {

        qMSource.PlayOneShot(qMCorrectClip);
        isRight = true;
        playRight();
    }
    public void wrong3()
    {

        qMSource.PlayOneShot(qMWrongClip);
        isRight = false;
        playRight();
    }

    void playRight()
    {
        //yield return new WaitForSeconds(1f);

        a.image.color = Color.gray;
        b.image.color = Color.green;
        c.image.color = Color.gray;

        a.enabled = false;
        b.enabled = false;
        c.enabled = false;

        Time.timeScale = 1;
        StartCoroutine(closeQ());

    }

    IEnumerator closeQ()
    {

        yield return new WaitForSeconds(2f);
        if (main.getTurn == 1)
        {
            if (!isRight)
            {
                main.player1.transform.position = new Vector2(main.player1.transform.position.x - (40 * 1), main.player1.transform.position.y);
                main.numP1 = 21;
            }

        }
        else if (main.getTurn == 2)
        {
            if (!isRight)
            {
                main.player2.transform.position = new Vector2(main.player2.transform.position.x - (40 * 1), main.player2.transform.position.y);
                main.numP2 = 21;
            }
        }


        qCont.SetActive(false);
        this.gameObject.SetActive(false);
        // Debug.Log("Should close");
    }
}
