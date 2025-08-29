using UnityEngine;

public class Troca_Personagens : MonoBehaviour
{
    [Header("Estado Atual")]
    public bool lobsomen_player = false;
    public bool zombie_player = false;
    public bool human_player = true;

    [Header("Referências de Objetos")]
    public GameObject Lobisomen_Object;
    public GameObject Zombie_Object;
    public GameObject Human_Object;
    public GameObject Vampiro_Object;

    [Header("Áudios")]
    public AudioSource audioSource;
    public AudioClip lobiSound;
    public AudioClip zombieSound;
    public AudioClip humanSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SwapLobi();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SwapZombie();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwapHuman();
        }
    }

    public void SwapLobi()
    {
        lobsomen_player = true;
        zombie_player = false;
        human_player = false;
        Update_Objects();
        PlaySound(lobiSound);
    }

    public void SwapZombie()
    {
        lobsomen_player = false;
        zombie_player = true;
        human_player = false;
        Update_Objects();
        PlaySound(zombieSound);
    }

    public void SwapHuman()
    {
        lobsomen_player = false;
        zombie_player = false;
        human_player = true;
        Update_Objects();
        PlaySound(humanSound);
    }

    void Update_Objects()
    {
        Lobisomen_Object.SetActive(lobsomen_player);
        Zombie_Object.SetActive(zombie_player);
        Human_Object.SetActive(human_player);
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
