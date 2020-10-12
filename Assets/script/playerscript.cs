using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    
    float jump = 10.0f;
    public int playerHP = 5;

    public static int score = 0;
    public GameObject hearts1;
    public GameObject hearts2;
    public GameObject hearts3;
    public GameObject hearts4;
    public GameObject hearts5;
    public GameObject scoretext;
    Animator animator;

    AudioSource audioSource;
    public AudioClip ya;
    public AudioClip ei;
    public AudioClip uu;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        score = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, jump, 0);
            animator.SetBool("jump", true);
            audioSource.PlayOneShot(ya);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("slide", true);
            audioSource.PlayOneShot(ei);
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            animator.SetBool("slide", false);
        }
        if (playerHP == 4)
        {
            Destroy(hearts5.gameObject);
        }
        if(playerHP == 3)
        {
            Destroy(hearts4.gameObject);
        }
        if(playerHP == 2)
        {
            Destroy(hearts3.gameObject);
        }
        if(playerHP == 1)
        {
            Destroy(hearts2);
        }
        if (playerHP == 0)
        {
            Destroy(hearts1.gameObject);
            SceneManager.LoadScene("Gameover");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHP--;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(uu);
        }

        if (other.CompareTag("score"))
        {
            score++;
            scoretext.GetComponent<Text>().text = "Score:" + score.ToString();
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("result");
        }
    }
    public static int getScore()
    {
        return score;
    }
}
