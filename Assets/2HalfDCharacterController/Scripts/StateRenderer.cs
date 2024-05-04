using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StateRenderer : MonoBehaviour
{
    // Start is called before the first frame update

    public StateController state;

    public TextMeshProUGUI idleUI;
    public TextMeshProUGUI moveUI;
    public TextMeshProUGUI runUI;
    public TextMeshProUGUI jumpUI;
    public TextMeshProUGUI fallUI;
    public TextMeshProUGUI dashUI;
    public TextMeshProUGUI rollUI;
    public TextMeshProUGUI groundUI;
    public TextMeshProUGUI horizontalUI;
    public TextMeshProUGUI verticalUI;

    private Dictionary<string, TextMeshProUGUI> stateTexts;

    // Define colors as static readonly fields
    private Color32 activeColor = new Color32(5, 255, 0, 255);
    private Color32 inactiveColor = new Color32(255, 0, 20, 255);

    void Start()
    {
        stateTexts = new Dictionary<string, TextMeshProUGUI>
        {
            {"idle", idleUI}, {"move", moveUI}, {"run", runUI}, {"jump", jumpUI},
            {"fall", fallUI}, {"dash", dashUI}, {"roll", rollUI},
            {"ground", groundUI}, {"horizontal", horizontalUI}, {"vertical", verticalUI}
        };
    }

    public void UpdateStateRenderer()
    {
        foreach (var entry in stateTexts)
        {
            bool isActive = state.GetMovementState(entry.Key);
            entry.Value.text = CreateUIText(entry.Key, isActive);
            entry.Value.color = isActive ? activeColor : inactiveColor;
        }
        if (state.GetIsGrounded())
        {
            groundUI.text = CreateUIText("ground", state.GetIsGrounded());
            groundUI.color = state.GetIsGrounded() ? activeColor : inactiveColor;
        }
    }

    private string CreateUIText(string name, bool state)
    {
        return $"{name}: {state}";
    }
}
