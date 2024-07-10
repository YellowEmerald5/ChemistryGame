using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private ObjectToSpawn objectToSpawn;
    private List<string> types;
    private List<int> amount;
    private int listPos;

    private void Start()
    {
        types = new List<string>();
        amount = new List<int>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var obj = objectToSpawn.obj;
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var lowerBound = new Vector3(-9, -3.7f, 0);
            var upperBound = new Vector3(9, 4.95f, 0);
            if ((pos.x < lowerBound.x || pos.y < lowerBound.y) || (pos.x > upperBound.x || pos.y > upperBound.y))
            {
                return;
            }
            var offset = new Vector3(0, 0, 10);
            var go = Instantiate(obj, pos+offset, Quaternion.identity);
            var i = Contains(obj.name);
            if (i >= 0)
            {
                amount[i]++;
                go.name = obj.name + " " + amount[i];
            }
            else
            {
                types.Add(obj.name);
                amount.Add(1);
                go.name = obj.name + " " + amount[listPos];
                amount[listPos]++;
            }
        }
    }

    private int Contains(string n)
    {
        var i = -1;
        for (var j = 0; j < types.Count; j++)
        {
            if (types[j].Equals(n))
            {
                i = j;
            }
        }
        return i;
    }
}
