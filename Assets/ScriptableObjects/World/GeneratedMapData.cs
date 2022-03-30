using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Generated Map Data")]
    public class GeneratedMapData : ScriptableObject
    {
        [SerializeField]
        public TileInfo[,] tiles;
    }
}

