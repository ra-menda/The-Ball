using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int StageNo;     //ステージナンバー
    public bool isBallMoving;    //ボールが移動中か

    public GameObject ballPrefab;   //ボールプレハブ
    public GameObject ball;         //ボールオブジェクト

    public GameObject goButton;     //ボタン：開始時
    public GameObject retryButton;  //ボタン：リトライ


    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);   //リトライボタン非表示
        isBallMoving = false;           //ボールは移動中ではない    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Goボタンを押した
    public void PushGoButton(){
        //ボールの重力有効化
        Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
        rd.isKinematic = false;

        retryButton.SetActive(true);
        goButton.SetActive(false);
        isBallMoving = true;
    }

      //Retryボタンを押した
    public void PushRetryButton(){
       Destroy (ball);

       ball = (GameObject)Instantiate (ballPrefab);

        retryButton.SetActive(false);
        goButton.SetActive(true);
        isBallMoving = false;
    }
}
