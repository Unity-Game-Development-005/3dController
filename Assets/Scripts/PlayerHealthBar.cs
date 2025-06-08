
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healtySlider;



    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealthBar(float currentHeath, float maximumHeath)
    {
        healtySlider.value = currentHeath / maximumHeath;
    }


} // end of class
