using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ObjectToSpawn", menuName = "Storages/ObjectToSpawn", order = 0)]
    public class ObjectToSpawn : ScriptableObject
    {
        public GameObject obj;
    }
}