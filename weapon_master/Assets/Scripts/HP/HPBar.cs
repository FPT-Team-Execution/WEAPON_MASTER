
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private HP playerHP;
    //[SerializeField]private Image totalHP;
    [SerializeField] private Image currentHP;

    void Update()
    {
        currentHP.fillAmount = playerHP.currentHP / 10;
        //totalHP.fillAmount = playerHP.currentHP / 10;

        //print(currentHP.fillAmount);
    }
}
