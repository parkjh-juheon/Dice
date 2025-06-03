using UnityEngine;

public class MapManager : MonoBehaviour
{
    public StageNode startNode;

    void Start()
    {
        startNode.SetState(StageNode.StageState.Available);
    }

    public void OnStageClear(StageNode node)
    {
        node.SetState(StageNode.StageState.Cleared);

        foreach (var next in node.nextNodes)
            if (next.state == StageNode.StageState.Locked)
                next.SetState(StageNode.StageState.Available);
    }
}
