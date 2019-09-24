using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;
    private int _score=0;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondReavealed;

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh score;

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public bool canReveal
    {
        get { return _secondReavealed == null; }
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondReavealed = card;
            StartCoroutine(CheckMatch());
            //Debug.Log("Match?" + (_firstRevealed.id == _secondReavealed.id));
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondReavealed.id)
        {
            _score++;
            score.text = ("Score: " + _score);
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();
            _secondReavealed.Unreveal();
        }
        _firstRevealed = null;
        _secondReavealed = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if(i==0 && j==0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        //int[] newArray = numbers.Clone() as int[];
        for (int i=0; i<numbers.Length; i++)
        {
            int tmp = numbers[i];
            int r = Random.Range(i, numbers.Length);
            numbers[i] = numbers[r];
            numbers[r] = tmp;
        }
        return numbers; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
