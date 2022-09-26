using System;
using UnityEngine;


namespace Utility
{
    [Serializable]
    public class ScenePath
    {
        [SerializeField] private string _scenePath = "empty";

        public override string ToString() => _scenePath;

        public static implicit operator string(ScenePath x) => x._scenePath;
    }
}