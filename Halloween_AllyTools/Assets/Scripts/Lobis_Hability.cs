using System.Diagnostics;
using UnityEngine;

public class Lobis_Hability : MonoBehaviour
{
    public LayerMask destruivel;
    Troca_Personagens troca;
    
    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;
    }

   
    void Update()
    {
        if (!troca.Lobisomen_Object.activeSelf)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) && troca.Lobisomen_Object.activeSelf)
        {
            Hability();
        }
    }

    void Hability()
    {
        Collider2D colisor = Physics2D.OverlapCircle(troca.Personagens_Object.transform.position, 0.1f, destruivel);
    }
}
