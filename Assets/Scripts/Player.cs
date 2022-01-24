using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool isAlive = true;
    public int keys = 0;
    public float speed = 5.0f;
    private float timeLeft = 13.0f;

    public Text keyAmount;
    public Text youWin;
    public Text YouLose;
    public Text Intro;
    public GameObject IntroBG;

    public AudioSource pickSource;
    //public AudioSource deathSource;
    // Start is called before the first frame update
    void Start()
    {
        pickSource = GetComponent<AudioSource> ();
        //deathSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //if(timeLeft >= 10)
        //{
        //    isAlive = false;
        //}

        if(timeLeft <= 10)
        {
            Destroy(Intro);
            Destroy(IntroBG);
            
        }

        if(timeLeft <= 0 & isAlive == true)
            GameOver();

        if(isAlive == true)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }

        if(keys==3 & timeLeft >= 0)
        {
            youWin.text = "YOU WIN!";
            timeLeft = 1;
            isAlive = false;
            FindObjectOfType<SoundEffects>().DeathSound();
        }
    }

    private void GameOver()
    {
        YouLose.text = "TOO SLOW, YOU LOSE!";
        isAlive = false;
        FindObjectOfType<SoundEffects2>().WinSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Keys")
        {
            pickSource.Play();    
            keys++;
            keyAmount.text = "Keys: " + keys;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "End")
        {
            youWin.text = "YOU WIN!";
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Enemies")
        {
            //deathSource.Play();
            FindObjectOfType<SoundEffects2>().WinSound();
            isAlive = false;
            YouLose.text = "YOU DIE, YOU LOSE";
        }
        if(collision.gameObject.tag == "Walls")
            {
                if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
