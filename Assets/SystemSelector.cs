using UnityEngine;
using System.Collections;
using GUIExtensions;

public enum displayMode
{
    NORMAL,
    STRUCTURE,
    POWER,
    CODE
}

public class SystemSelector : MonoBehaviour {
    public GUISkin skin;
    private RaycastHit hit;
    private Ray rcRay;
    private Touch touchPos;
    private string subsysName;
    private displayMode mode;
    private const string structText = "- 85% Aluminum Build\n"
        + "- 4 Omni Wheels + 2 Omni coaster drives\n"
        + "- Radical 8-bar: Reaches ~36 inches\n"
        + "- Pneumatic Flip Hopper\n"
        + "- Capable of descoring high goal from ally side\n"
        + "- Anti-tippers on back\n"
        + "- Pre-match selectable intake speed (Scoring / Descoring)\n"
        + "- Completely CAD-modeled beforehand\n"
        + "- ~18 lbs\n"
        + "- Max. Dimensions for Sack Attack";
    private const string powerText = "- 10 393 motors\n"
        + "- 4 speed motor drive\n"
        + "- 4 torque motor lift geared 7:1 - Max capacity 18 sacks\n"
        + "- 2 speed motor intake\n"
        + "- 2 Batteries: 3000 mAh with power expander\n"
        + "- 2 pneumatic tanks @100 PSI, capable of 20 dumps";
    private const string codeText = "- 1 VEX LCD Display showing battery information\n"
        + "- ~40 point complete autonomous\n"
        + "- PID controlled lift at all points\n"
        + "- PID controlled distance drive using ultrasonic sensors\n"
        + "- 2 solenoids for additional air flow\n"
        + "- Extensive use of ROBOTC Tasks framework";

    void Start()
    {
        subsysName = "NONE";
        mode = displayMode.NORMAL;
    }

    void Update()
    {
        rcRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(rcRay, out hit, 1000))
            {
                subsysName = hit.collider.gameObject.tag;
                print(subsysName);
                switch (subsysName)
                {
                    case "structure":
                        mode = displayMode.STRUCTURE;
                        break;
                    case "power":
                        mode = displayMode.POWER;
                        break;
                    case "code":
                        mode = displayMode.CODE;
                        break;
                    default:
                        mode = displayMode.NORMAL;
                        break;
                }
            }
            else
                subsysName = "NONE";
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Box(new Rect(5, 5, 300, 80), "", "robo");
        GUI.BeginGroup(new Rect(2 * Screen.width / 3, 0, Screen.width / 3, Screen.height));
        switch (mode)
        {
            case displayMode.STRUCTURE:
            {
                XGUI.Header(0.0f, 0.0f, Screen.width / 3, 40.0f, "Structural Data");
                GUI.Box(new Rect(0, 40, Screen.width / 3, Screen.height - 40), structText);
                if (GUI.Button(new Rect(Screen.width/6-40, Screen.height - 100, 80, 40), "Close"))
                    mode = displayMode.NORMAL;
                break;
            }
            case displayMode.POWER:
            {
                XGUI.Header(0.0f, 0.0f, Screen.width / 3, 40.0f, "Power Data");
                GUI.Box(new Rect(0, 40, Screen.width / 3, Screen.height - 40), powerText);
                if (GUI.Button(new Rect(Screen.width / 6 - 40, Screen.height - 100, 80, 40), "Close"))
                    mode = displayMode.NORMAL;
                break;
            }
            case displayMode.CODE:
            {
                XGUI.Header(0.0f, 0.0f, Screen.width / 3, 40.0f, "Code Data");
                GUI.Box(new Rect(0, 40, Screen.width / 3, Screen.height - 40), codeText);
                if (GUI.Button(new Rect(Screen.width / 6 - 40, Screen.height - 100, 80, 40), "Close"))
                    mode = displayMode.NORMAL;
                break;
            }
            case displayMode.NORMAL:
                break;
        }
        GUI.EndGroup();
    }
}
