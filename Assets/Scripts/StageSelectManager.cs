using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{

    public GameObject[] stageButtons;   //ステージ選択ボタン
    // Start is called before the first frame update
    void Start()
    {
        //どのステージまでクリアしているかをロード
        int clearStageNo = PlayerPrefs.GetInt("CLEAR",0);

        //ステージボタン有効化
        for (int i = 0; i <= stageButtons.GetUpperBound (0); i++){
            bool b;

            if(clearStageNo < i){
                b =false;
            } else {
                b = true;
            }

            //ボタンの有効化/無効化を設定
            stageButtons[i].GetComponent<Button>().interactable = b;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ステージ選択ボタンを押した
    public void PushStageSelectButton (int stageNo){
        //ゲームシーンへ
        SceneManager.LoadScene ("PuzzleScene" + stageNo);
    }

    public void PushBackButton (){
        //Backシーンへ
        SceneManager.LoadScene ("TitleScene");
    }
}
