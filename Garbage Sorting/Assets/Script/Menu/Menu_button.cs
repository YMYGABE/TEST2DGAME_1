using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_button : MonoBehaviour
{
    public void LodeGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
    
}
