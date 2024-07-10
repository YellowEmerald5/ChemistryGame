using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Storages/storage", order = 0)]
public class Storage : ScriptableObject
{
    public Map activeChems;

    public void AddChem(string n)
    {
        activeChems.Add(n);
    }

    public void RemoveChem(string n)
    {
        activeChems.Remove(n);
    }

    public int GetAmount(string n)
    {
        return activeChems.GetCount(n);
    }

    public void MergeValues(string n,string m)
    {
        var mSplit = m.Split(' ');
        var mNum = Int32.Parse(mSplit[1]);
        activeChems.MergeValues(n,mNum);
    }
    
    public void MergeChems(string n,string m,string newCategory,int i)
    {
        activeChems.MergeEntries(n,m,newCategory,i);
    }
}