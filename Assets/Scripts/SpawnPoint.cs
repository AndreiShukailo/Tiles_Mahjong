using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cards;
    [SerializeField] private Transform _field;

    private Vector3 _spawnPosition;

    private void Awake()
    {
        _spawnPosition = transform.position;
    }

    private void Start()
    {
        foreach (var item in _cards)
        {
            Instantiate(item,_spawnPosition , item.transform.rotation, _field);
            _spawnPosition.z -= 0.3f;
            _spawnPosition.y += 0.3f;
        }
    }
}
