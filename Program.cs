using System.Text;
using ToyParser.Core;

EncodingProvider ppp = CodePagesEncodingProvider.Instance;
Encoding.RegisterProvider(ppp);

if (File.Exists("./data.csv"))
{
    File.Delete("./data.csv");
}

ToyParserWorker worker = new ToyParserWorker();
Console.WriteLine(DateTime.Now);
await worker.Start();
Console.ReadLine();
