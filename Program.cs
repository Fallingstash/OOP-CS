using System;
public class Document
{
  public string Name { get; set; }
  public string Author { get; set; 
  public string Keywords { get; set; }
  public string Theme { get; set; } 
  public string FilePath { get; set; }

  public virtual string GetInfo()
  {
      return $"Name: {Name}, Author: {Author}, Keywords: {Keywords}, Theme: {Theme}, FilePath: {FilePath}";
  }
}

public class WordDocument : Document {
  public int WordCount { get; set; }

  public override string GetInfo()
    {
        return base.GetInfo() + $", Word Count: {WordCount}";
    }
}

public class PdfDocument : Document { 
  public bool IsEncrypted { get; set;}

  public override string GetInfo() { 
    return base.GetInfo() + $", is Encrypted: {IsEncrypted}";
  }
}

public class ExcelDocument : Document { 
  public int SheetCount { get; set; }

    public override string GetInfo() { 
      return base.GetInfo() + $", SheetCount: {SheetCount}";
    }
}

public class TxtDocument : Document { 
  public bool IsPlainText { get; set; }
  
  public override string GetInfo() {
    return base.GetInfo() + $", Is Plain Text: {IsPlainText}";
  }
}

public class HtmlDocument : Document { 
  public string DocType { get; set; }
  
  public override string GetInfo() {
        return base.GetInfo() + $", Doctype: {DocType}";
  }
}