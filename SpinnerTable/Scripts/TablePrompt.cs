using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TablePrompt : UdonSharpBehaviour {
  public TMPro.TextMeshProUGUI text;
  public void SetPrompt(string new_prompt) {
    text.text = new_prompt;
  }
}
