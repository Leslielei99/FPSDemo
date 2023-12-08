public class UIType
{
    private string name;

    public string Name
    {
        get { return name; }
    }

    private string path;

    public string Path
    {
        get { return path; }
    }

    public UIType(string m_name, string m_path)
    {
        name = m_name;
        path = m_path;
    }
}