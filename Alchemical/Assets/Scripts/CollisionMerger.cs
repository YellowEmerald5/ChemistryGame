using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionMerger : MonoBehaviour
{
    //public UnityEvent ev;
    //[SerializeField] private Storage store;
    public int contained;
    private bool _collided;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //ev.Invoke();
        _collided = true;
        var obj = other.gameObject;
        var colled = obj.name.Split(' ');
        var coller = name.Split(' ');
        var i = 0;
        var j = 0;
        if (colled.Length != 1)
        {
            i = Int32.Parse(colled[1]);
        }
        if (coller.Length != 1)
        {
            j = Int32.Parse(coller[1]);
        }
        var c = obj.GetComponent<CollisionMerger>().contained;
        contained += c;
        var ints = new [] {i,j};
        var sorted = Sort(ints);
        MergeAttributes(obj,c);
        if (sorted[1] == j)
        {
            Destroy(this);
        }
        else if(sorted[1] == i)
        {
            transform.localScale += obj.transform.localScale/10;
            Destroy(obj);
        }
        
        _collided = false;
    }

    private int[] Sort(int[] ints)
    {
        if (ints[0] > ints[1])
        {
            (ints[0], ints[1]) = (ints[1], ints[0]);
        }
        return ints;
    }

    private void MergeAttributes(GameObject obj,int i)
    {
        var thisSubstance = GetComponent<SubstanceProperties>();
        var a = thisSubstance.symbol;
        var b = thisSubstance.density;
        var c = thisSubstance.electronegativity;
        var d = thisSubstance.electronAffinity;
        var e = thisSubstance.shellLevel;
        var z = thisSubstance.shells;
        var x = thisSubstance.electronCountsPerShell;
        var f = thisSubstance.state;
        var g = thisSubstance.atomicMass;
        var h = thisSubstance.ionizationEnergy;
        var j = thisSubstance.meltingPoint;
        var k = thisSubstance.oxidizationStates;
        var l = thisSubstance.boilingPoint;
        var thatSubstance = obj.GetComponent<SubstanceProperties>();
        if (thisSubstance.symbol.Equals(thatSubstance.symbol))
        {
            return;
        }
        
        var perLow = 0f;
        var m = i + 0f;
        var perHigh = 1f;
        /*var newCol = new Color();
        var colThis = thisSubstance.c;
        var colThat = thatSubstance.c;
        newCol.a = 1;
        
        var thisR = colThis.r * 255 - 127.5f;
        var thisG = colThis.g * 255 - 127.5f;
        var thisB = colThis.b * 255 - 127.5f;
        
        var thatR = colThat.r * 255 - 127.5f;
        var thatG = colThat.g * 255 - 127.5f;
        var thatB = colThat.b * 255 - 127.5f;
        if (i > contained)
        {
            perLow = contained / m;
            perHigh = 1 - perLow;
            newCol.r = ((thisR*perLow + thatR*perHigh)+127.5f)/255;
            newCol.g = ((thisG*perLow + thatG*perHigh)+127.5f)/255;
            newCol.b = ((thisB*perLow + thatB*perHigh)+127.5f)/255;
        }
        else
        {
            perLow = m / contained;
            perHigh = 1 - perLow;
            newCol.r = ((thisR*perHigh + thatR*perLow)+127.5f)/255;
            newCol.g = ((thisG*perHigh + thatG*perLow)+127.5f)/255;
            newCol.b = ((thisB*perHigh + thatB*perLow)+127.5f)/255;
        }
        
        if (newCol.r > 1)
        {
            newCol.r = 1;
        }
        if (newCol.r < 0)
        {
            newCol.r = 0;
        }
        
        if (newCol.g > 1)
        {
            newCol.g = 1;
        }
        if (newCol.g < 0)
        {
            newCol.g = 0;
        }
        
        if (newCol.b > 1)
        {
            newCol.b = 1;
        }
        if (newCol.b < 0)
        {
            newCol.b = 0;
        }
        
        print(newCol + " " + name);

        thisSubstance.c = newCol;
        var rend = GetComponent<SpriteRenderer>();
        rend.color = newCol;*/
    }
}
