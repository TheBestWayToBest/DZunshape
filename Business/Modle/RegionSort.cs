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
            list.Add("夏津402");
            list.Add("夏津401");
            list.Add("乐陵204");

            list.Add("乐陵201");
            list.Add("乐陵202");
            list.Add("乐陵203");
            list.Add("乐陵206");

            list.Add("乐陵205");
            list.Add("禹城303");

            list.Add("禹城302");
            list.Add("禹城301");
            list.Add("禹城310");

            list.Add("禹城309");
            list.Add("禹城308");
            list.Add("禹城307");
            list.Add("禹城306");

            list.Add("禹城304");
            list.Add("禹城305");
            list.Add("德城114");

            list.Add("德城113");
            list.Add("德城112");
            list.Add("德城111");

            list.Add("德城110");
            list.Add("德城109");
            list.Add("德城115");

            list.Add("德城117");
            list.Add("德城116");
            list.Add("德城106");

            list.Add("德城107");
            list.Add("德城108");
            list.Add("德城118");

            list.Add("德城104");
            list.Add("德城105");
            list.Add("德城101");
            list.Add("德城102");
            list.Add("德城103");

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
