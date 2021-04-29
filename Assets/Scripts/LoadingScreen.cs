using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadingScreen : MonoBehaviour
{
    private int _curMask;
    [SerializeField]
    private Image[] masks;

    private readonly List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
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
    public IEnumerator GetSceneLoadProgress()
    {
        while (!_scenesLoading[0].isDone)
        {
            Image current = masks[_curMask];
            if (current.fillAmount.Equals(0))
            {
                while (!current.fillAmount.Equals(1f))
                {
                    current.fillAmount += 0.1f;
                    yield return new WaitForSeconds(1);
                }
            }
            else if(current.fillAmount.Equals(1))
            {
                while (current.fillAmount != 0)
                    
                {
                    current.fillAmount -= 0.1f;
                    yield return new WaitForSeconds(1);
                }
            }
            switch(_curMask)
            {
                case 0:
                    _curMask = 1;
                    break;
                case 1:
                    _curMask = 0;
                    break;
                default:
                    _curMask = 0;
                    break;
            }
            yield return null;
        }
    }
}
