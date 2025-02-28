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

public class WordDocument : Document
{
    public int WordCount { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Word Count: {WordCount}";
    }
}

public class PdfDocument : Document
{
    public bool IsEncrypted { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", is Encrypted: {IsEncrypted}";
    }
}

public class ExcelDocument : Document
{
    public int SheetCount { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", SheetCount: {SheetCount}";
    }
}

public class TxtDocument : Document
{
    public bool IsPlainText { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Is Plain Text: {IsPlainText}";
    }
}

public class HtmlDocument : Document
{
    public string DocType { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Doctype: {DocType}";
    }
}

public class DocumentManager
{
    private static DocumentManager _instance;

    private DocumentManager() { }

    public static DocumentManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DocumentManager();
            }
            return _instance;
        }
    }

    public void ShowDocumentInfo(Document document)
    {
        Console.WriteLine(document.GetInfo());
    }
}

class Program
{
    static void Main(string[] args)
    {
        WordDocument wordDoc = new WordDocument
        {
            Name = "Document Word",
            Author = "Author 1",
            Keywords = "Keyword 1",
            Theme = "Theme 1",
            FilePath = "C:\\forLaba\\word.docx",
            WordCount = 100,
        };

        PdfDocument pdfDoc = new PdfDocument
        {
            Name = "PDF Document",
            Author = "Author 2",
            Keywords = "Keyword 2",
            Theme = "Theme 2",
            FilePath = "C:\\forLaba\\PDF.pdf",
            IsEncrypted = true,
        };

        ExcelDocument excelDoc = new ExcelDocument
        {
            Name = "Excel Document",
            Author = "Author 3",
            Keywords = "Keyword 3",
            Theme = "Theme 3",
            FilePath = "C:\\forLaba\\Excel.xlsx",
            SheetCount = 5,
        };

        TxtDocument txtDoc = new TxtDocument
        {
            Name = "TXT Document",
            Author = "Author 4",
            Keywords = "Keyword 4",
            Theme = "Theme 4",
            FilePath = "C:\\forLaba\\Text.txt",
            IsPlainText = true,
        };

        HtmlDocument htmlDoc = new HtmlDocument
        {
            Name = "Document HTML",
            Author = "Author 5",
            Keywords = "Keyword 5",
            Theme = "Theme 5",
            FilePath = "C:\\forLaba\\HTML.html",
            DocType = "<!DOCTYPE html>",
        };

        while (true)
        {
            Console.WriteLine("Выберите тип документа:");
            Console.WriteLine("1. Word Document");
            Console.WriteLine("2. PDF Document");
            Console.WriteLine("3. Excel Document");
            Console.WriteLine("4. TXT Document");
            Console.WriteLine("5. HTML Document");
            Console.WriteLine("0. Выход");
            Document document = null ;
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    return;
                case "1":
                    document = wordDoc;
                    break;
                case "2":
                    document = pdfDoc;
                    break;
                case "3":
                    document = excelDoc;
                    break;
                case "4":
                    document = txtDoc;
                    break;
                case "5":
                    document = htmlDoc;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
            if (document != null)
            {
                DocumentManager.Instance.ShowDocumentInfo(document);
                break;
            }
        }
    }
}