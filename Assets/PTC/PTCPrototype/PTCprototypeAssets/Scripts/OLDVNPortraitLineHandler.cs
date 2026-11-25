using UnityEngine;
using Yarn.Unity;

public class OLDVNPortraitLineHandler : MonoBehaviour
{
    [Header("Character Portraits")] 
    public OLDVNCharacterPortrait ebenholz;
    public OLDVNCharacterPortrait kreide;

    /*
    [YarnCommand("portrait")]
    public void ChangePortrait(string speakerName, string expression)
    {
        if (speakerName == "Ebenholz")
        {
            ebenholz.SetSpeaking(true);
            kreide.SetSpeaking(false);
            
            ebenholz.SetExpression(expression);
        }
        else if (speakerName == "Kreide")
        {
            kreide.SetSpeaking(true);
            ebenholz.SetSpeaking(false);
            
            kreide.SetExpression(expression);
        }
        else
        {
            Debug.Log("Character name not found!");
        }
    }
    */
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
