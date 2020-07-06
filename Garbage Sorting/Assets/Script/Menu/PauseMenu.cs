using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isPused = false; //检测游戏是否暂停状态，默认为否
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPused){
                Resum();
            }else{
                Pause();
            }
        }
    }

    public void Resum(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        isPused = false;
    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        isPused = true;
    }
    public void MainMenu(){
        isPused = false;
        SceneManager.LoadScene("Menu");
    }
    public void QuiteGame(){
        Application.Quit();
    }
}
