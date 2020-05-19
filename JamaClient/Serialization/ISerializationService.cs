namespace JamaClient.Serialization
{
    public interface ISerializationService
    {
        string Serialize<TValue>(TValue value);

        TValue Deserialize<TValue>(string json);
    }
}
