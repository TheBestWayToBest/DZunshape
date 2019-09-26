using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Modle
{
    public class RegionSort
    {
        public static List<string> GetRegionSort() 
        {
            List<string> list = new List<string>();
            list.Add("141001@夏津1001刘刚");
            list.Add("141003@夏津1003王蓬");
            list.Add("141009@夏津1009赵华");

            list.Add("140203@乐陵刘长胜线");
            list.Add("140206@乐陵王欣雨线");
            list.Add("140210@乐陵耿红梅线");
            list.Add("140212@乐陵曲云线");

            list.Add("140801@庆云夏伟华线");
            list.Add("140803@庆云邵勇线");

            list.Add("141108@禹城三号车");
            list.Add("141109@禹城四号车");
            list.Add("141112@禹城五号车");

            list.Add("140701@齐河焦庙线");
            list.Add("140702@齐河潘店线");
            list.Add("140704@齐河城区二线");
            list.Add("140705@齐河南北线");

            list.Add("140302@临邑城区临盘送货线路");
            list.Add("140309@临邑临南兴隆送货线路");
            list.Add("140303@临邑城区孟寺送货线路");

            list.Add("140903@武城鲁N49272");
            list.Add("140905@武城鲁N48505");
            list.Add("140908@武城鲁N49291");
           
            list.Add("140501@宁津张艳霞送货线");
            list.Add("140502@宁津许书盈送货线");
            list.Add("140505@宁津王玉雷送货线");

            list.Add("140607@平原赵淑燕送货线");
            list.Add("140602@平原艾新玲送货线");
            list.Add("140603@平原刘凤春送货线");
            
            list.Add("140401@陵县401");
            list.Add("140402@陵县402");
            list.Add("140403@陵县403");

            list.Add("141205@德城冯晓红线");
            list.Add("141207@德城李春明线");
            list.Add("141202@德城张洪昌线");
            list.Add("141203@德城胡继鹏线");
            list.Add("141204@德城薛冰线");

            return list;

        }

        public static List<string> GetArea() 
        {
            List<string> list = new List<string>();

            list.Add("夏津");
            list.Add("乐陵");
            list.Add("庆云");
            list.Add("禹城");
            list.Add("齐河");
            list.Add("临邑");
            list.Add("武城");
            list.Add("宁津");
            list.Add("平原");
            list.Add("陵县");
            list.Add("德城");
            return list;
        }
    }
}
