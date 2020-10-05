using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resultscore : MonoBehaviour
{
    int score;
    public Text resultscoretext;
    public Text bestscoretext;
    private int bestscore;
    private string key = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        score = playerscript.getScore();
        resultscoretext.GetComponent<Text>().text = "Score:" + score.ToString();

        bestscore = PlayerPrefs.GetInt(key, 0);
        bestscoretext.text = "BestScore: " + bestscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > bestscore)
        {

            bestscore = score;

            PlayerPrefs.SetInt(key, bestscore);

            bestscoretext.text = "BestScore: " + bestscore.ToString();
        }

    }
}
