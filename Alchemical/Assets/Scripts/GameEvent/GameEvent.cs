using System.Collections.Generic;
using UnityEngine;

namespace GameEvent
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Event/gameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {

        private List<GameEventListener> _listeners = new();

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }
        public void UnRegisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Raise()
        {
            foreach (var listener in _listeners)
            {
                listener.OnEventRaised();
            }
        }
    }
}