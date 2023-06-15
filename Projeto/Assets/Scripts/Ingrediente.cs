using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform tf; //transform do ingrediente
    private Transform bread; // transform para pegar o posicionamento do pão
    private SpriteRenderer sr; //SpriteRenderer do ingrediente usado para manipular a layer
    
    ///variaveis utilizadas para pegar a posição inicial do ingrediente
    private float startX; 
    private float startY;

    //variavel para armazenar o id do ingrediente
    public int idIng;

    //variavel para controle da ação ao clicar no ingrediente
    public bool isClicked = false;

    void Start()
    {
        tf = GetComponent<Transform>();
        bread = GameObject.Find("Bread").transform;
        sr = GetComponent<SpriteRenderer>();
        startX = tf.position.x;
        startY = tf.position.y;
    }

    
     void OnMouseDown()
    {
        
        
        if (!isClicked)
        {
            ///posiciona o ingrediente no pão e passa os parametros para o gamecontroller
            sr.sortingOrder = GameController.instance.currentLayer;
            GameController.instance.currentLayer++;
            tf.position = bread.position;
            GameController.instance.sanduiche.Add(idIng);
            isClicked = true;
        }
        else
        {

            ///remove o ingrediente do pão para corrigir caso tenha sido posicionado erroneamente 
                if (GameController.instance.currentLayer-1==sr.sortingOrder)
            {
                sr.sortingOrder = 1;
                tf.position = new Vector3(startX, startY, 0);
                GameController.instance.currentLayer--;
                GameController.instance.sanduiche.Remove(idIng);
                isClicked = false;
            }
            
        }
       


    }
   public void reloadPosition () { 

        ///retorna para a posição inicial
        tf.position = new Vector3(startX, startY, 0); 
        isClicked= false;
            
    }



   
}
