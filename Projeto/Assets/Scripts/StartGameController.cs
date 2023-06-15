using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameController : MonoBehaviour
{
    

    public void loadGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");

    }
}
