using System.Collections.Generic;

namespace Serialisation
{
    [System.Serializable]
    public class SaveData
    {
        public PlayerDTO PlayerDTO;
        public List<ChestDTO> ChestListDTO;
    }
}