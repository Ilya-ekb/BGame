using System;
using System.Collections.Generic;
using UnityEngine;

namespace Plugins.BGame.Utilities.CustomInspector
{
    [Serializable]
    public abstract class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField, HideInInspector] private List<TKey> keys = new List<TKey>();
        [SerializeField, HideInInspector] private List<TValue> values = new List<TValue>();

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (var item in this)
            {
                keys.Add(item.Key);
                values.Add(item.Value);
            } 
        }

        public void OnAfterDeserialize()
        {
            Clear();
            for (var i = 0; i < this.keys.Count && i < this.values.Count; i++)
                this[keys[i]] = values[i];
        }
    }
}