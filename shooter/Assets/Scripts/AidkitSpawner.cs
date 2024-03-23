using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    public float delayMin = 3;
    public float delayMax = 9;

    public List<Transform> _spawnerPoints;

    private Aidkit _aidkit;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;

        Invoke("CreateAidkit", Random.Range(delayMin, delayMax));
    }

    private void CreateAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
    }
}
