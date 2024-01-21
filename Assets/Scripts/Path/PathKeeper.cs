using UnityEngine;

public class PathKeeper : MonoBehaviour
{
    private void Start()
    {
        ConnectNodes();
    }

    private void ConnectNodes()
    {
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            transform.GetChild(i).GetComponent<PathNode>().NextNode =
                transform.GetChild(i + 1).GetComponent<PathNode>();
        }
    }
}
