using UnityEngine;

public class Zombie_Hability : MonoBehaviour
{
    public LayerMask buraco;
    public Transform ponto_Teleporte;
    Troca_Personagens troca;
    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;

    }
      
    void Update()
    {
        if (troca.zombie_player == null)
        {
            return;
        }   
        if (Input.GetKeyDown(KeyCode.E) && troca.zombie_player != null)
        {
            Hability();
        }
    }

    void Hability()
    {
        Collider2D colisor = Physics2D.OverlapCircle(troca.Zombie_Object.transform.position, 0.1f, buraco);

        if (colisor != null && ponto_Teleporte != null)
        {
            troca.Zombie_Object.transform.position = ponto_Teleporte.position;
        }
        else 
        {
            Debug.Log("nothing hapend");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
