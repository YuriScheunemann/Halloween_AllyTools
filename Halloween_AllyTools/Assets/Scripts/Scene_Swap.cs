using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Swap : MonoBehaviour
{
    public string Scene;
   public void Swap()
    {
        SceneManager.LoadScene(Scene);
    }
}
