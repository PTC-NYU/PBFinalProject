using UnityEngine;
using Yarn.Unity;

public class VNPortraitLineHandler : MonoBehaviour
{
    VNCharacterPortrait[] characters;
    void Awake()
    {
        characters = GetComponentsInChildren<VNCharacterPortrait>();
    }    

    [YarnCommand("portrait")]
    public void ChangePortrait(string speakerName, string expression)
    {
        VNCharacterPortrait currentSpeaker = null;
        
        foreach (VNCharacterPortrait character in characters)
        {
            if (character.characterName == speakerName)
            {
                currentSpeaker = character;
                break;
            }
        }

        if (currentSpeaker == null)
        {
            Debug.Log("i cant find "  + speakerName);
            return;
        }

        foreach (VNCharacterPortrait character in characters)
        {
            if (character == currentSpeaker)
            {
                character.SetSpeaking(true);
            }
            else
            {
                character.SetSpeaking(false);
            }
        }

        if (!string.IsNullOrEmpty(expression))
        {
            currentSpeaker.SetExpression(expression);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }
}
