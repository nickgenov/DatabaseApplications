using System.Xml.Xsl;

namespace _17.XSL_Transform
{
    class XslTransform
    {
        static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../catalog.xsl");
            xslt.Transform("../../catalog.xml", "../../catalog.html");
        }
    }
}