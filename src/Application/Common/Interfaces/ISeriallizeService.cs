namespace Application.Common.Interfaces;

public interface ISeriallizeService
{
    string Serialize<T>(T obj);
    string Serialize<T>(T obj, Type type);
    T Deserialize<T>(string text);
}
