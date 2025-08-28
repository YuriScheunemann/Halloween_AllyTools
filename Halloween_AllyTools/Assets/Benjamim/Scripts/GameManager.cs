using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Arrays para guardar os bot�es, imagens e sons de cada forma
    // A ordem � importante! Por exemplo: 0=Lobisomem, 1=Zumbi, 2=Vampiro, 3=Humano
    public Button[] botoes;
    public Sprite[] spritesFormas;
    public AudioClip[] sonsFormas;

    // Refer�ncia ao AudioSource do GameManager
    private AudioSource audioSource;

    // Vari�vel para rastrear o �ndice da �ltima forma clicada
    private int ultimaFormaClicada = -1; // -1 significa que nenhuma forma foi clicada ainda

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Adiciona um listener para cada bot�o
        for (int i = 0; i < botoes.Length; i++)
        {
            // O '.bind(this)' � um truque para passar o valor de 'i' para a fun��o.
            // Para isso, a fun��o deve ser criada.
            int index = i;
            botoes[i].onClick.AddListener(() => OnBotaoClicado(index));
        }
    }

    public void OnBotaoClicado(int indiceDoBotao)
    {
        // Se j� houver uma forma clicada
        if (ultimaFormaClicada != -1)
        {
            // 1. Troca a imagem do �ltimo bot�o clicado para a do humano
            botoes[ultimaFormaClicada].image.sprite = spritesFormas[3]; // 3 � o �ndice do sprite do Humano

            // 2. Troca a imagem do bot�o atual para a do Lobisomem
            // Se o bot�o atual for o Zumbi (�ndice 1), ele vira Lobisomem (�ndice 0)
            if (indiceDoBotao == 1) // Zumbi -> Lobisomem
            {
                botoes[indiceDoBotao].image.sprite = spritesFormas[0];
                audioSource.PlayOneShot(sonsFormas[0]);
            }
            // Se o bot�o atual for o Vampiro (�ndice 2), ele vira Lobisomem
            else if (indiceDoBotao == 2) // Vampiro -> Lobisomem
            {
                botoes[indiceDoBotao].image.sprite = spritesFormas[0];
                audioSource.PlayOneShot(sonsFormas[0]);
            }
        }

        // Atualiza a �ltima forma clicada
        ultimaFormaClicada = indiceDoBotao;
    }
}