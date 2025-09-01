using System.Diagnostics;
using UnityEngine;

public class Lobis_Hability : MonoBehaviour
{
    public LayerMask destruivel;
    public GameObject Objeto_dest;
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
        Collider2D colisor = Physics2D.OverlapCircle(troca.Personagens_Object.transform.position, 0.1f, destruivel);

        if(colisor != null && troca.Lobisomen_Object.activeSelf && Objeto_dest != null)
        {
            Objeto_dest.SetActive(false);
        }
    }
}
