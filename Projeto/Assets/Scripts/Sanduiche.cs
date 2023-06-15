using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "sanduiche", menuName = "Sanduiche/New Sanduiche")]
public class Sanduiche : ScriptableObject
{
    public string nome;
    public Sprite logo;
    public List<int> ingredientes;



    private List<int> ingredientesPossiveis = new List<int>() { 1, 2, 3, 4, 5 };
    private List<string> ingNames = new List<string>() { "Tomate", "Presunto", "Queijo", "Alface", "Salame" }; //lista com nomes dos ingredientes para a geração do nome de cada sanduiche


    
    public void geraReceita(){


        ingredientes.Clear();
        int range = 5;
        for (int i = 0; i < 3; i++)
        {

            // Gera um índice aleatório dentro do tamanho atual da lista de ingredientes
            int indiceAleatorio = Random.Range(0, range);
            range--;

            // Adiciona o elemento selecionado à nova receita
            ingredientes.Add(ingredientesPossiveis[indiceAleatorio]);

            // Remove o elemento selecionado da lista de ingredientes para evitar repetição
            ingredientesPossiveis.RemoveAt(indiceAleatorio);
        }

        ////reinicia a lista de ingredientes
        ingredientesPossiveis.Clear();
        ingredientesPossiveis = new List<int>() { 1, 2, 3, 4, 5 };

        nome= "Sanduíche de " + ingNames[ingredientes[0] - 1] + " com " + ingNames[ingredientes[1] - 1] + " e " + ingNames[ingredientes[2] - 1];
        
    }


    //função para unir os sprites dos ingredientes e formar a logo do sanduice
    public void mergeSprites(Sprite sp0, Sprite sp1, Sprite sp2, Sprite sp3)
    {



        Resources.UnloadUnusedAssets();

        ///organiza os sprites dos ingredientes selecionados em um array
        Sprite[] spritesMix = new Sprite[4];
        spritesMix[0] = sp0;
        spritesMix[1] = sp1;
        spritesMix[2] = sp2;
        spritesMix[3] = sp3;


        //varivavel para armazenar uma nova textura
        var newTex = new Texture2D(500, 500);


        ///separa os pixels transparentes
        for (int x = 0; x < newTex.width; x++)
        {
            for (int y = 0; y < newTex.height; y++)
            {
                newTex.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        ///pinta a imagem com os pixels dos ingredientes
        for (int i = 0; i < spritesMix.Length; i++)
        {
            for (int x = 0; x < spritesMix[i].texture.width; x++)
            {
                for (int y = 0; y < spritesMix[i].texture.height; y++)
                {
                    var color = spritesMix[i].texture.GetPixel(x, y).a == 0 ? newTex.GetPixel(x, y) : spritesMix[i].texture.GetPixel(x, y);

                    newTex.SetPixel(x, y, color);
                }
            }
        }
        newTex.Apply();
        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = "logo";
        logo = finalSprite;
    }




}
