using UnityEngine;
using UnityEngine.UI;

public class Lobisomem : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip somClique;

    void Start()
    {
        // Pega o componente AudioSource que est� no mesmo GameObject
        audioSource = GetComponent<AudioSource>();

        // Adiciona a fun��o TocarSom ao evento de clique do bot�o
        GetComponent<Button>().onClick.AddListener(TocarSom);
    }

    void TocarSom()
    {
        // Agora que audioSource n�o � nulo, a fun��o PlayOneShot funciona
        audioSource.PlayOneShot(somClique);
    }
}
