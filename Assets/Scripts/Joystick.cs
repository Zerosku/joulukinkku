using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    // is the basic function for the onscreen joystick
    // (lots of inspiration from internet on this one)

    private Image bgImg;                //finds the joystick image and its background
    private Image joystickImg;

    public Vector2 InputDirection { set; get; }

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();

        // sets the joystick on [0,0] so its centered
        InputDirection = Vector2.zero;      

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        // activates following when the joystick is being dragged

        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImg.rectTransform.pivot.x == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            InputDirection = new Vector2(x, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

            joystickImg.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (bgImg.rectTransform.sizeDelta.x / 3), InputDirection.y * (bgImg.rectTransform.sizeDelta.y / 3));
        }


    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        //when the joystick is clicked or tapped on, activates the OnDrag function so you dont have to move the joystick to activate it
        OnDrag(ped);

    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        // sets the joysticks cordinates to [0,0]
        InputDirection = Vector2.zero;
        // joysticks [0,0] position is the center of the image behind the joystick
        joystickImg.rectTransform.anchoredPosition = Vector2.zero;
    }
}
