using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class じゃんけんマネージャー : MonoBehaviour
{
    public static じゃんけんマネージャー Instance { get; private set; }
    [SerializeField] private じゃんけんルール じゃんけんルール;
    private じゃんけん状態 現在の状態;
    private 手 プレイヤーの手;
    private 手 NPCの手;

    [SerializeField] private TextMeshProUGUI プレイヤーの手テキスト;
    [SerializeField] private TextMeshProUGUI NPCの手テキスト;
    [SerializeField] private Image プレイヤーの手Image;
    [SerializeField] private Image NPCの手Image;
    [SerializeField] private Sprite グー画像;
    [SerializeField] private Sprite チョキ画像;
    [SerializeField] private Sprite パー画像;
    [SerializeField] private TextMeshProUGUI 結果テキスト;
    [SerializeField] private CanvasGroup ゲーム層;
    [SerializeField] private CanvasGroup リザルト層
        ;
    [SerializeField] private オーディオマネージャー オーディオマネージャー;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        リザルト層.alpha = 0f; // リザルト用キャンバスを非表示にする
        リザルト層.blocksRaycasts = false;
    }
    public void Start()
    {
        待機状態();
    }

    public void 待機状態()
    {
        現在の状態 = じゃんけん状態.待機;
        Debug.Log("じゃんけんの待機状態です。");
        プレイヤー選択状態();
    }
    public void プレイヤー選択状態()
    {
        現在の状態 = じゃんけん状態.プレイヤー選択;
        Debug.Log("じゃんけんのプレイヤー選択状態です。");
    }
    public void NPC選択状態()
    {
        現在の状態 = じゃんけん状態.NPC選択;
        Debug.Log("じゃんけんのNPC選択状態です。");
        // NPCの手をランダムに選択
        NPCの手 = (手)Random.Range(0, 3);
        結果状態();
    }
    public void 結果状態()
    {
        現在の状態 = じゃんけん状態.結果;
        Debug.Log("じゃんけんの結果状態です。");
        リザルト層.alpha = 1f; // リザルト用キャンバスを表示する
        リザルト層.blocksRaycasts = true;
        プレイヤーの手テキスト.text = "プレイヤー: " + プレイヤーの手.ToString();
        NPCの手テキスト.text = "NPC: " + NPCの手.ToString();
        switch (プレイヤーの手)
        {
            case 手.グー:
                プレイヤーの手Image.sprite = グー画像;
                break;
            case 手.チョキ:
                プレイヤーの手Image.sprite = チョキ画像;
                break;
            case 手.パー:
                プレイヤーの手Image.sprite = パー画像;
                break;
        }
        switch (NPCの手)
        {
            case 手.グー:
                NPCの手Image.sprite = グー画像;
                break;
            case 手.チョキ:
                NPCの手Image.sprite = チョキ画像;
                break;
            case 手.パー:
                NPCの手Image.sprite = パー画像;
                break;
        }
        string 勝者;
        じゃんけんルール.勝敗判定(プレイヤーの手, NPCの手, out 勝者); // 例としてプレイヤーがグー、コンピュータがチョキの場合
        結果テキスト.text = "勝者: " + 勝者;
        ゲーム層.alpha = 0f; // ゲーム用キャンバスを半透明にする
        オーディオマネージャー.結果用SE(勝者);
    }
    public void プレイヤーの手が選択された(手 プレイヤーの手)
    {
        //もし現在の状態がプレイヤー選択状態であれば
        if (現在の状態 == じゃんけん状態.プレイヤー選択)
        {
            this.プレイヤーの手 = プレイヤーの手;
            NPC選択状態();
        }
    }
    public void リトライ()
    {
        //シーンをリロードする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
public enum じゃんけん状態
{
    待機,
    プレイヤー選択,
    NPC選択,
    結果,
}
public enum 手
{
    グー,
    チョキ,
    パー
}