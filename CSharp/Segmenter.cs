﻿using JiebaNet.Segmenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Segmenter
    {
        private static JiebaSegmenter segmenter;

        // 编程语言
        public static readonly List<string> ProgramLanguage = new List<string> {
                    "C++", "C#" , "Java" ,
                    "PHP" , "Python",
                    "JavaScript","HTML","C",
                    "Rust","Ruby","Go"
                };

        // 技术栈
        public static readonly List<string> TechnologyStack = new List<string>
                {
                    "linux","Windows","Web",
                    "Docker"
                };
        public static readonly List<string> Job = new List<string> {
                    "运维","后台",
                    "前端","后端","算法"
                };


        //中文分词
        public static List<string> ChineseSegmenter(string content)
        {
            if (segmenter == null)
            {
                segmenter = new JiebaSegmenter();
                List<string> temp = new List<string>().Concat(TechnologyStack)
                    .Concat(ProgramLanguage).Concat(Job).ToList();
                foreach(var word in temp)
                {
                    segmenter.AddWord(word);
                }
            }
               
            IEnumerable<string> segments = segmenter.Cut(content);
            return segments.ToList();
        }
    }
}
