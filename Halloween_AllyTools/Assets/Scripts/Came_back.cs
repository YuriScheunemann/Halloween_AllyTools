using UnityEngine;

public class Came_back : MonoBehaviour
{
    Troca_Personagens troca;
    public Transform Spawn;    
    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (troca != null && troca.Personagens_Object != null)
            {
                troca.Personagens_Object.transform.position = Spawn.position;
            }
        }
    }
}
