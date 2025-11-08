using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUtilities.Core.Html
{
    public static class TestHtmlStrings
    {

        public static string TestHtmlString1 =
            "<!DOCTYPE html>\n" +
            "<html>\n" +
            "<head>\n" +
            "    <title>Test HTML</title>\n" +
            "    <link rel=\"stylesheet\" href=\"https://example.com/styles.css\">\n" +
            "    <style>\n" +
            "        .test-class { color: blue; }\n" +
            "    </style>\n" +
            "</head>\n" +
            "<body>\n" +
            "    <div id=\"container\" style=\"background-color: #f9f9f9; padding: 10px;\">\n" +
            "        <h1 class=\"test-class\" style=\"text-align: center;\">Welcome to String Utilities</h1>\n" +
            "        <p>This is a <span style=\"font-weight: bold; color: red;\">sample HTML</span> for testing string methods.</p>\n" +
            "        <div class=\"external-style placeholder\">\n" +
            "            This is a placeholder div affected by external stylesheets.\n" +
            "        </div>\n" +
            "        <ul id=\"features\">\n" +
            "            <li data-value=\"1\" class=\"item-1\">Parsing tags</li>\n" +
            "            <li data-value=\"2\" class=\"highlighted\">Extracting attributes</li>\n" +
            "            <li data-value=\"3\">Manipulating styles</li>\n" +
            "        </ul>\n" +
            "        <a href=\"https://example.com\" target=\"_blank\" style=\"text-decoration: none;\">Visit Example</a>\n" +
            "        <table border=\"1\">\n" +
            "            <thead>\n" +
            "                <tr>\n" +
            "                    <th>Column 1</th>\n" +
            "                    <th>Column 2</th>\n" +
            "                </tr>\n" +
            "            </thead>\n" +
            "            <tbody>\n" +
            "                <tr>\n" +
            "                    <td style=\"color: green;\">Row 1, Cell 1</td>\n" +
            "                    <td>Row 1, Cell 2</td>\n" +
            "                </tr>\n" +
            "                <tr>\n" +
            "                    <td>Row 2, Cell 1</td>\n" +
            "                    <td style=\"font-size: 12px;\">Row 2, Cell 2</td>\n" +
            "                </tr>\n" +
            "            </tbody>\n" +
            "        </table>\n" +
            "        <footer class=\"footer-style\">\n" +
            "            This is a footer placeholder styled by the external stylesheet.\n" +
            "        </footer>\n" +
            "    </div>\n" +
            "</body>\n" +
            "</html>";

        public static string TestHtmlString2 =
            "<!DOCTYPE html>" +
            "<html>" +
                "<head>" +
                    "<title>Test HTML</title>" +
                    "<link rel=\"stylesheet\" href=\"https://example.com/styles.css\">" +
                    "<style>" +
                        ".test-class { color: blue; }" +
                    "</style>" +
                "</head>" +
                "<body>" +
                    "<div id=\"container\" style=\"background-color: #f9f9f9; padding: 10px;\">" +
                        "<h1 class=\"test-class\" style=\"text-align: center;\">Welcome to String Utilities</h1>" +
                        "<p>This is a <span style=\"font-weight: bold; color: red;\">sample HTML</span> for testing string methods.</p>" +
                        "<div class=\"external-style placeholder\">" +
                            "This is a placeholder div affected by external stylesheets." +
                        "</div>" +
                        "<ul id=\"features\">" +
                            "<li data-value=\"1\" class=\"item-1\">Parsing tags</li>" +
                            "<li data-value=\"2\" class=\"highlighted\">Extracting attributes</li>" +
                            "<li data-value=\"3\">Manipulating styles</li>" +
                        "</ul>" +
                        "<a href=\"https://example.com\" target=\"_blank\" style=\"text-decoration: none;\">Visit Example</a>" +
                        "<table border=\"1\">" +
                            "<thead>" +
                                "<tr>" +
                                    "<th>Column 1</th>" +
                                    "<th>Column 2</th>" +
                                "</tr>" +
                            "</thead>" +
                            "<tbody>" +
                                "<tr>" +
                                    "<td style=\"color: green;\">Row 1, Cell 1</td>" +
                                    "<td>Row 1, Cell 2</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td>Row 2, Cell 1</td>" +
                                    "<td style=\"font-size: 12px;\">Row 2, Cell 2</td>" +
                                "</tr>" +
                            "</tbody>" +
                        "</table>" +
                        "<footer class=\"footer-style\">" +
                            "This is a footer placeholder styled by the external stylesheet." +
                        "</footer>" +
                    "</div>" +
                "</body>" +
            "</html>";
    }
}
