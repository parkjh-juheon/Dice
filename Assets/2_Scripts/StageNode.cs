// StageNode.cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageNode : MonoBehaviour
{
    public enum StageState { Locked, Available, Cleared }
    public StageState state = StageState.Locked;

    public List<StageNode> nextNodes;
    public string sceneToLoad;

    public Image iconImage;
    public Button nodeButton;

    private void Start()
    {
        UpdateVisual();
        nodeButton.onClick.AddListener(OnClick);
    }

    void UpdateVisual()
    {
        nodeButton.interactable = (state == StageState.Available);
        iconImage.color = (state == StageState.Cleared) ? Color.gray : Color.white;
    }

    void OnClick()
    {
        if (state != StageState.Available) return;

        Debug.Log($"�̵�: {sceneToLoad}");
        // SceneManager.LoadScene(sceneToLoad); // ���� ��ȯ
    }

    public void SetState(StageState newState)
    {
        state = newState;
        UpdateVisual();
    }
}
