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
            pre:
            int pre;
            Console.Clear();
            Console.WriteLine("Ahora selecciona el metodo de organización: \n 1 = Inserción | 2 = Selección | 3 = Shell | 4 = Burbuja");
            while (true)
            {
                var h = Convert.ToString(Console.ReadLine());

                if (int.TryParse(h, out int val) == true)
                {
                    pre = Convert.ToInt32(h);
                    break;
                }
                Console.WriteLine("Número incorrecto, vuelve a intentar:");
            }
            if (pre == 1)
            {
                Console.Clear();
                metodoInsercion(lista);
                Console.WriteLine("Inserción");

            }else if (pre == 2)
            {
                Console.Clear();
                metodoSeleccion(lista);
                Console.WriteLine("Selección");

            }else if (pre == 3)
            {
                Console.Clear();
                metodoShell(lista);
                Console.WriteLine("Shell");

            }else if (pre == 4)
            {
                Console.Clear();
                metodoBurbuja(lista);
                Console.WriteLine("Burbuja");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Número equivocado");
                goto pre;
            }


        }

        public static void metodoInsercion(int[] lista)
        {
            int ordenamiento = 1;
            for (int i = 0; i < lista.Length; i++)
            {
                var clave = lista[i];
                var j = i - 1;
                while (j >= 0 && lista[j] > clave)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = clave;
                Console.WriteLine($"El ordenamiento No {ordenamiento} : ");
                listaShow(lista);
                ordenamiento++;
            }
            PreguntaArchivo(lista);

        }

        public static void metodoSeleccion(int[] lista)
        {
            int ordenamiento = 1;
            int menor = 0;
            int aux = 0;
            int aux2 = 0;
            for (int i = 0; i < lista.Length - 1; i++)
            {
                menor = lista[i];
                aux = i;
                for (int j = i + 1; j < lista.Length; j++)
                {
                    if (lista[j] < menor)
                    {
                        menor = lista[j];
                        aux = j;
                    }
                }
                if (aux != i)
                {
                    aux2 = lista[i];
                    lista[i] = lista[aux];
                    lista[aux] = aux2;
                }
                Console.WriteLine($"El ordenamiento No {ordenamiento} : ");
                listaShow(lista);
                ordenamiento++;
            }
            PreguntaArchivo(lista);
        }
        public static void metodoShell(int[] lista)
        {
            int mitad = 0;
            bool bucle = false;
            int aux = 0;
            int x = 0;
            int ordenamiento = 1;
            mitad = lista.Length / 2;
            while (mitad > 0)
            {
                bucle = true;
                while (bucle)
                {
                    bucle = false;
                    x = 1;
                    while (x <= (lista.Length - mitad))
                    {
                        if (lista[x - 1] > lista[(x - 1) + mitad])
                        {
                            aux = lista[(x - 1) + mitad];
                            lista[(x - 1) + mitad] = lista[x - 1];
                            lista[(x - 1)] = aux;
                            bucle = true;
                            Console.WriteLine($"El ordenamiento No {ordenamiento} : ");
                            listaShow(lista);
                            ordenamiento++;
                        }
                        x++;
                    }
                }
                mitad = mitad / 2;
            }
            PreguntaArchivo(lista);
        }
        public static void metodoBurbuja(int[] lista)
        {
            int ordenamiento = 1;

            for (int i = 0; i < lista.Length; i++)
            {
                for (int j = 0; j < lista.Length - i - 1; j++)
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
            PreguntaArchivo(lista);
        }

        public static void PreguntaArchivo(int[]lista)
        {
            string listaString = "";
            for (int i = 0; i < lista.Length; i++)
            {
                if(i == lista.Length-1)
                {
                    listaString += lista[i];
                    break;
                }
                listaString += lista[i] + ", ";
            }

            Console.WriteLine("Escoje entre: Guardar el arcivo en formato XML, Txt o si quieres salir sin hacer nada.\nApreta: 1. XML | 2.Txt | Cualquier tecla. Salir");

            try
            {
                var pr1 = Convert.ToInt32(Console.ReadLine());
                if (pr1 == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Como te gustaría llamar al arcivo? \n Escribe el nombre");
                    var x = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Seguro te gustaría llamarlo así? \n si lo quieres cambiar apreta cualquier tecla, si no, aprieta Enter");
                    var y = Console.ReadKey();
                    if (y.Key == ConsoleKey.Enter)
                    {
                        CrearArchivoXml(listaString, x);
                    }
                    else
                    {
                        Console.WriteLine("Escribe el nuevo nombre");
                        x = Convert.ToString(Console.ReadLine());
                        CrearArchivoXml(listaString, x);
                    }
                }
                else if (pr1 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Como te gustaría llamar al arcivo? \n Escribe el nombre");
                    var x = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Seguro te gustaría llamarlo así? \n si lo quieres cambiar aprieta cualquier tecla, si no, apreta Enter");
                    var y = Console.ReadKey();
                    if (y.Key == ConsoleKey.Enter)
                    {
                        CrearArchivoTxt(listaString, x);
                    }
                    else
                    {
                        Console.WriteLine("Escribe el nuevo nombre");
                        x = Convert.ToString(Console.ReadLine());
                        CrearArchivoTxt(listaString, x);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            catch (Exception ex)
            {
                Environment.Exit(0);
            }

            

                
        }
        public static string listaShow(int[] lista)
        {
            foreach (var number in lista)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine("\n");
            return "";
        }
        public static void CrearArchivoTxt(string listaString, string x)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (FileStream fs = File.Create(path + $@"\{x}.txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(listaString);
                fs.Write(info, 0, info.Length);
            }
            Console.WriteLine("Archivo .txt listo");
        }
        public static void CrearArchivoXml(string listaString, string x)
        {
            string path =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlWriter xmlWriter = XmlWriter.Create(path + $@"\{x}.xml");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("ListaNums");
            xmlWriter.WriteStartElement("Lista");
            xmlWriter.WriteString(Environment.NewLine +  listaString + Environment.NewLine);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Console.WriteLine("Archivo .xml listo");
        }
    }
}
