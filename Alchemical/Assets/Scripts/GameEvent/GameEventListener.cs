using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameEvent
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised()
        {
            response?.Invoke();
        }
    }
}