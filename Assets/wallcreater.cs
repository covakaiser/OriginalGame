using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcreater : MonoBehaviour
{
    public GameObject creater;
    float speed = 10.0f;
    float timer = 0;
    float interval = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Instantiate(creater, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
