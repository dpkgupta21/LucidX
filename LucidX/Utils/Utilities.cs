﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace LucidX.Utils
{
    public class Utilities
    {
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        public static string ToXML(object prams)
        {
            StringWriter writer = new Utf8StringWriter();
            var serializer = new XmlSerializer(prams.GetType());
            serializer.Serialize(writer, prams);
            return writer.ToString();
        }

        public static object LoadFromXMLString(string xmlText, Type toType)
        {
            //var stringReader = new System.IO.StringReader(xmlText);
            //var serializer = new XmlSerializer(typeof(object));
            //return serializer.Deserialize(stringReader);
            XmlSerializer ser = new XmlSerializer(toType);

            using (StringReader sr = new StringReader(xmlText))

            return ser.Deserialize(sr);
        }




        public static string GetEncryptedToken(string stringToEncrypt)
        {
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] bytPwdhash, bytBuff;
            string encrypted = "";
            string original = stringToEncrypt;
            hashmd5 = new MD5CryptoServiceProvider();
            bytPwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("EncryptDecrypt"));
            hashmd5 = null;
            des = new TripleDESCryptoServiceProvider();
            des.Key = bytPwdhash;
            des.Mode = CipherMode.ECB;
            bytBuff = ASCIIEncoding.ASCII.GetBytes(original);
            encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(bytBuff, 0, bytBuff.Length));
            des = null;
            return encrypted;
        }

    }
}
