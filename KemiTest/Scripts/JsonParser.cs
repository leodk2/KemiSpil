using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Godot;
using CFile = System.IO.File;

public class JsonParser {
    public static MemoryStream Stream { get; set; }
    public static DataContractJsonSerializer Serializer { get; set; }
    public static string Path { get; } = @"Score.score";

    public static async void SerializeJson (List<Score> scores, DataContractJsonSerializer serializer, MemoryStream stream) {
       
        serializer.WriteObject (stream, scores);
        stream.Position = 0;
        StreamReader streamReader = new StreamReader(stream);
        string readToEnd = await streamReader.ReadToEndAsync();

        CFile.WriteAllText (Path, readToEnd);
        //return (stream, serializer);
    }

    public static T DeSerializeJsonFromStream<T, Y> (MemoryStream stream, DataContractJsonSerializer jsonSerializer) where T : List<Y> {
        stream.Position = 0;
        T genericObject = (T) jsonSerializer.ReadObject (stream);

        return genericObject;
    }

    public static List<Score> DeserializeJsonFile (string path) {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof (List<Score>));
        try{
            using (StreamReader reader = new StreamReader (path)) {
                string read = reader.ReadToEnd ();

                var objects = (List<Score>) serializer.ReadObject (new MemoryStream (Encoding.UTF8.GetBytes (read)));
                return objects;
                }   
            }
        catch(Exception e){
            GD.Print(e.ToString());
            return null;
            }
    }

    public static bool CreateFile () {

        if (CFile.Exists ("Score.score")) {
            return true;
        } 
        else {
            var file = CFile.Create ("Score.score");
            file.Dispose ();
            CreateFile ();
            return false;
        }
    }

}