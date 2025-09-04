using UnityEngine;
using System.Collections.Generic;

public class Lobis_Hability : MonoBehaviour
{
    public LayerMask destruivel;
    public AudioClip somHabilidade; // som da habilidade (arraste no Inspector)
    private AudioSource audioSource;

    Troca_Personagens troca;

    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
        audioSource = GetComponent<AudioSource>();

        // Se não tiver AudioSource, cria um
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && troca.Lobisomen_Object.activeSelf)
        {
            Hability();
        }
    }

    void Hability()
    {
        Collider2D[] colisoes = Physics2D.OverlapCircleAll(
            troca.Personagens_Object.transform.position,
            1f,
            destruivel
        );

        bool destruiuAlgo = false;

        foreach (Collider2D colisor in colisoes)
        {
            if (colisor != null && troca.Lobisomen_Object.activeSelf)
            {
                colisor.gameObject.SetActive(false);
                destruiuAlgo = true;
            }
        }

        // Toca som apenas se destruiu pelo menos 1 objeto
        if (destruiuAlgo && somHabilidade != null)
        {
            audioSource.PlayOneShot(somHabilidade);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (troca != null && troca.Personagens_Object != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(troca.Personagens_Object.transform.position, 1f);
        }
    }
}
