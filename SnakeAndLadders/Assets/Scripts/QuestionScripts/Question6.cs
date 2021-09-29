using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Question6 : MonoBehaviour
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
                main.player1.transform.position = new Vector2(main.player1.transform.position.x , main.player1.transform.position.y - 40);
                main.numP1 = 50;
            }

        }
        else if (main.getTurn == 2)
        {
            if (!isRight)
            {
                main.player2.transform.position = new Vector2(main.player2.transform.position.x , main.player2.transform.position.y - 40);
                main.numP2 = 50;
            }
        }


        qCont.SetActive(false);
        this.gameObject.SetActive(false);
        // Debug.Log("Should close");
    }
}
