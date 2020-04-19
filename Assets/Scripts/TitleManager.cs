using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public GameObject resetText; 
    public AudioClip bombSE;    //消去音
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushStartButton(){
        SceneManager.LoadScene("StageSelectScene");
    }

    public void PushResetButton(){

        PlayerPrefs.DeleteAll();        
        resetText.SetActive(true);      //クリア表示
        audioSource.PlayOneShot (bombSE);  //爆発音再生

        //3秒後にセレクト画面へ
        Invoke ("GobackTitle", 3.0f);
    }

    void GobackTitle(){
        SceneManager.LoadScene("TitleScene");
    }
}
