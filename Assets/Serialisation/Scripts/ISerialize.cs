namespace Serialisation
{
    public interface ISerialize<T> where T : DataTransfetObject 
    {
        T Serialized();
        void Deserialize(T dto);
    }
}