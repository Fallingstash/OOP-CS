using System;
public class Document
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Keywords { get; set; }
    public string Theme { get; set; }
    public string FilePath { get; set; }

    public virtual string GetInfo()
    {
        return $"Name: {Name}, Author: {Author}, Keywords: {Keywords}, Theme: {Theme}, FilePath: {FilePath}";
    }
}
