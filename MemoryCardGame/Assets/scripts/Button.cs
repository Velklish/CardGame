using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highlightColor = Color.cyan;

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite!= null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void OnMouseUp()
    {
        transform.localScale = Vector3.one;
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
