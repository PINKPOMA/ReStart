using UnityEngine;

public class InputKey : MonoBehaviour
{
    Judgement judgement;
    GameObject[] notes;

    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject Key4;
    
    Transform s;
    Transform d;
    Transform num4;
    Transform num5;

    Touch touch;
    Vector3 touchPos;


    void Start()
    {
        judgement = GameObject.Find("Judgement").GetComponent<Judgement>();

        s = Key1.GetComponent<Transform>();
        d = Key2.GetComponent<Transform>();
        num4 = Key3.GetComponent<Transform>();
        num5 = Key4.GetComponent<Transform>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            s.gameObject.SetActive(true);
            judgement.JudgeNote(1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            s.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            d.gameObject.SetActive(true);
            judgement.JudgeNote(2);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            d.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            num4.gameObject.SetActive(true);
            judgement.JudgeNote(3);
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            num4.gameObject.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            num5.gameObject.SetActive(true);
            judgement.JudgeNote(4);
        }
        if (Input.GetKeyUp(KeyCode.Keypad5))
        {
            num5.gameObject.SetActive(false);
        }

    }

}
