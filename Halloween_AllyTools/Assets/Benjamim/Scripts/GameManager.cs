using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Arrays para guardar os botões, imagens e sons de cada forma
    // A ordem é importante! Por exemplo: 0=Lobisomem, 1=Zumbi, 2=Vampiro, 3=Humano
    public Button[] botoes;
    public Sprite[] spritesFormas;
    public AudioClip[] sonsFormas;

    // Referência ao AudioSource do GameManager
    private AudioSource audioSource;

    // Variável para rastrear o índice da última forma clicada
    private int ultimaFormaClicada = -1; // -1 significa que nenhuma forma foi clicada ainda

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Adiciona um listener para cada botão
        for (int i = 0; i < botoes.Length; i++)
        {
            // O '.bind(this)' é um truque para passar o valor de 'i' para a função.
            // Para isso, a função deve ser criada.
            int index = i;
            botoes[i].onClick.AddListener(() => OnBotaoClicado(index));
        }
    }

    public void OnBotaoClicado(int indiceDoBotao)
    {
        // Se já houver uma forma clicada
        if (ultimaFormaClicada != -1)
        {
            // 1. Troca a imagem do último botão clicado para a do humano
            botoes[ultimaFormaClicada].image.sprite = spritesFormas[3]; // 3 é o índice do sprite do Humano

            // 2. Troca a imagem do botão atual para a do Lobisomem
            // Se o botão atual for o Zumbi (índice 1), ele vira Lobisomem (índice 0)
            if (indiceDoBotao == 1) // Zumbi -> Lobisomem
            {
                botoes[indiceDoBotao].image.sprite = spritesFormas[0];
                audioSource.PlayOneShot(sonsFormas[0]);
            }
            // Se o botão atual for o Vampiro (índice 2), ele vira Lobisomem
            else if (indiceDoBotao == 2) // Vampiro -> Lobisomem
            {
                botoes[indiceDoBotao].image.sprite = spritesFormas[0];
                audioSource.PlayOneShot(sonsFormas[0]);
            }
        }

        // Atualiza a última forma clicada
        ultimaFormaClicada = indiceDoBotao;
    }
}