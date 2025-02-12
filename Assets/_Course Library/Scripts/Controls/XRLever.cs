using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// An interactable lever that snaps into an on or off position by a direct interactor
/// </summary>
public class XRLever : XRBaseInteractable // ✅ Eliminamos "Interactables."
{
    [Tooltip("The object that's grabbed and manipulated")]
    public Transform handle = null;

    [Tooltip("The initial value of the lever")]
    public bool defaultValue = false;

    // When the lever is activated
    public UnityEvent OnLeverActivate = new UnityEvent();

    // When the lever is deactivated
    public UnityEvent OnLeverDeactivate = new UnityEvent();

    public bool Value { get; private set; } = false;

    private IXRSelectInteractor selectInteractor = null; // ✅ Eliminamos "Interactors."

    private void Start()
    {
        FindSnapDirection(defaultValue);
        SetValue(defaultValue);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        selectEntered.AddListener(StartGrab);
        selectExited.AddListener(EndGrab);
        selectExited.AddListener(ApplyValue);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        selectEntered.RemoveListener(StartGrab);
        selectExited.RemoveListener(EndGrab);
        selectExited.RemoveListener(ApplyValue);
    }

    private void StartGrab(SelectEnterEventArgs eventArgs)
    {
        selectInteractor = eventArgs.interactorObject;
    }

    private void EndGrab(SelectExitEventArgs eventArgs)
    {
        selectInteractor = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected && selectInteractor != null) // ✅ Evita errores si es null
            {
                Vector3 lookDirection = GetLookDirection();
                handle.forward = transform.TransformDirection(lookDirection);
            }
        }
    }

    private Vector3 GetLookDirection()
    {
        if (selectInteractor == null) return Vector3.forward; // ✅ Evita NullReferenceException

        Vector3 direction = selectInteractor.transform.position - handle.position;
        direction = transform.InverseTransformDirection(direction);

        direction.x = 0;
        direction.y = Mathf.Clamp(direction.y, 0, 1);

        return direction;
    }

    private void ApplyValue(SelectExitEventArgs eventArgs)
    {
        if (eventArgs.interactorObject == null) return; // ✅ Evita errores si es null

        bool isOn = InOnPosition(eventArgs.interactorObject.transform.position);

        FindSnapDirection(isOn);
        SetValue(isOn);
    }

    private bool InOnPosition(Vector3 interactorPosition)
    {
        interactorPosition = transform.InverseTransformPoint(interactorPosition);
        return (interactorPosition.z > 0);
    }

    private void FindSnapDirection(bool isOn)
    {
        handle.forward = isOn ? transform.forward : -transform.forward;
    }

    private void SetValue(bool isOn)
    {
        Value = isOn;

        if (Value)
        {
            OnLeverActivate.Invoke();
        }
        else
        {
            OnLeverDeactivate.Invoke();
        }
    }
}