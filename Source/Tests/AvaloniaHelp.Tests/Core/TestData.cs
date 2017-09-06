using AvaloniaHelp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Tests.Core
{
    public static class TestData
    {
        public static List<Section> Toc;

        static TestData()
        {
            Toc = new List<Section>();

            var main1 = new Section("Section 1");
            Toc.Add(main1);

            var s1 = new Section("Section 1");
            main1.AddSubSection(s1);
            var s2 = new Section("Section 2");
            main1.AddSubSection(s2);

            var sub1_1 = new Section("SubSection 1.1");
            s1.AddSubSection(sub1_1);
            var sub1_2 = new Section("SubSection 1.2");
            s1.AddSubSection(sub1_2);

            var sub2_1 = new Section("SubSection 2.1");
            s2.AddSubSection(sub2_1);
            var sub2_2 = new Section("SubSection 2.2");
            s2.AddSubSection(sub2_2);

            var main2 = new Section("Help 2");
            Toc.Add(main2);

            var s3 = new Section("Section 1");
            main1.AddSubSection(s3);
        }
    }
}
