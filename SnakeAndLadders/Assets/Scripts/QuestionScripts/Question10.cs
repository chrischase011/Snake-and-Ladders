using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Question10 : MonoBehaviour
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
        b.image.color = Color.gray;
        c.image.color = Color.green;

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
                main.player1.transform.position = new Vector2(106f, 44f);
                main.numP1 = 1;
            }

        }
        else if (main.getTurn == 2)
        {
            if (!isRight)
            {
                main.player2.transform.position = new Vector2(106f, 44f);
                main.numP2 = 1;
            }
        }


        qCont.SetActive(false);
        this.gameObject.SetActive(false);
        // Debug.Log("Should close");
    }
}
