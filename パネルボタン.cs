using UnityEngine;
using UnityEngine.EventSystems;

public class パネルボタン : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public 手 手;

    public void OnPointerClick(PointerEventData eventData)
    {
        //もし左クリックなら
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            入力マネージャー.Instance.入力解釈(this.gameObject);
        }
    }

}
