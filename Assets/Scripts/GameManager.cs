using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public UnityEngine.UI.Text woodDisplay;
    public UnityEngine.UI.Text toolText;
    public UnityEngine.UI.Text upgradeText;
    public UnityEngine.UI.Image toolImage;
    public UnityEngine.UI.Image hackButtonImage;
    public UnityEngine.UI.Button upgradeButton;

    int wood = 0;
    int currentTool = 0;

    public Tool[] tools;
    public Sprite[] woodBlocks;

    void Update() {
        upgradeButton.interactable = (wood >= tools[currentTool + 1].cost);

        woodDisplay.text = "Wood: " + wood;
    }

    public void HandleClick() {
        wood += tools[currentTool].woodPerClick;
        hackButtonImage.sprite = woodBlocks[Random.Range(0, woodBlocks.Length)];
    }

    public void HandleUpgrade() {
        currentTool += 1;
        Tool tool = tools[currentTool];
        toolImage.sprite = tool.sprite;
        toolText.text = tool.name + " (+" + tool.woodPerClick + ")";
        upgradeText.text = "Upgrade (-" + tools[currentTool + 1].cost + ")";
        wood -= tools[currentTool].cost;
    }
}
