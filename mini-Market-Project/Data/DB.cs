namespace mini_Market_Project;

public static class DB
{
    //public static void JsonWrite<T>(string path, T obj)
    //{
    //    if (File.Exists(path))
    //        Write<T>(path, obj);

    //    else { File.WriteAllText(path, JsonSerializer.Serialize(new List<T>(), new JsonSerializerOptions() { WriteIndented = true })); Write<T>(path, obj); }
    //}

    public static void JsonWrite<T>(string path, T obj)
    {
        var exitsObj = new List<T>();

        if (!File.Exists(path))
        {
            File.WriteAllText(path, JsonSerializer.Serialize(new List<T>(), new JsonSerializerOptions() { WriteIndented = true }));
            exitsObj = JsonRead<T>(path);
            exitsObj!.Add(obj);
            File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
        }

        else
        {
            exitsObj = JsonRead<T>(path);
            exitsObj!.Add(obj);
            File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }


    [Obsolete("This method is work cannot", true)]
    private static void Write<T>(in string path, T obj)
    {
        var exitsObj = new List<T>();

        exitsObj = JsonRead<T>(path);

        //var maxId = exitsObj!.Select(x => (int)x!.GetType().GetProperty("Id")!.GetValue(x)!).DefaultIfEmpty(0).Max();
        //obj!.GetType().GetProperty("Id")!.SetValue(obj, maxId + 1); exitsObj!.Add(obj);
        File.WriteAllText(path, JsonSerializer.Serialize(exitsObj, new JsonSerializerOptions() { WriteIndented = true }));
    }

    public static List<T>? JsonRead<T>(string path) => File.Exists(path) ? NetJSON.NetJSON.Deserialize<List<T>>(File.ReadAllText(path: path)) : throw new FileNotFoundException(nameof(path));

    public static void ProductWriteLog<T>(string log, T products) where T : Product
    {
        using (var write = new StreamWriter(log, true))
            write.WriteLine($"{products} Product add");
    }
}
