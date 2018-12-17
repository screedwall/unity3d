using UnityEngine;

namespace Assets.SeaBattle.Scripts
{
    public class PlayerController:MonoBehaviour
    {
        public GridHolderManager OwnGridHolder;

        public void ChangeVisible(bool visibility)
        {
            gameObject.SetActive(visibility);
        }
    }
}
