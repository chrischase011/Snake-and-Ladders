using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    public Main main;


    private int numP1;
    private int numP2;

    public GameObject question;

    [SerializeField]
    private GameObject qCont;
    public GameObject qs;

    [SerializeField]
    private AudioSource bgm;
    [SerializeField]


    public int value;

    int visible;

    public bool done = false;

    void Start()
    {
       // Debug.Log(value);
    }
    void Update()
    {
        
        numP1 = main.getP1;
        numP2 = main.getP2;
       // Debug.Log(numP1);
        if(numP1 == value || numP2 == value)
        {
            LoadQuestion();
            Time.timeScale = 0;

        }
    }

     void LoadQuestion()
    {
       // yield return new WaitForSeconds(0.5f);
        qCont.SetActive(true);
        qs.SetActive(true);
        Destroy(this.gameObject);
    }
}
