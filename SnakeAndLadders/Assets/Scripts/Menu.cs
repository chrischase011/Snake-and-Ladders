using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public Canvas canvas;
    public GameObject options;
    public Dropdown graphics;

    public Toggle musicToggle;

    [SerializeField]
    private AudioSource bgm;

    bool isSetOp = false;
    bool isSet = false;
    int music = 1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        // canvas = GetComponent<Canvas>();
      //  Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i);
        PlayerPrefs.SetInt("quality", i);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSet == false)
            {
                isSet = true;
                canvas.enabled = true;
                Time.timeScale = 0;
            }
            else if (isSet == true)
            {
                isSet = false;
                canvas.enabled = false;
                Time.timeScale = 1;
            }

        }
    }


    public void Resume()
    {
        isSet = false;
        canvas.enabled = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Options()
    {
        if (isSetOp == false)
        {
            isSetOp = true;
            options.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void CloseOptions()
    {
        if (isSetOp == true)
        {
            isSetOp = false;
            options.SetActive(false);
        }
    }

   public void DropdownValueChanged(int change)
    {
        if (change == 0)
        {
            SetQuality(change);
        }
        else if (change == 1)
        {
            SetQuality(change);
        }
        else if (change == 2)
        {
            SetQuality(change);
        }
        Debug.Log(change);
        Debug.Log(QualitySettings.GetQualityLevel());
    }


    public void musicTog()
    {
        if(musicToggle.isOn)
        {
            bgm.volume = 1f;
        }
        else if(!musicToggle.isOn)
        {
            bgm.volume = 0f;
        }
    }
}
