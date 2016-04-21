using System;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Web.SessionState;
using System.Reflection;

namespace Snips.Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHtmlGen()
        {
            HttpContext.Current = FakeContext.FakeHttpContext();
            HttpContext.Current.Session.Add("guid", "12345");
            HttpContext.Current.Session.Add("timestamps", "11:11,04:04");
            HttpContext.Current.Session.Add("windows", "30,40");
            HttpContext.Current.Session.Add("snipsNum", "2");

            String html = Retrieve.GenerateHtml();

            String expected_html = "<div class='snippet row'>" +
                        "<div class='col-md-6 text-center'>" +
                            "<video class='video' width='320' height='240' controls>" +
                                "<source src='/videos/12345/Snippet_1.mp4' type='video/mp4'>" +
                                "Your browser does not support the video tag." +
                            "</video>" +
                        "</div>" +
                        "<div class='details col-md-6 text-center'>" +
                            "<dl class='snippet-info dl-horizontal'>" +
                                "<dt><strong>Title:</strong></dt><dd class='text-left'>Snippet_1.mp4</dd>" +
                                "<dt><strong>Timestamp:</strong></dt><dd class='text-left'>11:11</dd>" +
                                "<dt><strong>Window Size:</strong></dt><dd class='text-left'>30</dd>" +
                            "</dl>" +
                            "<div style='float:left; padding-left:40px;'>" +
                                "<input type='checkbox' id='chkSnippet1' name='1' runat='server' style='margin-right:5px;'>" +
                                "<label for='chkSnippet1'>  Select snippet</label>" +
                            "</div>" +
                        "</div>" +
                     "</div>" +
                     "<div class='snippet row'>" +
                        "<div class='col-md-6 text-center'>" +
                            "<video class='video' width='320' height='240' controls>" +
                                "<source src='/videos/12345/Snippet_2.mp4' type='video/mp4'>" +
                                "Your browser does not support the video tag." +
                            "</video>" +
                        "</div>" +
                        "<div class='details col-md-6 text-center'>" +
                            "<dl class='snippet-info dl-horizontal'>" +
                                "<dt><strong>Title:</strong></dt><dd class='text-left'>Snippet_2.mp4</dd>" +
                                "<dt><strong>Timestamp:</strong></dt><dd class='text-left'>04:04</dd>" +
                                "<dt><strong>Window Size:</strong></dt><dd class='text-left'>40</dd>" +
                            "</dl>" +
                            "<div style='float:left; padding-left:40px;'>" +
                                "<input type='checkbox' id='chkSnippet2' name='2' runat='server' style='margin-right:5px;'>" +
                                "<label for='chkSnippet2'>  Select snippet</label>" +
                            "</div>" +
                        "</div>" +
                     "</div>";

            Assert.AreEqual(expected_html, html);
        }
    }
}