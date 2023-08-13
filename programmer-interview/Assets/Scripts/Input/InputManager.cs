using UnityEngine;
using InputActions;

public class InputManager : Singleton<InputManager>
{

    public static Character character;

    private new void Awake()
    {
        base.Awake();

        character = new Character();
        character.Enable();

        CanvasManager.onOpenPopup += character.Disable;
        CanvasManager.onClosePopup += character.Enable;
    }

}