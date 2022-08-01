using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class candyText : MonoBehaviour
{
    [SerializeField]
    public Text uiText;


    // Start is called before the first frame update
    void Start()
    {
        uiText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        uiText.gameObject.SetActive(true);


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        uiText.gameObject.SetActive(false);

    }



}
