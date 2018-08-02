
namespace INNOMA.Mem.modules.Modal
{
    using UnityEngine;

    public class ModalManager : MonoBehaviour
    {
        public GameObject Modal;

        public void OpenModal()
        {
            Modal.SetActive(true);
        }

        public void CloseModal()
        {
            Modal.SetActive(false);
        }
    }

}
