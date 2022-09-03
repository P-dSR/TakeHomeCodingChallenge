using System;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace WebScraping
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://storage.googleapis.com/infosimples-public/commercia/case/product.html");

            Resultado ResultadoFinal = new Resultado();

            var title = doc.DocumentNode.SelectSingleNode("//*[@id='product_title']").InnerText;
            ResultadoFinal.Title = title;
            Console.WriteLine(ResultadoFinal.Title);

            var brand = doc.DocumentNode.SelectSingleNode("/html/body/div/section/div/div[1]").InnerText;
            ResultadoFinal.Brand = brand;
            Console.WriteLine(ResultadoFinal.Brand);

            List<string> Categories = new List<string>();
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[1]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[2]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[3]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[4]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[5]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[6]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[7]/a").InnerText);
            Categories.Add(doc.DocumentNode.SelectSingleNode("/html/body/header/ul/li[8]/a").InnerText);
            ResultadoFinal.Categories = Categories;


            List<Skus> ListaSkus = new List<Skus>();
            Skus skusinstancia1 = new Skus();
            skusinstancia1.Name = doc.DocumentNode.SelectSingleNode("//*[@id='product_S0002201'']/div[3]/div[1]").InnerText;
            skusinstancia1.Current_price = Int32.Parse(doc.DocumentNode.SelectSingleNode("//*[@id='product_S0002201']/div[3]/div[2]").InnerText);
            skusinstancia1.Old_price = Int32.Parse(doc.DocumentNode.SelectSingleNode("//*[@id='product_S0002201']/div[3]/div[3]").InnerText);
            ListaSkus.Add(skusinstancia1);
            ResultadoFinal.Skus = ListaSkus;


            List<Properties> ListaProperties = new List<Properties>();
            Properties propertiesinstancia1 = new Properties();
            propertiesinstancia1.Label = doc.DocumentNode.SelectSingleNode("/html/body/div/section/div/div[4]/table/tbody/tr[2]/td[1]/b").InnerText;
            propertiesinstancia1.value = doc.DocumentNode.SelectSingleNode("/html/body/div/section/div/div[4]/table/tbody/tr[2]/td[2]").InnerText;
            ListaProperties.Add(propertiesinstancia1) ;

            Properties propertiesinstancia2 = new Properties();
            propertiesinstancia2.Label = doc.DocumentNode.SelectSingleNode("").InnerText;
            propertiesinstancia2.value = doc.DocumentNode.SelectSingleNode("").InnerText;
            ListaProperties.Add(propertiesinstancia2);

            ResultadoFinal.Properties = ListaProperties;

            List<Reviews> ListaReviews = new List<Reviews>();
            Reviews reviewsinstancia1 = new Reviews();
            reviewsinstancia1.Name = doc.DocumentNode.SelectSingleNode("//*[@id='comments']/div[1]/div/div[2]/span[1]").InnerText;
            reviewsinstancia1.Date = doc.DocumentNode.SelectSingleNode("//*[@id='comments']/div[1]/div/div[2]/span[2]").InnerText;
            reviewsinstancia1.Text = doc.DocumentNode.SelectSingleNode("//*[@id='comments']/div[1]/p").InnerText;

            ListaReviews.Add(reviewsinstancia1);
            ResultadoFinal.Reviews = ListaReviews;

            var description = doc.DocumentNode.SelectSingleNode("/html/body/div/section/div/div[3]/p").InnerText;
            ResultadoFinal.Description = description;


            ResultadoFinal.url = "https://storage.googleapis.com/infosimples-public/commercia/case/product.html";

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("../../../../../Produto.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, ResultadoFinal);
            }

        }
    }
}

