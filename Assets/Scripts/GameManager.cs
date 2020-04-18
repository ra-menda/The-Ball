using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int StageNo;     //ステージナンバー
    public bool isBallMoving;    //ボールが移動中か

    public GameObject ballPrefab;   //ボールプレハブ
    public GameObject ball;         //ボールオブジェクト

    public GameObject goButton;     //ボタン：開始時
    public GameObject retryButton;  //ボタン：リトライ
    public GameObject clearText;    //テキスト：クリア*961

    public AudioClip clearSE;   //効果音：クリア
    private AudioSource audioSource;    //オーデイオソース



    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);   //リトライボタン非表示
        isBallMoving = false;           //ボールは移動中ではない   

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //ステージクリア処理
    public void StageClear(){
        audioSource.PlayOneShot (clearSE);  //クリアオン再生

        //セーブデータ更新
        if(PlayerPrefs.GetInt("CLEAR",0)< StageNo){
            PlayerPrefs.SetInt("CLEAR",StageNo);    //ステージナンバー記録

        }
        clearText.SetActive(true);      //クリア表示
        retryButton.SetActive(false);   //リトライボタン非表示

        //3秒後にセレクト画面へ
        Invoke ("GobackStageSelect", 3.0f);
    }

    //バックボタン押した
    public void PushBackButton(){
        GobackStageSelect();
    }

    //移動処理
    void GobackStageSelect(){
        SceneManager.LoadScene("StageSelectScene");
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
