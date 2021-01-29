using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace LangtonAnt
{
    public enum TileColor
    {
        Black,
        White
    }

    public class ColorTile : Tile
    {
        public TileColor Color;

#if UNITY_EDITOR

        [MenuItem("Assets/Create/ColorTile")]
        public static void CreateColorTile()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Color Tile", "New Color Tile", "Asset", "Save Color Tile", "Assets");
            if (path == "") return;

            AssetDatabase.CreateAsset(CreateInstance<ColorTile>(), path);
        }

#endif
    }

}