using UnityEngine;
using UnityEngine.Audio;

public class Troca_Personagens : MonoBehaviour
{
    public bool lobsomen_player = false;
    public bool zombie_player = false;
    public bool human_player = true;

    public GameObject Lobisomen_Object;
    public GameObject Zombie_Object;
    public GameObject Human_Object;
    public GameObject Personagens_Object;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SwapLobi();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwapZombie();
        }
        if (Input.GetKeyDown(KeyCode.Z))
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
    }

    public void SwapZombie()
    {
        lobsomen_player = false;
        zombie_player = true;
        human_player = false;
        Update_Objects();
    }

    public void SwapHuman()
    {
        lobsomen_player = false;
        zombie_player = false;
        human_player = true;
        Update_Objects();
    }

    void Update_Objects()
    {
        Lobisomen_Object.SetActive(lobsomen_player);
        Zombie_Object.SetActive(zombie_player);
        Human_Object.SetActive(human_player);
    }

   
}