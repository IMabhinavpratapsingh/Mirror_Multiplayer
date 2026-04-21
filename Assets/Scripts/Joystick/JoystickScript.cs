using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickScript : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public static JoystickScript instance;
    [SerializeField] RectTransform border;
    [SerializeField] RectTransform knob;

    float radius;
    Vector2 output;

    void Start()
    {
        instance = this;
        radius = border.sizeDelta.x/2;
    }

    public void OnPointerDown(PointerEventData data)
    {
        OnDrag(data);
    }

    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            border,
           eventdata.position,
           eventdata.pressEventCamera,
            out pos
       );

        pos = Vector2.ClampMagnitude(pos, radius);

        knob.anchoredPosition = pos;

        output = pos / radius;        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knob.anchoredPosition = Vector2.zero;
        output = Vector2.zero;
    }

    public Vector2 Output()
    {
        return output;
    }

}
