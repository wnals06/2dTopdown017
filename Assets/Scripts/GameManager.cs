using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public TMP_InputField inputField;  // InputField ����
    public Button gameStartButton; // Button ����

    private void Start()
    {
        gameStartButton.onClick.AddListener(OngameStartButtonClicked);
    }

    private void OngameStartButtonClicked()
    {
        string playerName = inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("�÷��̾� �̸��� �Է��ϼ���.");
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        Debug.Log("�÷��̾� �̸� �����: " + playerName);

        SceneManager.LoadScene("Level_1");
    }
}
