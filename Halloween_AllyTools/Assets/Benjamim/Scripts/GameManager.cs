using UnityEngine;
using UnityEngine.UI;

public class Transformacoes : MonoBehaviour
{
    public Sprite humanoSprite;
    public Sprite lobisomemSprite;
    public Sprite vampiroSprite;
    public Sprite zumbiSprite;

    public AudioClip somHumano;
    public AudioClip somLobisomem;
    public AudioClip somVampiro;
    public AudioClip somZumbi;

    public Button btnHumano;
    public Button btnLobisomem;
    public Button btnVampiro;
    public Button btnZumbi;

    private Image playerImage;
    private AudioSource audioSource;

    private enum Forma { Humano, Lobisomem, Vampiro, Zumbi }
    private Forma formaAtual = Forma.Humano;

    void Start()
    {
        playerImage = GetComponent<Image>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        // Botão humano começa desativado
        btnHumano.interactable = false;

        // Eventos dos botões
        btnHumano.onClick.AddListener(() => Transformar(Forma.Humano));
        btnLobisomem.onClick.AddListener(() => Transformar(Forma.Lobisomem));
        btnVampiro.onClick.AddListener(() => Transformar(Forma.Vampiro));
        btnZumbi.onClick.AddListener(() => Transformar(Forma.Zumbi));
    }

    void Transformar(Forma novaForma)
    {
        if (novaForma == formaAtual) return; // evita trocar para a mesma forma

        formaAtual = novaForma;

        // Troca sprite e toca som
        switch (novaForma)
        {
            case Forma.Humano:
                playerImage.sprite = humanoSprite;
                audioSource.PlayOneShot(somHumano);
                break;
            case Forma.Lobisomem:
                playerImage.sprite = lobisomemSprite;
                audioSource.PlayOneShot(somLobisomem);
                break;
            case Forma.Vampiro:
                playerImage.sprite = vampiroSprite;
                audioSource.PlayOneShot(somVampiro);
                break;
            case Forma.Zumbi:
                playerImage.sprite = zumbiSprite;
                audioSource.PlayOneShot(somZumbi);
                break;
        }

        // Atualiza quais botões estão ativos
        btnHumano.interactable = (formaAtual != Forma.Humano);
        btnLobisomem.interactable = (formaAtual != Forma.Lobisomem);
        btnVampiro.interactable = (formaAtual != Forma.Vampiro);
        btnZumbi.interactable = (formaAtual != Forma.Zumbi);
        btnZumbi.interactable = (formaAtual != Forma.Zumbi);
    }
}