using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject backside;
    [SerializeField] private SceneController controller;

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
        if (backside.activeSelf && controller.canReveal)
        {
            backside.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        backside.SetActive(true);
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
