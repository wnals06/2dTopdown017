using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public TMP_InputField inputField;  // InputField 연결
    public Button gameStartButton; // Button 연결

    private void Start()
    {
        gameStartButton.onClick.AddListener(OngameStartButtonClicked);
    }

    private void OngameStartButtonClicked()
    {
        string playerName = inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("플레이어 이름을 입력하세요.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("플레이어 이름 저장됨: " + playerName);

        SceneManager.LoadScene("Level_1");
    }
}
