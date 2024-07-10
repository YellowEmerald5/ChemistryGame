using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class SetObjectToSpawn : MonoBehaviour
    {
        [SerializeField] private ObjectToSpawn storedObjectToSpawn;
        [SerializeField] private GameObject objectToSetForSpawn;

        public void SetObject()
        {
            storedObjectToSpawn.obj = objectToSetForSpawn;
        }
    }
}