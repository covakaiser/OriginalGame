using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    
    float jump = 10.0f;
    public int playerHP = 5;
    public GameObject enemy;

    public int score = 0;
    public GameObject scoretext;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.Find("Notes0");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity += new Vector3(0, jump, 0);
        }
        if (playerHP == 0)
        {
            Debug.Log("gameover");
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHP--;
            Debug.Log(playerHP);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("score"))
        {
            score++;
            scoretext.GetComponent<Text>().text = "Score:" + score.ToString();
        }
    }
}
