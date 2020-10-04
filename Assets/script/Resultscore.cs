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
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        bestscoretext.text = "BestScore: " + bestscore.ToString();
        //ハイスコアを表示

    }

    // Update is called once per frame
    void Update()
    {
        //ハイスコアより現在スコアが高い時
        if (score > bestscore)
        {

            bestscore = score;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, bestscore);
            //ハイスコアを保存

            bestscoretext.text = "BestScore: " + bestscore.ToString();
            //ハイスコアを表示
        }

    }
}
