using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    /*
     *  Snake and Ladders 
     *  
     *  Coded by: Christopher Robin Chase
     *  
     *  09/21/2021
     */
    
    // Original X Position is 90.5
    // += 40 x-axis every turn
    // Original Y Position is 50
    // += 45 y-axis every edge turn

    // Sets turn
    [SerializeField]
    private int turn = 1;

    // Sprites container
    private Sprite[] diceSides;
    public SpriteRenderer rend;

    //private int[] edges = {10,20,30,40,50,60,70,80,90};
    private int[] ladders = {3,27,39,87};
    private int[] snakes = {15,44,49,88,99};
    
    // The players transform
    public Transform player1;
    public Transform player2;

    // Current position of the player based on squares
    int numP1 = 1;
    int numP2 = 1;
    
    // UI button and text
    [SerializeField]
    private Button btnRoll;
    [SerializeField]
    private Text btnText;

    int win = 0;
    // Start is called before the first frame update
    void Start()
    {
        //rend = gameObject.GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void RollDice()
    {
        StartCoroutine(rollDice());
        //Debug.Log("Clicked");
    }

    public IEnumerator rollDice()
    {
        int randomDiceSide = 0;
        int finalSide = 0;

        btnRoll.enabled = false;
        if (turn == 1)
            btnText.text = "Player 1 is Rolling";
        else if (turn == 2)
            btnText.text = "Player 2 is rolling";
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];

            yield return new WaitForSeconds(0.05f);
            
        }

        finalSide = randomDiceSide + 1;
        StartCoroutine(Turns(finalSide));

        if (turn == 1)
            btnText.text = "Player 1 is moving";
        else if (turn == 2)
            btnText.text = "Player 2 is moving";

       // Debug.Log(finalSide);
    }

    IEnumerator Turns(int dice)
    {
        yield return new WaitForSeconds(0.07f);

        if(turn == 1)
        {
            for (int i = 0; i <= dice - 1; i++)
            {
                if (numP1 == 10 || numP1 == 30 )
                {
                    player1.transform.position = new Vector2(player1.position.x, player1.position.y + 45);
                }
                else if (numP1 == 20 || numP1 == 40 || numP1 == 50 || numP1 == 70 || numP1 == 60 || numP1 == 80 || numP1 == 90)
                {
                    player1.transform.position = new Vector2(player1.position.x, player1.position.y + 40);
                }

                if ((numP1 >= 1 && numP1 < 10) || (numP1 >= 21 && numP1 < 30) || (numP1 >= 41 && numP1 < 50) 
                    || (numP1 >= 61 && numP1 < 70) || (numP1 >= 81 && numP1 < 90))
                {
                    player1.transform.position = new Vector2(player1.position.x + 40f, player1.position.y);
                }
                else if((numP1 >= 11 && numP1 < 20) || (numP1 >= 31 && numP1 < 40) || (numP1 >= 51 && numP1 < 60)
                    || (numP1 >= 71 && numP1 < 80) || (numP1 >= 91 && numP1 < 100))
                {
                    player1.transform.position = new Vector2(player1.position.x - 40f, player1.position.y);
                }
                if (numP1 < 100)
                    numP1++;
                else
                    numP1--;
                yield return new WaitForSeconds(1f);
            }
            checkSnakes(numP1);
            checkLadder(numP1);
            if (numP1 == 100)
            {
                Win(turn);
            }
            turn = 2;
        }
        else if(turn == 2)
        {
            for (int i = 0; i <= dice - 1; i++)
            {
                if (numP2 == 10 || numP2 == 30 )
                {
                    player2.transform.position = new Vector2(player2.position.x, player2.position.y + 45);
                }
                else if(numP2 == 20 || numP2 == 40 ||  numP2 == 60 || numP1 == 70 || numP2 == 50 || numP2 == 80 || numP2 == 90)
                {
                    player2.transform.position = new Vector2(player2.position.x, player2.position.y + 40);
                }
                if ((numP2 >= 1 && numP2 < 10) || (numP2 >= 21 && numP2 < 30) || (numP2 >= 41 && numP2 < 50)
                    || (numP2 >= 61 && numP2 < 70) || (numP2 >= 81 && numP2 < 90))
                {
                    player2.transform.position = new Vector2(player2.position.x + 40f, player2.position.y);
                }
                else if ((numP2 >= 11 && numP2 < 20) || (numP2 >= 31 && numP2 < 40) || (numP2 >= 51 && numP2 < 60)
                    || (numP2 >= 71 && numP2 < 80) || (numP2 >= 91 && numP2 < 100))
                {
                    player2.transform.position = new Vector2(player2.position.x - 40f, player2.position.y);
                }
                if (numP2 < 100)
                    numP2++;
                else
                    numP2--;
                Debug.Log("P1:" + numP1 + " | P2: " + numP2);
                yield return new WaitForSeconds(1f);
            }
            checkSnakes(numP2);
            checkLadder(numP2);
            
            if (numP2 == 100)
            {
                Win(turn);
            }

            turn = 1;
        }
        btnRoll.enabled = true;
        if (turn == 1)
            btnText.text = "Player 1 Turn";
        else if (turn == 2)
            btnText.text = "Player 2 Turn";

        if(win == 1)
        {
            btnRoll.enabled = false;
            btnText.text = "Player 1 wins.";
        }
        else if(win == 2)
        {
            btnRoll.enabled = false;
            btnText.text = "Player 2 wins.";
        }
        Debug.Log("P1:" + numP1 + " | P2: " + numP2);
    }

    void checkLadder(int pos)
    {
        int temp = 0;
        if(turn == 1)
        {
            for(int i = 0; i < ladders.Length;i++)
            {
                if(pos == ladders[i])
                {
                    temp = ladders[i];
                }
            }
            if (temp == 3)
            {
                numP1 = 17;
                 player1.transform.position = new Vector2(player1.transform.position.x + 40, player1.transform.position.y + 45);
            }
            else if(temp == 27)
            {
                numP1 = 85;
                player1.transform.position = new Vector2(player1.transform.position.x - (40*2), player1.transform.position.y + (40 * 6));
            }
            else if (temp == 39)
            {
                numP1 = 43;
                player1.transform.position = new Vector2(player1.transform.position.x + 40, player1.transform.position.y + 45);
            }
            else if (temp == 87)
            {
                numP1 = 93;
                player1.transform.position = new Vector2(player1.transform.position.x + 40, player1.transform.position.y + 40);
            }
        }
        else if(turn == 2)
        {
            for (int i = 0; i < ladders.Length; i++)
            {
                if (pos == ladders[i])
                {
                    temp = ladders[i];
                }
            }
            if (temp == 3)
            {
                numP2 = 17;
                player2.transform.position = new Vector2(player2.transform.position.x + 40, player2.transform.position.y + 45);
            }
            else if (temp == 27)
            {
                numP1 = 85;
                player2.transform.position = new Vector2(player2.transform.position.x - (40 * 2), player2.transform.position.y + (40 * 6));
            }
            else if (temp == 39)
            {
                numP2 = 43;
                player2.transform.position = new Vector2(player2.transform.position.x + 40, player2.transform.position.y + 45);
            }
            else if (temp == 87)
            {
                numP2 = 93;
                player2.transform.position = new Vector2(player2.transform.position.x + 40, player2.transform.position.y + 40);
            }
        }
        
        temp = 0;
    }
    void checkSnakes(int pos)
    {
        int temp = 0;

        if(turn == 1)
        {
            for (int i = 0; i < snakes.Length; i++)
            {
                if (numP1 == snakes[i])
                {
                    temp = snakes[i];
                }
            }
            if (temp == 15)
            {
                numP1 = 8;
                player1.transform.position = new Vector2(player1.transform.position.x + (40 *2), player1.transform.position.y - 45);
            }
            else if (temp == 44)
            {
                numP1 = 35;
                player1.transform.position = new Vector2(player1.transform.position.x + (40 * 2), player1.transform.position.y - 45);
            }
            else if (temp == 49)
            {
                numP1 = 12;
                player1.transform.position = new Vector2(player1.transform.position.x , player1.transform.position.y - 130);
            }
            else if(temp == 88)
            {
                numP1 = 52;
                player1.transform.position = new Vector2(player1.transform.position.x + 40, player1.transform.position.y - 125);
            }
            else if(temp == 99)
            {
                numP1 = 62;
                player1.transform.position = new Vector2(player1.transform.position.x, (420f - 120f));
            }

        }
        else if(turn == 2)
        {
            for (int i = 0; i < snakes.Length; i++)
            {
                if (numP2 == snakes[i])
                {
                    temp = snakes[i];
                }
            }
            if (temp == 15)
            {
                numP2 = 8;
                player2.transform.position = new Vector2(player2.transform.position.x + (40 * 2), player2.transform.position.y - 45);
            }
            else if (temp == 44)
            {
                numP2 = 35;
                player2.transform.position = new Vector2(player2.transform.position.x + (40 * 2), player2.transform.position.y - 45);
            }
            else if (temp == 49)
            {
                numP2 = 12;
                player2.transform.position = new Vector2(player2.transform.position.x, player2.transform.position.y - 130);
            }
            else if (temp == 88)
            {
                numP2 = 52;
                player2.transform.position = new Vector2(player2.transform.position.x + 40, player2.transform.position.y - 125);
            }
            else if (temp == 99)
            {
                numP2 = 62;
                player2.transform.position = new Vector2(player2.transform.position.x, (420f - 120f));
            }
        }

        temp = 0;
    }

    void Win(int turn)
    {
        if(turn == 1)
        {
            Debug.Log("Player 1 Win");
            btnRoll.enabled = false;
            win = 1;
            StartCoroutine(Restart());
        }
        else if(turn == 2)
        {
            Debug.Log("Player 2 Win");
            btnRoll.enabled = false;
            win = 2;
            StartCoroutine(Restart());
        }

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}