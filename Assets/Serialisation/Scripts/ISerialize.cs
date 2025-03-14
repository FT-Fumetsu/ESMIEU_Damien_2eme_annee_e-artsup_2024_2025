using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerialize<T> where T : DataTransfetObject 
{
    T Serialized();
    void Deserialize(T dto);
}
