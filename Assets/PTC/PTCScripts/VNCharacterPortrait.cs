using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Yarn.Unity;
[Serializable]
public class Expressions 
{
    public string expressionName;
    public Sprite sprite;
}

public class VNCharacterPortrait : MonoBehaviour
{
    [Header("Character")] 
    public string characterName;
    
    [Header("Character Sprites")] 
    public List<Expressions> expressions = new List<Expressions>();
    public string startingExpression = "neutral";

    
    [Header("Animation")]
    public bool useAnimation = true; 
    // legit just for Erin bc of how MC corner sprite will work
    
    public float backDist = 60f;
    public float backScale = 0.9f;
    public float animationSpeed = 8f;
    
    private Image characterImage;
    private RectTransform characterRectTransform;
    
    private Vector2 ogPosition;
    private Vector3 ogSize;
    
    private bool isSpeaking = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        characterImage = GetComponent<Image>();
        characterRectTransform = GetComponent<RectTransform>();
        
        ogPosition = characterRectTransform.anchoredPosition;
        ogSize = characterRectTransform.localScale;

        SetExpression(startingExpression);

        if (!useAnimation)
        {
            characterImage.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!useAnimation)
        {
            return;
        }
        
        Vector2 targetPos;
        Vector3 targetSize;
        Color targetColor;

        if (isSpeaking)
        {
            targetPos = ogPosition; 
            targetSize = ogSize;
            targetColor = Color.white;
        }
        else
        {
            targetPos = ogPosition + Vector2.down * backDist;
            targetSize = ogSize * backScale;
            targetColor = Color.gray;
        }
        
        float t = 1f - Mathf.Exp(-animationSpeed * Time.deltaTime);
        
        characterRectTransform.anchoredPosition = Vector2.Lerp(characterRectTransform.anchoredPosition, targetPos, t);
        characterRectTransform.localScale = Vector3.Lerp(characterRectTransform.localScale, targetSize, t);
        characterImage.color = Color.Lerp(characterImage.color, targetColor, t);
    }

    public void SetSpeaking(bool speaking)
    {
        isSpeaking = speaking;
    }

    public void SetExpression(string expression)
    {
        foreach (Expressions Ename in expressions)
        {
            if (Ename.expressionName == expression)
            {
                if (Ename.sprite != null)
                {
                    characterImage.sprite = Ename.sprite;
                }
                else
                {
                    Debug.Log("No sprite on" + expression);
                }

                return;
            }
        }
    }
    
}