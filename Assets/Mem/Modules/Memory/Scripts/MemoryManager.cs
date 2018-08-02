
namespace INNOMA.Mem.modules.Memory
{
    using UnityEngine;
    using INNOMA.Mem.modules.Card;

    public class MemoryManager : MonoBehaviour
    {
        class MemoryItem
        {
            public string title, detail, subDetail;
            
            public MemoryItem(string title, string detail, string subDetail)
            {
                this.title = title;
                this.detail = detail;
                this.subDetail = subDetail;
            }
            
            public static MemoryItem createFromString(string memoryString)
            {
                string[] extractedData = memoryString.Split(',');
                if (extractedData.Length < 3) return null;
                return new MemoryItem(extractedData[0], extractedData[1], extractedData[2]);
            }
        }

        public GameObject Card, CardList;

        // Use this for initialization
        void Start()
        {
            LoadMemoryFromPref();
        }

        void LoadMemoryFromPref()
        {
            if (!PlayerPrefs.HasKey("memories")) PlayerPrefs.SetString("memories", "");
            foreach (Transform child in CardList.transform)
            {
                Destroy(child.gameObject);
            }

            string memoriesString = PlayerPrefs.GetString("memories");
            string[] extractedData = Shuffle(memoriesString.Split('|'));
            foreach (string memoryString in extractedData)
            {
                MemoryItem memory = MemoryItem.createFromString(memoryString);
                if (memory != null)
                {
                    Instantiate(Card, CardList.transform).GetComponent<MemCard>().Initialize(memory.title, memory.detail, memory.subDetail);
                }
            }
        }

        string[] Shuffle(string[] list)
        {
            for (int i = 0; i < list.Length && list.Length > 1; i++)
            {
                string temp = list[i];
                int randomIndex = Random.Range(i, list.Length);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
            return list;
        }

        public void AddMemory(string title, string detail, string subDetail)
        {
            string memoryString = title + "," + detail + "," + subDetail;
            string memoriesString = PlayerPrefs.GetString("memories") + "|" + memoryString;
            PlayerPrefs.SetString("memories", memoriesString);
            LoadMemoryFromPref();
        }
    }

}
