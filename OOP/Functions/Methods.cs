using System;
using System.Collections.Generic;
using OOP.prom_zona;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OOP._de_serialization
{
  
    public class Methods
    {       
        public MainFactory factory = new MainFactory();
        internal static food f = new food();
        private int i = 0;
        Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Test\\bin\\Debug\\net5.0\\DynamicModule.dll");
        Assembly assembly2 = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\JSON-XML\\bin\\Debug\\net5.0\\JSON-XML.dll");
        public void addfood(string index)
        {
            string[] temp = new string[4];
            Console.WriteLine("Enter mass:");
            temp[0] = Console.ReadLine();
            Console.WriteLine("Enter price:");
            temp[1] = Console.ReadLine();
            Console.WriteLine("Enter arg1:");
            temp[2] = Console.ReadLine();
            Console.WriteLine("Enter arg2:");
            temp[3] = Console.ReadLine();
            f[i] = factory.Produce(index, System.Convert.ToInt32(temp[1]), System.Convert.ToInt32(temp[0]), temp[2], System.Convert.ToInt32(temp[3]));
            i++;
        }

        public void addhealthyfood() {
            Type type = assembly.GetType("DynamicModule.ExtaMethods.Methods");

        }

        public void RemoveFromList(string index)
        {
            showlist("");
            Console.WriteLine("Введите номер элемента: ");
            string s = Console.ReadLine();
            int ind = 0;
            try
            {
                ind = System.Convert.ToInt32(s);
            }
            catch (Exception)
            {
                throw new Exception("Incorect index");
            }
            f.DeleteFromList(ind);
        }

        public void edit(string index)
        {
            showlist("");
            Console.WriteLine("Введите номер элемента: ");
            string s = Console.ReadLine();
            int ind = 0;
            try
            {
                ind = System.Convert.ToInt32(s);
            }
            catch (Exception)
            {
                throw new Exception("Incorect index");
            }
            string foodtype = (f[i] as fastfood).name;
            int temp = i;
            i = ind;
            addfood(foodtype);
            i = temp;
        }

        public void showlist(string s)
        {
            List<food> list = f.FoodList;
            Console.WriteLine("____________________________________________________________");
            foreach (food element in list)
            {
                element.display_info();
                Console.WriteLine("____________________________________________________________");
            }
        }
        public void showinterface()
        {
            Console.WriteLine("1.Add burger");
            Console.WriteLine("2.Add sushi");
            Console.WriteLine("3.Add pizza");
            Console.WriteLine("4.Add hotdog");
            Console.WriteLine("5.Show list");
            Console.WriteLine("6.Delete");
            Console.WriteLine("8.Serialize(JSON)");
            Console.WriteLine("9.Deserialize(JSON)");
            Console.WriteLine("10.Extra functions");
            Console.WriteLine("11.JSON -> XML");
            Console.WriteLine("12.Cipher");
            Console.WriteLine("13.Decipher");
            Console.WriteLine("14.Exit");
        }

        public void showExtra(string s)
        {
            Type type = assembly.GetType("DynamicModule.ExtraMethods.Methods");
            object instance = Activator.CreateInstance(type);
            List<food> list = new List<food>();
            list = (List<food>)type.InvokeMember("startpoint", BindingFlags.InvokeMethod, null, instance, null);
            int len = list.Count();
            for (int j = 0; j <len; j++){
                f[i] = list[j];
                i++;
            }
        }

        public void JSONtoXML(string s) {
            Type type = assembly2.GetType("JSON_XML.Transformstions");
            object? instance = Activator.CreateInstance(type);
            type.InvokeMember("TransformJSONtoXML", BindingFlags.InvokeMethod, null, instance, null);
        }

        public void encrypt(string s) {
            Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Cipher\\bin\\Debug\\net5.0\\Cipher.dll");
            Type type = assembly.GetType("Cipher.Cryptography");
            object? instance = Activator.CreateInstance(type);
            object[] a = new object[1];
            a[0] = f.FoodList;
            type.InvokeMember("encpypt", BindingFlags.InvokeMethod, null, instance, a);
        }

        public void decpypt(string s) {
            Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Cipher\\bin\\Debug\\net5.0\\Cipher.dll");
            Type type = assembly.GetType("Cipher.Cryptography");
            object? instance = Activator.CreateInstance(type);
            object[] a = new object[1];
            a[0] = f.FoodList;
            List<food> list = new List<food>();
            list = (List<food>)type.InvokeMember("decipher", BindingFlags.InvokeMethod, null, instance, null);
            int len = list.Count();
            for (int j = 0; j < len; j++)
            {
                f[i] = list[j];
                i++;
            }
        }
    }
}
