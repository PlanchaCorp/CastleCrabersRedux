using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Tile Cursor")]
    public class TileCursor : ScriptableObject
    {
        [SerializeField]
        public Vector2Int cursorPosition;
    }
}
