using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    public void OnClickStage()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
