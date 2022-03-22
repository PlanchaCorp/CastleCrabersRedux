using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Tiles Variable")]
    public class TilesVariable : ScriptableObject
    {
        [SerializeField]
        public Tile[] tiles;
    }
}
