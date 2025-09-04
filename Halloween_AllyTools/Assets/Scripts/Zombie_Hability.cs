using UnityEngine;

public class Zombie_Hability : MonoBehaviour
{
    public LayerMask buraco;
    public Transform ponto_Teleporte;
    public Transform buraco_Teleporte;

    public AudioClip somHabilidade; 
    private AudioSource audioSource;

    Troca_Personagens troca;

    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
        audioSource = GetComponent<AudioSource>();

        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && troca.Zombie_Object.activeSelf)
        {
            Hability();
        }
    }

    void Hability()
    {
        Collider2D colisor = Physics2D.OverlapCircle(troca.Personagens_Object.transform.position,1f,buraco);

        if (colisor != null && ponto_Teleporte != null && troca.Zombie_Object.activeSelf)
        {
            troca.Personagens_Object.transform.position = buraco_Teleporte.position;
            TocarSom();
        }       
    }

    void TocarSom()
    {
        if (somHabilidade != null)
        {
            audioSource.PlayOneShot(somHabilidade);
        }
    }
}
