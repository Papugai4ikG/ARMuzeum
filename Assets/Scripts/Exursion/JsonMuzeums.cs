[System.Serializable]
public class JsonMuzeums
{
    public string name;
    public string url_zip_exc;
    public string url_zip_quest;
    public string header;
    public string desp;
    public string url_image;
    public string adress;
    public string site;
    public string city;

}

[System.Serializable]
public class JsonMuzeumsList
{
    public JsonMuzeums[] muzeums;
}
