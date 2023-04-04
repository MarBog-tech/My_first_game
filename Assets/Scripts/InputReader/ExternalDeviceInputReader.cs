using System;
using Core.Services.ProjectUpdater;
using InputReader;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExternalDeviceInputReader : IEntityInputSource, IDisposable
{
    public bool Attack { get; private set; }
    public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
    public float VerticalDirection => Input.GetAxisRaw("Vertical");

    public ExternalDeviceInputReader()
    {
        ProjectUpdater.Instance.UpdateCalled += OnFire;
    }
    
    public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnFire;

    public void ResetOneTimeActions() => Attack = false;

    private void OnFire()
    {
        if ( Input.GetButtonDown("Fire1") && !IsPointer())
        {
            Attack = true;
        }
    }
    
    private bool IsPointer() => EventSystem.current.IsPointerOverGameObject();
}