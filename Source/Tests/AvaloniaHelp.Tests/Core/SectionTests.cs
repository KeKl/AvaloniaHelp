using AvaloniaHelp.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Tests.Core
{
    [TestFixture]
    public class SectionTests
    {
        [Test]
        public static void TestSectionFind()
        {
            var toc = TestData.Toc;

            var res = Section.FindForHeader(toc.First(), "Section 1");
            var res2 = Section.FindForHeader(toc.First(), "SubSection 1");
            var res3 = Section.FindForHeader(toc.First(), "SubSection 1.1");
        }
    }
}
