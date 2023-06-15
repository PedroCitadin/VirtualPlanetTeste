using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndGameController : MonoBehaviour
{

    private int pontuacao;
    public Text txtPontuacao;
    
    void Start()
    {
        pontuacao = PlayerPrefs.GetInt("pontos");
        txtPontuacao.text = "Pontuação: "+pontuacao;
    }

    
   ///função para reiniciar o jogo 
   public void reloadGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");

    }


   
}
