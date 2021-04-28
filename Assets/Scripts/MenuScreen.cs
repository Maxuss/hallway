using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuScreen : MonoBehaviour
{
    #pragma warning disable CS0649
    [SerializeField]
    private Image fadeOut;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button controlsButton;
    [SerializeField]
    private Button infoButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Canvas mainCanvas;
    [SerializeField]
    private Button controlsBackButton;
    [SerializeField]
    private Button infoBackButton;
    [SerializeField]
    private Canvas controlsCanvas;
    [SerializeField]
    private Canvas infoCanvas;
    #pragma warning restore CS0649
    private void Start()
    {

        RemoveUnneccessary();

        startButton.onClick.AddListener(LoadGame);
        controlsButton.onClick.AddListener(ShowControls);
        infoButton.onClick.AddListener(ShowInfo);
        quitButton.onClick.AddListener(QuitGame);

        controlsBackButton.onClick.AddListener(BackToMain);
        infoBackButton.onClick.AddListener(BackToMain);
        StartCoroutine(Fade(FadeDirection.Out));
    }

    //

    private void RemoveUnneccessary()
    {
        controlsCanvas.enabled = false;
        infoCanvas.enabled = false;
        mainCanvas.enabled = true;
    }

    private void LoadGame()
    {
        SceneManager.LoadSceneAsync("Loading");
    }

    private void ShowControls()
    {
        FadeScreen(mainCanvas, controlsCanvas);
    }

    private void ShowInfo()
    {
        FadeScreen(mainCanvas, infoCanvas);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void BackToMain()
    {
        FadeScreen(new[]{ infoCanvas, controlsCanvas }, mainCanvas);
    }

    //
    private void FadeScreen(Canvas cur, Canvas newCanvas)
    {
        StartCoroutine(Fade(FadeDirection.Out));
        cur.enabled = false;
        newCanvas.enabled = true;
    }

    private void FadeScreen(Canvas[] all, Canvas main)
    {
        StartCoroutine(Fade(FadeDirection.Out));
        foreach(Canvas  cur in all)
        {
            cur.enabled = false;
        }
        main.enabled = true;
    }

    private enum FadeDirection
    {
        Out
    }

    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOut.enabled = false;
        }
        else
        {
            fadeOut.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }

    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOut.color = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / 0.8f) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }

}

