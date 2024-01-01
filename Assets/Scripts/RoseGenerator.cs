using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int num;

    void Start()
    {

    }

    void RandomColor()
    {
        var roses = transform.GetComponentsInChildren<Rose>();
        foreach (var rose in roses)
        {
            rose.RandomColor();
        }
    }
    void RandomGen()
    {
        foreach (var prefab in prefabs)
        {
            for (int i = 0; i < num; i++)
            {
                var go = GameObject.Instantiate(prefab);
                go.SetActive(true);
                go.transform.rotation = Quaternion.Euler(0, Random.value * 180, 0);
                go.transform.position = prefab.transform.position +
                                        new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) * 0.05f;
            }
        }
    }
}