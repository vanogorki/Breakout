using UnityEngine;
using UnityEngine.UI;

public class IconHandler : MonoBehaviour
{
    [SerializeField] private Image[] _icons;
    
    public void UpdateIcons(int health)
    {
        for (int i = 0; i < _icons.Length; i++)
        {
            if (i < health)
                _icons[i].enabled = true;
            else
                _icons[i].enabled = false;
        }
    }
}
