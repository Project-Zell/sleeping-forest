using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class EnemyHealthDisplayPooler : MonoBehaviour
{
    public List<Transform> healthBars = new List<Transform>();
    public List<Transform> reserveBars = new List<Transform>();
    public Transform healthBarPrefab;
    public int healthBarCount;
    public Transform reserveBarParent;
    public Transform activeBarParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 150; i++)
        {
            var thisBar = Instantiate(healthBarPrefab);
            thisBar.parent = reserveBarParent;
            thisBar.gameObject.SetActive(false);
            reserveBars.Add(thisBar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
