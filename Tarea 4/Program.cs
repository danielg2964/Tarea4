using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace Tarea4
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int[] lista = new int[10];
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Boolean xmlFind = false;
            Boolean txtFind = false;
            if (File.Exists(path + @"\archivo.txt"))
            {
                Console.WriteLine("Archivo .txt encontrado");
                txtFind = true;
            }else
            {
                Console.WriteLine("Archivo .txt NO encontrado");
            }
            if (File.Exists(path + @"\archivo.xml"))
            {
                Console.WriteLine("Archivo .xml encontrado");
                xmlFind = true;
            }else
            {
                Console.WriteLine("Archivo .xml NO encontrado");
            }
            if (xmlFind == true && txtFind == true)
            {
                Console.WriteLine("Los dos archivos fueron encontrados, puede seguir.");
            }else if (xmlFind == false && txtFind == false)
            {
                Console.WriteLine("Los dos archivos NO fueron encontrados, puede seguir, pero si desea puede crearlos.");
                Console.WriteLine("Da Enter para crearlo o cualquier tecla para continuar sin el archivo. Los datos se borraran al momemento de cerrar el programa");
                var igual = Console.ReadKey();
                if (igual.Key == ConsoleKey.Enter)
                {
                    CrearArchivoTxt();
                    CrearArchivoXml();
                }else
                {
                    Console.Clear();
                    Console.WriteLine("Continuaras sin crear ningún archivo. Los datos se perderan al finalizar el programa");
                }

            }else if (xmlFind == true || txtFind == false)
            {
                Console.WriteLine("Archivo .txt No encontrado pero .xml si fue encontrado, puede seguir, pero si desea puede crearlo.");
                Console.WriteLine("Da Enter para crearlo o cualquier tecla para continuar sin el archivo.\nLos datos se borraran al momemento de cerrar el programa");
                var igual = Console.ReadKey();
                if (igual.Key == ConsoleKey.Enter)
                {
                    CrearArchivoTxt();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Continuaras sin crear ningún archivo. Los datos se perderan al finalizar el programa");
                }

            }else if (xmlFind == false || txtFind == true)
            {
                Console.WriteLine("Archivo .xml No encontrado pero .txt si fue encontrado, puede seguir, pero si desea puede crearlo.");
                Console.WriteLine("Da Enter para crearlo o cualquier tecla para continuar sin el archivo.\nLos datos se borraran al momemento de cerrar el programa");
                var igual = Console.ReadKey();
                if (igual.Key == ConsoleKey.Enter)
                {
                    CrearArchivoXml();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Continuaras sin crear ningún archivo. Los datos se perderan al finalizar el programa");
                }

            }

            Console.WriteLine("Para este programa, se te pedirá una serie de 10 números, luego se te pedira el metodo para ordenenar esos números. ");
            string x;
            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine("Ingresa un número, faltan: " + (10 - index));
                while (true)
                {
                    x = Convert.ToString(Console.ReadLine());

                    if (int.TryParse(x, out int val) == true)
                    {
                        break;
                    }
                    Console.WriteLine("Número incorrecto, vuelve a intentar:");
                }
                lista[index] = Convert.ToInt32(x);
                
            }
            Console.Clear();
            Console.WriteLine("Ahora selecciona el metodo de organización: \n 1 = Burbuja");
            var y = Console.ReadLine();
            if (y == "1")
            {
                Console.Clear();
                metodoBurbuja(lista);
            }
        }

        public static void metodoBurbuja(int[] lista)
        {
            int ordenamiento = 1;

            for (int i = 0; i < lista.Length; i++)
            {
                for (int j = 0; j < lista.Length -i -1; j++)
                {

                    if (lista[j] > lista[j + 1])
                    {
                        int aux = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = aux;
                    }
                }
                Console.WriteLine($"El ordenamiento No {ordenamiento} : ");
                listaShow(lista);
                ordenamiento++;
            }
        }

        public static string listaShow(int[] lista)
        {
            foreach(var number in lista)
            {
                Console.Write(number + ",");
            }Console.WriteLine("\n");
            return "";
        }
        public static void CrearArchivoTxt()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (FileStream fs = File.Create(path + @"\archivo.txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            Console.WriteLine("Archivo .txt listo");
        }
        public static void CrearArchivoXml()
        {
            string path =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlWriter xmlWriter = XmlWriter.Create(path + @"\archivo.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListaNums");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Console.WriteLine("Archivo .xml listo");
        }
    }
}