public struct Mission
{
    private string _name;
    private int _id;
    private string _description;
    private float _duration;

    public Mission(string name, int id, string description, float duration)
    {
        _name = name;
        _id = id;
        _description = description;
        _duration = duration;
    }

    public string name { get => _name; set => _name = value; }
    public int id { get => _id; set => _id = value; }
    public string description { get => _description; set => _description = value; }
    public float duration { get => _duration; set => _duration = value; }
}