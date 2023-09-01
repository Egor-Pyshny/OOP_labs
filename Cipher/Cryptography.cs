using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using OOP;
using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace Cipher
{
    class Cryptography
    {
        private static volatile RijndaelManaged cipher = null;
        private static string filePath = "3.txt";
        public static RijndaelManaged Cipher() {
            if (cipher == null) {
                cipher = new RijndaelManaged();
                cipher.KeySize = 256;
                cipher.BlockSize = 128;
                cipher.Padding = PaddingMode.ISO10126;
                cipher.Mode = CipherMode.CBC;
                cipher.Key = Encoding.UTF8.GetBytes("oY979843156975197486kfdx89439828");
                cipher.IV = Encoding.UTF8.GetBytes("1234567890123456");
            }
            return cipher;
        }

        public static void encpypt(List<food> list) {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (food element in list)
            {
                Type type = element.GetType();
                string jsonString = System.Text.Json.JsonSerializer.Serialize(Convert.ChangeType(element, type));
                stringBuilder.AppendLine(jsonString);
            }
            string tocypher = stringBuilder.ToString();
            RijndaelManaged encrypter = Cipher();
            ICryptoTransform c = encrypter.CreateEncryptor();
            byte[] textInBytes = Encoding.UTF8.GetBytes(tocypher);
            byte[] result = c.TransformFinalBlock(textInBytes, 0, textInBytes.Length);
            File.WriteAllBytes(filePath,result);
        }

        public static List<food> decipher() {
            byte[] bytearr = File.ReadAllBytes(filePath);
            RijndaelManaged decipher = Cipher();
            ICryptoTransform decryptor = decipher.CreateDecryptor();
            byte[] decryptedTextBytes = decryptor.TransformFinalBlock(bytearr, 0, bytearr.Length);
            string decryptedText = Encoding.UTF8.GetString(decryptedTextBytes);
            Assembly assembly = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\Test\\bin\\Debug\\net5.0\\DynamicModule.dll");
            Assembly assembly2 = Assembly.LoadFrom("C:\\Users\\user\\source\\repos\\OOP\\OOP\\bin\\Debug\\net5.0\\OOP.dll");
            List<food> res_list = new List<food>();
            foreach (string item in decryptedText.Split("\n"))
            {
                string findtype = "";
                string[] arr = item.Split(',');
                foreach (string str in arr)
                {
                    if (str.StartsWith("\"name\""))
                    {
                        findtype = str.Split(':')[1].Replace("\"", "");
                        break;
                    }
                }
                Type mytype = assembly2.GetType("OOP." + findtype);
                if (mytype == null)
                {
                    mytype = assembly.GetType("DynamicModule." + findtype);
                }

                object res = JsonConvert.DeserializeObject(item, mytype);
                res_list.Add((food)res);
            }
            res_list.RemoveAt(res_list.Count - 1);
            return res_list;
        }
    }
}
