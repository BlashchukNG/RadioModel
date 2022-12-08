using UnityEngine;

namespace GIG.FPS
{
  public class FPSDisplay : MonoBehaviour
  {
    [SerializeField] private bool show;
    [SerializeField] private bool setTo60FPS;
    [SerializeField] private Color colorFPS = Color.gray;

    private float deltaTime;
    private string _ver;

    private void Start()
    {
      if (setTo60FPS)
        Application.targetFrameRate = 60;
      else
        Application.targetFrameRate = 120;

      _ver = Application.version;
    }

    private void Update()
    {
      deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
      if (!show)
        return;

      int w = Screen.width, h = Screen.height;

      GUIStyle style = new GUIStyle();

      Rect rect = new Rect(0, 0, w, h * 2 / 100);
      style.alignment = TextAnchor.UpperLeft;
      style.fontSize = h * 2 / 100;
      style.normal.textColor = colorFPS;
      float msec = deltaTime * 1000.0f;
      float fps = 1.0f / deltaTime;
      string text = string.Format(_ver + " ({1:0.} fps)", msec, fps);
      GUI.Label(rect, text, style);
    }
  }
}