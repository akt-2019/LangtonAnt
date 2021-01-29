using UnityEngine;
using UnityEngine.Tilemaps;

namespace LangtonAnt
{
    public class AntController : MonoBehaviour
    {
        public Tilemap tilemap;
        public float stepInterval;
        public Direction facingDirection;

        public ColorTile blackTile;
        public ColorTile whiteTile;

        private float elapsed;

        private void Update()
        {
            ColorTile tile;

            elapsed += Time.deltaTime;
            if (elapsed >= stepInterval)
            {
                Vector3Int tilePosition = new Vector3Int(
                    (int)(transform.position.x - 0.5f),
                    (int)(transform.position.y - 0.5f),
                    (int)(transform.position.z));
                tile = tilemap.GetTile<ColorTile>(tilePosition);

                if (tile == null)
                {
                    Destroy(gameObject);
                    return;
                }

                if (tile.Color == TileColor.Black)
                {
                    Rotate(-1);
                    tilemap.SetTile(tilePosition, whiteTile);
                }
                else if (tile.Color == TileColor.White)
                {
                    Rotate(1);
                    tilemap.SetTile(tilePosition, blackTile);
                }

                tilemap.RefreshTile(tilePosition);

                Move();

                elapsed = 0;
            }
        }

        private void Move()
        {
            switch (facingDirection)
            {
                case Direction.North:
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                    break;
                case Direction.South:
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                    break;
                case Direction.East:
                    transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                    break;
                case Direction.West:
                    transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                    break;
            }
        }

        private void Rotate(int direction)
        {
            facingDirection = (Direction)(((int)facingDirection + direction + 4) % 4);
        }

        public enum Direction
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }
    }
}