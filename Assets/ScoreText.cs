using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // 得点計算用
    private int points = 0;

    //得点を表示するテキスト
    private GameObject scoretextText;

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        //オブジェクトにボール接触時得点更新
        if (collision.gameObject.CompareTag("SmallStarTag"))
        {
            this.points += 10;
        }
        else if (collision.gameObject.CompareTag("LargeStarTag"))
        {
            this.points += 30;
        }
        else if (collision.gameObject.CompareTag("LargeCloudTag") || collision.gameObject.CompareTag("SmallCloudTag"))
        {
            this.points += 20;
        }
        //得点表示
        scoretextText.GetComponent<Text>().text = points.ToString();
    }

    // Use this for initialization
    void Start()
    {
        //シーン中のPointsCountTextオブジェクトを取得
        this.scoretextText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {

    }

}