using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject restartMenu;
    public static MainManager Instance;

    private void Awake() {

        if(Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RestartScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene to restart it
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ActivateRestartMenu() {
        restartMenu.SetActive(true);
    }
}
