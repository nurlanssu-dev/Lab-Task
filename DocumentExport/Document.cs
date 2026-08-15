namespace DocumentExport;

public class Document
{
    public string Title { get; init; }
    public readonly string Author;
    public string RawContent { get; set; }
    public int PageCount { get; private set; }

    public Document(string title, string author, string rawContent)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            Title = title;
        }

        if (!string.IsNullOrWhiteSpace(author))
        {
            Author = author;
        }

        if (!string.IsNullOrWhiteSpace(rawContent))
        {
            RawContent = rawContent;
        }
        PageCount = rawContent.Length / 500;
        if (rawContent.Length % 500 != 0)
        {
            PageCount++;
        }

        if (PageCount == 0)
        {
            PageCount = 1;
        }

    }
    public void UpdateContent(string newContent)
    {
        if (!string.IsNullOrWhiteSpace(newContent))
        {
            RawContent = newContent;
            PageCount = newContent.Length / 500;
            if (newContent.Length % 500 != 0)
            {
                PageCount++;
            }

            if (PageCount == 0)
            {
                PageCount = 1;
            }
        }
    }
    public void UpdateContent(string newContent, string appendNote)
    {
        if (!string.IsNullOrWhiteSpace(newContent))
        {
            RawContent = newContent;
            PageCount = newContent.Length / 500;
            if (newContent.Length % 500 != 0)
            {
                PageCount++;
            }
            if (PageCount == 0)
            {
                PageCount = 1;
            }
        }
        if (!string.IsNullOrWhiteSpace(appendNote))
        {
            RawContent += "\n\n" + appendNote;
            PageCount = RawContent.Length / 500;
            if (RawContent.Length % 500 != 0)
            {
                PageCount++;
            }
            if (PageCount == 0)
            {
                PageCount = 1;
            }
        }
    }
    public virtual double CalculateExportSizeKB() => RawContent.Length / 1024.0;
    public virtual string Export()=> $"Title: {Title}\nAuthor: {Author}\nPage Count: {PageCount}\nSize (KB): {CalculateExportSizeKB():F2}\nContent:\n{RawContent}";
    public virtual void Print()
    {
        Console.WriteLine(Export());
    }
}
