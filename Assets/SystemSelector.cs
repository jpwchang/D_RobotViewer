using UnityEngine;
using System.Collections;

public class SystemSelector : MonoBehaviour {
    private RaycastHit hit;
    private Ray rcRay;
    private Touch touchPos;
    private string subsysName;

    void Start()
    {
        subsysName = "NONE";
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
                    case "intake":
                        break;
                    case "lift":
                        break;
                    case "drive":
                        Application.LoadLevel(1);
                        break;
                    default:
                        break;
                }
            }
            else
                subsysName = "NONE";
        }
    }
}
