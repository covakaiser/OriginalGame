using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    
    float jump = 10.0f;
    public int playerHP = 5;
    public GameObject enemy;

    public static int score = 0;
    public GameObject scoretext;
    public GameObject HPtext;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.Find("Notes0");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, jump, 0);
            animator.SetBool("jump", true);
        }else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("jump", false);
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetBool("slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
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
    }
    public static int getScore()
    {
        return score;
    }
}
