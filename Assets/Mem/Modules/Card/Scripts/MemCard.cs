
namespace INNOMA.Mem.modules.Card
{
    using UnityEngine;
    using UnityEngine.UI;

    public class MemCard : MonoBehaviour
    {
        public enum CardState
        {
            FRONT,
            BACK,
            DELETE
        }

        CardState state = CardState.FRONT;
        
        public GameObject Front, Back, Delete;

        public void Initialize(string title, string detail, string subDetail)
        {
            Front.GetComponentInChildren<Text>().text = title;
            Back.GetComponentsInChildren<Text>()[0].text = subDetail;
            Back.GetComponentsInChildren<Text>()[1].text = detail;
        }

        public void OnEnter()
        {
            switch (state)
            {
                case CardState.FRONT:
                    ChangeState(CardState.BACK);
                    break;
                case CardState.BACK:
                    ChangeState(CardState.FRONT);
                    break;
            }
        }

        void ChangeState(CardState nextState)
        {
            Front.SetActive(false);
            Back.SetActive(false);
            Delete.SetActive(false);
            switch (nextState)
            {
                case CardState.FRONT:
                    Front.SetActive(true);
                    break;
                case CardState.BACK:
                    Back.SetActive(true);
                    break;
                case CardState.DELETE:
                    Delete.SetActive(true);
                    break;
            }
            state = nextState;
        }
    }

}
