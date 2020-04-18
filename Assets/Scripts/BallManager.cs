using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボールがなにかに衝突
    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.gameObject.tag =="OutArea") {
            //アウトエリアに衝突
            //ゲームマネージャーを取得
            GameObject gameManager = GameObject.Find ("GameManager");
            //リトライ
            gameManager.GetComponent<GameManager> ().PushRetryButton ();
            
            
        }
    }

    //ボールがなにかのトリガーに衝突
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "ClearArea"){
             GameObject gameManager = GameObject.Find ("GameManager");
            //クリアエリアに入った
            gameManager.GetComponent<GameManager> ().StageClear ();
            
        }
    }
}