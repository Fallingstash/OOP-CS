using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

public class Document {
  public string Name { get; set; }
  public string Author { get; set; }
  public string Keywords { get; set; }
  public string Theme { get; set; }
  public string FilePath { get; set; }

  public Document(string name, string author, string keywords, string theme, string filePath) {
    Name = name;
    Author = author;
    Keywords = keywords;
    Theme = theme;
    FilePath = filePath;
  }

  public virtual string GetInfo() {
    return $"Name: {Name}, Author: {Author}, Keywords: {Keywords}, Theme: {Theme}, FilePath: {FilePath}";
  }
}

public class WordDocument : Document {
  public int WordCount { get; set; }
  public WordDocument(string name, string author, string keywords, string theme, string filePath, int wordCount)
    : base(name, author, keywords, theme, filePath) {
    WordCount = wordCount;
  }

  public override string GetInfo() {
    return base.GetInfo() + $", Word Count: {WordCount}";
  }
}

public class PdfDocument : Document {
  public bool IsEncrypted { get; set; }

  public PdfDocument(string name, string author, string keywords, string theme, string filePath, bool isEncrypted)
  : base(name, author, keywords, theme, filePath) {
    IsEncrypted = isEncrypted;
  }

  public override string GetInfo() {
    return base.GetInfo() + $", is Encrypted: {IsEncrypted}";
  }
}

public class ExcelDocument : Document {
  public int SheetCount { get; set; }

  public ExcelDocument(string name, string author, string keywords, string theme, string filePath, int sheetCount)
      : base(name, author, keywords, theme, filePath) {
    SheetCount = sheetCount;
  }

  public override string GetInfo() {
    return base.GetInfo() + $", SheetCount: {SheetCount}";
  }
}

public class TxtDocument : Document {
  public bool IsPlainText { get; set; }

  public TxtDocument(string name, string author, string keywords, string theme, string filePath, bool isPlainText)
  : base(name, author, keywords, theme, filePath) {
    IsPlainText = isPlainText;
  }

  public override string GetInfo() {
    return base.GetInfo() + $", Is Plain Text: {IsPlainText}";
  }
}

public class HtmlDocument : Document {
  public string DocType { get; set; }

  public HtmlDocument(string name, string author, string keywords, string theme, string filePath, string docType)
   : base(name, author, keywords, theme, filePath) {
    DocType = docType;
  }

  public override string GetInfo() {
    return base.GetInfo() + $", Doctype: {DocType}";
  }
}

public class DocumentManager {
  private static DocumentManager _instance;
  public List<Document> documents = new List<Document>();

  private DocumentManager() { }

  public static DocumentManager Instance {
    get {
      if (_instance == null)
      {
        _instance = new DocumentManager();
      }
      return _instance;
    }
  }
  public void AddDoc(Document document) {
    documents.Add(document);
  }

  public void OutputMenu() {
    Console.WriteLine("Выберите тип документа:");
    Console.WriteLine("1. Word Document");
    Console.WriteLine("2. PDF Document");
    Console.WriteLine("3. Excel Document");
    Console.WriteLine("4. TXT Document");
    Console.WriteLine("5. HTML Document");
    Console.WriteLine("0. Выход");  
  }

  public void ShowDocumentInfo(int number) {
    Console.WriteLine(documents[number].GetInfo());
  }
}

class Program {
  static void Main(string[] args) {
    DocumentManager documentManager = DocumentManager.Instance;

    documentManager.AddDoc(new WordDocument("Document Word", "Author 1", "Keyword 1", "Theme 1", "C:\\forLaba\\word.docx", 1200));
    documentManager.AddDoc(new PdfDocument("PDF Document", "Author 2", "Keyword 2", "Theme 2", "C:\\forLaba\\PDF.pdf", true));
    documentManager.AddDoc(new ExcelDocument("Excel Document", "Author 3", "Keyword 3", "Theme 3", "C:\\forLaba\\Excel.xlsx", 5));
    documentManager.AddDoc(new TxtDocument("TXT Document", "Author 4", "Keyword 4", "Theme 4", "C:\\forLaba\\Text.txt", true));
    documentManager.AddDoc(new HtmlDocument("Document HTML", "Author 5", "Keyword 5", "Theme 5", "C:\\forLaba\\HTML.html", "<!DOCTYPE html>"));
    documentManager.OutputMenu();

    string choice = Console.ReadLine();
    switch (choice)
    {
      case "0":
        return;
      case "1":
        documentManager.ShowDocumentInfo(1);
        break;
      case "2":
        documentManager.ShowDocumentInfo(2);
        break;
      case "3":
        documentManager.ShowDocumentInfo(3);
        break;
      case "4":
        documentManager.ShowDocumentInfo(4);
        break;
      case "5":
        documentManager.ShowDocumentInfo(5);
        break;
      default:
        Console.WriteLine("Неверный выбор, попробуйте снова.");
        break;
    }
  }
}
