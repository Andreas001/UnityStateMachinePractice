using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string currentScene;

    private void Start() {
        currentScene = "Level 1";
    }

    public void LoadLevelOneScene() {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevelTwoScene() {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadWinScene() {
        SceneManager.LoadScene("Win");
    }
}
