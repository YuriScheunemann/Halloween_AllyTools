using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    Troca_Personagens troca;
    [SerializeField] private UnityEvent OnVictory;
    
    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnVictory.Invoke();
        }
    }
}
