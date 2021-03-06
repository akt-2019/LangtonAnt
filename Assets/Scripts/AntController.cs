using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace LangtonAnt
{
    public class AntController : MonoBehaviour
    {
        public Tilemap tilemap;
        public float stepInterval;
        public Direction facingDirection;
        public Sprite TileSprite;

        private ColorTile coloredTile;
        private ColorTile uncoloredTile;

        public Text StepCounter;

        private float elapsed;

        private int step = 0;

        private void Start()
        {
            coloredTile = new ColorTile();
            coloredTile.sprite = TileSprite;
            coloredTile.Color = TileColor.Colored;
            coloredTile.color = new Color(255, 255, 255);


            uncoloredTile = new ColorTile();
            uncoloredTile.sprite = TileSprite;
            uncoloredTile.Color = TileColor.Uncolored;
            uncoloredTile.color = Random.ColorHSV();
        }

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

                if (tile.Color == TileColor.Colored)
                {
                    Rotate(-1);
                    tilemap.SetTile(tilePosition, uncoloredTile);
                }
                else if (tile.Color == TileColor.Uncolored)
                {
                    Rotate(1);
                    tilemap.SetTile(tilePosition, coloredTile);
                }

                tilemap.RefreshTile(tilePosition);

                Move();

                elapsed = 0;
                step++;
                StepCounter.text = $"Step : {step}";
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