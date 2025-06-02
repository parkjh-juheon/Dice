using System.Collections.Generic;
using UnityEngine;

public class StageMapManager : MonoBehaviour
{
    public List<StageNode> allNodes;
    private StageNode currentNode;

    public void SetCurrentNode(StageNode node)
    {
        currentNode = node;
        foreach (var n in allNodes)
        {
            n.isReachable = false;
        }

        foreach (var next in node.nextNodes)
        {
            next.isReachable = true;
        }
    }
}
