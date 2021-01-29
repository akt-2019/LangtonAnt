using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace LangtonAnt
{
    public class InputListener : MonoBehaviour
    {
        public AntController Ant;
        public Tilemap tilemap;
        public Text counter;
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                GameObject ant = Instantiate(Ant.gameObject, new Vector2(Random.Range(-10, 10) + 0.5f, Random.Range(-10, 10) + 0.5f), Quaternion.identity);
                AntController controller = ant.GetComponent<AntController>();
                controller.tilemap = tilemap;
                controller.StepCounter = counter;
            }
        }
    }
}
