using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler CurrentObjectPooler;

    [SerializeField] private int _startPoolCount;
    [SerializeField] private int _maxPoolCount;
    [SerializeField] private bool _canGrow;

    [SerializeField] private GameObject _pooledObject;
    [SerializeField] private List<GameObject> _pooledObjects;

    private void Awake()
    {
        CurrentObjectPooler = this;
    }

	private void Start ()
    {
        for (var i = 0; i < _startPoolCount; i++)
        {
            GameObject obj = Instantiate(_pooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (var i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        if(_canGrow && _pooledObjects.Count < _maxPoolCount)
        {
            GameObject obj = Instantiate(_pooledObject);
            _pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
