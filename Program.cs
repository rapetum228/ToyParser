using AngleSharp.Html.Dom;
using AngleSharp.Io;
using AngleSharp;
using System.Text;
using ToyParser.Core;
using AngleSharp.Js;

EncodingProvider ppp = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(ppp);

//if (!File.Exists("./data.csv"))
//{
//    File.Create("./data.csv");
//    Console.WriteLine("FIle created");
//}

//ToyParserWorker worker = new ToyParserWorker();
//Console.WriteLine(DateTime.Now);
//await worker.Start();
//Console.ReadLine();
