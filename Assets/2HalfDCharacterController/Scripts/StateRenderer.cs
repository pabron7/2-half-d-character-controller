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


    /// <summary>
    /// This function updates States Renderer UI. Simply implement it under state changers.
    /// </summary>
    public void UpdateStateRenderer()
    {
        idleUI.text = CreateUIText("idle", state.GetMovementState("idle"));
        moveUI.text = CreateUIText("move", state.GetMovementState("move"));
        runUI.text = CreateUIText("run", state.GetMovementState("run"));
        jumpUI.text = CreateUIText("jump", state.GetMovementState("jump"));
        fallUI.text = CreateUIText("fall", state.GetMovementState("fall"));
        rollUI.text = CreateUIText("roll", state.GetMovementState("roll"));
        dashUI.text = CreateUIText("dash", state.GetMovementState("dash"));
        groundUI.text = CreateUIText("ground", state.GetMovementState("ground"));
        horizontalUI.text = CreateUIText("horizontal", state.GetMovementState("horizontal"));
        verticalUI.text = CreateUIText("vertical", state.GetMovementState("vertical"));
    }

    private string CreateUIText(string name, bool state)
    {
        return name + ": " + state;
    }
}
