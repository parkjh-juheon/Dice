using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NodeType { Battle, Event, Shop }

public class StageNode : MonoBehaviour
{
    public NodeType nodeType;
    public List<StageNode> nextNodes;
    public bool isCurrent;
    public bool isReachable;

    public void OnClick()
    {
        if (!isReachable) return;

        // 다음 씬으로 이동
        switch (nodeType)
        {
            case NodeType.Battle:
                SceneManager.LoadScene("BattleScene");
                break;
            case NodeType.Event:
                SceneManager.LoadScene("EventScene");
                break;
            case NodeType.Shop:
                SceneManager.LoadScene("ShopScene");
                break;
        }
    }
}

