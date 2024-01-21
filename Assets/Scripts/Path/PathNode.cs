using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private PathNode _nextNode;

    public PathNode NextNode
    {
        get => _nextNode;
        set => _nextNode = value;
    }
}
