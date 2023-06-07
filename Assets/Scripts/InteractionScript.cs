using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionScript : MonoBehaviour
{

    private WorkerScript workerScript;
    private AnimalData animalData;
    

    public Button _feedCow;
    public Button  _cleanCow;
    public Button _petCow;
    public Button redBullCow;



    public Button _feedDuck;
    public Button _cleanDuck;
    public Button _petDuck;
    public Button redBullDuck;

    public Button _feedHorse;
    public Button _cleanHorse;
    public Button _petHorse;
    public Button redBullHorse;

    private void Start()
    {
        _feedCow.gameObject.SetActive(false);
        _cleanCow.gameObject.SetActive(false);
        _petCow.gameObject.SetActive(false) ;
        redBullCow.gameObject.SetActive(false);

        _feedDuck.gameObject.SetActive(false);
        _cleanDuck.gameObject.SetActive(false) ;
        _petDuck.gameObject.SetActive(false) ;
        redBullDuck.gameObject.SetActive(false) ;

        _feedHorse.gameObject.SetActive(false);
        _cleanHorse.gameObject.SetActive(false);
        _petHorse.gameObject.SetActive(false) ;
        redBullHorse.gameObject.SetActive(false) ;

       
    }

    public void ShowInteractionButtons(AnimalData animalData, WorkerScript workerScript)
    {
        this.animalData = animalData;
        this.workerScript = workerScript;

        switch (animalData.animalName)
        {
            case "cow":





                _feedCow.gameObject.SetActive(true);
                _cleanCow.gameObject.SetActive(true);
                _petCow.gameObject.SetActive(true);
                redBullCow.gameObject.SetActive(true);

                _feedCow.onClick.AddListener(FeedAnimal);
                _cleanCow.onClick.AddListener(CleanAnimal);
                _petCow.onClick.AddListener(PetAnimal);
                redBullCow.onClick.AddListener(GiveRedBull);
                break;
            case "duck":

                _feedDuck.gameObject.SetActive(true);
                _cleanDuck.gameObject.SetActive(true);
                _petDuck.gameObject.SetActive(true);
                redBullDuck.gameObject.SetActive(true);

                _cleanDuck.onClick.AddListener(CleanAnimal);
                _feedDuck.onClick.AddListener(FeedAnimal);
                _petDuck.onClick.AddListener(PetAnimal);
                redBullDuck.onClick.AddListener(GiveRedBull);
                break;
            case "horse":

                _feedHorse.gameObject.SetActive(true);
                _cleanHorse.gameObject.SetActive(true);
                _petHorse.gameObject.SetActive(true);
                redBullHorse.gameObject.SetActive(true);
                _feedHorse.onClick.AddListener(FeedAnimal);
                _cleanHorse.onClick.AddListener(CleanAnimal);
                _petHorse.onClick.AddListener(PetAnimal);
                redBullHorse.onClick.AddListener(GiveRedBull);
                break;
            default:
                break;
        }
        
    }

    public void HideInteractionButtons()
    {
        _feedDuck.gameObject.SetActive(false);
        _cleanDuck.gameObject.SetActive(false);
        _petDuck.gameObject.SetActive(false);
        redBullDuck.gameObject.SetActive(false);
        _feedDuck.onClick.RemoveAllListeners();
      //  _cleanDuck.onCLick.RemoveAllListeners();
      _petDuck.onClick.RemoveAllListeners();
        redBullDuck.onClick.RemoveAllListeners();

        workerScript = null;
        animalData= null;


        _feedHorse.gameObject.SetActive(false);
        _cleanHorse.gameObject.SetActive(false);
        _petHorse.gameObject.SetActive(false);
        redBullHorse.gameObject.SetActive(false);
        _feedHorse.onClick.RemoveAllListeners();
        _cleanHorse.onClick.RemoveAllListeners();
        _petHorse.onClick.RemoveAllListeners();
        redBullHorse.onClick.RemoveAllListeners();

        workerScript= null;
        animalData= null;

            _feedCow.gameObject.SetActive(false);
            _cleanCow.gameObject.SetActive(false);
        _petCow.gameObject.SetActive(false);
        redBullCow.gameObject.SetActive(false) ;
            _feedCow.onClick.RemoveAllListeners();
            _cleanCow.onClick.RemoveAllListeners();
        _petCow.onClick.RemoveAllListeners();
        redBullCow.onClick.RemoveAllListeners();

            workerScript = null;
            animalData= null;

           
        
    }

    public void FeedAnimal()
    {
        if (workerScript != null && animalData != null)
        {
            animalData.Feed(15f);
        }
    }

    public void CleanAnimal()
    {
        if(workerScript != null && animalData != null)
        {
            animalData.Clean(15f);
        }
    }

    public void PetAnimal()
    {
        if(workerScript != null && animalData != null )
        {
            animalData.Pet(15f);
        }
    }

    public void GiveRedBull()
    {
        if(workerScript != null && animalData !=null )
        {
            animalData.RedBull(15f);
        }
    }
}
