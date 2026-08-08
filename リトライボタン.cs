using UnityEngine;
using UnityEngine.EventSystems;

public class リトライボタン : MonoBehaviour　, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        入力マネージャー.Instance.入力解釈(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
