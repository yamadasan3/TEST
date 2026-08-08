using UnityEngine;

public class オーディオマネージャー : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // AudioSourceコンポーネントをアタッチするための変数


    [SerializeField] private AudioClip プレイヤー勝ち;
    [SerializeField] private AudioClip プレイヤー負け;
    [SerializeField] private AudioClip 引き分け;
    public void 結果用SE(string 勝者)
    {
        // ここで手の種類に応じて音声を再生する処理を実装します
        switch (勝者)
        {
            case "プレイヤー":
                audioSource.PlayOneShot(プレイヤー勝ち);
                break;
            case "コンピュータ":

                audioSource.PlayOneShot(プレイヤー負け);
                break;
            case "引き分け":

                audioSource.PlayOneShot(引き分け);
                break;
            default:
                Debug.LogWarning("不明な手の種類です");
                break;
        }
    }
}
