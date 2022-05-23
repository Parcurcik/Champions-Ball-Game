using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public static Controller instance;
    public Text txt_GoalsRight, txt_GoalsLeft, txt_MatchTime;
    public static int number_GR, number_GL;
    public bool EndMatch, isScore;
    public float MatchTime;
    private GameObject ball, player, player2;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        number_GL = 0;
        number_GR = 0;
        MatchTime = 90;
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        StartCoroutine(BeginningOfTheMatch());
    }
    

    // Update is called once per frame
    void Update()
    {
        txt_GoalsLeft.text = number_GL.ToString();
        txt_GoalsRight.text = number_GR.ToString();
        txt_MatchTime.text = MatchTime.ToString();
    }
    IEnumerator BeginningOfTheMatch()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if(MatchTime > 0)
            {
                MatchTime --;
            }
            else
            {
                StartCoroutine(WaitEndGame());
                EndMatch = true;
                break;
            }
        }
    }

    public void ContinueMatch(bool winner)
    {
        StartCoroutine(WaitingContinueMatch(winner));
    }
    IEnumerator WaitingContinueMatch(bool winner)
    {
        yield return new WaitForSeconds(2f);
        isScore = false;
        if(EndMatch == false)
        {
            ball.transform.position = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.transform.position = new Vector3(4, 0, 0);
            player2.transform.position = new Vector3(-10, 0, 0);
            if (winner == true)
            {
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
            }
            else
            { 
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 200));
            }
        }
    }
    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndGame");
    }
}
