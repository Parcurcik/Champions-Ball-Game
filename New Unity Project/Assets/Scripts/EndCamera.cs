using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCamera : MonoBehaviour
{
    public Text result, goalsMU, goalsPsg;
     void Start()
    {
        goalsPsg.text = 0.ToString();
        goalsMU.text = 0.ToString();
        goalsPsg.text = Controller.number_GL.ToString();
        goalsMU.text = Controller.number_GR.ToString();

        if (Controller.number_GL > Controller.number_GR)
        {
            result.text = "Messi win!";
        }
        else if (Controller.number_GL < Controller.number_GR)
        {
            result.text = "Ronaldo win!";
        }
        else
        {
            result.text = "Draw!";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
