
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarButtonAction : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(0);
    }

}