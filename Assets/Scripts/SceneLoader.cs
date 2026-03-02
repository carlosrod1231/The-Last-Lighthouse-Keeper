using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadOutside() => SceneManager.LoadScene("Outside");
    public void LoadInterior() => SceneManager.LoadScene("LighthouseInterior");
    public void LoadEnd() => SceneManager.LoadScene("End");
}
