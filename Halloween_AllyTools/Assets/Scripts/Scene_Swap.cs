using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Swap : MonoBehaviour
{
    public string Scene;
   void Swap()
    {
        SceneManager.LoadScene(Scene);
    }
}
