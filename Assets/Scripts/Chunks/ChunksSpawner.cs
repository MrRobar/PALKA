using UnityEngine;

public class ChunksSpawner : MonoBehaviour
{
    [SerializeField] private AbstarctChunk[] _chunksPrefabs;
    [SerializeField] private Transform _chunksParent;
    [SerializeField] private AbstarctChunk _currentChunk;
    [SerializeField] private int _offset;

    [ContextMenu("Spawn")]
    public void SpawnRandomChunk()
    {
        var newChunk = Instantiate(GetRandomChunk(), _chunksParent);
        var newPos = GetPositionForChunk();
        var newRot = GetRotationForChunk();
        newChunk.transform.localPosition = newPos;
        newChunk.transform.localRotation = newRot;
        _currentChunk = newChunk;
    }

    private Vector3 GetPositionForChunk()
    {
        var position = _currentChunk.transform.localPosition;
        switch (_currentChunk.ChunkDirection)
        {
            case ChunkDirection.Forward:
                position.z += _offset;
                break;
            case ChunkDirection.Left:
                position.x -= _offset;
                break;
            case ChunkDirection.Right:
                position.x += _offset;
                break;
        }

        return position;
    }

    private Quaternion GetRotationForChunk()
    {
        var rotation = _currentChunk.transform.localRotation;
        switch (_currentChunk.ChunkDirection)
        {
            case ChunkDirection.Forward:
                rotation = Quaternion.identity;
                break;
            case ChunkDirection.Left:
                rotation = Quaternion.identity;
                break;
            case ChunkDirection.Right:
                rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
        }

        return rotation;
    }

    private AbstarctChunk GetRandomChunk()
    {
        var randomChunk = Random.Range(0, _chunksPrefabs.Length);
        while ((_currentChunk.ChunkDirection == ChunkDirection.Left &&
                _chunksPrefabs[randomChunk].ChunkDirection == ChunkDirection.Left) ||
               (_currentChunk.ChunkDirection == ChunkDirection.Right &&
                _chunksPrefabs[randomChunk].ChunkDirection == ChunkDirection.Right))
        {
            randomChunk = Random.Range(0, _chunksPrefabs.Length);
        }

        return _chunksPrefabs[randomChunk];
    }
}