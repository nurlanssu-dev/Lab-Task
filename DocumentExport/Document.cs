namespace DocumentExport;

public class Document
{
    public string Title
    {
        get; init
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Title = value;
            }
        }
    }

    public readonly string Author;
    public string RawContent { get; set; }
    public int PageCount { get; private set; }

    public Document(string title, string author, string rawContent)
    {
        Title = title;
        Author = author;
        RawContent = rawContent;
    }
}
