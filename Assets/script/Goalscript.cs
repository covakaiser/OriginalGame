using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goalscript : MonoBehaviour
{
    public GameObject goal;
    float timer = 0;
    float interval = 108.5f;
    public bool musicstart = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (musicstart == false)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                Instantiate(goal, new Vector3(35f, 7, 17), transform.rotation);
                timer = 0;
            }

        }
    }

    public void GameStart()
    {
            musicstart = !musicstart;
    }

}

