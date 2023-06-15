using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public List<int> sanduiche = new List<int>();//lista utilizada para constru��o do sanduiche
    private List<int> ingredientes = new List<int>() {1, 2, 3, 4, 5};//lista numerica para representa��o dos ingredientes
    private List<string> ingNames = new List<string>() {"Tomate", "Presunto", "Queijo", "Alface", "Salame"}; //lista com nomes dos ingredientes para a gera��o do nome de cada sanduiche
    public List<int> receita = new List<int>(); //lista para gera��o da receita de cada rodada
    public GameObject groupRoot; //grupo para controle dos ingredientes
    public int pontuacao; //contador da pontua��o do usu�rio
    public int currentLayer = 1; //Variavel para controle do layer atual, usada para posicionar um ingrediente sobre o outro na ordem de coloca��o
    public Text txtPotuacao; //txt da pontua��o do jogador
    public Sanduiche currentSanduiche;
    


    
    public Text nomeS; //txt nome do sanduiche


    ///Sprites dos ingredientes
    public Sprite pao;
    public Sprite tomate;
    public Sprite presunto;
    public Sprite queijo;
    public Sprite alface;
    public Sprite salame;

    ///lista dos sprites
    private List<Sprite> ingSprites = new List<Sprite>();

    ///Imagens para o posicionamento da logo do sanduiche
    public Image ing1;
    

    ///Imagens para o posicionamento dos ingredientes na receita
    public Image ing1Receita;
    public Image ing2Receita;
    public Image ing3Receita;


    public Text txtTime;
    private float timeCount = 120;
    private bool timeOver = false;
    
    void Start()
    {
        instance = this;
        ingSprites = new List<Sprite>() { tomate, presunto, queijo, alface, salame };
        currentSanduiche.geraReceita();
        currentSanduiche.mergeSprites(pao, ingSprites[currentSanduiche.ingredientes[0] - 1], ingSprites[currentSanduiche.ingredientes[1] - 1], ingSprites[currentSanduiche.ingredientes[2] - 1]);
        pontuacao = 0;
        
       
        
        setUIReceita();
        
    }

    
    void Update()
    {

         verificaIngredientes();
         Timer();

        
    }
    

    
    



    void verificaIngredientes()
    {
        ///verifica quantos ingredientes ja foram acrescentados
        if(sanduiche.Count == 3)
        {
            verificaSanduiche();
        }
        
    }


    public void setUIReceita()
    {
        //atualiza a UI da receita
        
        nomeS.text = currentSanduiche.nome;
        ing1.sprite = currentSanduiche.logo;
        
        
        ing1Receita.sprite = ingSprites[currentSanduiche.ingredientes[0] - 1];
        ing2Receita.sprite = ingSprites[currentSanduiche.ingredientes[1] - 1];
        ing3Receita.sprite = ingSprites[currentSanduiche.ingredientes[2] - 1];

    }


    void verificaSanduiche()
    {
        ///verifica se o sanduiche criado corresponde com a receita solicitada
        


        if (currentSanduiche.ingredientes.SequenceEqual(sanduiche))
        {
            pontuacao++;
        }
        else
        {
            pontuacao--;
        }
        txtPotuacao.text = pontuacao.ToString();
        sanduiche.Clear();

        ///reposiciona os ingredientes para o proximo sanduiche
        var components = groupRoot.GetComponentsInChildren<Ingrediente>();
        foreach (var component in components)
        {
            
            component.reloadPosition();
        }


        
        currentSanduiche.geraReceita();
        currentSanduiche.mergeSprites(pao, ingSprites[currentSanduiche.ingredientes[0] - 1], ingSprites[currentSanduiche.ingredientes[1] - 1], ingSprites[currentSanduiche.ingredientes[2] - 1]);
        currentLayer = 1;
        setUIReceita();
    }


    ///Timer
    void updateUITimer()
    {
        txtTime.text =timeCount.ToString("F0");
    }
    
    void Timer()
    {
        timeOver = false;
        if(!timeOver  && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            updateUITimer();
        }
        if (timeCount <= 0)
        {
            timeCount = 0;
            timeOver = true;
            PlayerPrefs.SetInt("pontos", pontuacao);
            SceneManager.LoadScene("EndGame");
        }
    }

    //m�todo para gerar receitas de sandu�che aleatoriamente
    
}
