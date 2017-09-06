using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaHelp.Core;

namespace AvaloniaHelp.Tests.Core
{
    [TestFixture]
    public class ToCTests
    {
        [Test]
        public static void TestToCFind()
        {
            var toc = TestData.Toc;



            var res = toc.FindInSectionsForHeader("Section ");
            Assert.IsTrue(res.All(s => s.Header.Contains("Section ", StringComparison.CurrentCultureIgnoreCase)));
            
            var res2 = toc.FindInSectionsForHeader("Section 1");
            Assert.IsTrue(res2.All(s => s.Header.Contains("Section 1", StringComparison.CurrentCultureIgnoreCase)));

            var res3 = toc.FindInSectionsForHeader("section 2");
            Assert.IsTrue(res3.All(s => s.Header.Contains("section 2", StringComparison.CurrentCultureIgnoreCase)));

            var res4 = toc.FindInSectionsForHeader("subsection 1");
            Assert.IsTrue(res4.All(s => s.Header.Contains("subsection 1", StringComparison.CurrentCultureIgnoreCase)));

            var res5 = toc.FindInSectionsForHeader("SubSection 1.1");
            Assert.IsTrue(res5.All(s => s.Header.Contains("SubSection 1.1", StringComparison.CurrentCultureIgnoreCase)));

            var res6 = toc.FindInSectionsForHeader("SubSection 2.2");
            Assert.IsTrue(res6.All(s => s.Header.Contains("SubSection 2.2", StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}
