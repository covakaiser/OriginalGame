using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallscript : MonoBehaviour
{
    public GameObject wall;
    float timer = 0;
    float interval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Instantiate(wall, new Vector3(35f,5,30), new Quaternion(0,0,180,0));
            timer = 0;
        }
    }
}
