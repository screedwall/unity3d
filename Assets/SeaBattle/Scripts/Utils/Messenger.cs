using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.SeaBattle.Scripts.Utils
{
    public static class Messenger
    {

        private static Dictionary<Type, List<object>> subscribers = new Dictionary<Type, List<object>>();

        public static void Subscribe<TMessage>(Action<TMessage> handler)
        {
            if (subscribers.ContainsKey(typeof(TMessage)))
                subscribers[typeof(TMessage)].Add((object)handler);
            else
                subscribers[typeof(TMessage)] = new List<object>()
        {
          (object) handler
        };
        }

        public static void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            if (!subscribers.ContainsKey(typeof(TMessage)))
                return;
            List<object> subscriber = subscribers[typeof(TMessage)];
            subscriber.Remove((object)handler);
            if (subscriber.Count != 0)
                return;
            subscribers.Remove(typeof(TMessage));
        }

        public static void Publish<TMessage>(TMessage message)
        {
            if (!subscribers.ContainsKey(typeof(TMessage)))
                return;
            foreach (Action<TMessage> action in subscribers[typeof(TMessage)])
                action(message);
        }
    }
}
