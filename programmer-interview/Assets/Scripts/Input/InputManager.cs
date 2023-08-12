using UnityEngine;
using InputActions;

namespace Input
{

    public class InputManager : Singleton<InputManager>
    {

        public static Character character;

        private new void Awake()
        {
            base.Awake();

            character = new Character();
            character.Enable();
        }

    }

}