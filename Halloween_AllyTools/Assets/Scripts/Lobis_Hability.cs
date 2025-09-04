using UnityEngine;
using System.Collections.Generic;

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
        if (Input.GetKeyDown(KeyCode.E) && troca.Lobisomen_Object.activeSelf)
        {
            Hability();
        }
    }

    void Hability()
    {
        Collider2D[] colisoes = Physics2D.OverlapCircleAll(troca.Personagens_Object.transform.position, 1f, destruivel);

        foreach (Collider2D colisor in colisoes)
        {
            if (colisor != null && troca.Lobisomen_Object.activeSelf)
            {
                colisor.gameObject.SetActive(false);               
            }
        }        
    }

    void OnDrawGizmosSelected()
    {
        if (troca != null && troca.Personagens_Object != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(troca.Personagens_Object.transform.position, 0.1f);
        }
    }  
}
