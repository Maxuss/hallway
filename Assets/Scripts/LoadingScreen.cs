using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadingScreen : MonoBehaviour
{
    private int curMask = 0;
    [SerializeField]
    private Image[] masks;

    List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
    private void Awake()
    {
        SceneManager.LoadSceneAsync("Hallway");
        LoadGame();
    }

    private void LoadGame()
    {
        _scenesLoading.Add(SceneManager.LoadSceneAsync("Hallway"));
        StartCoroutine(GetSceneLoadProgress());
    }

    float totalProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        while (!_scenesLoading[0].isDone)
        {
            Image current = masks[curMask];
            if (current.fillAmount == 0)
            {
                while (current.fillAmount != 1)
                {
                    current.fillAmount += 0.01f;
                }
            }
            else if(current.fillAmount == 1)
            {
                while (current.fillAmount != 0)
                {
                    current.fillAmount -= 0.01f;
                }
            }
            switch(curMask)
            {
                case 0:
                    curMask = 1;
                    break;
                case 1:
                    curMask = 0;
                    break;
                default:
                    curMask = 0;
                    break;
            }
            yield return null;
        }
    }
}
