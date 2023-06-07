using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class AnimalData : MonoBehaviour
{
    public string animalName = "cow";

     public float _attention = 15f;
     public float _hunger = 15f;
    public float _energy = 15f;
     public float _hygiene = 15f;
     public float _health = 15f;

     public float attentionDecreaseRate = 2f;
    public float hungerDecreaseRate = 2f;
    public float energyDecreaseRate = 2f;
    public float hygieneDecreaseRate = 2f;
    public float healthDecreaseRate = 2f;

    public Slider hungerSlider;
    public Slider energySlider;
    public Slider hygieneSlider;
    public Slider attentionSlider;

    public Slider healthSlider;

    public Image hungerFillImage;
    public Image energyFillImage;
    public Image hygieneFillImage;
    public Image attentionFillImage;
    public Image healthFillImage;

    public SpriteRenderer cowSprite;
    public Sprite coffinSprite;


    private void Start()
    {
        hungerSlider.value = _hunger / 15f;
        energySlider.value = _energy / 15f;
        hygieneSlider.value = _hygiene / 15f;
        attentionSlider.value = _attention / 15f;

        healthSlider.value = _health / 15f;

        coffinSprite = Resources.Load<Sprite>("coffin");
    }
    private void Update()
    {
       
   

        float deltaTime = Time.deltaTime;

        _attention -= (attentionDecreaseRate * deltaTime);
        _hunger -= (hungerDecreaseRate * deltaTime);
        _energy -= (energyDecreaseRate * deltaTime);
        _hygiene -= (hygieneDecreaseRate * deltaTime);
        _health -= (healthDecreaseRate * deltaTime);

        
        _attention = Mathf.Clamp(_attention, 0, 15f);
        _hunger = Mathf.Clamp(_hunger, 0, 15f);
        _energy = Mathf.Clamp(_energy, 0, 15f);
        _hygiene = Mathf.Clamp(_hygiene, 0, 15f);
        _health = Mathf.Clamp(_health, 0, 15f);

        hungerSlider.value = _hunger / 15f;
        energySlider.value = _energy / 15f;
        hygieneSlider.value = _hygiene / 15f;
        attentionSlider.value = _attention / 15f;

        float averageStatValue = (_attention + _hunger + _energy + _hygiene) / 4f;
        _health = averageStatValue;

        healthSlider.value = _health / 15f;
        _health = Mathf.Clamp(_health, 0f, 15f);


        if (_attention <= 0 || _hunger <= 0 || _energy <= 0 || _hygiene <= 0 || _health <= 0)
        {

            Debug.Log("dying");
        }

        if (_hunger <= 0)
        {
            hungerFillImage.color = Color.grey;
        }
      

        if (_energy <= 0)
        {
            energyFillImage.color = Color.grey;
        }
      

        if (_hygiene <= 0)
        {
            hygieneFillImage.color = Color.grey;
        }
        

        if (_attention <= 0)
        {
            attentionFillImage.color = Color.grey;
        }
       

        if (_health <= 0)
        {
            healthFillImage.color = Color.grey;
            cowSprite.sprite = coffinSprite;
        }
      

     
    




}

    private void ZeroValue()
    {

        Debug.Log("dead");
     
    }

    public void Feed(float amount)
    {
        if (_hunger > 0)
        {
            _hunger += amount;
            _hunger = Mathf.Clamp(_hunger, 0f, 15f);

            _health += amount / 4f;
            //_health = Mathf.Clamp(_health, 0f, 15f);
        }
    }

    public void Clean(float amount)
    {
        if (_hygiene > 0)
        {
            _hygiene += amount;
            _hygiene = Mathf.Clamp(_hygiene, 0f, 15f);

            _health += amount / 4f;
            // _health = Mathf.Clamp(_health, 0f, 15f);
        }
    }

    public void Pet(float amount)
    {
        if (_attention > 0)
        {
            _attention += amount;
            _attention = Mathf.Clamp(_attention, 0f, 15f);

            _health += amount / 4f;
            // _health = Mathf.Clamp(_health, 0f, 15f);
        }
    }

    public void RedBull(float amount)
    {
        if (_energy > 0)
        {


            _energy += amount;
            _energy = Mathf.Clamp(_energy, 0f, 15f);

            _health += amount / 4f;
            // _health = Mathf.Clamp(_health, 0f, 15f);
        }
    }
}

   

    

    




