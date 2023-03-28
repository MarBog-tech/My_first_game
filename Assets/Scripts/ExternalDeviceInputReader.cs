using Player.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExternalDeviceInputReader : IEntityInputSource
{
    public bool Attack { get; private set; }
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public float VerticalDirection => Input.GetAxisRaw("Vertical");

    public void OnFire()
    {
        if ( Input.GetButtonDown("Fire1") && !IsPointer())
        {
            Attack = true;
        }
    }

    private bool IsPointer() => EventSystem.current.IsPointerOverGameObject();
    public void ResetOneTimeActions() => Attack = false;
}