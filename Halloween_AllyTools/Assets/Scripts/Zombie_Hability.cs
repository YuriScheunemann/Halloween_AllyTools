using System;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie_Hability : MonoBehaviour
{
    public LayerMask buraco;
    public Transform ponto_Teleporte;
    public Transform buraco_Teleporte;
    Troca_Personagens troca;
    void Start()
    {
        troca = FindObjectOfType(typeof(Troca_Personagens)) as Troca_Personagens;

    }

    void Update()
    {
        if (!troca.Zombie_Object.activeSelf)
        {
            return;
        }   
        if (Input.GetKeyDown(KeyCode.E) && troca.Zombie_Object.activeSelf)
        {
            Hability();
        }
    }
    
    void Hability()
    {    
        Collider2D colisor = Physics2D.OverlapCircle(troca.Personagens_Object.transform.position, 0.1f, buraco);

        if (colisor != null && ponto_Teleporte != null && troca.Zombie_Object.activeSelf)
        {
            troca.Personagens_Object.transform.position = buraco_Teleporte.position;
        }
        
        if (colisor != null && buraco_Teleporte != null && troca.Zombie_Object.activeSelf)
        {           
            troca.Personagens_Object.transform.position = ponto_Teleporte.position;
        }        
    }
   
}
