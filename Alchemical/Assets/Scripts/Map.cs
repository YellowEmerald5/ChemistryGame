using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Map : MonoBehaviour
{
    private string[] names;
    private List<int>[] nums;
    private int index;
    private int size;

    public void Add(string s)
    {
        if (names == null)
        {
            IncreaseArrays();
        }

        if (index >= size - 1)
        {
            size += size;
            IncreaseArrays();
        }

        var sSplit = s.Split(' ');
        var i = Contains(sSplit[0]);

        if (i > -1)
        {
            nums[i].Add(1);
        }
        else
        {
            names[index] = s;
            nums[index].Add(1);
            index++;
        }
    }

    public void Remove(string s)
    {
        var i = Contains(s);
        if (i<0) return;
        Move(i);
        index--;
    }

    public int GetCount(string s)
    {
        var n = s.Split(' ');
        var num = int.Parse(n[1]);
        var i = Contains(n[0]);
        return i<0 ? 0 : nums[i][num];
    }

    public int GetAmount(string s)
    {
        var n = s.Split(' ');
        var i = Contains(n[0]);
        return nums[i].Count;
    }

    private void IncreaseArrays()
    {
        size = 10;
        var tempName = names;
        var tempNums = nums;
        names = new string[size];
        nums = new List<int>[size];
        for (var i = 0; i < index-1; i++)
        {
            names[i] = tempName[i];
            nums[i] = tempNums[i];
        }
    }

    private int Contains(string s)
    {
        var t = -1;
        for (var i = 0; i <= names.Length; i++)
        {
            if (names[i].Equals(s))
            {
                t = i;
            }
        }
        return t;
    }

    private void Move(int pos)
    {
        for (var i = pos; i < index-1; i++)
        {
            names[i] = names[i + 1];
            nums[i] = nums[i + 1];
        }

        names[index] = "";
        nums[index] = null;
    }

    private void AddAmount(string s,int to,int amount)
    {
        var pos = Contains(s);
        nums[pos][to] += amount - 1;
    }

    public void MergeValues(string n,int i)
    {
        var nSplit = n.Split(' ');
        var num = Int32.Parse(nSplit[1]);
        var p = Contains(nSplit[0]);
        nums[p][num] += nums[p][i];
        nums[p][i] = 0;
    }

    public void MergeEntries(string n,string m, string newCat, int amount)// Set up the reaction to call with the resulting amount
    {
        var nSplit = n.Split(' ');
        var mSplit = m.Split(' ');
        var nPos = Contains(nSplit[0]);
        var mPos = Contains(mSplit[0]);
        var j = Int32.Parse(nSplit[1]);
        var k = Int32.Parse(mSplit[1]);
        Add(newCat);
        var pos = Contains(newCat);
        AddAmount(newCat, nums[pos].Count, amount);
        
        nums[nPos][j] = 0;
        nums[mPos][k] = 0;
    }
    
}