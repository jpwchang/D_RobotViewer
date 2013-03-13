using UnityEngine;
using System.Collections;

namespace GUIExtensions
{
    public class XGUI : MonoBehaviour
    {
        public static void Header(float x, float y, float width, float height, string content)
        {
            GUI.Box(new Rect(x, y, width, height), content, "header");
        }
    }
}
