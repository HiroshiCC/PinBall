using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    private GameObject scoreText;
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

            // デバッグ用　（無限に続く）
            this.transform.position = new Vector3(3, 3, 4);
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // 衝突したターゲットが何かを調べて、得点を加算する。
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.score += 5;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.score += 15;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.score += 10;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.score += 20;
        }

        // スコアの表示
        this.scoreText.GetComponent<Text>().text = "Score:"+this.score ;

    }
}

