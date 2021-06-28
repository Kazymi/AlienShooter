using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void OnEnable()
    {
        restartButton.onClick.AddListener(() => { });
        mainMenuButton.onClick.AddListener(() => { });
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveAllListeners();
        mainMenuButton.onClick.RemoveAllListeners();
    }
}