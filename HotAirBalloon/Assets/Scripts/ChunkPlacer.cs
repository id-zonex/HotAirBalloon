using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Chunk _firstChunkPrefab;

    [SerializeField] private float MAX_Y_POS = 14;
    [SerializeField] private int MAX_CHUNKS_COUNT = 5;

    private List<Chunk> _spawedChunks;

    private Chunk _lastChunk => _spawedChunks[_spawedChunks.Count - 1];
    private Chunk _firstChunk => _spawedChunks[0];


    private void Start()
    {
        _spawedChunks = new List<Chunk>();

        _spawedChunks.Add(_firstChunkPrefab);
        SpawnChunk(GetRandomChunk());
    }


    private void Update()
    {
        if(_firstChunk.Begin.position.y <= MAX_Y_POS)
            SpawnChunk(GetRandomChunk());

        if(_spawedChunks.Count > MAX_CHUNKS_COUNT)
            DestroyFirstChunk();
    }

    private void SpawnChunk(Chunk chunk)
    {
        Vector3 chunkPosition = _lastChunk.End.position - chunk.Begin.localPosition;
        Chunk newChunk = Instantiate(chunk, chunkPosition, Quaternion.identity, transform);

        _spawedChunks.Add(newChunk);
    }

    private void DestroyFirstChunk()
    {
        Destroy(_firstChunk.gameObject);
        _spawedChunks.Remove(_firstChunk);
    }

    private Chunk GetRandomChunk() { return _chunks[Random.Range(0, _chunks.Length)]; }
}
