using UnityEngine;

public abstract class AbstarctChunk : MonoBehaviour
{
    [SerializeField] protected ChunkDirection _direction;

    public ChunkDirection ChunkDirection => _direction;

    public void GetDirection()
    {
    }
}