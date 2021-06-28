using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneID;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Load);
    }

    private void Load()
    {
        SceneManager.LoadScene(sceneID);
    }
}
