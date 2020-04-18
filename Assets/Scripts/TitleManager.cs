using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public GameObject resetText; 
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
