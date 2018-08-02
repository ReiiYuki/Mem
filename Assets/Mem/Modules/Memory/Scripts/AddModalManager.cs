
namespace INNOMA.Mem.modules.Memory
{
    using UnityEngine;
    using UnityEngine.UI;

    public class AddModalManager : MonoBehaviour
    {

        public GameObject TitleInputField, DetailInputField, SubDetailInputField;

        public void AddMemory()
        {
            string title = TitleInputField.GetComponent<InputField>().text;
            string detail = DetailInputField.GetComponent<InputField>().text;
            string subDetail = SubDetailInputField.GetComponent<InputField>().text;
            GameObject.FindObjectOfType<MemoryManager>().AddMemory(title, detail, subDetail);
            TitleInputField.GetComponent<InputField>().text = "";
            DetailInputField.GetComponent<InputField>().text = "";
            SubDetailInputField.GetComponent<InputField>().text = "";
        }
    }

}
