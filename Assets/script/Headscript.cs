using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Headscript : MonoBehaviour
{
    public int playerHP = 5;
    public GameObject HPtext;
    public GameObject headhit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            headhit.SetActive(false);
        }else if (Input.GetKeyUp(KeyCode.M))
        {
            headhit.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            headhit.SetActive(false);
        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            headhit.SetActive(true);
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
    }
}