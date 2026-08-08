using UnityEngine;

public class 入力マネージャー : MonoBehaviour
{
    public static 入力マネージャー Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void 入力解釈(GameObject a)
    {
        //aがパネルコントローラーを持っているか確認
        if (a.TryGetComponent<パネルボタン>(out var パネルコントローラー))
        {
            じゃんけんマネージャー.Instance.プレイヤーの手が選択された(パネルコントローラー.手);
        }

        //aがリトライボタンを持っているか確認
        if (a.TryGetComponent<リトライボタン>(out var リトライコントローラー))
        {
            じゃんけんマネージャー.Instance.リトライ();
        }
    }
}
