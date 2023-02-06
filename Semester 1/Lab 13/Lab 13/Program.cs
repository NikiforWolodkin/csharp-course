using Lab_13;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml;
using Newtonsoft.Json.Linq;
using static Lab_13.Examination;

Exam exam = new Exam(5, 3, "Joe");

Serializer<Exam> binaryserializer = new Serializer<Exam>(@"../../../files/exam.bin");
ISerialize<Exam> binaryser = binaryserializer as ISerialize<Exam>;
binaryser.SerializeBinary(exam);
Console.WriteLine(binaryser.Deserialize());
Serializer<Exam> jsonserializer = new Serializer<Exam>(@"../../../files/exam.json");
ISerialize<Exam> jsonser = jsonserializer as ISerialize<Exam>;
jsonser.SerializeJSON(exam);
Console.WriteLine(jsonser.Deserialize());
Serializer<Exam> xmlserializer = new Serializer<Exam>(@"../../../files/exam.xml");
ISerialize<Exam> xmlser = xmlserializer as ISerialize<Exam>;
xmlser.SerializeXML(exam);
Console.WriteLine(xmlser.Deserialize());
Serializer<Exam> soapserializer = new Serializer<Exam>(@"../../../files/examsoap.xml");
ISerialize<Exam> soapser = soapserializer as ISerialize<Exam>;
soapser.SerializeSOAP(exam);
Console.WriteLine(soapser.Deserialize());
Console.WriteLine();

Exam exam1 = new Exam(2, 2);
Exam exam2 = new Exam(4, 1);
Exam exam3 = new Exam(5, 5);
List<Exam> exams = new List<Exam>();
exams.Add(exam1);
exams.Add(exam2);
exams.Add(exam3);

Serializer<List<Exam>> listserializer = new Serializer<List<Exam>>(@"../../../files/exams.xml");
ISerialize<List<Exam>> listser = listserializer as ISerialize<List<Exam>>;
listser.SerializeXML(exams);
foreach (var ex in listser.Deserialize())
{
    Console.WriteLine(ex);
}

XmlDocument doc = new XmlDocument();
doc.Load("../../../files/examsxpath.xml");
XmlNode root = doc.DocumentElement;

XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
nsmgr.AddNamespace("ex", "urn:exams-schema");

XmlNodeList nodeList = root.SelectNodes("descendant::ex:Exam[ex:Status='Ожидает']", nsmgr);
foreach (XmlNode xmlnode in nodeList)
{
    Console.WriteLine(xmlnode.LastChild.InnerText);
}

XmlNode node = root.SelectSingleNode("descendant::ex:Exam[ex:AmountOfQuestions>4.00]", nsmgr);
Console.WriteLine(node.FirstChild.InnerText);
Console.WriteLine();

string json = JsonSerializer.Serialize(exams);
JArray jsonnode = JArray.Parse(json);

var all = from item in jsonnode
          select item;
foreach (var item in all)
{
    Console.WriteLine(item);
}

var amounts = from amount in jsonnode.Select(item => item["AmountOfQuestions"])
              where amount.ToObject<int>() > 2
              select amount;
foreach (var item in amounts)
{
    Console.WriteLine(item);
}

var statuses = from status in jsonnode.Select(item => item["Status"].ToString())
              select status;
foreach (var item in statuses)
{
    Console.WriteLine(item);
}

