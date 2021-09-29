using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question5 : MonoBehaviour
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

    public void right()
    {

        qMSource.PlayOneShot(qMCorrectClip);
        isRight = true;
        playRight();
    }
    public void wrong()
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

        yield return new WaitForSeconds(3f);
        if (main.getTurn == 1)
        {
            if (!isRight)
            {
                main.player1.transform.position = new Vector2(main.player1.transform.position.x - (40 * 6), main.player1.transform.position.y);
                main.numP1 = 42;
            }

        }
        else if (main.getTurn == 2)
        {
            if (!isRight)
            {
                main.player2.transform.position = new Vector2(main.player2.transform.position.x - (40 * 6), main.player2.transform.position.y);
                main.numP2 = 42;
            }
        }


        qCont.SetActive(false);
        this.gameObject.SetActive(false);
        // Debug.Log("Should close");
    }
}
