using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CastleCrabers.ScriptableObjects;

namespace CastleCrabers.GUI {
    [RequireComponent(typeof(Grid))]
    public class TileHoverSelector : MonoBehaviour
    {
        [SerializeField]
        private TileCursor tileCursor;
        private Grid grid;

        public void Start() {
            grid = GetComponent<Grid>();
        }

        public void FixedUpate() {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int cellPosition = (Vector2Int)grid.WorldToCell(mousePosition);
            tileCursor.cursorPosition = cellPosition;
        }
    }
}
