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
    public GameObject scoretext;
    public GameObject HPtext;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.Find("Notes0");
        animator = GetComponent<Animator>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, jump, 0);
            animator.SetBool("jump", true);
            GetComponent<AudioSource>().Play();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("jump", false);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetBool("slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            animator.SetBool("slide", false);
        }
        if (playerHP == 0)
        {
            SceneManager.LoadScene("Gameover");
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHP--;
            Destroy(other.gameObject);
            HPtext.GetComponent<Text>().text = "HP:" + playerHP.ToString();
            
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
