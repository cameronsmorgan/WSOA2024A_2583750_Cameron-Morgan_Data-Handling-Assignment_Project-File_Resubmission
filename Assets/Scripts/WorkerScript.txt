using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorkerScript : MonoBehaviour
{

    public float _speed = 5f;
    private Vector3 _target;
    private Vector3 initialPosition;

    private bool selected;
    private bool disabled;
    public  List<WorkerScript> moveableObjects = new List<WorkerScript>();

    public InteractionScript animalInteractionUI;
  

    private void Start()
    {
        initialPosition = transform.position;
        _target = transform.position;
        moveableObjects.Add(this);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);  //the _target variable here is probably the destination
    }

    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        foreach (WorkerScript obj in moveableObjects)
        {
      
            if (obj != this)
            {
                
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AnimalData animalData = collision.gameObject.GetComponent<AnimalData>();
        if (animalData != null)
        {

            Debug.Log("collision");
            animalInteractionUI.ShowInteractionButtons(animalData, this);
                
        }
       
    }

    public bool Selected
    {
        get { return selected; }
        set { selected = value; }
    }
    


    private void OnCollisionExit2D(Collision2D collision)
    {
        AnimalData animalData = collision.gameObject.GetComponent<AnimalData>();
        if (animalData != null)
        {
            animalInteractionUI.HideInteractionButtons();
        }
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    public void Disable()
    {
        disabled = true;
        gameObject.SetActive(false);

    }

    public void Enable()
    {
        
        disabled= false;
        gameObject.SetActive(true);

        
    }


}


