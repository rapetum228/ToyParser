using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Concurrent;
using System.Globalization;
using System.IO;
using System.Text;
using ToyParser.Core.Data;

namespace ToyParser.Core.Csv
{
    public class CustomCsvWriter
    {
        private string _path;
        private CsvConfiguration _csvConfiguration;
        private static Mutex _mutex = new Mutex();
        private static int _id;

        public CustomCsvWriter()
        {
            _path = "./data.csv";
            _csvConfiguration = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Delimiter = "|"
            };
        }

        public void WriteList(IEnumerable<ToyInformation> toys)
        {
            _mutex.WaitOne();
            using (StreamWriter streamWriter = new StreamWriter(_path, true, Encoding.BigEndianUnicode))
            {
                using (CsvWriter csvReader = new CsvWriter(streamWriter, _csvConfiguration))
                {
                    csvReader.WriteRecords(toys);
                    _id++;
                    Console.WriteLine(new StringBuilder("Запись произведена ").Append(_id).Append(" ").Append(DateTime.Now));
                }
            }
            _mutex.ReleaseMutex();
        }

        public void Write(ToyInformation toy)
        {
            _mutex.WaitOne();
            Encoding encoding = Encoding.BigEndianUnicode;
            if (!File.Exists(_path))
            {
                File.Create(_path);
            }

            using (StreamWriter streamWriter = new StreamWriter(_path, true, encoding))
            {
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, _csvConfiguration))
                {
                    csvWriter.NextRecord();
                    csvWriter.WriteRecord(toy);
                    _id++;
                }
            }
            _mutex.ReleaseMutex();

        }

        private static readonly ConcurrentDictionary<string, object> _locks = new ConcurrentDictionary<string, object>();

        public static void ConcurrentSave(string path, string text)
        {
            object obj;
            while (!_locks.TryGetValue(path, out obj))
            {
                obj = new object();
                if (_locks.TryAdd(path, obj))
                    break;
            }
            lock (obj)
            {
                File.AppendAllText(path, text + Environment.NewLine);
            }
        }
    }
}
