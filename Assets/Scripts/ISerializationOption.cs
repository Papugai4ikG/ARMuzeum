using System;

    public interface ISerializationOption
    {
        T Deserialize<T>(string text);
    }