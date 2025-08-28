using UnityEngine;
using UnityEngine.UI;

public class Lobisomem : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip somClique;

    void Start()
    {
        // Pega o componente AudioSource que está no mesmo GameObject
        audioSource = GetComponent<AudioSource>();

        // Adiciona a função TocarSom ao evento de clique do botão
        GetComponent<Button>().onClick.AddListener(TocarSom);
    }

    void TocarSom()
    {
        // Agora que audioSource não é nulo, a função PlayOneShot funciona
        audioSource.PlayOneShot(somClique);
    }
}
