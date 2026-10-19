using UnityEngine; 
using UnityEngine.EventSystems;

public class MobileInput : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
    public static Vector2 MoveInput { get; private set; }
    public static bool IsFiring { get; private set; }
    public static bool DashPressed { get; private set; }
    
[Header("Virtual Joystick")]
public RectTransform joystickBackground;
public RectTransform joystickHandle;

private Vector2 inputVector;

public void OnPointerDown(PointerEventData eventData)
{
    UpdateJoystick(eventData);
}

public void OnDrag(PointerEventData eventData)
{
    UpdateJoystick(eventData);
}

public void OnPointerUp(PointerEventData eventData)
{
    inputVector = Vector2.zero;
    MoveInput = Vector2.zero;

    if (joystickHandle != null)
        joystickHandle.anchoredPosition = Vector2.zero;
}

private void UpdateJoystick(PointerEventData eventData)
{
    if (joystickBackground == null)
        return;

    Vector2 localPoint;

    if (RectTransformUtility
        .ScreenPointToLocalPointInRectangle(
            joystickBackground,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
    {
        Vector2 radius =
            joystickBackground.rect.size * 0.5f;

        inputVector = new Vector2(
            radius.x > 0 ? localPoint.x / radius.x : 0,
            radius.y > 0 ? localPoint.y / radius.y : 0
        );

        inputVector = Vector2.ClampMagnitude(
            inputVector, 1f);

        MoveInput = inputVector;

        if (joystickHandle != null)
        {
            joystickHandle.anchoredPosition =
                new Vector2(
                    inputVector.x * radius.x,
                    inputVector.y * radius.y
                );
        }
    }
}

public void OnFireDown(BaseEventData eventData)
{
    IsFiring = true;
}

public void OnFireUp(BaseEventData eventData)
{
    IsFiring = false;
}

public void OnDashPressed()
{
    DashPressed = true;
}

public void OnDashReleased()
{
    DashPressed = false;
}

private void OnDisable()
{
    MoveInput = Vector2.zero;
    IsFiring = false;
    DashPressed = false;
    inputVector = Vector2.zero;
}
}