 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private GameObject _player;
    private GameObject _player2;
    public GameObject goals;
    [SerializeField] private AudioSource audioMessi;
    [SerializeField] private AudioSource audioRonaldo;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = true;

        }
        if (collision.gameObject.tag == "Player2")
        {
            _player2.GetComponent<Player2>().canShoot2 = true;
        }
        if (collision.gameObject.tag == "GoalsRight")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if (Controller.instance.isScore == false && Controller.instance.EndMatch == false)
            {
                Controller.number_GL++;
                Controller.instance.isScore = true;
                Controller.instance.ContinueMatch(true);
                audioMessi.Play();
            }
        }
        if (collision.gameObject.tag == "GoalsLeft")
        {
            Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
            if (Controller.instance.isScore == false && Controller.instance.EndMatch == false)
            {
                Controller.number_GR++;
                Controller.instance.isScore = true;
                Controller.instance.ContinueMatch(false);
                audioRonaldo.Play();
            }
        }
        if (collision.gameObject.tag == "BehindCol")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = false;

        }
        if (collision.gameObject.tag == "Player2")
        {
            _player2.GetComponent<Player2>().canShoot2 = false;
        }
    }
}
